using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace airmily
{
	public partial class TimelinePage : ContentPage
	{
		public TimelinePage()
		{
			InitializeComponent();

			this.BindingContext = new TimelineViewModel();
		}
	}
}

