using System.Collections.ObjectModel;

namespace MoviesDirectory.Movies.Interfaces
{
	/// <summary>
	/// Interface to call back view via Presenter
	/// </summary>
	public interface IMoviesListView
	{
		#region Properties

		ObservableCollection<Movie> MoviesList{ get; set; }

		#endregion Properties

		#region Methods

		void AlertMessage();
		void GetMovieName(string moviename,string movieid,int itemposition);

		#endregion Methods
	}
}