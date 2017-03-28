using airmily.Views.Controls;
using Xamarin.Forms;

namespace airmily.Views
{
    public partial class ViewImagesPage : ContentPageShakeView
    {
        public ViewImagesPage()
        {
            InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
		}
    }
}