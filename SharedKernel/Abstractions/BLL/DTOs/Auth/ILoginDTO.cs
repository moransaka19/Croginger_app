namespace SharedKernel.Abstractions.BLL.DTOs.Auth
{
	public interface ILoginDTO
	{
		string UserName { get; set; }
		string Password { get; set; }
	}
}
