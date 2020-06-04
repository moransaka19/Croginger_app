using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel.Abstractions.PLL.Messages.Models;

namespace SharedKernel.Abstractions.PLL.Messages
{
	public interface IMessageController
	{
		Task AddAsync(IAddMessageViewModel model);
	}
}
