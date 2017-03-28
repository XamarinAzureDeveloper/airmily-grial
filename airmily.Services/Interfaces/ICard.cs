namespace airmily.Services.Interfaces
{
	public interface ICard
	{
		string CardID { get; set; }

		string CardHolder { get; set; }

		string CardNumber { get; set; }

		string Currency { get; set; }

		string Balance { get; set; }

		bool Active { get; set; }
	}
}