using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace airmily
{
	public partial class WalkthroughFlatStepItemTemplate : ContentPage
	{
		public static BindableProperty TextProperty =
			BindableProperty.Create(
				nameof(Text),
				typeof(string),
				typeof(WalkthroughFlatStepItemTemplate),
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (bindable, oldValue, newValue) =>
				{
					var ctrl = (WalkthroughFlatStepItemTemplate)bindable;
					ctrl.DescriptionLabel.Text = (string)newValue;
				}
			);

		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		/* HEADER */

		public static BindableProperty HeaderProperty =
			BindableProperty.Create(
				nameof(Header),
				typeof(string),
				typeof(WalkthroughFlatStepItemTemplate),
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (bindable, oldValue, newValue) =>
				{
					var ctrl = (WalkthroughFlatStepItemTemplate)bindable;
					ctrl.HeaderLabel.Text = (string)newValue;
				}
			);

		public string Header
		{
			get { return (string)GetValue(HeaderProperty); }
			set { SetValue(HeaderProperty, value); }
		}

		/* BUTTON */

		public static BindableProperty ButtonTextProperty =
			BindableProperty.Create(
				nameof(ButtonText),
				typeof(string),
				typeof(WalkthroughFlatStepItemTemplate),
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (bindable, oldValue, newValue) =>
				{
					var ctrl = (WalkthroughFlatStepItemTemplate)bindable;
					ctrl.PrimaryActionButton.Text = (string)newValue;
				}
			);

		public string ButtonText
		{
			get { return (string)GetValue(ButtonTextProperty); }
			set { SetValue(ButtonTextProperty, value); }
		}

		public static BindableProperty ButtonBackgroundColorProperty =
			BindableProperty.Create(
				nameof(ButtonBackgroundColor),
				typeof(string),
				typeof(WalkthroughFlatStepItemTemplate),
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (bindable, oldValue, newValue) =>
				{
					var ctrl = (WalkthroughFlatStepItemTemplate)bindable;
					ctrl.PrimaryActionButton.BackgroundColor = Color.FromHex((string)newValue);
				}
			);

		public string ButtonBackgroundColor
		{
			get { return (string)GetValue(ButtonBackgroundColorProperty); }
			set { SetValue(ButtonBackgroundColorProperty, value); }
		}

		/* ICON */

		public static BindableProperty IconColorProperty =
			BindableProperty.Create(
				nameof(IconColor),
				typeof(string),
				typeof(WalkthroughFlatStepItemTemplate),
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (bindable, oldValue, newValue) =>
				{
					var ctrl = (WalkthroughFlatStepItemTemplate)bindable;
					ctrl.IconLabel.TextColor = Color.FromHex((string)newValue);
				}
			);

		public string IconColor
		{
			get { return (string)GetValue(IconColorProperty); }
			set { SetValue(IconColorProperty, value); }
		}

		/* IMAGE */

		public static BindableProperty StepBackgroundImageProperty =
			BindableProperty.Create(
				nameof(StepBackgroundImage),
				typeof(string),
				typeof(WalkthroughFlatStepItemTemplate),
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (bindable, oldValue, newValue) =>
				{
					var ctrl = (WalkthroughFlatStepItemTemplate)bindable;
					ctrl.img.Source = (string)newValue;
				}
			);

		public string StepBackgroundImage
		{
			get { return (string)GetValue(StepBackgroundImageProperty); }
			set { SetValue(StepBackgroundImageProperty, value); }
		}

		public static BindableProperty IconTextProperty =
			BindableProperty.Create(
				nameof(IconText),
				typeof(string),
				typeof(WalkthroughFlatStepItemTemplate),
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (bindable, oldValue, newValue) =>
				{
					var ctrl = (WalkthroughFlatStepItemTemplate)bindable;
					ctrl.IconLabel.Text = (string)newValue;
				}
			);

		public string IconText
		{
			get { return (string)GetValue(IconTextProperty); }
			set { SetValue(IconTextProperty, value); }
		}

		public WalkthroughFlatStepItemTemplate()
		{
			InitializeComponent();

			ResetAnimation();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			ResetAnimation();
		}

		public async Task AnimateIn()
		{
			await Task.WhenAll(new[] {
				AnimateItem (IconLabel, 500),
				AnimateItem (HeaderLabel, 600),
				AnimateItem (DescriptionLabel, 700)
			});
		}

		private async Task AnimateItem(View uiElement, uint duration)
		{
			await Task.WhenAll(new Task[] {
				uiElement.ScaleTo(1.5, duration, Easing.CubicIn),
				uiElement.FadeTo(1, duration/2, Easing.CubicInOut).ContinueWith(
					_ =>
					{
                        // Queing on UI to workaround an issue with Forms 2.1
                        Device.BeginInvokeOnMainThread(() => {
							uiElement.ScaleTo(1, duration, Easing.CubicOut);
						});
					})
			});
		}

		void OnPrimaryActionButtonClicked(object sender, EventArgs args)
		{
			var parent = (WalkthroughFlatPage)Parent;
			parent.GoToStep();
		}

		void OnCloseButtonClicked(object sender, EventArgs args)
		{
			var parent = (WalkthroughFlatPage)Parent;
			parent.Close();
		}

		private void ResetAnimation()
		{
			IconLabel.Opacity = 0;
			HeaderLabel.Opacity = 0;
			DescriptionLabel.Opacity = 0;
		}
	}
}
