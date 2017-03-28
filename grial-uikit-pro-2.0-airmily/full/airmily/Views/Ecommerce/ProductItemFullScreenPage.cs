using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace airmily
{
	public partial class ProductItemFullScreenPage : ContentPage
	{
		public ProductItemFullScreenPage()
		{
			InitializeComponent();

			BindingContext = SampleData.Products[0];
		}

		//private async void OnImageTapped(Object sender, EventArgs e)
		//{
		//	var imagePreview = new ProductImageFullScreenPage((sender as FFImageLoading.Forms.CachedImage).Source);

		//	await Navigation.PushModalAsync(new NavigationPage(imagePreview));
		//}
	}
}