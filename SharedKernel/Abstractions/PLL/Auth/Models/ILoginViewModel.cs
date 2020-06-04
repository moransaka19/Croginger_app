namespace SharedKernel.Abstractions.PLL.Auth.Models
{
	public interface ILoginViewModel
	{
		string UserName { get; set; }
		string Password { get; set; }
	}
}
