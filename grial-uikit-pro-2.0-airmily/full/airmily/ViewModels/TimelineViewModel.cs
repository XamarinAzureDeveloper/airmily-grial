using System;
using System.Collections.Generic;

namespace airmily
{
	public class TimelineViewModel
	{
		public TimelineViewModel()
		{
			TimelineList = new List<TimelineEvent>
			{
				new TimelineEvent {
					EventTitle = "Eric Douglas has a new photo",
					EventDescription = "Eric uploaded a more recently pic from him.",
					Image = "friend_thumbnail_27.jpg",
					When = "JUN 29, 2016"
				 },

				 new TimelineEvent {
					EventTitle = "Sam joined a new group",
					EventDescription = "Sam joined the Marketing and Affiliates group",
					Image = "friend_thumbnail_34.jpg",
					When = "JUN 28, 2016"
				 },

				 new TimelineEvent {
					EventTitle = "You have a new follower!",
					EventDescription = "Tony is now folowing you.",
					Image = "friend_thumbnail_55.jpg",
					When = "JUN 17, 2016"
				 },

				 new TimelineEvent {
					EventTitle = "You have a new follower!",
					EventDescription = "Ingrid Davies is now followig you.",
					Image = "friend_thumbnail_71.jpg",
					When = "JUN 17, 2016"
				 },

				 new TimelineEvent {
					EventTitle = "You have a new like!",
					EventDescription = "Emily liked your last post!",
					Image = "friend_thumbnail_75.jpg",
					When = "JUN 14, 2016"
				 },

				 new TimelineEvent {
					EventTitle = "Jaco joined a new group!",
					EventDescription = "Jaco Davies has joined the Internet of Things group. He is now the member number 100 of this group.",
					Image = "friend_thumbnail_93.jpg",
					When = "JUN 14, 2016"
				 },
				 
				 new TimelineEvent {
					EventTitle = "Jaco added a new comment to 'Internet of Things' group",
					EventDescription = "Hi guys, thanks for allow me be part of this great group. I would like to suggest...",
					Image = "friend_thumbnail_93.jpg",
					When = "JUN 14, 2016"
				 },
				 
				 new TimelineEvent {
					EventTitle = "Ingrid have a new like!",
					EventDescription = "Jaco liked your last post.",
					Image = "friend_thumbnail_71.jpg",
					When = "JUN 14, 2016"
				 },
				 
				 new TimelineEvent {
					EventTitle = "Eric Douglas joined a new group!",
					EventDescription = "Eric has joined the Jazz and Blues group. He is now the member number 207 of this group.",
					Image = "friend_thumbnail_27.jpg",
					When = "JUN 12, 2016"
				 },
				 
				 new TimelineEvent {
					EventTitle = "You have a new like!",
					EventDescription = "Emily liked your last post!",
					Image = "friend_thumbnail_75.jpg",
					When = "JUN 12, 2016"
				 },
				 
				 new TimelineEvent {
					EventTitle = "You have a new like!",
					EventDescription = "Sam liked your last post!",
					Image = "friend_thumbnail_34.jpg",
					When = "JUN 12, 2016"
				 },
				 
				 new TimelineEvent {
					EventTitle = "Sam joined a new group!",
					EventDescription = "Sam has joined the Avant Garde group. She is now the member number 99 of this group.",
					Image = "friend_thumbnail_27.jpg",
					When = "JUN 12, 2016"
				 },
				 
				 new TimelineEvent {
					EventTitle = "Sam joined a new group!",
					EventDescription = "Sam has joined the Bon Apetite! group. She is now the member number 487 of this group.",
					Image = "friend_thumbnail_27.jpg",
					When = "JUN 12, 2016"
				 },
				 
				 new TimelineEvent {
					EventTitle = "Ingrid have a new like!",
					EventDescription = "Jaco liked your last post.",
					Image = "friend_thumbnail_71.jpg",
					When = "JUN 11, 2016"
				 },
			};

		}

		public List<TimelineEvent> TimelineList { get; set; }
	}

	public class TimelineEvent
	{
		public string EventTitle { get; set; }
		public string EventDescription { get; set; }
		public string Image { get; set; }
		public string When { get; set; }
	}
}

