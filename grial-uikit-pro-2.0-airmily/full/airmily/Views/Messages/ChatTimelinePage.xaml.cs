using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace airmily
{
	public partial class ChatTimelinePage : ContentPage
	{
		public ChatTimelinePage()
		{
			InitializeComponent();
			BindingContext = SampleData.ChatMessagesList;
		}
	}
}
