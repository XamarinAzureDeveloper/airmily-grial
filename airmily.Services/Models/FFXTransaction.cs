using airmily.Services.Interfaces;
using Newtonsoft.Json;

namespace airmily.Services.Models
{
	[JsonObject]
	public class FFXTransaction : EntityDataOfflineSync, IFFXTransaction
	{
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("currency")]
		public string Currency { get; set; }
		[JsonProperty("transactionamount")]
		public string InternalDifference { get; set; }
		[JsonProperty("transactionbill")]
		public string Amount { get; set; }
		[JsonProperty("isdebit")]
		public bool NegativeAmount { get; set; }
		[JsonProperty("transactiondate")]
		public string TransDate { get; set; }
		[JsonProperty("postdate")]
		public string PostDate { get; set; }

		public FFXTransaction() { }
		public FFXTransaction(Transaction t)
		{
			Description = t.Description;
			Currency = t.Currency;
			InternalDifference = t.InternalDifference;
			Amount = t.Amount;
			NegativeAmount = t.NegativeAmount;
			TransDate = t.TransDate;
			PostDate = t.PostDate;
		}

		//Operator Override
		public static bool operator ==(FFXTransaction a, FFXTransaction b)
		{
			bool desc = a.Description == b.Description;
			bool diff = a.InternalDifference == b.InternalDifference;
			bool amnt = a.Amount == b.Amount;
			bool ngtv = a.NegativeAmount == b.NegativeAmount;
			bool trns = a.TransDate == b.TransDate;
			bool post = a.PostDate == b.PostDate;

			return desc && diff && amnt && ngtv && trns && post;
		}

		public static bool operator !=(FFXTransaction a, FFXTransaction b)
		{
			return !(a == b);
		}

		public override bool Equals(object obj)
		{
			try { return this == (FFXTransaction)obj; }
			catch { /*ignored*/ }

			return false;
		}

		public override int GetHashCode()
		{
			// ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
			return base.GetHashCode();
		}
	}
}
