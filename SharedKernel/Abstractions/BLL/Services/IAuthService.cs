using SharedKernel.Abstractions.BLL.DTOs.Auth;
using System.Threading.Tasks;

namespace SharedKernel.Abstractions.BLL.Services
{
	public interface IAuthService
	{
		Task<object> LoginAsync(ILoginDTO dto);
		Task<object> RegisterAsync(IRegisterDTO dto);
	}
}
