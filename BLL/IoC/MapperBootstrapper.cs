using System.Linq;
using System.Reflection;
using AutoMapper.Configuration;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using SharedKernel.Abstractions.BLL.DTOs.Messages;
using SharedKernel.Abstractions.BLL.DTOs.Rooms;
using SharedKernel.Extensions;

namespace BLL.IoC
{
	public class MapperBootstrapper
	{
		public static void Bootstrap(MapperConfigurationExpression cfg)
		{
			cfg.AddProfiles(Assembly.GetExecutingAssembly());

			DAL.IoC.MapperBootstrapper.Bootstrap(cfg);
		}
	}
}
