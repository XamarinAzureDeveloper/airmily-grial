using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace airmily
{
	public partial class NotificationsPage : ContentPage
	{
		public NotificationsPage()
		{
			InitializeComponent();
			BindingContext = new NotificationsViewModel();
		}
	}
}

