using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Abstractions.DAL.Models
{
	public interface IBaseEntity
	{
		long Id { get; set; }
	}
}
