using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel.Abstractions.BLL.DTOs.Media;
using SharedKernel.Abstractions.BLL.DTOs.Rooms;
using SharedKernel.Abstractions.DAL.Models;

namespace SharedKernel.Abstractions.BLL.Services
{
	public interface IRoomService
	{
		Task AddAsync(IAddRoomDTO dto);
		Task SignInAsync(ISignInRoomDTO dto);
		string GetRoomName();
		string GetHostConnectionId();
		Task DisconnectFromRoomAsync();
		Task AddToRoomAsync(string roomName, string connectionId);
		void SetPlaylist(IEnumerable<IMediaDTO> medias);
		IEnumerable<IMedia> CheckMedia(string roomName, IEnumerable<IMedia> medias);
		IEnumerable<string> GetUserConnectionIdsInCurrentRoom();
		void MediaDownloaded(string roomName);
		bool IsAllUsersReadyToStart(string roomName);
		IRoomDTO GetRoomInfo(string roomName);

		void TrackEnded(string roomName);
		void TrackStarted(string roomName);
		void NextMedia(string roomName, IMedia media);
		IMediaDTO GetCurrentMedia(string roomName);
		bool IsAllUsersWaitingOnNextTrack(string roomName);
	}
}
