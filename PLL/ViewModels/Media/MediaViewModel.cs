using System;
using SharedKernel.Abstractions.PLL.Media;

namespace PLL.ViewModels.Media
{
	public class MediaViewModel : IMediaViewModel
	{
		public string Name { get; set; }
		public TimeSpan Duration { get; set; }
		public string FileName { get; set; }
		public string Type { get; set; }
		public string Genre { get; set; }
		public string Singler { get; set; }
		public long PlayListId { get; set; }
		public double BitRate { get; set; }
		public double Rate { get; set; }
		public string Album { get; set; }
		public string Description { get; set; }
		public string MimeType { get; set; }
		public decimal StartPosition { get; set; }
		public decimal EndPosition { get; set; }
	}
}
