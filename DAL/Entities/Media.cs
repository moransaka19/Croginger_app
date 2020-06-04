using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SharedKernel.Abstractions.DAL.Models;

namespace DAL.Entities
{
	// Create
	// Read
	public class Media : IMedia, IEquatable<Media>
	{
		public string Name { get; set; }
		public TimeSpan Duration { get; set; }
		public string FileName { get; set; }
		public string Type { get; set; }
		public string Genre { get; set; }
		public string Singler { get; set; }
		public long PlayListId { get; set; }
		private PlayList _playList { get; set; }
		public double BitRate { get; set; }
		public double Rate { get; set; }
		public string Album { get; set; }
		public string Description { get; set; }
		public string MimeType { get; set; }
		public decimal StartPosition { get; set; }
		public decimal EndPosition { get; set; }

		IPlayList IMedia.PlayList
		{
			get => _playList;
			set => _playList = value as PlayList;
		}

		public override bool Equals(object obj)
		{
			return obj is Media media && Equals(media);
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool Equals(Media other)
		{
			if (other == null) return false;
			if (this == other) return true;

			var points = 0;

			points += CompareStrings(Name, other.Name);
			points += Duration == other.Duration ? 1 : 0;
			points += CompareStrings(FileName, other.FileName);
			points += CompareStrings(Type, other.Type);
			points += CompareStrings(Genre, other.Genre);
			points += CompareStrings(Singler, other.Singler);
			points += BitRate == other.BitRate ? 1 : 0;
			points += Rate == other.Rate ? 1 : 0;
			points += CompareStrings(Album, other.Album);
			points += CompareStrings(Description, other.Description);
			points += CompareStrings(MimeType, other.MimeType);
			points += StartPosition == other.StartPosition ? 1 : 0;
			points += EndPosition == other.EndPosition ? 1 : 0;

			return points > 10;
		}

		private int CompareStrings(string s1, string s2)
		{
			return string.Equals(s1, s2, StringComparison.CurrentCultureIgnoreCase) ? 1 : 0;
		}
	}
}
