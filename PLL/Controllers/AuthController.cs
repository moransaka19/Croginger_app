using System.Threading.Tasks;
using AutoMapper;
using SharedKernel.Abstractions.BLL.DTOs.Auth;
using SharedKernel.Abstractions.BLL.Services;
using SharedKernel.Abstractions.PLL.Auth;
using SharedKernel.Abstractions.PLL.Auth.Models;

namespace PLL.Controllers
{
	public class AuthController : IAuthController
	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		public async Task<object> LoginAsync(ILoginViewModel model)
		{
			var res = _authService.LoginAsync(Mapper.Map<ILoginDTO>(model));

			return await res;
		}

		public async Task<object> RegisterAsync(IRegisterViewModel model)
		{
			var res = _authService.RegisterAsync(Mapper.Map<IRegisterDTO>(model));

			return await res;
		}
	}
}
