using System.Threading.Tasks;
using SharedKernel.Abstractions.PLL.Auth.Models;

namespace SharedKernel.Abstractions.PLL.Auth
{
	public interface IAuthController
	{
		Task<object> LoginAsync(ILoginViewModel model);
		Task<object> RegisterAsync(IRegisterViewModel model);
	}
}
