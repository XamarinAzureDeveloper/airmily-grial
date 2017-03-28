using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using airmily.Interfaces;
using airmily.Services.Auth;
using airmily.Services.Azure;
using airmily.Services.Models;
using Microsoft.Practices.ObjectBuilder2;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

/*
 *	CAN IGNORE THIS VIEWMODEL
 */

namespace airmily.ViewModels
{
	public class CarouselImageGalleryPageViewModel : BindableBase, INavigationAware, IBaseViewModel
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

		private bool _isUnitTesting = false;
        public bool IsUnitTesting
        {
            get { return _isUnitTesting; }
            set { SetProperty(ref _isUnitTesting, value); }
        }

	    private bool _isRefreshing;
	    public bool IsLoading
	    {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
	    }

		private string _otherText = "Delete";
		public string OtherText
		{
			get { return _otherText; }
		}

		private DelegateCommand _otherCmd;
		public DelegateCommand OtherCmd
		{
			get { return _otherCmd ?? (_otherCmd = new DelegateCommand(DeleteSelectedImage)); }
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

		private DelegateCommand _addCommentCmd;
		public DelegateCommand AddCommentCmd
		{
			get { return _addCommentCmd ?? (_addCommentCmd = new DelegateCommand(AddComment)); }
		}

		private DelegateCommand<ViewCell> _deleteCommentCmd;
		public DelegateCommand<ViewCell> DeleteCommentCmd
		{
			get { return _deleteCommentCmd ?? (_deleteCommentCmd = new DelegateCommand<ViewCell>(DeleteComment)); }
		}

		private DelegateCommand _refreshCmd;
		public DelegateCommand RefreshCmd
		{
			get { return _refreshCmd ?? (_refreshCmd = new DelegateCommand(async () => await Refresh())); }
		}

		private DelegateCommand _deleteCmd;
		public DelegateCommand DeleteCmd
		{
			get { return _deleteCmd ?? (_deleteCmd = new DelegateCommand(DeleteSelectedImage)); }
		}

		private ImagesWithComments _selectedImage = new ImagesWithComments();
		public ImagesWithComments SelectedImage
		{
			get { return _selectedImage; }
			set { SetProperty(ref _selectedImage, value); }
		}

		private ObservableCollection<ImagesWithComments> _images = new ObservableCollection<ImagesWithComments>();
		public ObservableCollection<ImagesWithComments> Images
		{
			get { return _images; }
			set { SetProperty(ref _images, value); }
		}

		public CarouselImageGalleryPageViewModel(IPageDialogService pageDialogService, IAzure azure, INavigationService navigationService, IAuth auth)
		{
			_pageDialogService = pageDialogService;
			_azure = azure;
			_navigationService = navigationService;
			_auth = auth;
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
		}

		public async void OnNavigatedTo(NavigationParameters parameters)
		{
			if (!parameters.ContainsKey("Images")) return;

			IsLoading = true;
			ObservableCollection<AlbumItem> albumItems = (ObservableCollection<AlbumItem>) parameters["Images"];
			foreach (AlbumItem t in albumItems)
			{
				ImagesWithComments temp = new ImagesWithComments();
				temp.Items.Add(new Comment {CurrentType = GalleryType.Image, Image = t});
				foreach (Comment c in await _azure.GetComments(t.ID)) temp.Items.Add(c);
				temp.Items.Add(new Comment {CurrentType = GalleryType.AddComment});
				temp.AddCommentText = "";
				Images.Add(temp);
			}
			
			if (albumItems.Count != Images.Count)
				Debug.WriteLine("what?");

			try
			{
				if (!parameters.ContainsKey("Current"))
				{
					SelectedImage = Images.First();
					return;
				}

				int index = albumItems.IndexOf((AlbumItem) parameters["Current"]);
				if (index != -1) SelectedImage = Images[index];
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			Title = SelectedImage.Items.First().Image.IsReceipt ? "Receipts" : "Goods";
			IsLoading = false;
		}

		private async void AddComment()
		{
			try
			{
				if (string.IsNullOrEmpty(SelectedImage.AddCommentText))
					return;

				IsLoading = true;
				Comment newComment = new Comment
				{
					ImageID = SelectedImage.Items.First().Image.ID,
					CardID = _auth.CurrentCard.CardID,
					User = _auth.CurrentUser.UserName,
					Message = SelectedImage.AddCommentText,
					Date = DateTime.Now
				};
				await _azure.AddComment(newComment);
				await Refresh();
				
				HockeyApp.MetricsManager.TrackEvent("Comment Added");
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}

		private bool _deleting = false;

		private async void DeleteComment(ViewCell cell)
		{
			Comment c = cell.BindingContext as Comment;
			if (c == null)
				return;

			if (!_deleting)
			{
				IsLoading = true;
				_deleting = true;
				await _azure.DeleteComment(c);
				await Refresh();
				_deleting = false;
			}
		}

		private async void DeleteSelectedImage()
		{
			if (!await _pageDialogService.DisplayAlertAsync("Warning", "Are you sure you want to delete this image?", "Yes", "No") && !IsUnitTesting)
				return;

			if (SelectedImage == null)
				return;

			IsLoading = true;

			AlbumItem item = SelectedImage.Items.First().Image;
			Images.Remove(SelectedImage);
			await _azure.DeleteImage(item);

			IsLoading = false;

			if (Images.Count < 1)
				await _navigationService.GoBackAsync(new NavigationParameters { ["refreshing"] = true });
		}

		private async Task Refresh()
		{
		    IsLoading = true;
			Comment image = SelectedImage.Items.First();
			SelectedImage.Items.Clear();

			SelectedImage.Items.Add(image);
			foreach (Comment c in await _azure.GetComments(image.Image.ID)) SelectedImage.Items.Add(c);
			SelectedImage.Items.Add(new Comment { CurrentType = GalleryType.AddComment });

			SelectedImage.AddCommentText = "";
		    IsLoading = false;
		}
	}

	public class ImagesWithComments : BindableBase
	{
		private ObservableCollection<Comment> _items = new ObservableCollection<Comment>();
		public ObservableCollection<Comment> Items { get { return _items; } set { SetProperty(ref _items, value); } }

		private string _addCommentText;
		public string AddCommentText { get { return _addCommentText; } set { SetProperty(ref _addCommentText, value); } }
	}

	public class GalleryDataTemplateSelector : DataTemplateSelector
	{
		public DataTemplate ImageTemplate { get; set; }
		public DataTemplate CommentTemplate { get; set; }
		public DataTemplate AddCommentTemplate { get; set; }
		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			Comment c = (Comment)item;
			if (c == null) return AddCommentTemplate;

			switch (c.CurrentType)
			{
				default:
					return CommentTemplate;
				case GalleryType.Image:
					return ImageTemplate;
				case GalleryType.AddComment:
					return AddCommentTemplate;
			}
		}
	}
}
