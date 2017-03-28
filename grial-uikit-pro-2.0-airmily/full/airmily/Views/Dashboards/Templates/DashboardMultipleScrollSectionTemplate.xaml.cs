using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace airmily
{
	public partial class DashboardMultipleScrollSectionTemplate : ContentView
	{
		public DashboardMultipleScrollSectionTemplate()
		{
			InitializeComponent();
		}

		// Defined only to avoid ListView item selection animation on tap.
		private void OnTapGestureRecognizerTapped(object sender, EventArgs args)
		{
		}

	}
}
