using System;
using Xamarin.Forms;
namespace airmily
{
	public class ChatTemplateSelector : DataTemplateSelector
	{
		public DataTemplate IncomingDataTemplate { get; set; }
		public DataTemplate OutgoingDataTemplate { get; set; }
		
		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			
			System.Diagnostics.Debug.WriteLine((item));
			System.Diagnostics.Debug.WriteLine((container));

			var chatMessage = item as ChatMessage;

				if ( chatMessage != null ) {
					System.Diagnostics.Debug.WriteLine("chatMessage != null");
					if (chatMessage.IsInbound) { 
						System.Diagnostics.Debug.WriteLine("chatMessage == IsInbound");
						return OutgoingDataTemplate;
					}
				}
				System.Diagnostics.Debug.WriteLine("chatMessage != IsInbound");
			
			return IncomingDataTemplate;
		}
	}
}
