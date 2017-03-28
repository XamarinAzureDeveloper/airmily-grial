using System;
using System.Collections.Generic;
namespace airmily
{
	public class RecentChatViewModel
	{	
		public List<ChatMessage> Messages {
			get;
			set;
		}
		
		public RecentChatViewModel(
			List<ChatMessage> messages
		)
		{
			Messages = messages;
		}
	}
}