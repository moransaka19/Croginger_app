using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Abstractions.DAL.Models
{
	public interface IUser<TKey> where TKey : IEquatable<TKey>
	{
		DateTimeOffset? LockoutEnd { get; set; }
		bool TwoFactorEnabled { get; set; }
		bool PhoneNumberConfirmed { get; set; }
		string PhoneNumber { get; set; }
		string ConcurrencyStamp { get; set; }
		string SecurityStamp { get; set; }
		string PasswordHash { get; set; }
		bool EmailConfirmed { get; set; }
		string NormalizedEmail { get; set; }
		string Email { get; set; }
		string NormalizedUserName { get; set; }
		string UserName { get; set; }
		TKey Id { get; set; }
		bool LockoutEnabled { get; set; }
		int AccessFailedCount { get; set; }

		IEnumerable<IUserRoom> UserRooms { get; set; }
	}
}
