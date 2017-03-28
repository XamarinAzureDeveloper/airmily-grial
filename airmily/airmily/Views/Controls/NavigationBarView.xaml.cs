using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Xamarin.Forms;

namespace airmily.Views.Controls
{
	public partial class NavigationBarView : ContentView
	{
		public NavigationBarView()
		{
			InitializeComponent();
		}

		public string Title
		{
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}
		public static BindableProperty TitleProperty =
			BindableProperty.Create(nameof(Title), typeof(string), typeof(NavigationBarView), "Title");

		public bool IsBackButton
		{
			get { return (bool) GetValue(IsBackButtonProperty); }
			set { SetValue(IsBackButtonProperty, value); }
		}
		public static BindableProperty IsBackButtonProperty = 
			BindableProperty.Create(nameof(IsBackButton), typeof(bool), typeof(NavigationBarView), true);

		public DelegateCommand BackCmd
		{
			get { return (DelegateCommand) GetValue(BackCmdProperty); }
			set { SetValue(BackCmdProperty, value);}
		}
		public static BindableProperty BackCmdProperty =
			BindableProperty.Create(nameof(BackCmd), typeof(DelegateCommand), typeof(NavigationBarView), new DelegateCommand(() => { }));
		
		public string OtherText
		{
			get { return (string)GetValue(OtherTextProperty); }
			set { SetValue(OtherTextProperty, value); }
		}
		public static BindableProperty OtherTextProperty =
			BindableProperty.Create(nameof(OtherText), typeof(string), typeof(NavigationBarView), "Options");

		public DelegateCommand OtherCmd
		{
			get { return (DelegateCommand)GetValue(OtherCmdProperty); }
			set { SetValue(OtherCmdProperty, value); }
		}
		public static BindableProperty OtherCmdProperty =
			BindableProperty.Create(nameof(OtherCmd), typeof(DelegateCommand), typeof(NavigationBarView), new DelegateCommand(() => { }));



		protected override void OnPropertyChanged(string propertyName)
		{
			base.OnPropertyChanged(propertyName);

			if (propertyName == TitleProperty.PropertyName)
				TitleLabel.Text = Title;

			if (propertyName == IsBackButtonProperty.PropertyName)
				BackButton.IsVisible = BackButton.IsEnabled = IsBackButton;
			if (propertyName == BackCmdProperty.PropertyName)
				BackButton.Command = BackCmd;
			
			if (propertyName == OtherTextProperty.PropertyName)
				OtherButton.Text = OtherText;
			if (propertyName == OtherCmdProperty.PropertyName)
				OtherButton.Command = OtherCmd;
		}
	}
}
