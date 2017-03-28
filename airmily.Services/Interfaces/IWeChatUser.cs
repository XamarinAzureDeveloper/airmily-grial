namespace airmily.Services.Interfaces
{
	public interface IWeChatUser
	{
		string OpenID { get; set; }
		string Nickname { get; set; }
		int Sex { get; set; }
		string Language { get; set; }
		string City { get; set; }
		string Province { get; set; }
		string Country { get; set; }
		string HeadImgUrl { get; set; }
		object[] Privilege { get; set; }
		string UnionID { get; set; }
	}

}