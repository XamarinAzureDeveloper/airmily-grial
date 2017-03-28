using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace airmily
{
	public partial class DashboardVariantItemTemplate : DashboardItemTemplateBase
	{
		
		public DashboardVariantItemTemplate ()
		{
			InitializeComponent ();
		}

		public async void OnTileTapped(object sender, EventArgs args)
		{
			await Application.Current.MainPage.DisplayAlert("Tile Tapped!", "You have tapped a \r\n DashboardItemTemplateBase", "OK");
		}

	}

}
