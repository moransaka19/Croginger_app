using System.Threading.Tasks;

namespace SharedKernel.Abstractions.BLL.Services
{
	public interface ITokenService
	{
		Task<string> GenerateTokenAsync(string userName);
		Task<string> RefreshToken(string oldToken, string userName);
	}
}
