using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace airmily
{
	public partial class ProductsCatalogPage : ContentPage
	{
		public ProductsCatalogPage()
		{
			InitializeComponent();
			BindingContext = SampleData.Products;
		}
		
		public async void OnItemSelected (object sender, SelectedItemChangedEventArgs e) {
			var selectedItem = ((ListView)sender).SelectedItem;
			
			var page = GetPage();
			page.BindingContext = selectedItem;
			await Navigation.PushAsync( page );
		}
		
		public static Page GetPage( )
		{
			return new ProductItemViewPage( );
		}
	}
}

