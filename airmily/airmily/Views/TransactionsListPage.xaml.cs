using airmily.Views.Controls;
using Xamarin.Forms;

namespace airmily.Views
{
    public partial class TransactionsListPage : ContentPageShakeView
    {
        public TransactionsListPage()
        {
            InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
		}
    }
}