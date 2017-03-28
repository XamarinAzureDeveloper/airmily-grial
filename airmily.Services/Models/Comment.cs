using System;
using airmily.Services.Interfaces;
using Newtonsoft.Json;

namespace airmily.Services.Models
{
	public class Comment : EntityDataOfflineSync, IComment
	{
		[JsonProperty]
		public string CardID { get; set; }

		[JsonProperty]
		public string ImageID { get; set; }

		[JsonProperty]
		public string Message { get; set; }

		[JsonProperty]
		public string User { get; set; }

		[JsonProperty]
		public DateTime? Date { get; set; }
		
		public Comment() { CurrentType = GalleryType.Comment; }

		[JsonIgnore]
		public AlbumItem Image { get; set; }

		[JsonIgnore]
		public GalleryType CurrentType { get; set; }

		[JsonIgnore]
		public string Main
		{
			get { return Message; }
		}

		[JsonIgnore]
		public string Detail
		{
			get { return Date.HasValue ? Date.Value.ToString("HH:mm - dd MMM") : "Missing Date"; }
		}

		[JsonIgnore]
		public string Value
		{
			get { return User; }
		}
	}

	public enum GalleryType
	{
		Image, Comment, AddComment
	};
}
