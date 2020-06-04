using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using SharedKernel.Abstractions.BLL.DTOs.Auth;
using SharedKernel.Abstractions.BLL.Services;
using SharedKernel.Exceptions;

namespace BLL.Services
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly ITokenService _tokenService;

		public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_tokenService = tokenService;
		}

		public async Task<object> LoginAsync(ILoginDTO dto)
		{
			var user = await _userManager.FindByNameAsync(dto.UserName);

			if (user == null)
				throw new UserNotFoundException();

			var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

			if (!result.Succeeded)
				throw new IncorrectPasswordException();

			var token = _tokenService.GenerateTokenAsync(dto.UserName);

			return new
			{
				dto.UserName,
				AccessToken = await token
			};
		}

		public async Task<object> RegisterAsync(IRegisterDTO dto)
		{
			var user = new User() { UserName = dto.UserName };

			var result = await _userManager.CreateAsync(user, dto.Password);

			if (!result.Succeeded)
				throw new UserNotRegisteredException(result.Errors.First().Description);

			return new
			{
				dto.UserName,
				AccessToken = await _tokenService.GenerateTokenAsync(dto.UserName)
			};
		}
	}
}
