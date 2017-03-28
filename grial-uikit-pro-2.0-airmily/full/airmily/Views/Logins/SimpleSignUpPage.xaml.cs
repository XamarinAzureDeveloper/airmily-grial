using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace airmily
{
	public partial class SimpleSignUpPage : ContentPage
	{
		public SimpleSignUpPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar (this, false);
		}
		async void OnCloseButtonClicked (object sender, EventArgs args)
		{
			await Navigation.PopModalAsync ();
		}
	}
}

