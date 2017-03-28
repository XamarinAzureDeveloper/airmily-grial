using System;
using Xamarin.Forms;

namespace airmily
{
	public class NotificationColorConverter : IValueConverter
	{
		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var notificationType = (NotificationType)value;

			switch (notificationType)
			{
				case NotificationType.Confirmation:
					return Application.Current.Resources["OkColor"];
					
				case NotificationType.Notification:
					return Application.Current.Resources["NotificationColor"];
					
				case NotificationType.Success:
					return Application.Current.Resources["OkColor"];

				case NotificationType.Warning:
					return Application.Current.Resources["WarningColor"];

				default: // Error
					return Application.Current.Resources["ErrorColor"];
			}
		}
		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException ();
		}
	}
}