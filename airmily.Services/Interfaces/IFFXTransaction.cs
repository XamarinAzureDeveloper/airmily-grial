namespace airmily.Services.Interfaces
{
	public interface IFFXTransaction
	{
		string Description { get; set; }

		string Currency { get; set; }

		string InternalDifference { get; set; }

		string Amount { get; set; }

		bool NegativeAmount { get; set; }

		string TransDate { get; set; }

		string PostDate { get; set; }
	}
}