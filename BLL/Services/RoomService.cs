using AutoMapper;
using BLL.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SharedKernel.Abstractions.BLL.DTOs.Rooms;
using SharedKernel.Abstractions.BLL.Services;
using SharedKernel.Abstractions.DAL.Repositories;
using SharedKernel.Exceptions;
using SharedKernel.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SharedKernel.Abstractions.BLL.DTOs.Media;
using SharedKernel.Abstractions.BLL.DTOs.User;
using SharedKernel.Abstractions.DAL.Models;

namespace BLL.Services
{
	public class RoomService : IRoomService
	{
		private readonly HttpContext _httpContext;
		private readonly UserManager<User> _userManager;
		private readonly IRepository<Room> _roomRepository;
		private readonly string _currentUserName;

		private static readonly Dictionary<string, LocalRoomModel> _rooms = new Dictionary<string, LocalRoomModel>();

		public RoomService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, IRepository<Room> roomRepository)
		{
			_httpContext = httpContextAccessor.HttpContext;
			_userManager = userManager;
			_roomRepository = roomRepository;
			_currentUserName = _httpContext.User.Identity.Name.ToUpper();
		}

		public async Task AddAsync(IAddRoomDTO dto)
		{
			if (_roomRepository.GetAll(r => r.UniqName.ToUpper() == dto.UniqName.ToUpper()).Count() > 0)
				throw new DuplicateNameException();

			var room = Mapper.Map<Room>(dto);

			var user = await _userManager.FindByNameAsync(_currentUserName);

			room.HostId = user.Id;

			room.UserRooms = new List<UserRoom>() { new UserRoom() { Room = room, UserId = user.Id } };

			_roomRepository.Add(room);

			var localRoom = new LocalRoomModel();

			localRoom.Name = dto.Name;
			localRoom.Medias = Mapper.Map<ICollection<Media>>(dto.Medias);

			_rooms.Add(room.UniqName, localRoom);
		}

		public async Task SignInAsync(ISignInRoomDTO dto)
		{
			var room = _roomRepository.GetAll(r => r.UniqName == dto.UniqName).FirstOrDefault();

			if (room == null)
				throw new RoomNotFoundException();

			if (room.UserRooms.Any(ur => ur.User.NormalizedUserName == _currentUserName))
			{
				AddRoomToUserIdentity(dto.UniqName);
				return;
			}

			if (room.PasswordHash != HashPasswordHelper.GetPasswordHash(dto.Password))
				throw new IncorrectPasswordException();

			var user = await _userManager.FindByNameAsync(_currentUserName);

			room.UserRooms.Add(new UserRoom() { UserId = user.Id, RoomId = room.Id });

			_roomRepository.Update(room);

			AddRoomToUserIdentity(dto.UniqName);
		}

		private void AddRoomToUserIdentity(string roomName)
		{
			_httpContext.User.AddIdentity(new ClaimsIdentity(new Claim[] { new Claim("room", roomName) }));
		}

		public string GetRoomName()
		{
			return _roomRepository
				.GetAll(r => r.UserRooms.Any(ur => ur.User.NormalizedUserName == _currentUserName))
				.Select(r => r.UniqName)
				.LastOrDefault();
		}

		public string GetHostConnectionId()
		{
			var roomName = GetRoomName();

			return _rooms[roomName].Users.First(u => u.IsHost).ConnectionId;
		}

		public async Task DisconnectFromRoomAsync()
		{
			var user = await _userManager.FindByNameAsync(_currentUserName);

			var rooms = _roomRepository
				.GetAll(r => r.UserRooms.Any(ur => ur.User.NormalizedUserName == user.NormalizedUserName));
			rooms.ToList().ForEach(room =>
			{
				if (user.Id == room.HostId)
				{
					_roomRepository.Delete(room);
					_rooms.Remove(room.UniqName);
					return;
				}

				room.UserRooms = room.UserRooms.Where(ur => ur.User.NormalizedUserName != _currentUserName).ToList();

				_roomRepository.Update(room);

				var localUser = _rooms[room.UniqName].Users.Single(u => u.Id == user.Id);

				_rooms[room.UniqName].Users.Remove(localUser);
			});
		}

		public async Task AddToRoomAsync(string roomName, string connectionId)
		{
			var localUser = _rooms[roomName].Users
											.FirstOrDefault(u => u.UserName.ToUpper() == _currentUserName);

			if (localUser != null)
			{
				_rooms[roomName].Users.Remove(localUser);
			}

			var user = await _userManager.FindByNameAsync(_currentUserName);

			var roomHostId = _roomRepository
							 .GetAll(r => r.UniqName.ToUpper() == roomName.ToUpper())
							 .Select(r => r.HostId)
							 .First();

			_rooms[roomName].Users.Add(new LocalUserModel()
			{
				Id = user.Id,
				UserName = user.UserName,
				ConnectionId = connectionId,
				IsHost = user.Id == roomHostId
			});
		}

		public void SetPlaylist(IEnumerable<IMediaDTO> medias)
		{
			_rooms[GetRoomName()].Medias = Mapper.Map<ICollection<Media>>(medias);
		}

		public void TrackEnded(string roomName)
		{
			_rooms[roomName].Users
							.Where(u => u.UserName.ToUpper() == _currentUserName)
							.ToList()
							.ForEach(u => u.TrackEnded = true);
		}

		public void TrackStarted(string roomName)
		{
			_rooms[roomName].Users = _rooms[roomName].Users.Select(u =>
			{
				u.TrackEnded = false;
				return u;
			}).ToList();
		}

		public void NextMedia(string roomName, IMedia media)
		{
			_rooms[roomName].CurrentMedia = Mapper.Map<Media>(media);
		}

		public IMediaDTO GetCurrentMedia(string roomName)
		{
			return Mapper.Map<IMediaDTO>(_rooms[roomName].CurrentMedia);
		}

		public IEnumerable<IMedia> CheckMedia(string roomName, IEnumerable<IMedia> medias)
		{
			var mediaModels = Mapper.Map<IEnumerable<Media>>(medias);

			var missedMedias = _rooms[roomName].Medias.Except(mediaModels).ToList();

			_rooms[roomName].Users
							.Single(u => u.UserName.ToUpper() == _currentUserName)
							.MediasInDownloadCount = missedMedias.Count();

			return missedMedias;
		}

		public void MediaDownloaded(string roomName)
		{
			_rooms[roomName].Users.Single(u => u.UserName.ToUpper() == _currentUserName).MediasInDownloadCount--;
		}

		public bool IsAllUsersReadyToStart(string roomName)
		{
			return _rooms[roomName].Users
									.All(u => u.MediasInDownloadCount == 0);
		}

		public bool IsAllUsersWaitingOnNextTrack(string roomName)
		{
			return _rooms[roomName].Users
								   .All(u => u.TrackEnded);
		}

		public IRoomDTO GetRoomInfo(string roomName)
		{
			if (!_rooms.ContainsKey(roomName))
				throw new KeyNotFoundException();

			var room = Mapper.Map<IRoomDTO>(_rooms[roomName]);

			room.Name = roomName;

			return room;
		}

		public IEnumerable<string> GetUserConnectionIdsInCurrentRoom()
		{
			return _rooms[GetRoomName()].Users.Select(u => u.ConnectionId);
		}
	}
}
