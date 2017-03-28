using System.Collections.Generic;
using System.Linq;
using airmily.Services.Models;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Auth;
using Xamarin.Forms;

namespace airmily.Services.Auth
{
	public class Auth : IAuth
	{
		private static User _currentUser;
		public User CurrentUser
		{
			get { return _currentUser; }
			set
			{
				if (_currentUser != value)
					_currentUser = value;
			}
		}

		private static Card _currentCard;
		public Card CurrentCard
		{
			get { return _currentCard; }
			set
			{
				if (_currentCard != value)
					_currentCard = value;
			}
		}

		private static WeChatUser _currentWeChat;
		public WeChatUser CurrentWeChat
		{
			get { return _currentWeChat; }
			set
			{
				if (_currentWeChat != value)
					_currentWeChat = value;
			}
		}

		// Xamarin.Auth Account Store
		public static MobileServiceUser GetAuthentication()
		{
			Account[] accounts = AccountStore.Create().FindAccountsForService("custom").ToArray();

			return accounts.Length < 1
				? null
				: new MobileServiceUser(accounts.First().Properties["userId"])
				{
					MobileServiceAuthenticationToken = accounts.First().Properties["token"]
				};
		}

		public static void StoreAuthentication(MobileServiceUser user)
		{
			AccountStore.Create().Save(new Account(_currentUser.UserName ?? "null username", new Dictionary<string, string> { ["token"] = user.MobileServiceAuthenticationToken, ["userId"] = user.UserId }), "custom");
		}

		public static void ClearAuthentication()
		{
			Account[] accounts = AccountStore.Create().FindAccountsForService("custom").ToArray();

			if (accounts.Length < 1) return;
			foreach (Account acc in accounts)
				AccountStore.Create().Delete(acc, "custom");
		}
	}
}
