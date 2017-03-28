using System;
using System.Threading.Tasks;
using airmily.Ext;
using Xamarin.Forms;

namespace airmily.Views
{
    public partial class ExampleDashboardItemContentView : ContentView, INavigationServiceExt, IEventAggregatorExt
    {
        public static BindableProperty ShowBackgroundImageProperty =
            BindableProperty.Create("ShowBackgroundImage", typeof(bool),
                typeof(ExampleDashboardItemContentView),
                true,
                BindingMode.OneWay
            );

        public static BindableProperty ShowBackgroundColorProperty =
            BindableProperty.Create("ShowBackgroundColor", typeof(bool),
                typeof(ExampleDashboardItemContentView),
                false,
                BindingMode.OneWay
            );

        public static BindableProperty ShowiconColoredCircleBackgroundProperty =
            BindableProperty.Create("ShowiconColoredCircleBackground", typeof(bool),
                typeof(ExampleDashboardItemContentView),
                true,
                BindingMode.OneWay
            );

        public static BindableProperty TextColorProperty =
            BindableProperty.Create("TextColor", typeof(Color),
                typeof(ExampleDashboardItemContentView),
                Color.White,
                BindingMode.OneWay
            );

        public uint _animationDuration = 250;
        public bool _processingTag;

        public ExampleDashboardItemContentView()
        {
            InitializeComponent();
        }

        public bool ShowBackgroundImage
        {
            get { return (bool) GetValue(ShowBackgroundImageProperty); }
            set { SetValue(ShowBackgroundImageProperty, value); }
        }

        public bool ShowBackgroundColor
        {
            get { return (bool) GetValue(ShowBackgroundColorProperty); }
            set { SetValue(ShowBackgroundColorProperty, value); }
        }

        public bool ShowiconColoredCircleBackground
        {
            get { return (bool) GetValue(ShowiconColoredCircleBackgroundProperty); }
            set { SetValue(ShowiconColoredCircleBackgroundProperty, value); }
        }

        public Color TextColor
        {
            get { return (Color) GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        private async Task AnimateItem(View uiElement, uint duration)
        {
            var originalOpacity = uiElement.Opacity;

            await uiElement.FadeTo(.5, duration / 2, Easing.CubicIn);
            await uiElement.FadeTo(originalOpacity, duration / 2, Easing.CubicIn);
        }

        private async void OnItemTapped(object sender, EventArgs e)
        {
            if (_processingTag)
                return;

            _processingTag = true;

            try
            {
                await AnimateItem(this, _animationDuration);

                OnNavigating(e);
            }
            finally
            {
                _processingTag = false;
            }
        }

        public event EventHandler Navigating;

        private void OnNavigating(EventArgs e)
        {
            if (Navigating != null)
                Navigating(this, e);
        }
    }
}