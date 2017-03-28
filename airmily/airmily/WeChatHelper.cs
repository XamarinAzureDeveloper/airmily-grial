using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using airmily.Services.Interfaces;
using Xamarin.Forms;
using airmily.Services.Models;

namespace airmily
{
	public class WeChatHelper
	{
		public static async Task GetUserInfo(string url)
		{
			using (HttpClient client = new HttpClient())
			{
				var response = await client.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsStringAsync();
					var model = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenModel>(result);

					string userUrl = "https://api.weixin.qq.com/sns/userinfo?access_token=" + model.Access_token + "&openid=" + model.Openid;

					var userResponse = await client.GetAsync(userUrl);
					if (userResponse.IsSuccessStatusCode)
					{
						//return true;
						var userResult = await userResponse.Content.ReadAsStringAsync();
						var userItem = Newtonsoft.Json.JsonConvert.DeserializeObject<WeChatUser>(userResult);
						MessagingCenter.Send(userItem, "WeChatLoggedIn");
					}
				}
			}
		}
	}

	public class TokenModel
	{
		public string Access_token { get; set; }
		public string Openid { get; set; }
	}
}