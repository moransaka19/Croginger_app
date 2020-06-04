using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLL.ViewModels.Media;
using SharedKernel.Abstractions.PLL.Media;
using SharedKernel.Abstractions.PLL.Rooms.Models;

namespace PLL.ViewModels.Rooms
{
	public class AddRoomViewModel : IAddRoomViewModel
	{
		public string Name { get; set; }
		public string Password { get; set; }
		public string UniqName { get; set; }

		public IEnumerable<MediaViewModel> Medias { get; set; }

		IEnumerable<IMediaViewModel> IAddRoomViewModel.Medias
		{
			get => Medias.Select(e => e as IMediaViewModel).ToList();
			set { Medias = value.Select(e => e as MediaViewModel).ToList(); }
		}
	}
}
