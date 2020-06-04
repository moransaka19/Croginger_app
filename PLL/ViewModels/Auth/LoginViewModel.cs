using SharedKernel.Abstractions.PLL.Auth.Models;

namespace PLL.VIewModels.Auth
{
	public class LoginViewModel : ILoginViewModel
	{
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}
