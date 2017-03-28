using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using airmily.Interfaces;
using airmily.Services.Auth;
using airmily.Services.Azure;
using airmily.Services.Models;
using Microsoft.Practices.Unity.Utility;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace airmily.ViewModels
{
	public class ViewImagesPageViewModel : BindableBase, INavigationAware, IBaseViewModel
	{
		private readonly IAuth _auth;
		private readonly IAzure _azure;
		private readonly INavigationService _navigationService;
		private readonly IPageDialogService _pageDialogService;

		private Transaction _currentTransaction = new Transaction
		{
			Currency = "GBP",
			NegativeAmount = true,
			InternalDifference = "0.00",
			Amount = "0.00",
			Description = "Description"
		};
		public Transaction CurrentTransaction
		{
			get { return _currentTransaction; }
			set { SetProperty(ref _currentTransaction, value); }
		}

		public Card CurrentCard
		{
			get { return _auth.CurrentCard; }
		}

		private string _title;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		private bool _isUnitTesting = false;
		public bool IsUnitTesting
		{
			get { return _isUnitTesting; }
			set { SetProperty(ref _isUnitTesting, value); }
		}

		private bool _isLoading;
		public bool IsLoading
		{
			get { return _isLoading; }
			set { SetProperty(ref _isLoading, value); }
		}

		private string _otherText = "Refresh";
		public string OtherText
		{
			get { return _otherText; }
		}

		private DelegateCommand _otherCmd;
		public DelegateCommand OtherCmd
		{
			get { return _otherCmd ?? (_otherCmd = new DelegateCommand(async () => await Refresh())); }
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

		private DelegateCommand<AlbumItem> _onImageTapped;
		public DelegateCommand<AlbumItem> OnImageTapped
		{
			get
			{
				return _onImageTapped ?? (_onImageTapped = new DelegateCommand<AlbumItem>(async selected =>
				{
					AlbumItem item = selected;
					if (item == null) return;

					if (!item.IsAddButton)
					{
						//Unused at the moment

						//CarouselVersion
						//NavigationParameters parameters = new NavigationParameters { ["Images"] = (item.IsReceipt ? Receipts : Goods), ["Current"] = item };
						//await _navigationService.NavigateAsync("CarouselImageGalleryPage", parameters);
					}
					else
					{
						string action = await _pageDialogService.DisplayActionSheetAsync(null, "Cancel", null,
							"Take New Picture", "Add From Camera Roll");
						if (action != "Take New Picture" && action != "Add From Camera Roll") return;

						await CrossMedia.Current.Initialize();
						if (action == "Take New Picture")
						{
							if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
							{
								var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
								{
									Directory = "ReceiptsAndGoods",
									Name = "test.jpg",
									SaveToAlbum = false,
									CompressionQuality = 10
								});
								await AddPicture(item, file);
							}
						}
						else if (action == "Add From Camera Roll")
						{
							if (CrossMedia.Current.IsPickPhotoSupported)
							{
								var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
								{
									CompressionQuality = 75
								});
								await AddPicture(item, file);
							}
						}
					}
				}));
			}
		}

		private DelegateCommand _refreshCmd;
		public DelegateCommand RefreshCmd
		{
			get { return _refreshCmd ?? (_refreshCmd = new DelegateCommand(async () => await Refresh())); }
			set { SetProperty(ref _refreshCmd, value); }
		}

		private ObservableCollection<AlbumItem> _images = new ObservableCollection<AlbumItem>();
		public ObservableCollection<AlbumItem> Images
		{
			get { return _images; }
			set { SetProperty(ref _images, value); }
		}

		public ViewImagesPageViewModel(IPageDialogService pageDialogService, IAzure azure,
			INavigationService navigationService, IAuth auth)
		{
			_pageDialogService = pageDialogService;
			_azure = azure;
			_navigationService = navigationService;
			_auth = auth;

			Title = "Documents";
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
			//Debug.WriteLine("OnNavigateFrom");
		}

		public async void OnNavigatedTo(NavigationParameters parameters)
		{
			if (!parameters.ContainsKey("refreshing"))
			{
				if (!parameters.ContainsKey("transaction")) return;
				CurrentTransaction = (Transaction)parameters["transaction"];
			}

			await Refresh();
		}

		public async Task Refresh()
		{
			// NEED TO REWORK FOR THE NEW VIEW - OUTDATED

			IsLoading = true;

			#region Receipts
			Receipts.Clear();
			List<AlbumItem> receipts = await _azure.GetAllImages(CurrentTransaction.ID, true);
			foreach (AlbumItem t in receipts)
				Receipts.Add(t);

			receipts.Add(new AlbumItem { IsAddButton = true, IsReceipt = true });
			int i = 0;
			ImageListItems tempILI = new ImageListItems();

			//ClearItems before applying new items
			ReceiptItems.Clear();
			foreach (AlbumItem t in receipts)
			{
				//RESET temp class for next ListEntry
				if (tempILI == null)
					tempILI = new ImageListItems();

				//Add Image
				tempILI.ItemImages.Add(t);

				//Add ListEntry content and reset for next Entry
				if (i >= 3)
				{
					ReceiptItems.Add(tempILI);
					tempILI = null;
					i = 0;
				}
				i++;
			}

			//Fill aditional spaces with filler image
			if (tempILI != null)
			{
				for (int j = tempILI.ItemImages.Count; j < 3; j++)
				{
					tempILI.ItemImages.Add(new AlbumItem());
				}
				ReceiptItems.Add(tempILI);
			}
			#endregion

			//Reset Values to refresh Goods
			tempILI = null;
			i = 0;

			#region Goods
			Goods.Clear();
			List<AlbumItem> goods = await _azure.GetAllImages(CurrentTransaction.ID, false);
			foreach (AlbumItem t in goods)
				Goods.Add(t);

			goods.Add(new AlbumItem { IsAddButton = true, IsReceipt = false });
			//ClearItems before applying new items
			GoodsItems.Clear();
			foreach (AlbumItem t in goods)
			{
				if (tempILI == null)
					tempILI = new ImageListItems();

				tempILI.ItemImages.Add(t);
				if (i >= 3)
				{
					GoodsItems.Add(tempILI);
					tempILI = null;
					i = 0;
				}
				i++;
			}

			//Fill aditional spaces with filler image
			if (tempILI != null)
			{
				for (int j = tempILI.ItemImages.Count; j < 3; j++)
				{
					tempILI.ItemImages.Add(new AlbumItem());
				}
				GoodsItems.Add(tempILI);
			}
			#endregion

			List<AlbumItem> images = await _azure.GetAllImages(CurrentTransaction.ID);
			foreach (AlbumItem image in images)
				Images.Add(image);

			if (!IsUnitTesting)
				HockeyApp.MetricsManager.TrackEvent("Images Page Loaded");

			IsLoading = false;
		}

		public async Task AddPicture(AlbumItem item, MediaFile image)
		{
			if (image == null) return;

			IsLoading = true;
			AlbumItem newItem = new AlbumItem
			{
				CardID = _auth.CurrentCard.CardID,
				Album = CurrentTransaction.ID,
				IsAddButton = false,
				IsReceipt = item.IsReceipt,
				ImageName = Guid.NewGuid().ToString(),
				Image = new byte[image.GetStream().Length]
			};
			image.GetStream().Read(newItem.Image, 0, newItem.Image.Length);

			await _azure.UploadImage(newItem);
			await Refresh();

			HockeyApp.MetricsManager.TrackEvent("Goods Added");
		}

		#region Our Collections for Old Control
		private ObservableCollection<ImageListItems> _receiptItems = new ObservableCollection<ImageListItems>();
		public ObservableCollection<ImageListItems> ReceiptItems
		{
			get { return _receiptItems; }
			set { SetProperty(ref _receiptItems, value); }
		}

		private ObservableCollection<ImageListItems> _goodsItems = new ObservableCollection<ImageListItems>();
		public ObservableCollection<ImageListItems> GoodsItems
		{
			get { return _goodsItems; }
			set { SetProperty(ref _goodsItems, value); }
		}

		private ObservableCollection<AlbumItem> _receipts = new ObservableCollection<AlbumItem>();
		public ObservableCollection<AlbumItem> Receipts
		{
			get { return _receipts; }
			set { SetProperty(ref _receipts, value); }
		}

		private ObservableCollection<AlbumItem> _goods = new ObservableCollection<AlbumItem>();
		public ObservableCollection<AlbumItem> Goods
		{
			get { return _goods; }
			set { SetProperty(ref _goods, value); }
		}
		#endregion
	}

	public class ImageListItems : BindableBase
	{
		private ObservableCollection<AlbumItem> _itemImages = new ObservableCollection<AlbumItem>();

		public ObservableCollection<AlbumItem> ItemImages
		{
			get { return _itemImages; }
			set { SetProperty(ref _itemImages, value); }
		}
	}

}