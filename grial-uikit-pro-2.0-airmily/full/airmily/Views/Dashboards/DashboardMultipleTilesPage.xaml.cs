using Xamarin.Forms;

namespace airmily
{
	public partial class DashboardMultipleTilesPage : ContentPage
	{
		public DashboardMultipleTilesPage ()
		{			
			InitializeComponent();

			BindingContext = new DashboardMutipleTilesViewModel ();
		}
	}
}