using DAL.Entities;
using SharedKernel.Abstractions.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
	class PlayListRepository : Repository<PlayList>, IRepository<PlayList>
	{
		public PlayListRepository(ApplicationContext dbContext) 
			: base(dbContext)
		{
		}
	}
}
