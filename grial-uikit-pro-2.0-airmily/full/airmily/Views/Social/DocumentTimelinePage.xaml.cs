using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace airmily
{
	public partial class DocumentTimelinePage : ContentPage
	{
		public DocumentTimelinePage()
		{
			InitializeComponent ();
			BindingContext = new DocumentTimelineViewModel();
		}
	}
}

