using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Abstractions.DAL.Models
{
	public interface IMessage
	{
		long UserId { get; set; }
		IUser<long> User { get; set; }
		string HashMessage { get; set; }
		DateTime DateSent { get; set; }
		long RoomId { get; set; }
		IRoom Room { get; set; }
	}
}
