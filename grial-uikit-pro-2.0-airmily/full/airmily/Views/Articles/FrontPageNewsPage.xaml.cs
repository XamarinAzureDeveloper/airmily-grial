using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace airmily
{
	public partial class FrontPageNewsPage : ContentPage
	{
		public FrontPageNewsPage()
		{
			InitializeComponent();

			BindingContext = new FrontPageNewsViewModel();

		}
	}
}

