using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace airmily
{
	public partial class SocialVariantPage : ContentPage
	{
		public SocialVariantPage ()
		{
			InitializeComponent ();

			BindingContext = new SocialViewModel ();
		}
	}
}