using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using airmily.Interfaces;
using airmily.Services.Auth;
using airmily.Services.Azure;
using airmily.Services.Interfaces;
using airmily.Services.Models;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace airmily.ViewModels
{
	public class LoginPageViewModel : BindableBase, INavigationAware
	{
		// POSSIBLE VALUES FOR SAMPLE DATA:
		// USERNAME		ACCOUNT TYPE		DATA
		// - user01		- Regular user		- Has SOME cards
		// - user02		- Controller		- Has ALL cards
		// - user03		- Regular user		- Has NO cards

		// Switch this between user01, user02 and user03
		private const string _username = "user01";

		private readonly INavigationService _navigationService;
		private readonly ILoginServiceWeChat _weChatLogin;
		private readonly IAzure _azure;
		private readonly IAuth _auth;

		private bool _isLoading;
		public bool IsLoading
		{
			get { return _isLoading; }
			set { SetProperty(ref _isLoading, value); }
		}

		private bool _loginFailed;
		public bool LoginFailed
		{
			get { return _loginFailed; }
			set { SetProperty(ref _loginFailed, value); }
		}

		private bool _showLoginButton;
		public bool ShowLoginButton
		{
			get { return _showLoginButton; }
			set { SetProperty(ref _showLoginButton, value); }
		}

		private DelegateCommand _loginCmd;
		public DelegateCommand LoginCmd
		{
			get { return _loginCmd ?? (_loginCmd = new DelegateCommand(Login)); }
		}

		public LoginPageViewModel(INavigationService navigationService, IAzure azure, IAuth auth)
		{
			_navigationService = navigationService;
			_azure = azure;
			_auth = auth;
			_weChatLogin = Xamarin.Forms.DependencyService.Get<ILoginServiceWeChat>();
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{

		}
		public void OnNavigatedTo(NavigationParameters parameters)
		{
			ShowLoginButton = _weChatLogin.IsWXSupported();

			if (parameters.ContainsKey("logout"))
				if ((bool)parameters["logout"])
					_azure.LogoutAsync();
		}

		private void Login()
		{
			IsLoading = true;
			LoginFailed = false;

			MessagingCenter.Subscribe<WeChatUser>(this, "WeChatLoggedIn", CompleteLogin);
			_weChatLogin.WXLogin();
		}

		private async void CompleteLogin(WeChatUser user)
		{
			MessagingCenter.Unsubscribe<WeChatUser>(this, "WeChatLoggedIn");

			Debug.WriteLine("User: {0} UnionID: {1}", user.Nickname, user.UnionID);
			if (await _azure.LoginAsync(_username, user.UnionID))
			{
				if (_auth.CurrentUser != null)
				{
					IsLoading = false;
					_auth.CurrentWeChat = user;

					await _navigationService.NavigateAsync("NavigationPage/CardsListPage");
				}
			}

			LoginFailed = true;
			IsLoading = false;
		}
	}
}
