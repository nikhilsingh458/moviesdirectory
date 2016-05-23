using System;
using UIKit;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Json;
using Foundation;
using System.Linq;
using CoreGraphics;
using System.IO;
using Newtonsoft.Json;
using MoviesDirectory.Enums;
using MoviesDirectory.Movies.Presenter;
using MoviesDirectory.Movies.Interfaces;
using System.Threading.Tasks;

namespace MoviesDirectory
{
	/// <summary>
	/// Movies view controller.Displays the movies list based on used input
	/// </summary>
	public partial class MoviesViewController : UIViewController,IMoviesListView
	{
		#region Member

		ObservableCollection<Movie> Movies=new ObservableCollection<Movie>();
		MoviesItemDataSource dataSource;
		private MoviesListPresenter _presenter;

		#endregion

		#region Properties

		DetailsViewController detailsController{ get; set; }

		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="MoviesDirectory.MoviesViewController"/> class.
		/// </summary>
		/// <param name="handle">Handle.</param>
		public MoviesViewController (IntPtr handle) : base (handle)
		{
		}

		#endregion

		#region IMoviesListView implementation

		/// <summary>
		/// Alert message if user input less than 3 characters
		/// </summary>
		public void AlertMessage ()
		{
			UIAlertView alert = new UIAlertView();
			alert.Title = "Information";
			alert.AddButton("OK");
			alert.Message = "Please enter aleast 3 characters to search";
			alert.AlertViewStyle = UIAlertViewStyle.Default;
			alert.Clicked += (object s, UIButtonEventArgs ev) => {};
			alert.Show();
		}

		/// <summary>
		/// Gets the name of the movie.
		/// </summary>
		/// <param name="moviename">Moviename.</param>
		/// <param name="movieid">Movieid.</param>
		/// <param name="itemposition">Itemposition.</param>
		public void GetMovieName (string moviename, string movieid,int itemposition)
		{
			DetailsViewController controller = (DetailsViewController)this.Storyboard.InstantiateViewController("DetailsViewController") as DetailsViewController;
			controller.MovieDetailItem = Movies [itemposition];
			this.PresentViewController (controller, false, null);
		}

		/// <summary>
		/// Gets or sets the movies list.
		/// </summary>
		/// <value>The movies list.</value>
		public ObservableCollection<Movie> MoviesList {
			get 
			{
				return Movies;
			}

			set 
			{
				Movies = value;
				MoviesTableView.ReloadData ();
				MoviesTableView.Source = dataSource = new MoviesItemDataSource (this, Movies);
			}
		}

		#endregion

		#region Overridden Methods

		/// <summary>
		/// Called after the controller's view is loaded into memory.
		/// </summary>
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			_presenter = new MoviesListPresenter (this);
			MoviesTableView.SeparatorInset = new UIEdgeInsets (10, 4, 250, 2);
			MoviesTableView.SeparatorEffect = UIBlurEffect.FromStyle (UIBlurEffectStyle.ExtraLight);
			MoviesTableView.SeparatorStyle = UITableViewCellSeparatorStyle.DoubleLineEtched;
			MoviesTableView.Source = dataSource = new MoviesItemDataSource (this,Movies);
			var searchcontroller = searchDisplayController;
			searchcontroller.SearchResultsSource = new MoviesItemDataSource (this,Movies);
			MoviesSearchBar.SearchButtonClicked+=(sender, e) =>_presenter.GetMovieData(MoviesSearchBar.Text);
		}
			
		/// <summary>
		/// Dids the receive memory warning.
		/// </summary>
		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}
			
		#endregion

     }

}