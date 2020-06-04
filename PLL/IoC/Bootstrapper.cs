using PLL.Controllers;
using SharedKernel.Abstractions.PLL.Auth;
using SharedKernel.Abstractions.PLL.Messages;
using SharedKernel.Abstractions.PLL.Rooms;
using SimpleInjector;

namespace PLL.IoC
{
	public class Bootstrapper
	{
		public static void Bootstrap(Container container)
		{
			container.Register<IAuthController, AuthController>();
			container.Register<IMessageController, MessageController>();
			container.Register<IRoomController, RoomController>();

			BLL.IoC.Bootstrapper.Bootstrap(container);
		}
	}
}
