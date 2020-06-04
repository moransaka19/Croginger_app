using System.Reflection;
using AutoMapper.Configuration;
using SharedKernel.Abstractions.BLL.DTOs.Rooms;
using SharedKernel.Abstractions.PLL.Rooms.Models;

namespace PLL.IoC
{
	public class MapperBootstrapper
	{
		public static void Bootstrap(MapperConfigurationExpression cfg)
		{
			cfg.AddProfiles(Assembly.GetExecutingAssembly());

			BLL.IoC.MapperBootstrapper.Bootstrap(cfg);
		}
	}
}
