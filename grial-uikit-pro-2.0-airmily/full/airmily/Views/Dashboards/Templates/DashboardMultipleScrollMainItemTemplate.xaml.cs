using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace airmily
{
	public partial class DashboardMultipleScrollMainItemTemplate : ContentView
	{
		public DashboardMultipleScrollMainItemTemplate()
		{
			InitializeComponent();
		}

		public async void OnMovieTapped(object sender, EventArgs args)
		{
			await Application.Current.MainPage.DisplayAlert("Movie Tapped!", "You should start playing the movie now", "OK");
		}
	}
}

