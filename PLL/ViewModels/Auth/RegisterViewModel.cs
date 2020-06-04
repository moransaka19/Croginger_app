using SharedKernel.Abstractions.PLL.Auth.Models;

namespace PLL.VIewModels.Auth
{
	public class RegisterViewModel : IRegisterViewModel
	{
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}
