using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace airmily
{
	public partial class MovieSelectionPage : ContentPage
	{
		public MovieSelectionPage()
		{
			InitializeComponent();
			var defaultMovie = new DashboardMultipleScrollPageViewModel().Sections[3].Content[3];
			this.BindingContext = defaultMovie;
		}

		public async void OnMovieTapped(object sender, EventArgs args)
		{
			await DisplayAlert("Movie Tapped!", "You should start playing the movie now", "OK");
		}
	}
}

