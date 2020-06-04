using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using SharedKernel.Abstractions.DAL.Models;

namespace DAL.Entities
{
	// login
	// true + user
	// or 
	// null

	// Register
	// true + user
	// or
	// UsernameAlreadyExists
	public class User : IdentityUser<long>, IUser<long>
	{
		public ICollection<UserRoom> UserRooms { get; set; }

		[NotMapped]
		IEnumerable<IUserRoom> IUser<long>.UserRooms
		{
			get => UserRooms.Select(ur => ur as IUserRoom);
			set => UserRooms = value.Select(ur => ur as UserRoom).ToList();
		}

		public User()
		{
			UserRooms = new List<UserRoom>();
		}
	}
}
