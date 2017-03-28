using airmily.Views.Controls;
using Xamarin.Forms;

namespace airmily.Views
{
    public partial class CardsListPage : ContentPageShakeView
    {
        public CardsListPage()
        {
            InitializeComponent();
	        NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}