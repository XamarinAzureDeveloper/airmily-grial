using System;

namespace airmily
{
	public class ChatMessage
	{
		public User From {
			get;
			set;
		}

		public string When {
			get;
			set;
		}

		public string Body {
			get;
			set;
		}
		
		public bool IsRead
		{
			get;
			set;
		}

		public bool IsInbound
		{
			get;
			set;
		}

		public ChatMessage (
			User from, 
			string when,
			string body,
			bool isRead = false,
			bool isInbound = false
			)
		{
			From 			= from;
			When 			= when;
			Body 			= body;
			IsRead 			= isRead;
			IsInbound		= isInbound;
		}
	}
}

