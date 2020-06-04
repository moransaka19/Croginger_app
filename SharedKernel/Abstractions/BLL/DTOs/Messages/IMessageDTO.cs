using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Abstractions.BLL.DTOs.Messages
{
	public interface IMessageDTO
	{
		long RoomId { get; set; }
		string Message { get; set; }
	}
}
