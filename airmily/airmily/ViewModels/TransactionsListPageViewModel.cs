using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using airmily.Interfaces;
using airmily.Services.Auth;
using airmily.Services.Azure;
using airmily.Services.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace airmily.ViewModels
{
	public class TransactionsListPageViewModel : BindableBase, INavigationAware, IBaseViewModel
	{
		private readonly IAzure _azure;
		private readonly INavigationService _navigationService;
		private readonly IPageDialogService _pageDialogService;
		private readonly IAuth _auth;

		private Card _currentCard = new Card
		{
			CardHolder = "John Smith",
			CardNumber = "0000********0000",
			Currency = "£",
			Balance = "0.00"
		};
		public Card CurrentCard
		{
			get { return _currentCard; }
			set { SetProperty(ref _currentCard, value); }
		}

		private Transaction _selectedTransaction;
		public Transaction SelectedTransaction
		{
			get { return _selectedTransaction; }
			set { SetProperty(ref _selectedTransaction, value); }
		}

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

		private string _otherText = "";
		public string OtherText
		{
			get { return _otherText; }
		}

		private DelegateCommand _otherCmd;
		public DelegateCommand OtherCmd
		{
			get { return _otherCmd ?? (_otherCmd = new DelegateCommand(() => { })); }
		}

		private bool _isBackButton = true;
		public bool IsBackButton
		{
			get { return _isBackButton; }
		}

		private DelegateCommand _backCmd;
		public DelegateCommand BackCmd
		{
			get { return _backCmd ?? (_backCmd = new DelegateCommand(async () => { await _navigationService.GoBackAsync(); })); }
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

		private ObservableCollection<Transaction> _transactionsList;
		public ObservableCollection<Transaction> TransactionsList
		{
			get { return _transactionsList; }
			set { SetProperty(ref _transactionsList, value); }
		}

		private DelegateCommand<ItemTappedEventArgs> _onTransactionTapped;
		public DelegateCommand<ItemTappedEventArgs> OnTransactionTapped
		{
			get
			{
				return _onTransactionTapped ?? (_onTransactionTapped = new DelegateCommand<ItemTappedEventArgs>(async selected =>
				{
					var trans = selected.Item as Transaction;
					if (trans != null)
						await _navigationService.NavigateAsync("ViewImagesPage", new NavigationParameters {["transaction"] = trans});
				}));
			}
		}

		public TransactionsListPageViewModel(IPageDialogService pageDialogService, IAzure azure, INavigationService navigationService, IAuth auth)
		{
			_pageDialogService = pageDialogService;
			_azure = azure;
			_navigationService = navigationService;
			_auth = auth;

			Title = "Transactions";
		}

		public async void RefreshList()
		{
			IsLoading = true;
			if (!IsUnitTesting)
				HockeyApp.MetricsManager.TrackEvent("Transaction List Refreshed");

			await _azure.UpdateAllTransactions(_auth.CurrentUser, _auth.CurrentCard.CardID);
			var ret = await _azure.GetAllTransactions(CurrentCard.CardID);
			TransactionsList = null;
			TransactionsList = new ObservableCollection<Transaction>(ret);
			IsLoading = false;
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
			SelectedTransaction = null;
		}
		public async void OnNavigatedTo(NavigationParameters parameters)
		{
			if (_auth.CurrentCard != null)
			{
				// CurrentUser = parameters.ContainsKey("ffx") ? (User) parameters["ffx"] : new User {Active = false};
				CurrentCard = _auth.CurrentCard;
				RefreshList();
				HockeyApp.MetricsManager.TrackEvent("Transaction Page Loaded");
			}
		}
	}
}