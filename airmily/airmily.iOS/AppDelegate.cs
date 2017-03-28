using System;
using System.Collections.Generic;
using airmily.Interfaces;
using airmily.Services.Auth;
using UIKit;
using Foundation;
using Xamarin.Forms;
using HockeyApp.iOS;
using WinXinIOSBinding;
using Newtonsoft.Json.Linq;
using UXDivers.Artina.Grial;
using Microsoft.WindowsAzure.MobileServices;
using airmily.Services.Interfaces;
using airmily.Services.Azure;
using EventKit;
using UXDivers.Artina.Shared;
using Xamarin.Auth;

namespace airmily.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
			// HockeyApp
            var manager = BITHockeyManager.SharedHockeyManager;
            manager.Configure("1578f0ce30e440b98f4478e239d38dd6");
            manager.StartManager();
            HockeyApp.MetricsManager.TrackEvent("Feedback");
            manager.Authenticator.AuthenticateInstallation(); //Obsolete for crash only builds (assuming we're using it for more) 

			// Azure
			CurrentPlatform.Init();
            SQLitePCL.CurrentPlatform.Init();

			// WeChat
            WXApi.RegiserApp("wx8b14701dca600e63");
            DependencyService.Register<ILoginServiceWeChat, WeChatService>();

			// Xamarin
			global::Xamarin.Forms.Forms.Init();

			// Push Notifications
			App appToLoad = new App();
			//if (!appToLoad.MockData)
			//{
			//	var pushSettings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, new NSSet());
			//	UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);
			//	UIApplication.SharedApplication.RegisterForRemoteNotifications();
			//}

			// Grial
			Appearance.Configure();
			GrialKit.Init(new ThemeColors(), "airmily.iOS.GrialLicense");

			// Launch
	        LoadApplication(appToLoad);

            UIApplication.SharedApplication.ApplicationSupportsShakeToEdit = true;
            return base.FinishedLaunching(app, options);
        }

        public override bool HandleOpenURL(UIApplication application, NSUrl url)
        {
            return WXApi.HandleOpenURL(url, new WXapiImplement());
        }

        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            return WXApi.HandleOpenURL(url, new WXapiImplement());
        }

		public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
		{
			//const string templateBodyAPNS = "{\"aps\":{\"alert\":\"$(messageParam)\"},\"card\":\"$(cardParam)\"}";

			//JObject templates = new JObject();
			//templates["genericMessage"] = new JObject
			//{
			//	{ "body", templateBodyAPNS }
			//};

			//Push push = Azure.Client.GetPush();
			//push.RegisterAsync(deviceToken, templates);
		}

		public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
	    {
		 //   NSObject card = userInfo.ObjectForKey(new NSString("card"));
			//if (application.ApplicationState != UIApplicationState.Active)
			//	(Xamarin.Forms.Application.Current as App)?.OpenCardsTransactionPage(card.ToString());
	    }
    }

    public class WXapiImplement : WXApiDelegate
    {
        public override async void OnResp(BaseResp resp)
        {
            if (resp.ErrCode == (int)AuthErrCode.WechatAuth_Err_Ok)
            {
                SendAuthResp authResp = (SendAuthResp)resp;
                if (authResp != null)
                {
                    string code = authResp.Code;

                    string url = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=wx8b14701dca600e63&secret=5ed091c79c9fcbec01bd74d8c573a874&code=" + code + "&grant_type=authorization_code";
                    await WeChatHelper.GetUserInfo(url);
                }
            }
        }
    }
}
