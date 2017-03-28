using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace airmily
{
	public partial class SocialHeaderStyleTemplate : ContentView
	{
		public SocialHeaderStyleTemplate ()
		{
			InitializeComponent ();
		}
	
		public static BindableProperty TextProperty =
			BindableProperty.Create (
				nameof( Text ), 
				typeof ( string ),
				typeof ( SocialHeaderStyleTemplate ),
				string.Empty,
				defaultBindingMode	: BindingMode.OneWay,
				propertyChanged	: ( bindable, oldValue, newValue ) => {
					var ctrl = ( SocialHeaderStyleTemplate )bindable;
					ctrl.Text = ( string )newValue;
				}
			);

		public string Text {
			get { return ( string )GetValue( TextProperty ); }
			set { 
				SetValue ( TextProperty, value );
				HeaderLabel.Text = value;
			}
		}

		/* ICON */

		public static BindableProperty IconTextProperty =
			BindableProperty.Create (
				nameof( IconText),
				typeof ( string ),
				typeof ( SocialHeaderStyleTemplate ),
				string.Empty,
				defaultBindingMode	: BindingMode.OneWay,
				propertyChanged	: ( bindable, oldValue, newValue ) => {
					var ctrl = ( SocialHeaderStyleTemplate )bindable;
					ctrl.IconText = ( string )newValue;
				}
			);

		public string IconText {
			get { return ( string )GetValue( IconTextProperty ); }
			set { 
				SetValue ( IconTextProperty, value );
				HeaderIcon.Text = (value);
			}
		}
	}
}

