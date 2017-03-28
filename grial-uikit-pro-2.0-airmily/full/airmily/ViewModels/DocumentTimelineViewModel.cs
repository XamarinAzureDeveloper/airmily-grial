using System;
using System.Collections.Generic;

namespace airmily
{
	public class DocumentTimelineViewModel
	{
		public DocumentTimelineViewModel()
		{
			DocumentTimelineList = new List<DocumentTimelineEvent>
			{
				new DocumentTimelineEvent
				{
					Title = "Document Added",
					Author = "Andrew Reynolds",
					Icon = GrialShapesFont.QueryBuilder,
					When = "Jul 7",
					IsInbound = true
				},

				 new DocumentTimelineEvent
				 {
					Title = "Document Edited",
					Author = "Tony Kamo",
					Icon = GrialShapesFont.InsertFile,
					When = "Jul 7",
					IsInbound = false
				 },

				 new DocumentTimelineEvent
				 {
					Title = "Document Edited",
					Author = "Elissa Steamer",
					Icon = GrialShapesFont.InsertFile,
					When = "Jul 8",
					IsInbound = true
				 },

				 new DocumentTimelineEvent
				 {
					Title = "I've added comments on policy section. Need to discuss about this first.",
					Author = "Gershon Mosley",
					Icon = GrialShapesFont.Forum,
					When = "Jul 9",
					IsInbound = false
				 },

				 new DocumentTimelineEvent
				 {
					Title = "Looks great!",
					Author = "Ingrid Davies",
					Icon = GrialShapesFont.Forum,
					When = "Jul 9",
					IsInbound = true
				 },

				new DocumentTimelineEvent
				 {
					Title = "Approved!",
					Author = "Patrick Rampsey",
					Icon = GrialShapesFont.Check,
					When = "Jul 9",
					IsInbound = false
				 },
				new DocumentTimelineEvent
				 {
					Title = "Document signed",
					Author = "Ingrid Davies",
					Icon = GrialShapesFont.Notifications,
					When = "Jul 11",
					IsInbound = true
				 },

				new DocumentTimelineEvent
				{
					Title = "Document Added",
					Author = "Chris Duff",
					Icon = GrialShapesFont.QueryBuilder,
					When = "Jul 7",
					IsInbound = true
				},

				 new DocumentTimelineEvent
				 {
					Title = "Document Edited",
					Author = "Tony Kamo",
					Icon = GrialShapesFont.InsertFile,
					When = "Aug 7",
					IsInbound = false
				 },

				new DocumentTimelineEvent
				{
					Title = "Document Added",
					Author = "Chris Duff",
					Icon = GrialShapesFont.QueryBuilder,
					When = "Jul 7",
					IsInbound = true
				},

				 new DocumentTimelineEvent
				 {
					Title = "Document Edited",
					Author = "Tony Kamo",
					Icon = GrialShapesFont.InsertFile,
					When = "Jul 7",
					IsInbound = false
				 },

			};
		}

		public List<DocumentTimelineEvent> DocumentTimelineList { get; set; }
	}

	public class DocumentTimelineEvent
	{
		public string Title { get; set; }
		public string Author { get; set; }
		public string Icon { get; set; }
		public string When { get; set; }
		public bool IsInbound
		{
			get;
			set;
		}
	}
}
