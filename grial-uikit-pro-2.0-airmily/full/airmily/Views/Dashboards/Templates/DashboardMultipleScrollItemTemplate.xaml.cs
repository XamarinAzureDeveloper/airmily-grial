using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace airmily
{
	public partial class DashboardMultipleScrollItemTemplate : ContentView
	{
		public DashboardMultipleScrollItemTemplate()
		{
			InitializeComponent();
		}
		
		private async void OnTapGestureRecognizerTapped(object sender, EventArgs args) {
			var selectedItem = (MovieViewModel)((VisualElement)sender).BindingContext;
			var movieView = new MovieSelectionPage(){
				BindingContext = selectedItem
			};

			// Using this.Navigation does not work as expected, therefore we 
			// need to find the first parent page and push the new page there.
			Page page = null;
			var parent = ((VisualElement)sender).Parent;

			do
			{
				page = parent as Page;

				if (page != null)
				{
					break;
				}

				parent = parent.Parent;
			}
			while (parent != null);

			if (page != null)
			{
				await page.Navigation.PushAsync(movieView);
			}
		}
	}
}
