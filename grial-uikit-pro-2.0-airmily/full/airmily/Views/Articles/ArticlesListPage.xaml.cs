using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace airmily
{
	public partial class ArticlesListPage : ContentPage
	{
		public ArticlesListPage ()
		{
			InitializeComponent ();

			BindingContext = new PostsViewModel ();
		}

		private async void OnItemTapped(Object sender, EventArgs e){
			var selectedItem = ((ListView)sender).SelectedItem;
			var post = (Post) selectedItem;
			var articleView = new ArticleViewPage(new ArticleViewModel(post));

			await Navigation.PushAsync( articleView );
		}
	}
}

