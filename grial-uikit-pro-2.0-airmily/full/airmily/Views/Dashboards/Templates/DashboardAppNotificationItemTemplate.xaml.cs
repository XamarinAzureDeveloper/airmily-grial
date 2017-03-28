using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace airmily
{
	public partial class DashboardAppNotificationItemTemplate : ContentView
	{
		public DashboardAppNotificationItemTemplate ()
		{
			InitializeComponent ();
		}

		public async void OnTileTapped(object sender, EventArgs args)
		{
			await Application.Current.MainPage.DisplayAlert("Tile Tapped!", "You have tapped a DashboardAppNotificationItemTemplate", "OK");
		}
	}
}
