using airmily.Services.Models;

namespace airmily.Services.Auth
{
    public interface IAuth
    {
		User CurrentUser { get; set; }

		Card CurrentCard { get; set; }

		WeChatUser CurrentWeChat { get; set; }
    }
}
