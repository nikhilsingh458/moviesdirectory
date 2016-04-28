using System;

using UIKit;
using System.Collections.ObjectModel;

namespace MoviesDirectory
{
	public partial class SecondViewController : UIViewController
	{
		public Movie movieDetails{ get; set; }
		MoviesItemDataSource dataSource;
		ObservableCollection<Movie> Movies=new ObservableCollection<Movie>();

		public SecondViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();	
			lblEpisodeName.Text="Episodes and Series : man";
			GetMoviesData ();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public async void GetMoviesData()
		{
			OMDBService service = new OMDBService ();
			var moviedetail=await service.GetEpisodesAndSeriesList ("man", "episode", "");
			//Movies = (Movie)moviedetail;
			EpisodeTableView.ReloadData ();
			EpisodeTableView.Source = dataSource = new MoviesItemDataSource (this, Movies);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

