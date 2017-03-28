namespace airmily.Services.Interfaces
{
	public interface IFFXCard
	{
		string CardID { get; set; }

		string Number { get; set; }

		Models.FFXCardHolder CardHolder { get; set; }

		Models.FFXCardCurrency Currency { get; set; }
		
		string Available { get; set; }

		string Blocked { get; set; }

		Models.FFXCardStatus CardStatus { get; set; }
	}
}