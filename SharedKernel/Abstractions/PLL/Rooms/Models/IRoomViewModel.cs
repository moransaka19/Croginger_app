using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel.Abstractions.BLL.DTOs.User;
using SharedKernel.Abstractions.PLL.User;

namespace SharedKernel.Abstractions.PLL.Rooms.Models
{
	public interface IRoomViewModel
	{
		string Name { get; set; }

		IEnumerable<IUserViewModel> Users { get; set; }
	}
}
