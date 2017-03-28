using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace airmily
{
	public partial class DashboardCardItemTemplate : ContentView
	{
		public DashboardCardItemTemplate()
		{
			InitializeComponent();
		}

		public async void OnCardTapped(object sender, EventArgs args)
		{
			await Application.Current.MainPage.DisplayAlert("Card Tapped!", "You have tapped a Card", "OK");
		}
	}
}

