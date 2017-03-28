using System;
using System.Collections.Generic;
namespace airmily
{
	public class NotificationsViewModel
	{
		public List<Notification> Notifications
		{
			get
			{
				return SampleData.Notifications;
			}
		}
	}

}