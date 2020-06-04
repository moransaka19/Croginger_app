using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SharedKernel.Abstractions.BLL.DTOs.Media;
using SharedKernel.Abstractions.BLL.DTOs.Rooms;
using SharedKernel.Abstractions.BLL.Services;
using SharedKernel.Abstractions.DAL.Models;
using SharedKernel.Abstractions.PLL.Media;
using SharedKernel.Abstractions.PLL.Rooms;
using SharedKernel.Abstractions.PLL.Rooms.Models;

namespace PLL.Controllers
{
	public class RoomController : IRoomController
	{
		private readonly IRoomService _roomService;

		public RoomController(IRoomService roomService)
		{
			_roomService = roomService;
		}

		public async Task AddAsync(IAddRoomViewModel model)
		{
			await _roomService.AddAsync(Mapper.Map<IAddRoomDTO>(model));
		}
		
		public async Task SignInAsync(ISignInRoomViewModel model)
		{
			await _roomService.SignInAsync(Mapper.Map<ISignInRoomDTO>(model));
		}

		public async Task AddToRoomAsync(string roomName, string connectionId)
		{
			await _roomService.AddToRoomAsync(roomName, connectionId);
		}

		public void SetPlaylist(IEnumerable<IMediaViewModel> medias)
		{
			_roomService.SetPlaylist(Mapper.Map<IEnumerable<IMediaDTO>>(medias));
		}

		public string GetRoomName()
		{
			return _roomService.GetRoomName();
		}

		public string GetHostConnectionId()
		{
			return _roomService.GetHostConnectionId();
		}

		public async Task DisconnectFromRoomAsync()
		{
			await _roomService.DisconnectFromRoomAsync();
		}

		public IEnumerable<IMediaDTO> CheckMedia(string roomName, IEnumerable<IMediaDTO> mediaDTOs)
		{
			var medias = Mapper.Map<IEnumerable<IMedia>>(mediaDTOs);
			return Mapper.Map<IEnumerable<IMediaDTO>>(_roomService.CheckMedia(roomName, medias));
		}

		public IEnumerable<string> GetUserConnectionIdsInCurrentRoom()
		{
			return _roomService.GetUserConnectionIdsInCurrentRoom();
		}

		public void MediaDownloaded(string roomName)
		{
			_roomService.MediaDownloaded(roomName);
		}

		public bool IsAllUsersReadyToStart(string roomName)
		{
			return _roomService.IsAllUsersReadyToStart(roomName);
		}

		public IRoomViewModel GetRoomInfo(string roomName)
		{
			return Mapper.Map<IRoomViewModel>(_roomService.GetRoomInfo(roomName));
		}

		public void TrackEnded(string roomName)
		{
			_roomService.TrackEnded(roomName);
		}

		public void TrackStarted(string roomName)
		{
			_roomService.TrackStarted(roomName);
		}

		public void NextMedia(string roomName, IMediaDTO media)
		{
			_roomService.NextMedia(roomName, Mapper.Map<IMedia>(media));
		}

		public IMediaViewModel GetCurrentMedia(string roomName)
		{
			return Mapper.Map<IMediaViewModel>(_roomService.GetCurrentMedia(roomName));
		}

		public bool IsAllUsersWaitingOnNextTrack(string roomName)
		{
			return _roomService.IsAllUsersWaitingOnNextTrack(roomName);
		}
	}
}
