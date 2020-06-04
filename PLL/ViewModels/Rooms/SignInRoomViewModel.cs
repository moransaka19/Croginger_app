using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel.Abstractions.PLL.Rooms.Models;

namespace PLL.ViewModels.Rooms
{
	public class SignInRoomViewModel : ISignInRoomViewModel
	{
		public string UniqName { get; set; }
		public string Password { get; set; }
	}
}
