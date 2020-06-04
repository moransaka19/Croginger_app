using System.Collections.Generic;

namespace SharedKernel.Abstractions.DAL.Models
{
	public interface IRoom
	{
		string Name { get; set; }
		string PasswordHash { get; set; }
		string UniqName { get; set; }
		long HostId { get; set; }

		long PlayListId { get; set; }
		IPlayList PlayList { get; set; }

		IEnumerable<IUserRoom> UserRooms { get; set; }
		IEnumerable<IMessage> Messages { get; set; }
	}
}