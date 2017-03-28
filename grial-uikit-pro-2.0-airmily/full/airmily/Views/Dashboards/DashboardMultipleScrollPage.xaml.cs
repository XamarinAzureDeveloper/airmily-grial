using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace airmily
{
	public partial class DashboardMultipleScrollPage : ContentPage
	{
		public DashboardMultipleScrollPage ()
		{
			InitializeComponent ();

			this.BindingContext = new DashboardMultipleScrollPageViewModel();
		}

		private void DisableSelectionHandler(object sender, SelectedItemChangedEventArgs e)
		{
			//((ListView)sender).SelectedItem = null;
		}

		private void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			if (e.Item == null) return;
			// do something with e.SelectedItem
			((ListView)sender).SelectedItem = null;
		}
	}
}
