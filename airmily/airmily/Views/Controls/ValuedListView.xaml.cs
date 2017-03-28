using Xamarin.Forms;

namespace airmily.Views.Controls
{
    public partial class ValuedListView : ListView
    {
        public ValuedListView()
        {
            InitializeComponent();
            ItemSelected += (sender, e) => SelectedItem = null;
        }
    }
}