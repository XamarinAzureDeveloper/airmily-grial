using System.Collections.Generic;

namespace airmily
{
	public class PostsViewModel
	{
		public List<Post> PostsList 
		{ 
			get 
			{
				return SampleData.Posts;
			}
		}
	}
}

