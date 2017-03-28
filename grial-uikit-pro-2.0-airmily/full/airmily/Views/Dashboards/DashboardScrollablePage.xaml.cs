using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace airmily
{
	public partial class DashboardScrollablePage : ContentPage
	{
		public DashboardScrollablePage()
		{
			InitializeComponent();

			BindingContext = new DashboardScrollableViewModel();
		}
	}

}
