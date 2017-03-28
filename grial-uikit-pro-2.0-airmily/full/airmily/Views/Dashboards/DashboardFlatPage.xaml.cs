using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace airmily
{
	public partial class DashboardFlatPage : ContentPage
	{
		public DashboardFlatPage()
		{			
			InitializeComponent();

			BindingContext = new DashboardViewModel ();
		}		

		public async Task NavigateToGrialSettingsPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new GrialDemoSettings());
		}
	}
}