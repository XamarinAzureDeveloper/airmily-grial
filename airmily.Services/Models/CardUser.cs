using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using airmily.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace airmily.Services.Models
{
	[JsonObject]
	public class CardUser : EntityDataOfflineSync, ICardUser
	{
		[JsonProperty]
		public string CardID { get; set; }

		[JsonProperty]
		public string UserID { get; set; }
	}
}
