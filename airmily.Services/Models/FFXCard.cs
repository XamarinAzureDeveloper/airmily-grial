using airmily.Services.Interfaces;
using Newtonsoft.Json;

namespace airmily.Services.Models
{
	[JsonObject]
	public class FFXCard : EntityDataOfflineSync, IFFXCard
	{
		[JsonProperty("id")]
		public string CardID { get; set; }

		[JsonProperty("obscured")]
		public string Number { get; set; }

		[JsonProperty("cardholder")]
		public FFXCardHolder CardHolder { get; set; }

		[JsonProperty("currency")]
		public FFXCardCurrency Currency { get; set; }

		[JsonProperty("balance")]
		public string Available { get; set; }

		[JsonProperty("blocked")]
		public string Blocked { get; set; }

		[JsonProperty("status")]
		public FFXCardStatus CardStatus { get; set; }

	}

	public class FFXCardHolder
	{
		[JsonProperty("firstname")]
		public string Firstname { get; set; }
		[JsonProperty("surname")]
		public string Surname { get; set; }

		public override string ToString()
		{
			return Firstname + " " + Surname;
		}
	}

	public class FFXCardStatus
	{
		[JsonProperty("name")]
		public string Status { get; set; }
		[JsonIgnore]
		public bool Current { get { return Status.ToUpper() == "ACTIVE"; } }
	}

	public class FFXCardCurrency
	{
		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		[JsonProperty("code")]
		public string Code { get; set; }
	}
}
