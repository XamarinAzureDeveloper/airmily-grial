using System;
namespace airmily
{
	public class Movie
	{
		public string Title { get; set; }
		public string Source { get; set; }
		public string Seasons { get; set; }
		public double RatingValue { get; set; }
		public double RatingMax { get; set; }
		
		public string Director { get; set; }
		public string Plot { get; set; }
		
		public string Cast { get; set; }
		
		/*public Movie(
			string title,
			string source,
			
			string seasons = "2010-2014",
			uint ratingValue = 5,
			uint ratingMax = 10,
			string director = "DIRECTOR HERE",
			string plot = "PLOT HERE",
			string cast = "CAST HERE"
		)
		{
			Title = title;
			Source = source;
			Seasons = seasons;
			RatingValue = ratingValue;
			RatingMax = ratingMax;
			Director = director;
			Plot = plot;
			Cast = cast;
		}*/
		public Movie()
		{
		}
	}
}
