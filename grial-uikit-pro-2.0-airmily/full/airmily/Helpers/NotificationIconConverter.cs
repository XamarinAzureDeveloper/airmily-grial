using System;
using Xamarin.Forms;

namespace airmily
{
	public class NotificationIconConverter : IValueConverter
	{
		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var notificationType = (NotificationType)value;

			switch (notificationType)
			{
				case NotificationType.Confirmation:
					return GrialShapesFont.Check;
					
				case NotificationType.Notification:
					return GrialShapesFont.Notifications;
					
				case NotificationType.Success:
					return GrialShapesFont.Check;
					
				case NotificationType.Warning:
					return GrialShapesFont.Warning;
					
				default: // Error
					return GrialShapesFont.Close; 
			}
		}
		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException ();
		}
	}
}