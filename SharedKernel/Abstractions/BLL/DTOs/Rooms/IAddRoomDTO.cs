using SharedKernel.Abstractions.BLL.DTOs.Media;
using System.Collections.Generic;

namespace SharedKernel.Abstractions.BLL.DTOs.Rooms
{
	public interface IAddRoomDTO
	{
		string Name { get; set; }
		string Password { get; set; }
		string UniqName { get; set; }

		IEnumerable<IMediaDTO> Medias { get; set; }
	}
}
