using System;
using Xamarin.Forms;
namespace airmily

{
	public class DocumentTimelineSelector : DataTemplateSelector 
	{
		public DataTemplate DocumentTimelineLeftItemTemplate { get; set; }
		public DataTemplate DocumentTimelineRightItemTemplate { get; set; }

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			System.Diagnostics.Debug.WriteLine((item));
			System.Diagnostics.Debug.WriteLine((container));

			var documentItem = item as DocumentTimelineEvent;

			if (documentItem != null)
			{
				System.Diagnostics.Debug.WriteLine("chatMessage != null");
				if (documentItem.IsInbound)
				{
					System.Diagnostics.Debug.WriteLine("chatMessage == IsInbound");
					return DocumentTimelineRightItemTemplate;
				}
			}
			System.Diagnostics.Debug.WriteLine("DocumentTimelineRightItemTemplate != IsInbound");

			return DocumentTimelineLeftItemTemplate;
		}
	}
}
