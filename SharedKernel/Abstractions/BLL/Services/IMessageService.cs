using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel.Abstractions.BLL.DTOs.Messages;

namespace SharedKernel.Abstractions.BLL.Services
{
	public interface IMessageService
	{
		Task AddAsync(IMessageDTO dto);
	}
}
