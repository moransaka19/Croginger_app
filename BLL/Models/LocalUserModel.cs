using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
	class LocalUserModel
	{
		public long Id { get; set; }
		public string UserName { get; set; }
		public string ConnectionId { get; set; }
		public bool IsHost { get; set; }
		public int MediasInDownloadCount { get; set; }
		public bool TrackEnded { get; set; }
	}
}
