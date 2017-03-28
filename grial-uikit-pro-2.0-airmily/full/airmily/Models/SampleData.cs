using System.Collections.Generic;
using System.Linq;

namespace airmily
{
	public static class SampleData
	{
		private static string[] _names;
		private static List<string> _socialImageGalleryItems;
		private static List<string> _articlesImagesList;
		private static List<string> _usersImagesList;
		private static List<string> _dashboardImagesList;
		private static List<string> _productsImagesList;
		private static List<User> _users;
		private static List<Post> _posts;
		private static List<Message> _comments;
		private static List<User> _smallUserList;
		private static List<Post> _smallPostList;
		private static List<Message> _messages;
		private static List<ChatMessage> _chatMessagesList;
		private static List<ChatMessage> _recentChatMessagesList;
		private static List<Product> _products;
		private static List<MovieSection> _movies;


		private static List<Notification> _notifications;

		public static List<Notification> Notifications
		{
			get
			{
				if (_notifications == null)
				{
					_notifications = InitNotifications();
				}

				return _notifications;
			}
		}



		public static string[] Names {
			get
			{
				if (_names == null)
				{
					_names = InitNames();
				}

				return _names;
			}
		}

		public static List<string> SocialImageGalleryItems {
			get
			{
				if (_socialImageGalleryItems == null)
				{
					_socialImageGalleryItems = InitSocialImageGalleryItems();
				}

				return _socialImageGalleryItems;
			}
		}

		public static List<string> ArticlesImagesList {
			get
			{
				if (_articlesImagesList == null)
				{
					_articlesImagesList = InitArticlesImagesList();
				}

				return _articlesImagesList;
			}
		}

		public static List<string> UsersImagesList{
			get
			{
				if (_usersImagesList == null)
				{
					_usersImagesList = InitUsersImagesList();
				}

				return _usersImagesList;
			}
		}

		public static List<string> DashboardImagesList{
			get
			{
				if (_dashboardImagesList == null)
				{
					_dashboardImagesList = InitDashboardImagesList();
				}

				return _dashboardImagesList;
			}
		}

		public static List<string> ProductsImagesList {
			get
			{
				if (_productsImagesList == null)
				{
					_productsImagesList = InitProductsImagesList();
				}

				return _productsImagesList;
			}
		} 

		public static List<User> Users {
			get
			{
				if (_users == null)
				{
					_users = InitUsers();
				}

				return _users;
			}
		}

		public static List<User> Friends
		{
			get
			{
				return Users;
			}
		}

		public static List<Post> Posts
		{
			get
			{
				if (_posts == null)
				{
					_posts = InitPosts();
				}

				return _posts;
			}
		}

		public static List<Message> Messages
		{
			get
			{
				if (_messages == null)
				{
					_messages = InitMessages();
				}

				return _messages;
			}
		}

		public static List<Message> Comments
		{
			get
			{
				if (_comments == null)
				{
					_comments = Messages.GetRange((Messages.Count() / 2), (Messages.Count() / 2));
				}

				return _comments;
			}
		}	

		public static List<User> SmallUserList
		{
			get
			{
				if (_smallUserList == null)
				{
					_smallUserList = Users.GetRange(0, 2);
				}

				return _smallUserList;
			}
		}	

		public static List<Post> SmallPostList
		{
			get
			{
				if (_smallPostList == null)
				{
					_smallPostList = Posts.GetRange(0, 1);
				}

				return _smallPostList;
			}
		}	

		public static List<ChatMessage> ChatMessagesList
		{
			get
			{
				if (_chatMessagesList == null)
				{
					_chatMessagesList = InitChatMessagesList();
				}

				return _chatMessagesList;
			}
		}

		public static List<ChatMessage> RecentChatMessagesList
		{
			get
			{
				if (_recentChatMessagesList == null)
				{
					_recentChatMessagesList = InitRecentChatMessagesList();
				}

				return _recentChatMessagesList;
			}
		}

		public static List<Product> Products
		{
			get
			{
				if (_products == null)
				{
					_products = InitProducts();
				}

				return _products;
			}
		}

		public static List<MovieSection> Movies 
		{
			get
			{
				if (_movies == null)
				{
					_movies = InitMoviesSections();
				}

				return _movies;
			}
		}

		private static List<Notification> InitNotifications()
		{
			return new List<Notification> {

				new Notification {
					Title = "Confirmation",
					Type = NotificationType.Confirmation,
					Description = "Please confirm your email address"
				},

				new Notification {
					Title = "Error",
					Type = NotificationType.Error,
					Description = "Please confirm your email address"
				},

				new Notification {
					Title = "Warning",
					Type = NotificationType.Warning,
					Description = "Can't reach your current location"
				},

				new Notification {
					Title = "Warning",
					Type = NotificationType.Warning,
					Description = "Please contact support center"
				},

				new Notification {
					Title = "Notification",
					Type = NotificationType.Notification,
					Description = "You have new message"
				},

				new Notification {
					Title = "Success",
					Type = NotificationType.Success,
					Description = "You have a new follower"
				},

			};

		}


		private static string[] InitNames()
		{
			return new[]{
				"Pat Davies",
				"Janis Spector",
				"Regina Joplin",
				"Jaco Morrison",
				"Margaret Whites",
				"Skyler Harrisson",
				"Al Pastorius",
			};
		}

		private static List<string> InitSocialImageGalleryItems()
		{
			return new List<string>() {				
				"social_album_1.jpg",
				"social_album_2.jpg",
				"social_album_3.jpg",
				"social_album_4.jpg",
				"social_album_5.jpg",
				"social_album_6.jpg",
				"social_album_7.jpg",
				"social_album_8.jpg",
                "social_album_9.jpg",
            };
		}

		private static List<string> InitArticlesImagesList()
		{
			return new List<string>() {
				"article_image_0.jpg",
				"article_image_1.jpg",
				"article_image_2.jpg",
				"article_image_3.jpg",
				"article_image_4.jpg",
				"article_image_5.jpg"
			};
		}
		private static List<string> InitUsersImagesList()
		{
			return new List<string>() {
				"friend_thumbnail_27.jpg",
				"friend_thumbnail_31.jpg",
				"friend_thumbnail_34.jpg",
				"friend_thumbnail_55.jpg",
				"friend_thumbnail_71.jpg",
				"friend_thumbnail_75.jpg",
				"friend_thumbnail_93.jpg",
			};
		}

		private static List<string> InitDashboardImagesList()
		{
			return new List<string>() {
				"dashboard_thumbnail_0.jpg",
				"dashboard_thumbnail_1.jpg",
				"dashboard_thumbnail_2.jpg",
				"dashboard_thumbnail_3.jpg",
				"dashboard_thumbnail_4.jpg",
				"dashboard_thumbnail_5.jpg",
				"dashboard_thumbnail_6.jpg",
				"dashboard_thumbnail_7.jpg",
				"dashboard_thumbnail_8.jpg",
			};
		}
		private static List<string> InitProductsImagesList()
		{
			return new List<string>() {
				"product_item_0.jpg",
				"product_item_1.jpg",
				"product_item_2.jpg",
				"product_item_3.jpg",
				"product_item_4.jpg",
				"product_item_5.jpg",
				"product_item_6.jpg",
				"product_item_7.jpg",
			};
		}

		private static List<User> InitUsers()
		{
			return new List<User> {
				new User( Names[0], UsersImagesList[0] ),
				new User( Names[1], UsersImagesList[1] ),
				new User( Names[2], UsersImagesList[2] ),
				new User( Names[3], UsersImagesList[3] ),
				new User( Names[4], UsersImagesList[4] ),
				new User( Names[5], UsersImagesList[5] ),
				new User( Names[6], UsersImagesList[6] ),
			};
		}

		private static List<Post> InitPosts()
		{
			return new List<Post> {

				new Post {
					Title           = "United by faith",
					Subtitle        = "Friendship beyond everything",
					Body            = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent et aliquet nunc. \nSed ultricies sed augue sit amet maximus. In vel tellus sed ipsum volutpat venenatis et sit amet diam. Suspendisse feugiat mollis nibh, in facilisis diam convallis sit amet. \n\nMaecenas lectus turpis, rhoncus et est at, lacinia placerat urna. Praesent malesuada consectetur justo, scelerisque fermentum enim lobortis ullamcorper. Duis commodo sit amet ligula vitae luctus. Nulla commodo ipsum a lorem efficitur luctus.",
					Section         = "ACTUALITY",
					Author          = "UXDIVERS",
					Avatar          = SampleData.Friends[3].Avatar,
					BackgroundImage = SampleData.ArticlesImagesList[0],
					Quote           = "Donec euismod nulla et sem lobortis ultrices. Cras id imperdiet metus. Sed congue luctus arcu.",
					QuoteAuthor     = SampleData.Friends[3].Name,
					When            = "JAN 6, 2017",
					Likes           = "2.1k",
					Followers       = "112",
				},
				new Post {
					Title           = "Olympic dream",
					Subtitle        = "The way to the podium",
					Body            = "In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors. This is how we design a great article sample.",
					Section         = "SPORTS",
					Author          = SampleData.Friends[0].Name,
					Avatar          = SampleData.Friends[0].Avatar,
					BackgroundImage = SampleData.ArticlesImagesList[1],
					Quote           = "Donec euismod nulla et sem lobortis ultrices. Cras id imperdiet metus. Sed congue luctus arcu.",
					QuoteAuthor     = SampleData.Friends[0].Name,
					When            = "FEB 13, 2017",
					Likes           = "12K",
					Followers       = "340",

				},
				new Post {
					Title           = "Wheels of fortune",
					Subtitle		= "And the wind cries mary",
					Body            = "In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors. This is how we design a great article sample.",
					Section         = "FREE TIME",
					Author          = SampleData.Friends[2].Name,
					Avatar          = SampleData.Friends[2].Avatar,
					BackgroundImage = SampleData.ArticlesImagesList[2],
					Quote           = "Donec euismod nulla et sem lobortis ultrices. Cras id imperdiet metus. Sed congue luctus arcu.",
					QuoteAuthor     = SampleData.Friends[2].Name,
					When            = "FEB 21, 2017",
					Likes           = "798",
					Followers       = "120",

				},
				new Post {
					Title           = "Last adventure",
					Subtitle		= "The conquest of space",
					Body            = "In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors. This is how we design a great article sample.",
					Section         = "SCIENCE",
					Author          = "UXDIVERS",
					Avatar          = SampleData.Friends[1].Avatar,
					BackgroundImage = SampleData.ArticlesImagesList[3],
					Quote           = "Donec euismod nulla et sem lobortis ultrices. Cras id imperdiet metus. Sed congue luctus arcu.",
					QuoteAuthor     = SampleData.Friends[1].Name,
					When            = "MAR 9, 2017",
					Likes           = "921",
					Followers       = "327",

				},
				new Post {
					Title           = "Sweet leaf",
					Subtitle		= "The rainforest newest hope",
					Body            = "In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors. This is how we design a great article sample.",
					Section         = "NATURE",
					Author          = SampleData.Friends[4].Name,
					Avatar          = SampleData.Friends[4].Avatar,
					BackgroundImage = SampleData.ArticlesImagesList[4],
					Quote           = "Donec euismod nulla et sem lobortis ultrices. Cras id imperdiet metus. Sed congue luctus arcu.",
					QuoteAuthor     = SampleData.Friends[0].Name,
					When            = "JUN 17, 2015",
					Likes           = "92",
					Followers       = "2K",

				},

				new Post {
					Title           = "Smoke kills",
					Subtitle		= "The war against tabacco",
					Body            = "In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors. This is how we design a great article sample.",
					Section         = "HEALTH",
					Author          = SampleData.Friends[5].Name,
					Avatar          = SampleData.Friends[5].Avatar,
					BackgroundImage = SampleData.ArticlesImagesList[5],
					Quote           = "Donec euismod nulla et sem lobortis ultrices. Cras id imperdiet metus. Sed congue luctus arcu.",
					QuoteAuthor     = SampleData.Friends[5].Name,
					When            = "JUN 12, 2017",
					Likes           = "4.7K",
					Followers       = "235",

				},
			};
		}

		private static List<Message> InitMessages()
		{
			return new List<Message> {
				new Message(
					Friends[5],
					7,
					true,
					"July 7",
					"Hey check this out!",
					"In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors.",
					true,
					true
				),

				new Message(
					Friends[1],
					3,
					false,
					"Yesterday",
					"Artina is awesome...you'll love it",
					"In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors.",
					false,
					true
				),

				new Message(
					Friends[2],
					1,
					true,
					"July 7",
					"Artina is awesome...you'll love it",
					"In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors.",
					false,
					false
				),

				new Message(
					Friends[3],
					2,
					true,
					"July 7",
					"Artina is awesome...you'll love it",
					"In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors.",
					false,
					false
				),

				new Message(
					Friends[4],
					10,
					false,
					"3 minutes ago",
					"Artina is awesome...you'll love it",
					"In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors.",
					true,
					false
				),

				new Message(
					Friends[0],
					5,
					false,
					"July 7",
					"Artina is awesome...you'll love it",
					"In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors.",
					true,
					true
				),

				new Message(
					Friends[6],
					7,
					false,
					"July 7",
					"Artina is awesome...you'll love it",
					"In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors.",
					true,
					false
				),

			};
		}

		private static List<ChatMessage> InitChatMessagesList()
		{
			return new List<ChatMessage> {
				new ChatMessage (
					Friends [5],
					"July 7",
					"Hey buddy :), what's up? I'm currently working on this amazing stuff called Grial. Have you heard about it? You shoud give it a try....it really rocks!!!!!.",
					false,
					true
				),
				new ChatMessage (
					Friends [5],
					"July 7",
					"You should give it a try!",
					false,
					true
				),
				new ChatMessage (
					Friends [1],
					"July 7",
					"Wooow! Didn't know this exist!! Really cool stuff!"
				),

				new ChatMessage (
					Friends [1],
					"July 7",
					"I was wondering if something like this existed. This will save hundred of hours. I rather be skateboarding with my friends instead of compiling every little visual change." +
					"Thanks for sharing!"
				),

				new ChatMessage (
					Friends [5],
					"July 7",
					"No problem! I hope you can find it useful. It really makes the difference to me.",
					false,
					true
				),

				new ChatMessage (
					Friends [1],
					"July 7",
					"Ok thanks and thanks again!! This is really awesome"
				),

				new ChatMessage (
					Friends [5],
					"July 7",
					"Indeed.",
					false,
					true
				),

				new ChatMessage (
					Friends [1],
					"July 7",
					"C u later tonight at Gillian Japi party, right?"
				),

				new ChatMessage (
					Friends [5],
					"July 7",
					"For sure! See you later :)"
				),
			};
		}

		private static List<ChatMessage> InitRecentChatMessagesList()
		{
			return new List<ChatMessage> {
				new ChatMessage (
					Friends [5],
					"July 7",
					"Hey buddy :), what's up? I'm currently working on this amazing stuff called Grial. Have you heard about it? You shoud give it a try....it really rocks!!!!!.",
					true
				),
				new ChatMessage (
					Friends [5],
					"July 7",
					"You should give it a try!",
					true
				),
				new ChatMessage (
					Friends [1],
					"July 7",
					"Wooow! Didn't know this exist!! Really cool stuff!"
				),

				new ChatMessage (
					Friends [1],
					"July 7",
					"I was wondering if something like this existed. This will save hundred of hours. I rather be skateboarding with my friends instead of compiling every little visual change." +
					"Thanks for sharing!"
				),

				new ChatMessage (
					Friends [5],
					"July 7",
					"No problem! I hope you can find it useful. It really makes the difference to me.",
					true
				),

				new ChatMessage (
					Friends [1],
					"July 7",
					"Ok thanks and thanks again!! This is really awesome"
				),

				new ChatMessage (
					Friends [5],
					"July 7",
					"Indeed.",
					true
				),

				new ChatMessage (
					Friends [1],
					"July 7",
					"C u later tonight at Gillian Japi party, right?"
				),

				new ChatMessage (
					Friends [5],
					"July 7",
					"For sure! See you later :)",
					true
				),
			};
		}

		private static List<Product> InitProducts()
		{
			return new List<Product> {
				new Product {
					Name            = "Flannel Shirt",
					Description     = "Classic 90's Skateboarding style shirt. Feel like Pat Duffy or even flow like Edie from Pearl Jam. With that casual grunge style this is the shirt you need.",
					Image           = SampleData.ProductsImagesList[0],
					Price           = "$39.90",
					ThumbnailHeight = "100",
					RatingMax       = 5,
					RatingValue     = 4.5,
				},

				new Product {
					Name            = "Bomber Jacket",
					Description     = "Top gun in every gentelman closet. This leather jacket will make you feel like Tom Cruise without that crazy look. Be a good boy make mom proud.",
					Image           = SampleData.ProductsImagesList[1],
					Price           = "$89.90",
					ThumbnailHeight = "100",
					RatingMax       = 5,
					RatingValue     = 4.5,
				},

				new Product {
					Name            = "Classic Black",
					Description     = "Get that instant normal look that everybody wants. Blend with the humans, it will make you feel less strange. You know you are not normal",
					Image           = SampleData.ProductsImagesList[2],
					Price           = "$49.90",
					ThumbnailHeight = "100",
					RatingMax       = 5,
					RatingValue     = 4.5,
				},

				new Product {
					Name            = "Flowers Shirt",
					Description     = "Our newest swim tees with a much looser fit than traditional rash guard for yet more comfort and versatility, is well known for great fit, function and colors.",
					Image           = SampleData.ProductsImagesList[3],
					Price           = "$29.90",
					ThumbnailHeight = "100",
					RatingMax       = 5,
					RatingValue     = 4.5,
				},

				new Product {
					Name            = "Sccotish Shirt",
					Description     = "Not just another common shirt. Upgrade your sexappeal looking good. Rock and roll never gets old. Eric Burdon wears a shirt like this one when he wants to lood good. ",
					Image           = SampleData.ProductsImagesList[4],
					Price           = "$34.90",
					ThumbnailHeight = "100",
					RatingMax       = 5,
					RatingValue     = 4.5,
				},

				new Product {
					Name            = "Silk Shirt",
					Description     = "Let's face it, this shirt does not look good on anybody. But how many times do you buy something that you don't need? Buy this one feel happy for a minute then dismiss it. ",
					Image           = SampleData.ProductsImagesList[5],
					Price           = "$39.90",
					ThumbnailHeight = "100",
					RatingMax       = 5,
					RatingValue     = 4.5,
				},

				new Product {
					Name            = "Entrepreneur Shirt",
					Description     = "Do you have a meeting? Do you want to look good reliable and confident? This is the shirt that you need for those horrible meetings trying to find someone that lend you some money.",
					Image           = SampleData.ProductsImagesList[6],
					Price           = "$65.90",
					ThumbnailHeight = "100",
					RatingMax       = 5,
					RatingValue     = 4.5,
				},

				new Product {
					Name            = "Soldier Shirt",
					Description     = "Now is your time. Wanna be the alpha male of your local bar? Common! Get this shirt now and feel like a sexy Rambo on your next date. Remember that girls loves peacefull soliders.",
					Image           = SampleData.ProductsImagesList[7],
					Price           = "$46.90",
					ThumbnailHeight = "1000",
					RatingMax       = 5,
					RatingValue     = 4.5,
				}
			};
		}

		private static List<MovieSection> InitMoviesSections() 
		{
			var actorOfTheMonth = new MovieSection();
			actorOfTheMonth.Title = "Actor of the Month";
			actorOfTheMonth.Content = new List<Movie>
			{
				new Movie{
					Title = "Inception",
					Source = "http://ia.media-imdb.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2010",
					RatingValue = 4.4,
					RatingMax = 5,
					Director = "Christopher Nolan",
					Plot = "A thief, who steals corporate secrets through use of dream-sharing technology, is given the inverse task of planting an idea into the mind of a CEO.",
					Cast = "Leonardo DiCaprio, Joseph Gordon-Levitt, Ellen Page "
				},

				new Movie{
					Title = "Django Unchained",
					Source = "http://ia.media-imdb.com/images/M/MV5BMjIyNTQ5NjQ1OV5BMl5BanBnXkFtZTcwODg1MDU4OA@@._V1_UY190_CR0,0,128,190_AL_.jpg",
					
					Seasons = "2012",
					RatingValue = 4.25,
					RatingMax = 5,
					Director = "Quentin Tarantino",
					Plot = "With the help of a German bounty hunter, a freed slave sets out to rescue his wife from a brutal Mississippi plantation owner.",
					Cast = "Jamie Foxx, Christoph Waltz, Leonardo DiCaprio"
				},

				new Movie{
					Title = "The Revenant",
					Source = "http://ia.media-imdb.com/images/M/MV5BMjU4NDExNDM1NF5BMl5BanBnXkFtZTgwMDIyMTgxNzE@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2015",
					RatingValue = 4.05,
					RatingMax = 5,
					Director = "Alejandro G. Iñárritu",
					Plot = "A frontiersman on a fur trading expedition in the 1820s fights for survival after being mauled by a bear and left for dead by members of his own hunting team.",
					Cast = "Leonardo DiCaprio, Tom Hardy, Will Poulter"
				},

				new Movie{
					Title = "The Departed",
					Source = "http://ia.media-imdb.com/images/M/MV5BMTI1MTY2OTIxNV5BMl5BanBnXkFtZTYwNjQ4NjY3._V1_UX148_CR0,0,148,216_AL_.jpg",
					
					Seasons = "2006",
					RatingValue = 4.25,
					RatingMax = 5,
					Director = "Martin Scorsese",
					Plot = "An undercover cop and a mole in the police attempt to identify each other while infiltrating an Irish gang in South Boston.",
					Cast = "Leonardo DiCaprio, Matt Damon, Jack Nicholson"
				},

				new Movie{
					Title = "Titanic",
					Source = "http://ia.media-imdb.com/images/M/MV5BMzg1MDA0MTU2Nl5BMl5BanBnXkFtZTcwMTMzMjkxNw@@._V1_UX148_CR0,0,148,216_AL_.jpg",
					
					Seasons = "1997",
					RatingValue = 3.85,
					RatingMax = 5,
					Director = "James Cameron",
					Plot = "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.",
					Cast = "Leonardo DiCaprio, Kate Winslet, Billy Zane"
				},

				new Movie{
					Title = "The Audition",
					Source = "http://ia.media-imdb.com/images/M/MV5BODVlNGQ1ODUtYTMxNi00OTM3LTlmMzEtYjM2NzAwZTYwZTgzXkEyXkFqcGdeQXVyNjUwODIzOTI@._V1_UY268_CR4,0,182,268_AL_.jpg",
					
					Seasons = "2015",
					RatingValue = 3.7,
					RatingMax = 5,
					Director = "Martin Scorsese",
					Plot = "A short film promoting the opening of Melco-Crown's movie-themed resort and casino in Macau.",
					Cast = "Robert De Niro, Leonardo DiCaprio, Brad Pitt"
				},

				new Movie{
					Title = "Gatsby",
					Source = "http://ia.media-imdb.com/images/M/MV5BMTkxNTk1ODcxNl5BMl5BanBnXkFtZTcwMDI1OTMzOQ@@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2013",
					RatingValue = 3.65,
					RatingMax = 5,
					Director = "Baz Luhrmann",
					Plot = "A writer and wall street trader, Nick, finds himself drawn to the past and lifestyle of his millionaire neighbor, Jay Gatsby.",
					Cast = "Leonardo DiCaprio, Carey Mulligan, Joel Edgerton"
				},

				new Movie{
					Title = "Shutter Island",
					Source = "http://ia.media-imdb.com/images/M/MV5BMTMxMTIyNzMxMV5BMl5BanBnXkFtZTcwOTc4OTI3Mg@@._V1_UX128_CR0,0,128,190_AL_.jpg",
					
					Seasons = "2010",
					RatingValue = 4.05,
					RatingMax = 5,
					Director = "Martin Scorsese",
					Plot = "In 1954, a U.S. marshal investigates the disappearance of a murderess who escaped from a hospital for the criminally insane.",
					Cast = "Leonardo DiCaprio, Emily Mortimer, Mark Ruffalo"
				},

				new Movie{
					Title = "Blood Diamond",
					Source = "http://ia.media-imdb.com/images/M/MV5BMTY5MTYyNjkwNV5BMl5BanBnXkFtZTcwODE3MTI0MQ@@._V1_UY190_CR0,0,128,190_AL_.jpg",
					
					Seasons = "2006",
					RatingValue = 4,
					RatingMax = 5,
					Director = "Edward Zwick",
					Plot = "A fisherman, a smuggler, and a syndicate of businessmen match wits over the possession of a priceless diamond.",
					Cast = "Leonardo DiCaprio, Djimon Hounsou, Jennifer Connelly"
				},

				new Movie{
					Title = "Catch Me If You Can",
					Source = "http://ia.media-imdb.com/images/M/MV5BMTY5MzYzNjc5NV5BMl5BanBnXkFtZTYwNTUyNTc2._V1_UY190_CR0,0,128,190_AL_.jpg",
					
					Seasons = "2002",
					RatingValue = 4,
					RatingMax = 5,
					Director = "Steven Spielberg",
					Plot = "The true story of Frank Abagnale Jr. who, before his 19th birthday, successfully conned millions of dollars' worth of checks as a Pan Am pilot, doctor, and legal prosecutor.",
					Cast = "Leonardo DiCaprio, Tom Hanks, Christopher Walken"
				},
			};

			var lastBestPicture = new MovieSection();
			lastBestPicture.Title = "Latest Best Picture-Winning Titles";
			lastBestPicture.Content = new List<Movie>
			{
				new Movie{
					Title = "Spotlight",
					Source = "http://ia.media-imdb.com/images/M/MV5BMjIyOTM5OTIzNV5BMl5BanBnXkFtZTgwMDkzODE2NjE@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2015",
					RatingValue = 4.05,
					RatingMax = 5,
					Director = "Tom McCarthy",
					Plot = "The true story of how the Boston Globe uncovered the massive scandal of child molestation and cover-up within the local Catholic Archdiocese, shaking the entire Catholic Church to its core.",
					Cast = "Mark Ruffalo, Michael Keaton, Rachel McAdams"
				},

				new Movie{
					Title = "Birdman",
					Source = "http://ia.media-imdb.com/images/M/MV5BODAzNDMxMzAxOV5BMl5BanBnXkFtZTgwMDMxMjA4MjE@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2014",
					RatingValue = 3.9,
					RatingMax = 5,
					Director = "Alejandro G. Iñárritu",
					Plot = "Illustrated upon the progress of his latest Broadway play, a former popular actor's struggle to cope with his current life as a wasted actor is shown.",
					Cast = "Alejandro G. Iñárritu, Nicolás Giacobone"
				},

				new Movie{
					Title = "12 Years As A Slave",
					Source = "http://ia.media-imdb.com/images/M/MV5BMjExMTEzODkyN15BMl5BanBnXkFtZTcwNTU4NTc4OQ@@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2013",
					RatingValue = 4.05,
					RatingMax = 5,
					Director = "Steve McQueen",
					Plot = "In the antebellum United States, Solomon Northup, a free black man from upstate New York, is abducted and sold into slavery.",
					Cast = "Chiwetel Ejiofor, Michael Kenneth Williams, Michael Fassbender"
				},

				new Movie{
					Title = "Argo",
					Source = "http://ia.media-imdb.com/images/M/MV5BMTc3MjI0MjM0NF5BMl5BanBnXkFtZTcwMTYxMTQ1OA@@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2012",
					RatingValue = 3.85,
					RatingMax = 5,
					Director = "Ben Affleck",
					Plot = "Acting under the cover of a Hollywood producer scouting a location for a science fiction film, a CIA agent launches a dangerous operation to rescue six Americans in Tehran during the U.S. hostage crisis in Iran in 1980.",
					Cast = "Ben Affleck, Bryan Cranston, John Goodman"
				},

				new Movie{
					Title = "The Artist",
					Source = "http://ia.media-imdb.com/images/M/MV5BMzk0NzQxMTM0OV5BMl5BanBnXkFtZTcwMzU4MDYyNQ@@._V1_UY268_CR9,0,182,268_AL_.jpg",
					
					Seasons = "2010",
					RatingValue = 4,
					RatingMax = 5,
					Director = "Michel Hazanavicius",
					Plot = "A silent movie star meets a young dancer, but the arrival of talking pictures sends their careers in opposite directions.",
					Cast = "Jean Dujardin, Bérénice Bejo, John Goodman"
				},

				new Movie{
					Title = "The King's Speech",
					Source = "http://ia.media-imdb.com/images/M/MV5BMzU5MjEwMTg2Nl5BMl5BanBnXkFtZTcwNzM3MTYxNA@@._V1_UY268_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2010",
					RatingValue = 4,
					RatingMax = 5,
					Director = "DIRECTOR HERE",
					Plot = "PLOT HERE",
					Cast = "CAST HERE"
				},

				new Movie{
					Title = "The Hurt Locker",
					Source = "http://ia.media-imdb.com/images/M/MV5BNzEwNzQ1NjczM15BMl5BanBnXkFtZTcwNTk3MTE1Mg@@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2010-2014",
					RatingValue = 2.5,
					RatingMax = 5,
					Director = "Tom Hooper",
					Plot = "The story of King George VI of the United Kingdom of Great Britain and Northern Ireland, his impromptu ascension to the throne and the speech therapist who helped the unsure monarch become worthy of it.",
					Cast = "Colin Firth, Geoffrey Rush, Helena Bonham Carter"
				},

				new Movie{
					Title = "Slumdog Millionaire",
					Source = "http://ia.media-imdb.com/images/M/MV5BMTU2NTA5NzI0N15BMl5BanBnXkFtZTcwMjUxMjYxMg@@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2008",
					RatingValue = 4,
					RatingMax = 5,
					Director = "Danny Boyle, Loveleen Tandan",
					Plot = "A Mumbai teen reflects on his upbringing in the slums when he is accused of cheating on the Indian Version of \"Who Wants to be a Millionaire?\"",
					Cast = "Dev Patel, Freida Pinto, Saurabh Shukla"
				},

				new Movie{
					Title = "No Country For Old Men",
					Source = "http://ia.media-imdb.com/images/M/MV5BMjA5Njk3MjM4OV5BMl5BanBnXkFtZTcwMTc5MTE1MQ@@._V1_UY268_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2007",
					RatingValue = 1.05,
					RatingMax = 5,
					Director = "Ethan Coen, Joel Coen",
					Plot = "Violence and mayhem ensue after a hunter stumbles upon a drug deal gone wrong and more than two million dollars in cash near the Rio Grande.",
					Cast = "Tommy Lee Jones, Javier Bardem, Josh Brolin"
				},

				new Movie{
					Title = "The Departed",
					Source = "http://ia.media-imdb.com/images/M/MV5BMTI1MTY2OTIxNV5BMl5BanBnXkFtZTYwNjQ4NjY3._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2006",
					RatingValue = 4.25,
					RatingMax = 5,
					Director = "Martin Scorsese",
					Plot = "An undercover cop and a mole in the police attempt to identify each other while infiltrating an Irish gang in South Boston.",
					Cast = "Leonardo DiCaprio, Matt Damon, Jack Nicholson"
				},
			};

			var sciFiClassic = new MovieSection();
			sciFiClassic.Title = "Sci-Fi Classic Titles";
			sciFiClassic.Content = new List<Movie>
			{
				new Movie{
					Title = "Blade Runner",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BZWZlYmEyYTItNGRjYy00ZmMxLWEzMWItM2Q2NjZlNTMwMjQ3XkEyXkFqcGdeQXVyNDYyMDk5MTU@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "1982",
					RatingValue = 4.1,
					RatingMax = 5,
					Director = "Ridley Scott",
					Plot = "A blade runner must pursue and try to terminate four replicants who stole a ship in space and have returned to Earth to find their creator.",
					Cast = "Harrison Ford, Rutger Hauer, Sean Young"
				},

				new Movie{
					Title = "Back to the Future",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BZmU0M2Y1OGUtZjIxNi00ZjBkLTg1MjgtOWIyNThiZWIwYjRiXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "1985",
					RatingValue = 4.25,
					RatingMax = 5,
					Director = "Robert Zemeckis",
					Plot = "Marty McFly, a 17-year-old high school student, is accidentally sent 30 years into the past in a time-traveling DeLorean invented by his close friend, the maverick scientist Doc Brown.",
					Cast = "Michael J. Fox, Christopher Lloyd, Lea Thompson"
				},

				new Movie{
					Title = "Back to the Future Part II",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BZTMxMGM5MjItNDJhNy00MWI2LWJlZWMtOWFhMjI5ZTQwMWM3XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "1989",
					RatingValue = 3.9,
					RatingMax = 5,
					Director = "Robert Zemeckis",
					Plot = "After visiting 2015, Marty McFly must repeat his visit to 1955 to prevent disastrous changes to 1985...without interfering with his first trip.",
					Cast = "Michael J. Fox, Christopher Lloyd, Lea Thompson"
				},

				new Movie{
					Title = "Back to the Future Part III",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTk3ODgyMTgzNF5BMl5BanBnXkFtZTcwODE3MzYwMg@@._V1_UY268_CR7,0,182,268_AL_.jpg",
					
					Seasons = "1990",
					RatingValue = 3.7,
					RatingMax = 5,
					Director = "Robert Zemeckis",
					Plot = "Enjoying a peaceable existence in 1885, Doctor Emmet Brown is about to be killed by Buford \"Mad Dog\" Tannen. Marty McFly travels back in time to save his friend.",
					Cast = "Michael J. Fox, Christopher Lloyd, Mary Steenburgen"
				},

				new Movie{
					Title = "The Terminator",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BODE1MDczNTUxOV5BMl5BanBnXkFtZTcwMTA0NDQyNA@@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2010-2014",
					RatingValue = 4.5,
					RatingMax = 5,
					Director = "James Cameron",
					Plot = "A human-looking indestructible cyborg is sent from 2029 to 1984 to assassinate a waitress, whose unborn son will lead humanity in a war against the machines, while a soldier from that war is sent to protect her at all costs.",
					Cast = "Arnold Schwarzenegger, Linda Hamilton, Michael Biehn"
				},

				new Movie{
					Title = "Terminator 2: Judgment Day",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BZDM2YjYwYWMtMWZlNi00ZDQxLWExMDctMDAzNzQ0OTkzZjljXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "1984",
					RatingValue = 4.05,
					RatingMax = 5,
					Director = "James Cameron",
					Plot = "A human-looking indestructible cyborg is sent from 2029 to 1984 to assassinate a waitress, whose unborn son will lead humanity in a war against the machines, while a soldier from that war is sent to protect her at all costs.",
					Cast = "Arnold Schwarzenegger, Linda Hamilton, Michael Biehn"
				},

			};

			var sciFiMovies = new MovieSection();
			sciFiMovies.Title = "Sci-Fi Titles";
			sciFiMovies.Content = new List<Movie>
			{
				new Movie{
					Title = "Mad Max: Fury Road",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTUyMTE0ODcxNF5BMl5BanBnXkFtZTgwODE4NDQzNTE@._V1_UY268_CR1,0,182,268_AL_.jpg",
					
					Seasons = "2015",
					RatingValue = 4.05,
					RatingMax = 5,
					Director = "George Miller",
					Plot = "A woman rebels against a tyrannical ruler in postapocalyptic Australia in search for her home-land with the help of a group of female prisoners, a psychotic worshipper, and a drifter named Max.",
					Cast = "Tom Hardy, Charlize Theron, Nicholas Hoult"
					},

				new Movie{
					Title = "The Martian",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTc2MTQ3MDA1Nl5BMl5BanBnXkFtZTgwODA3OTI4NjE@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2015",
					RatingValue = 4,
					RatingMax = 5,
					Director = "Ridley Scott",
					Plot = "An astronaut becomes stranded on Mars after his team assume him dead, and must rely on his ingenuity to find a way to signal to Earth that he is alive.",
					Cast = "Matt Damon, Jessica Chastain, Kristen Wiig"
					},

				new Movie{
					Title = "Limitless",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BYmViZGM0MGItZTdiYi00ZDU4LWIxNDYtNTc1NWQ5Njc2N2YwXkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_UY268_CR2,0,182,268_AL_.jpg",
					
					Seasons = "2011",
					RatingValue = 3.7,
					RatingMax = 5,
					Director = "Neil Burger",
					Plot = "With the help of a mysterious pill that enables the user to access 100 percent of his brain abilities, a struggling writer becomes a financial wizard, but it also puts him in a new world with lots of dangers.",
					Cast = "Bradley Cooper, Anna Friel, Abbie Cornish"
					},

				new Movie{
					Title = "TRON: Legacy",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTk4NTk4MTk1OF5BMl5BanBnXkFtZTcwNTE2MDIwNA@@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2010",
					RatingValue = 3.4,
					RatingMax = 5,
					Director = "Joseph Kosinski",
					Plot = "The son of a virtual world designer goes looking for his father and ends up inside the digital world that his father designed. He meets his father's corrupted creation and a unique ally who was born inside the digital world.",
					Cast = "Jeff Bridges, Garrett Hedlund, Olivia Wilde"
					},

				new Movie{
					Title = "Gravity",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BNjE5MzYwMzYxMF5BMl5BanBnXkFtZTcwOTk4MTk0OQ@@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2013",
					RatingValue = 3.9,
					RatingMax = 5,
					Director = "Alfonso Cuarón",
					Plot = "A medical engineer and an astronaut work together to survive after an accident leaves them adrift in space.",
					Cast = "Sandra Bullock, George Clooney, Ed Harris"
				},

				new Movie{
					Title = "Oblivion",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTQwMDY0MTA4MF5BMl5BanBnXkFtZTcwNzI3MDgxOQ@@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2013",
					RatingValue = 3.5,
					RatingMax = 5,
					Director = "Joseph Kosinski",
					Plot = "A veteran assigned to extract Earth's remaining resources begins to question what he knows about his mission and himself.",
					Cast = "Tom Cruise, Morgan Freeman, Andrea Riseborough"
				},

				new Movie{
					Title = "Ghost In The Shell",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BM2NmZjQ4MjUtZGQ1YS00NjY0LTgzMDQtZjM4ZjJmMjNmZGY3XkEyXkFqcGdeQXVyNjA2MDM5MjU@._V1_UY268_CR120,0,182,268_AL_.jpg",
					
					Seasons = "2017",
					RatingValue = 3.5,
					RatingMax = 5,
					Director = "Rupert Sanders",
					Plot = "A cyborg policewoman attempts to bring down a nefarious computer hacker.",
					Cast = "Jonathan Herman, Jamie Moss"
				},

				new Movie{
					Title = "Elysium",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BNDc2NjU0MTcwNV5BMl5BanBnXkFtZTcwMjg4MDg2OQ@@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2013",
					RatingValue = 3.3,
					RatingMax = 5,
					Director = "Neill Blomkamp",
					Plot = "In the year 2154, the very wealthy live on a man-made space station while the rest of the population resides on a ruined Earth. A man takes on a mission that could bring equality to the polarized worlds.",
					Cast = "Matt Damon, Jodie Foster, Sharlto Copley"
				},

				new Movie{
					Title = "Terminator Genisys",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BMjM1NTc0NzE4OF5BMl5BanBnXkFtZTgwNDkyNjQ1NTE@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2015",
					RatingValue = 3.3,
					RatingMax = 5,
					Director = "Alan Taylor",
					Plot = "When John Connor, leader of the human resistance, sends Sgt. Kyle Reese back to 1984 to protect Sarah Connor and safeguard the future, an unexpected turn of events creates a fractured timeline.",
					Cast = "Arnold Schwarzenegger, Jason Clarke, Emilia Clarke"
				},

				new Movie{
					Title = "Looper",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTY3NTY0MjEwNV5BMl5BanBnXkFtZTcwNTE3NDA1OA@@._V1_UY268_CR12,0,182,268_AL_.jpg",
					
					Seasons = "2012",
					RatingValue = 3.7,
					RatingMax = 5,
					Director = "Rian Johnson",
					Plot = "In 2074, when the mob wants to get rid of someone, the target is sent into the past, where a hired gun awaits - someone like Joe - who one day learns the mob wants to 'close the loop' by sending back Joe's future self for assassination.",
					Cast = "Joseph Gordon-Levitt, Bruce Willis, Emily Blunt"
				},

			};

			var marvelUniverse = new MovieSection();
			marvelUniverse.Title = "Marvel Universe Titles";
			marvelUniverse.Content = new List<Movie>
			{
				new Movie{
					Title = "X-Men Origins: Wolverine",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BZWRhMzdhMzEtZTViNy00YWYyLTgxZmUtMTMwMWM0NTEyMjk3XkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2009",
					RatingValue = 3.35,
					RatingMax = 5,
					Director = "Gavin Hood",
					Plot = "A look at Wolverine's early life, in particular his time with the government squad Team X and the impact it will have on his later years.",
					Cast = "Hugh Jackman, Liev Schreiber, Ryan Reynolds"
				},

				new Movie{
					Title = "Iron Man",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2008",
					RatingValue = 3.95,
					RatingMax = 5,
					Director = "Jon Favreau",
					Plot = "After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil.",
					Cast = "Robert Downey Jr., Gwyneth Paltrow, Terrence Howard"
				},

				new Movie{
					Title = "Iron Man 2",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTM0MDgwNjMyMl5BMl5BanBnXkFtZTcwNTg3NzAzMw@@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2010",
					RatingValue = 3.5,
					RatingMax = 5,
					Director = "Jon Favreau",
					Plot = "With the world now aware of his identity as Iron Man, Tony Stark must contend with both his declining health and a vengeful mad man with ties to his father's legacy.",
					Cast = "Robert Downey Jr., Mickey Rourke, Gwyneth Paltrow"
				},

				new Movie{
					Title = "Iron Man 3",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTkzMjEzMjY1M15BMl5BanBnXkFtZTcwNTMxOTYyOQ@@._V1_UY268_CR3,0,182,268_AL_.jpg",
					
					Seasons = "2013",
					RatingValue = 3.6,
					RatingMax = 5,
					Director = "Shane Black",
					Plot = "When Tony Stark's world is torn apart by a formidable terrorist called the Mandarin, he starts an odyssey of rebuilding and retribution.",
					Cast = "Robert Downey Jr., Guy Pearce, Gwyneth Paltrow"
				},

				new Movie{
					Title = "Fantastic 4",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTk0OTMyMDA0OF5BMl5BanBnXkFtZTgwMzY5NTkzNTE@._V1_UX182_CR0,0,182,268_AL_.jpg",
					
					Seasons = "2015",
					RatingValue = 2.15,
					RatingMax = 5,
					Director = "Josh Trank",
					Plot = "Four young outsiders teleport to an alternate and dangerous universe which alters their physical form in shocking ways. The four must learn to harness their new abilities and work together to save Earth from a former friend turned enemy.",
					Cast = "Miles Teller, Kate Mara, Michael B. Jordan"
				},

				new Movie{
					Title = "Hulk",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTQxNzUxNTE4Nl5BMl5BanBnXkFtZTYwMjcyNTk5._V1_UY268_CR4,0,182,268_AL_.jpg",
					
					Seasons = "2003",
					RatingValue = 2.85,
					RatingMax = 5,
					Director = "Ang Lee",
					Plot = "Bruce Banner, a genetics researcher with a tragic past, suffers an accident that causes him to transform into a raging green monster when he gets angry.",
					Cast = "Eric Bana, Jennifer Connelly, Sam Elliott"
				},

				new Movie{
					Title = "The Incredible Hulk",
					Source = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTUyNzk3MjA1OF5BMl5BanBnXkFtZTcwMTE1Njg2MQ@@._V1_UY190_CR0,0,128,190_AL_.jpg",
					
					Seasons = "2008",
					RatingValue = 3.4,
					RatingMax = 5,
					Director = "Louis Leterrier",
					Plot = "Bruce Banner, a scientist on the run from the U.S. Government, must find a cure for the monster he emerges whenever he loses his temper. However, Banner then must fight a soldier who unleashes himself as a threat stronger than he.",
					Cast = "Edward Norton, Liv Tyler, Tim Roth"
				},
			};


			return new List<MovieSection> { actorOfTheMonth, lastBestPicture, sciFiClassic, sciFiMovies, marvelUniverse };
		}
	}


}