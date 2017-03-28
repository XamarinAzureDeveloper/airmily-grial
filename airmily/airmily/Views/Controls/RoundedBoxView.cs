using Xamarin.Forms;

namespace airmily.Views.Controls
{
    public class RoundedBoxView : BoxView
    {
        public static readonly BindableProperty CornerRadiusProperty =
                BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(RoundedBoxView), 0);
            //May not work, trying to fix Warnings

        //BindableProperty.Create<RoundedBoxView, float>(p => p.CornerRadius, 0);

        public static readonly BindableProperty StrokeProperty =
                BindableProperty.Create(nameof(Stroke), typeof(Color), typeof(RoundedBoxView), Color.Red);
            //May not work, trying to fix Warnings

        //BindableProperty.Create<RoundedBoxView, Color>(p => p.Stroke, Color.Red);

        public static readonly BindableProperty StrokeThicknessProperty =
                BindableProperty.Create(nameof(StrokeThickness), typeof(int), typeof(RoundedBoxView), 0);
            //May not work, trying to fix Warnings

        //BindableProperty.Create<RoundedBoxView, int>(p => p.StrokeThickness, 0);

        public float CornerRadius
        {
            get { return (float) GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public Color Stroke
        {
            get { return (Color) GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        public int StrokeThickness
        {
            get { return (int) GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }
    }
}