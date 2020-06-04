using SharedKernel.Abstractions.DAL.Models;

namespace SharedKernel.Models
{
	public class BaseEntity : IBaseEntity
	{
		public long Id { get; set; }
	}
}
