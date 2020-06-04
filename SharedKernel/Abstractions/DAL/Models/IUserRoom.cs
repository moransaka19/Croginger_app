using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Abstractions.DAL.Models
{
	public interface IUserRoom
	{
		long UserId { get; set; }
		IUser<long> User { get; set; }

		long RoomId { get; set; }
		IRoom Room { get; set; }
	}
}
