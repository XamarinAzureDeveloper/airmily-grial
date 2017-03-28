using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Services.Client;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using airmily.Interfaces;
using airmily.Services.Auth;
using airmily.Services.Azure;
using airmily.Services.Interfaces;
using airmily.Services.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using HockeyApp;
using Prism.Services;

namespace airmily.ViewModels
{
	public class CardsListPageViewModel : BindableBase, INavigationAware, IBaseViewModel
	{
		private readonly IAzure _azure;
		private readonly INavigationService _navigationService;
		private readonly IPageDialogService _pageDialogService;
		private readonly IAuth _auth;

		private string _title;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		private bool _isLoading;
		public bool IsLoading
		{
			get { return _isLoading; }
			set { SetProperty(ref _isLoading, value); }
		}

		private bool _isUnitTesting = false;
		public bool IsUnitTesting
		{
			get { return _isUnitTesting; }
			set { SetProperty(ref _isUnitTesting, value); }
		}

		private Card _selectedCard;
		public Card SelectedCard
		{
			get { return _selectedCard; }
			set { SetProperty(ref _selectedCard, value); }
		}
		public User CurrentUser
		{
			get { return _auth.CurrentUser; }
		}

		private string _otherText = "...";
		public string OtherText
		{
			get { return _otherText; }
		}

		private DelegateCommand _otherCmd;
		public DelegateCommand OtherCmd
		{
			get { return _otherCmd ?? (_otherCmd = new DelegateCommand(LoadActionSheet)); }
		}

		private bool _isBackButton = false;
		public bool IsBackButton
		{
			get { return _isBackButton; }
		}

		private DelegateCommand _backCmd;
		public DelegateCommand BackCmd
		{
			get { return _backCmd ?? (_backCmd = new DelegateCommand(() => { })); }
		}

		private ObservableCollection<Card> _cardsList = new ObservableCollection<Card>();
		public ObservableCollection<Card> CardsList
		{
			get { return _cardsList; }
			set { SetProperty(ref _cardsList, value); }
		}

		private DelegateCommand _refreshCommand;
		public DelegateCommand RefreshCommand
		{
			get
			{
				if (_refreshCommand == null)
				{
					_refreshCommand = new DelegateCommand(RefreshList);
				}
				return _refreshCommand;
			}
		}

		private DelegateCommand<ItemTappedEventArgs> _goToTransactionsListPage;
		public DelegateCommand<ItemTappedEventArgs> GoToTransactionsListPage
		{
			get
			{
				if (IsUnitTesting)
					HockeyApp.MetricsManager.TrackEvent("TransactionClicked");


				if (_goToTransactionsListPage == null)
					_goToTransactionsListPage = new DelegateCommand<ItemTappedEventArgs>(async selected =>
					{
						_auth.CurrentCard = selected.Item as Card;
						if (_auth.CurrentCard != null)
							await _navigationService.NavigateAsync("TransactionsListPage");
					});
				return _goToTransactionsListPage;
			}
		}

		private ImageSource _headingPicture;
		public ImageSource HeadingPicture
		{
			get { return _headingPicture ?? (_headingPicture = ImageSource.FromUri(new Uri(_auth.CurrentWeChat.HeadImgUrl))); }
		}

		private string _numberOfCards;
		public string NumberOfCards
		{
			get { return _numberOfCards + " cards"; }
			set { SetProperty(ref _numberOfCards, value); }
		}

		public CardsListPageViewModel(INavigationService navigationService, IAzure azure, IAuth auth, IPageDialogService pageDialogService)
		{
			_navigationService = navigationService;
			_pageDialogService = pageDialogService;
			_azure = azure;
			_auth = auth;

			Title = _auth.CurrentUser.UserName;
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
			SelectedCard = null;
		}
		public async void OnNavigatedTo(NavigationParameters parameters)
		{
			if (parameters.ContainsKey("gotocard"))
			{
				List<Card> cards = await _azure.GetAllCards(_auth.CurrentUser);
				_auth.CurrentCard = cards.First(c => c.CardID == parameters["gotocard"].ToString());
				await _navigationService.NavigateAsync("TransactionsListPage");
				return;
			}

			_auth.CurrentCard = null;
			RefreshList();
		}

		public async void LoadActionSheet()
		{
			switch (await _pageDialogService.DisplayActionSheetAsync(_auth.CurrentUser.UserName, "Cancel", "Logout", "Profile", "Settings"))
			{
				case "Logout":
					await _azure.LogoutAsync();
					await _navigationService.NavigateAsync("LoginPage", useModalNavigation: true);
					break;
				case "Profile":
					break;
				case "Settings":
					break;
				default:
					break;
			}
		}
		public async void RefreshList()
		{
			if (!IsUnitTesting) MetricsManager.TrackEvent("Cards List Refreshed");
			IsLoading = true;

			List<Card> cards = await _azure.GetAllCards(_auth.CurrentUser);

			CardsList.Clear();
			foreach (Card c in cards)
				CardsList.Add(c);
			NumberOfCards = CardsList.Count.ToString();

			IsLoading = false;
		}
	}
}
