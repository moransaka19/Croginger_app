namespace SharedKernel.Abstractions.PLL.Messages.Models
{
	public interface IAddMessageViewModel
	{
		long RoomId { get; set; }
		string Message { get; set; }
	}
}
