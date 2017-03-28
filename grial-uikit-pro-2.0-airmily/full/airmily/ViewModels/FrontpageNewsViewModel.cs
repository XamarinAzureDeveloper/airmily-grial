using System; using System.Collections.Generic;  namespace airmily { 	public class FrontPageNewsViewModel 	{ 		public FrontPageNewsViewModel() 		{ 			NewsList = new List<News> 			{ 				new News { 					Title           = "United by faith", 					Subtitle        = "Friendship beyond everything", 					Body            = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent et aliquet nunc. Sed ultricies sed augue sit amet maximus. In vel tellus sed ipsum volutpat venenatis et sit amet diam. Suspendisse feugiat mollis nibh, in facilisis diam convallis sit amet. Maecenas lectus turpis, rhoncus et est at, lacinia placerat urna. Praesent malesuada consectetur justo, scelerisque fermentum enim lobortis ullamcorper. Duis commodo sit amet ligula vitae luctus. Nulla commodo ipsum a lorem efficitur luctus.", 					Section         = "ACTUALITY", 					Author          = "UXDIVERS", 					Avatar          = SampleData.Friends[3].Avatar, 					BackgroundImage = SampleData.ArticlesImagesList[0], 					Quote           = "Donec euismod nulla et sem lobortis ultrices. Cras id imperdiet metus. Sed congue luctus arcu.", 					QuoteAuthor     = SampleData.Friends[3].Name, 					When            = "JAN 5, 2017", 					Likes           = "102", 					Followers       = "2.1K", 				} , 				new News { 					Title           = "Olympic dream", 					Subtitle        = "The path to podium", 					Body            = "In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors. This is how we design a great article sample.", 					Section         = "SPORTS", 					Author          = SampleData.Friends[0].Name, 					Avatar          = SampleData.Friends[0].Avatar, 					BackgroundImage = SampleData.ArticlesImagesList[1], 					Quote           = "Donec euismod nulla et sem lobortis ultrices. Cras id imperdiet metus. Sed congue luctus arcu.", 					QuoteAuthor     = SampleData.Friends[0].Name, 					When            = "FEB 16, 2017", 					Likes           = "224", 					Followers       = "2.2K",  				} , 				new News { 					Title           = "Weels of fortune", 					Subtitle        = "And the wind cries mary", 					Body            = "In connection with this is of great leap of yer happiness leadership colors. This is how we design a great article sample.", 					Section         = "FREE TIME", 					Author          = SampleData.Friends[2].Name, 					Avatar          = SampleData.Friends[2].Avatar, 					BackgroundImage = SampleData.ArticlesImagesList[2], 					Quote           = "Donec euismod nulla et sem lobortis ultrices. Cras id imperdiet metus. Sed congue luctus arcu.", 					QuoteAuthor     = SampleData.Friends[2].Name, 					When            = "MAY 22, 2017", 					Likes           = "69", 					Followers       = "1.7K",  				} , 				new News { 					Title           = "Last adventure", 					Subtitle        = "The conquest of space", 					Body            = "In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors. This is how we design a great article sample.", 					Section         = "SCIENCE", 					Author          = "UXDIVERS", 					Avatar          = SampleData.Friends[1].Avatar, 					BackgroundImage = SampleData.ArticlesImagesList[3], 					Quote           = "Donec euismod nulla et sem lobortis ultrices. Cras id imperdiet metus. Sed congue luctus arcu.", 					QuoteAuthor     = SampleData.Friends[1].Name, 					When            = "JUN 14, 2017", 					Likes           = "91", 					Followers       = "2K",  				} , 				new News { 					Title           = "Sweet leaf", 					Subtitle        = "The rainforest newest hope", 					Body            = "In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors. This is how we design a great article sample.", 					Section         = "NATURE", 					Author          = SampleData.Friends[4].Name, 					Avatar          = SampleData.Friends[4].Avatar, 					BackgroundImage = SampleData.ArticlesImagesList[4], 					Quote           = "Donec euismod nulla et sem lobortis ultrices. Cras id imperdiet metus. Sed congue luctus arcu.", 					QuoteAuthor     = SampleData.Friends[0].Name, 					When            = "JUL 12, 2017", 					Likes           = "42", 					Followers       = "1K",  				} ,  				new News { 					Title           = "Smoke kills", 					Subtitle        = "The war against tabacco", 					Body            = "In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors. This is how we design a great article sample.", 					Section         = "HEALTH", 					Author          = SampleData.Friends[5].Name, 					Avatar          = SampleData.Friends[5].Avatar, 					BackgroundImage = SampleData.ArticlesImagesList[5], 					Quote           = "Donec euismod nulla et sem lobortis ultrices. Cras id imperdiet metus. Sed congue luctus arcu.", 					QuoteAuthor     = SampleData.Friends[5].Name, 					When            = "JUN 15, 2015", 					Likes           = "92", 					Followers       = "2K",  				} , 			};  			MainNews = new MainNews 			{ 				Title = "Sweet leaf", 				Subtitle ="The rainforest newest hope", 				Body = "Whether you are starting with Xamarin or if you are more experienced, Grial will boost your development time by giving all you need to start with the right foot. Forget about endless hours browsing for an specific solution in Xamarin Forms, we’ve done that for you. In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors. This is how we design a great article sample.", 				BackgroundImage = SampleData.ArticlesImagesList[4] 			};  		}

		public List<News> NewsList { get; set; }

		public MainNews MainNews { get; set; }
	}

	public class News
	{
		public string Title {
			get;
			set;
		}  		public string Subtitle
		{ 			get; 			set; 		}

		public string Body {
			get;
			set;
		}

		public string Section {
			get;
			set;
		}

		public string Author {
			get;
			set;
		}

		public string Avatar {
			get;
			set;
		}

		public string BackgroundImage { 
			get; 
			set; 
		}

		public string Quote { 
			get; 
			set; 
		}

		public string QuoteAuthor { 
			get; 
			set; 
		}

		public string When {
			get;
			set;
		}

		public string Followers {
			get;
			set;
		}

		public string Likes {
			get;
			set;
		}
	}
	
	public class MainNews
	{
		public string Title {
			get;
			set;
		}
 		public string Subtitle 		{ 			get; 			set; 		}  
		public string Body {
			get;
			set;
		}
		
		public string BackgroundImage {
			get;
			set;
		}
	}
	
}
