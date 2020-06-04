using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SharedKernel.Abstractions.DAL.Models;
using SharedKernel.Models;

namespace DAL.Entities
{
	// Update
	// Read
	// Compare
	// Play
	// Pause
	// Stop

	public class PlayList : BaseEntity, IPlayList
	{
		public long RoomId { get; set; }
		public Room Room { get; set; }

		public TimeSpan TrackCurrentTime { get; set; }

		[NotMapped]
		IRoom IPlayList.Room
		{
			get => Room;
			set => Room = value as Room;
		}
		[NotMapped]
		ICollection<IMedia> IPlayList.Medias { get; set; }
	}
}
