using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SharedKernel.Abstractions.BLL.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class TokenService : ITokenService
	{
		private UserManager<User> _userManager;
		private readonly IConfiguration _configuration;

		public TokenService(UserManager<User> userManager, IConfiguration configuration)
		{
			_userManager = userManager;
			_configuration = configuration;
		}

		public async Task<string> GenerateTokenAsync(string UserName)
		{
			User user = await _userManager.FindByNameAsync(UserName);
			ClaimsIdentity identity = await GetIdentity(user);

			DateTime now = DateTime.UtcNow;
			DateTime expires = DateTime.UtcNow.Add(TimeSpan.FromHours(int.Parse(_configuration["AuthOptions:LIFETIME"])));

			JwtSecurityToken token = new JwtSecurityToken(
				issuer: _configuration["AuthOptions:ISSUER"],
				audience: _configuration["AuthOptions:AUDIENCE"],
				notBefore: now,
				claims: identity.Claims,
				expires: expires,
				signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["AuthOptions:KEY"])), SecurityAlgorithms.HmacSha256));

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public async Task<string> RefreshToken(string oldToken, string userName)
		{
			JwtSecurityToken token = new JwtSecurityTokenHandler().ReadJwtToken(oldToken);

			Claim UserClaims = token.Claims
				.Where(x => x.Type == ClaimsIdentity.DefaultNameClaimType)
				.SingleOrDefault();

			if (UserClaims.Value != userName)
				throw new Exception();

			return await GenerateTokenAsync(userName);
		}

		private async Task<ClaimsIdentity> GetIdentity(User user)
		{
			IList<string> userRoles = await _userManager.GetRolesAsync(user);

			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName)
			};

			userRoles.ToList().ForEach(r => claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, r)));

			return new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
		}
	}
}
