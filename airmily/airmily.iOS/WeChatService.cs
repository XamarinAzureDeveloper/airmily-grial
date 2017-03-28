using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using airmily.Services.Interfaces;
using WinXinIOSBinding;
using Xamarin.Forms;

namespace airmily.iOS
{
    public class WeChatService : ILoginServiceWeChat
    {
        public bool IsWXSupported()
        {
			return WXApi.IsWXAppInstalled() && WXApi.IsWXAppSupportApi();
        }

        public void WXLogin()
        {
	        if (IsWXSupported())
	        {
				SendAuthReq req = new SendAuthReq();
				req.Scope = "snsapi_userinfo";
				req.State = "123";
				WXApi.SendReq(req);
	        }
        }
    }

}