using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
	class LocalRoomModel
	{
		public string Name { get; set; }
		public ICollection<LocalUserModel> Users { get; set; }
		public ICollection<Media> Medias { get; set; }
		public Media CurrentMedia { get; set; }

		public LocalRoomModel()
		{
			Users = new List<LocalUserModel>();
			Medias = new List<Media>();
		}
	}
}
