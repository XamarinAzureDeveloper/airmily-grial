using System;
using System.Linq;
using airmily.Services.Interfaces;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace airmily.Services.Models
{
	[JsonObject]
	public class Transaction : EntityDataOfflineSync, ITransaction, IFFXTransaction
	{
		[JsonProperty]
		public string CardID { get; set; }

		[JsonProperty]
		public string Description { get; set; }

		[JsonProperty]
		public string Currency { get; set; }

		[JsonProperty]
		public string InternalDifference { get; set; }

		[JsonProperty]
		public string Amount { get; set; }

		[JsonProperty]
		public bool NegativeAmount { get; set; }

		[JsonProperty]
		public string TransDate { get; set; }

		[JsonProperty]
		public string PostDate { get; set; }

		public Transaction() { }
		public Transaction(FFXTransaction t, string card)
		{
			Description = t.Description;
			TransDate = t.TransDate;
			PostDate = t.PostDate;
			Currency = t.Currency;
			Amount = t.Amount;
			NegativeAmount = t.NegativeAmount;
			InternalDifference = t.InternalDifference;
			CardID = card;
		}
		public Transaction(string desc, string date, string post, string curr, string amou, bool ngtv, string diff, string card)
		{
			Description = desc;
			TransDate = date;
			PostDate = post;
			Currency = curr;
			Amount = amou;
			NegativeAmount = ngtv;
			InternalDifference = diff;
			CardID = card;
		}

		[JsonIgnore]
		public string Main { get { return Description; } }
		[JsonIgnore]
		public string Details
		{
			get
			{
				string date = TransDate.Split('T')[0];
				return string.Join("-", date.Split('-').Reverse());
			}
		}
		[JsonIgnore]
		public string Value
		{
			get
			{
				string cur;
				switch (Currency)
				{
					default:
						cur = "£";
						break;
					case "EUR":
						cur = "€";
						break;
					case "USD":
						cur = "$";
						break;
				}

				string top = (NegativeAmount ? "-" : "") + cur + Convert.ToDouble(InternalDifference).ToString("F");
				string bot = (NegativeAmount ? "-" : "") + "£" + Convert.ToDouble(Amount).ToString("F");

				if (Description == "Card Load" || Description.StartsWith("Card Transfer"))
					return bot;

				return InternalDifference == Amount ? top : top + Environment.NewLine + bot;
			}
		}
	}
}