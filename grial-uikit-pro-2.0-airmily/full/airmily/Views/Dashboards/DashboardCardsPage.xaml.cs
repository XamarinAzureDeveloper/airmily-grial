using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace airmily
{
	public partial class DashboardCardsPage : ContentPage
	{
		public DashboardCardsPage()
		{
			InitializeComponent();

			this.BindingContext = new DashboardCardsViewModel();
		}
	}
}

