namespace airmily.Services.Interfaces
{
	public interface IUser
	{
		string UserName { get; set; }

		string UserID { get; set; }

		int AccessLevel { get; set; }

		string UnionID { get; set; }

		string OpenID { get; set; }

		string FairFX { get; set; }
	}
}