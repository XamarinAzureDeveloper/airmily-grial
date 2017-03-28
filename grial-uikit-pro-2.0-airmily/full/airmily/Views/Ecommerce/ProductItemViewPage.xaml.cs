using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace airmily
{
	public partial class ProductItemViewPage : ContentPage
	{
		public ProductItemViewPage()
		{
			InitializeComponent ();

			BindingContext = SampleData.Products[0];
		}
			
		private async void OnImageTapped(Object sender, EventArgs e){
			var imagePreview =  new ProductImageFullScreenPage ( (sender as FFImageLoading.Forms.CachedImage).Source);

			await Navigation.PushModalAsync(NavigationPageHelper.Create(imagePreview));
		}
	}
}

