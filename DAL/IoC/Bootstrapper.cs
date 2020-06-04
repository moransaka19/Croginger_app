using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Abstractions.DAL.Repositories;
using DAL.Entities;
using DAL.Repositories;

namespace DAL.IoC
{
	public class Bootstrapper
	{
		public static void Bootstrap(Container container)
		{
			container.Register<IRepository<Room>, RoomRepository>();
			container.Register<IRepository<Message>, MessageRepository>();
			container.Register<IRepository<PlayList>, PlayListRepository>();
		}
	}
}
