using SharedKernel.Abstractions.DAL.Models;
using SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class UserRoom : IUserRoom, IEquatable<UserRoom>
	{
		public long UserId { get; set; }
		public User User { get; set; }

		public long RoomId { get; set; }
		public Room Room { get; set; }

		[NotMapped]
		IUser<long> IUserRoom.User
		{
			get => User;
			set => User = value as User;
		}

		[NotMapped]
		IRoom IUserRoom.Room
		{
			get => Room;
			set => Room = value as Room;
		}

		public bool Equals(UserRoom other)
		{
			return UserId == other.UserId
			       && RoomId == other.RoomId;
		}
	}
}
