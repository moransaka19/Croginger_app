using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharedKernel.Abstractions.BLL.DTOs.Media;
using SharedKernel.Abstractions.PLL.Media;
using SharedKernel.Abstractions.PLL.Rooms.Models;

namespace SharedKernel.Abstractions.PLL.Rooms
{
	public interface IRoomController
	{
		Task AddAsync(IAddRoomViewModel model);
		Task SignInAsync(ISignInRoomViewModel model);
		Task AddToRoomAsync(string roomName, string connectionId);
		void SetPlaylist(IEnumerable<IMediaViewModel> medias);
		string GetRoomName();
		string GetHostConnectionId();
		Task DisconnectFromRoomAsync();
		IEnumerable<IMediaDTO> CheckMedia(string roomName, IEnumerable<IMediaDTO> medias);
		IEnumerable<string> GetUserConnectionIdsInCurrentRoom();
		void MediaDownloaded(string roomName);
		bool IsAllUsersReadyToStart(string roomName);
		IRoomViewModel GetRoomInfo(string roomName);

		void TrackEnded(string roomName);
		void TrackStarted(string roomName);
		void NextMedia(string roomName, IMediaDTO media);
		IMediaViewModel GetCurrentMedia(string roomName);
		bool IsAllUsersWaitingOnNextTrack(string roomName);
	}
}
