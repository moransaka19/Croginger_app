using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SharedKernel.Abstractions.DAL.Models;
using SharedKernel.Models;

namespace DAL.Entities
{
	// Create
	public class Message : BaseEntity, IMessage
	{
		public long UserId { get; set; }
		public User User { get; set; }
		public string HashMessage { get; set; }
		public DateTime DateSent { get; set; }
		public long RoomId { get; set; }
		public Room Room { get; set; }

		[NotMapped]
		IUser<long> IMessage.User
		{
			get => User;
			set => User = value as User;
		}

		[NotMapped]
		IRoom IMessage.Room
		{
			get => Room;
			set => Room = value as Room;
		}
	}
}
