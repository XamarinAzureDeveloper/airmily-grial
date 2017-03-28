using System;
using System.Collections.Generic;
using System.Linq;

namespace airmily
{
	public class ArticleViewModel
	{
		public ArticleViewModel() : this(SampleData.Posts[0]) {
		}

		public ArticleViewModel(Post post){
			this.Post = post;
		}

		public Post Post { get; private set;}

		public List<Message> Comments {
			get{ 
				return SampleData.Comments;
			}
		}

	}
}