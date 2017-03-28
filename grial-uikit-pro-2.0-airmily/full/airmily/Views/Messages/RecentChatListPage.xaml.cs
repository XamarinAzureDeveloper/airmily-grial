using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace airmily
{
	public partial class RecentChatListPage : ContentPage
	{
		public RecentChatListPage()
		{
			InitializeComponent();

			this.BindingContext = new RecentChatViewModel( SampleData.RecentChatMessagesList );
		}
	}
}

