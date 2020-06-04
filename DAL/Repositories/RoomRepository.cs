using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Abstractions.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
	class RoomRepository : Repository<Room>, IRepository<Room>
	{
		public RoomRepository(ApplicationContext dbContext) 
			: base(dbContext)
		{
		}

		public override Room FindById(long id)
		{
			return GetAll(r => r.Id == id)
				.Single();
		}

		public override IQueryable<Room> GetAll()
		{
			return DbContext.Set<Room>()
				.Include(r => r.UserRooms)
					.ThenInclude(ur => ur.User);
		}

		public override IQueryable<Room> GetAll(Func<Room, bool> predicate)
		{
			return GetAll().Where(predicate).AsQueryable();
		}
	}
}
