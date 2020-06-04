using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Abstractions.BLL.DTOs.Rooms
{
	public interface ISignInRoomDTO
	{
		string UniqName { get; set; }
		string Password { get; set; }
	}
}
