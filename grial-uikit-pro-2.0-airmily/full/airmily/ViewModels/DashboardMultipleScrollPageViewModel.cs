using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace airmily
{
	public class DashboardMultipleScrollPageViewModel
	{
		public DashboardMultipleScrollPageViewModel()
		{
			HighlightMovieTitle = "The Wolf of Wall Street (2013)";
			HighlightMovieDescription = "Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.)";
			HighlightMovieImage = "http://ia.media-imdb.com/images/M/MV5BYWRhMjlmNGUtYTIwYS00OTYyLThjYmMtMTU2MWU3MmRhNGNkXkEyXkFqcGdeQXVyNjUwNzk3NDc@._V1_SY1000_SX1500_AL_.jpg";

			var movieSections = new List<MovieSectionViewModel>();

			foreach (var movieSection in SampleData.Movies)
			{
				movieSections.Add(new MovieSectionViewModel(movieSection));
			}

			Sections = movieSections;
		}

		public string HighlightMovieTitle { get; private set; }

		public string HighlightMovieDescription { get; private set; }

		public string HighlightMovieImage { get; private set; }

		public List<MovieSectionViewModel> Sections { get; private set; }
	}

	public class MovieSectionViewModel : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;
		private double _scroll;

		public MovieSectionViewModel(MovieSection section, bool related = false)
		{
			this.Title = related ? $"More from {section.Title}" : section.Title;

			var content = new List<MovieViewModel>();

			foreach (var m in section.Content)
			{
				content.Add(new MovieViewModel(m, section));
			}

			Content = content;
		}

		public double Scroll 
		{ 
			get
			{
				return _scroll;
			}

			set
			{
				if (_scroll != value)
				{
					_scroll = value;

					RaisePropertyChanged(nameof(Scroll));
				}
			}
		}

		public string Title { get; private set; }

		public List<MovieViewModel> Content { get; private set; }

		private void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}

	public class MovieViewModel
	{
		private readonly Movie _movie;
		private readonly MovieSection _movieSection;
		private MovieSectionViewModel _movieSectionViewModel;

		public MovieViewModel(Movie movie, MovieSection section)
		{
			_movie = movie;
			_movieSection = section;
		}

		public string Title => _movie.Title;
		public string Source => _movie.Source;
		public string Seasons => _movie.Seasons;
		public double RatingValue => _movie.RatingValue;
		public double RatingMax => _movie.RatingMax;
		public string Director => _movie.Director;
		public string Plot => _movie.Plot;
		public string Cast => _movie.Cast;

		public MovieSectionViewModel Section 
		{ 
			get
			{
				if (_movieSectionViewModel == null)
				{
					_movieSectionViewModel = new MovieSectionViewModel(_movieSection, true);
				}

				return _movieSectionViewModel;
			}
		}
	}
}