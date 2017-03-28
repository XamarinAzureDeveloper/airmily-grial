using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class ProductIItemFullScreenPage : ContentPage
	{
		public ProductItemViewPage()
		{
			InitializeComponent ();

			BindingContext = SampleData.Products[0];
		}
			
		private async void OnImageTapped(Object sender, EventArgs e){
			var imagePreview =  new ProductImageFullScreenPage ( (sender as FFImageLoading.Forms.CachedImage).Source);

			await Navigation.PushModalAsync( new NavigationPage( imagePreview ) );
		}
	}
}

