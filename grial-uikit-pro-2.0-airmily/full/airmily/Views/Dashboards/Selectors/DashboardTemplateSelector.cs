using System;
using Xamarin.Forms;

namespace airmily
{
	public class DashboardTemplateSelector : DataTemplateSelector
	{
		public DataTemplate FirstTemplate { get; set; }

		public DataTemplate SecondTemplate { get; set; }


		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			var asTile = item as DashboardMultipleTileItem;

			if (asTile != null)
			{
				if (asTile.IsNotification )
				{
					return SecondTemplate;
				}
			}

			return FirstTemplate;
		}
	}
}

