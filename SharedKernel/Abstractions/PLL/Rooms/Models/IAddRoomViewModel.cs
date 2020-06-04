using SharedKernel.Abstractions.PLL.Media;
using System.Collections.Generic;

namespace SharedKernel.Abstractions.PLL.Rooms.Models
{
	public interface IAddRoomViewModel
	{
		string Name { get; set; }
		string Password { get; set; }
		string UniqName { get; set; }

		IEnumerable<IMediaViewModel> Medias { get; set; }
	}
}
