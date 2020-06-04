using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Abstractions.PLL.Rooms.Models
{
	public interface ISignInRoomViewModel
	{
		string UniqName { get; set; }
		string Password { get; set; }
	}
}
