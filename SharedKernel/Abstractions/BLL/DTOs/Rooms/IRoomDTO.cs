using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel.Abstractions.BLL.DTOs.User;

namespace SharedKernel.Abstractions.BLL.DTOs.Rooms
{
	public interface IRoomDTO
	{
		string Name { get; set; }

		IEnumerable<IUserDTO> Users { get; set; }
	}
}
