	using System;
	using System.Collections.Generic;

namespace airmily
{
	public class DashboardCardsViewModel
	{
		public DashboardCardsViewModel()
		{

			DashboardCardsList = new List<DashboardCardItem>
			{ 
				
				new DashboardCardItem
				{
					Title = "Top fishing secrets revealed",
					Body = "In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors. This is how we design a great article sample.",
					Section = "NATURE",
					Author = "Margaret Whites",
					BackgroundImage = SampleData.DashboardImagesList[3],
					Avatar = SampleData.UsersImagesList[3],
					BackgroundColor = "#d81b60"
				},

				new DashboardCardItem
				{
					Title = "Chasing mavericks",
					Body = "In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors. This is how we design a great article sample.",
					Section = "SPORTS",
					Author = "Skyler Harrisson",
					BackgroundImage = SampleData.DashboardImagesList[4],
					Avatar = SampleData.UsersImagesList[4],
					BackgroundColor = "#c2185b"
				},

				new DashboardCardItem
				{
					Title = "Another one bites the dust",
					Body = "In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors. This is how we design a great article sample.",
					Section = "HEALTH",
					Author = "Irma Leites",
					BackgroundImage = SampleData.DashboardImagesList[5],
					Avatar = SampleData.UsersImagesList[5],
					BackgroundColor = "#56329A"
				},

				new DashboardCardItem
				{
					Title = "United by faith ",
					Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent et aliquet nunc. \nSed ultricies sed augue sit amet maximus. In vel tellus sed ipsum volutpat venenatis et sit amet diam. Suspendisse feugiat mollis nibh, in facilisis diam convallis sit amet. \n\nMaecenas lectus turpis, rhoncus et est at, lacinia placerat urna. Praesent malesuada consectetur justo, scelerisque fermentum enim lobortis ullamcorper. Duis commodo sit amet ligula vitae luctus. Nulla commodo ipsum a lorem efficitur luctus.",
					Section = "ACTUALITY",
					Author = "UXDIVERS",
					BackgroundImage = SampleData.DashboardImagesList[0],
					Avatar = SampleData.UsersImagesList[0],
					BackgroundColor = "#4B436E"
				},

				new DashboardCardItem
				{
					Title = "The road to you",
					Body = "In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors. This is how we design a great article sample.",
					Section = "DISCIPLINE",
					Author = "Pat Davies",
					BackgroundImage = SampleData.DashboardImagesList[1],
					Avatar = SampleData.UsersImagesList[1],
					BackgroundColor = "#1e88e5"
				},

				new DashboardCardItem
				{
					Title = "Nature and its influence on design",
					Body = "In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors. This is how we design a great article sample.",
					Section = "FREE TIME",
					Author = "Regina Joplin",
					BackgroundImage = SampleData.DashboardImagesList[2],
					Avatar = SampleData.UsersImagesList[2],
					BackgroundColor = "#1565c0"
				},


				new DashboardCardItem
				{
					Title = "Another one bites the dust",
					Body = "In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors. This is how we design a great article sample.",
					Section = "SELF-ESTEEM",
					Author = "Dimitar Taradasov",
					BackgroundImage = SampleData.DashboardImagesList[6],
					Avatar = SampleData.UsersImagesList[6],
					BackgroundColor = "#0097a7"
				},

				new DashboardCardItem
				{
					Title = "A retrospective on Jazz evolution",
					Body = "In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors. This is how we design a great article sample.",
					Section = "CULTURE",
					Author = "Thelonious Davies",
					BackgroundImage = SampleData.DashboardImagesList[7],
					Avatar = SampleData.UsersImagesList[0],
					BackgroundColor = "#00838f"
				},

				new DashboardCardItem
				{
					Title = "Blowing in the wind",
					Body = "In connection with this appellative of 'Whalebone whales,' it is of great leap of yer happiness leadership colors. This is how we design a great article sample.",
					Section = "MUSIC",
					Author = "Cire Notpalc",
					BackgroundImage = SampleData.DashboardImagesList[8],
					Avatar = SampleData.UsersImagesList[1],
					BackgroundColor = "#2e7d32"
				}
			};
		}

		public List<DashboardCardItem> DashboardCardsList { get; set; }
	}
}

public class DashboardCardItem
{
	public string Title { get; set; }
	public string Body { get; set; }
	public string Section { get; set; }
	public string Author { get; set; }
	public string Avatar { get; set; }
	public string BackgroundImage { get; set; }
	public string BackgroundColor { get; set; }
}
