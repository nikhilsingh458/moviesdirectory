using System;

using UIKit;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Json;
using Foundation;

namespace omdbios
{
	public partial class MoviesViewController : UIViewController
	{
		#region Member

		ObservableCollection<MovieList> lstMovies=new ObservableCollection<MovieList>();
		MoviesItemDataSource dataSource;

		#endregion

		#region Properties

		DetailsViewController detailsController{ get; set; }

		#endregion

		#region Constructor

		public MoviesViewController (IntPtr handle) : base (handle)
		{
		}

		#endregion

		#region Overridden Methods

		public async override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			MoviesTableView.Source = dataSource = new MoviesItemDataSource (this,lstMovies);
			var data = new Dictionary<string, string>();
			data.Add("s", "peace");
			JsonValue result = await OMDBService.getInstanse().get(RequestType.FIND_MOVIE, data);
			JsonValue resultJson = result;

			if (resultJson.ContainsKey("Search"))
			{
				lstMovies.Clear();
				var searchResults = resultJson["Search"];

				var itemsCollection = new List<string>();
				for (int i = 0; i < searchResults.Count; i++)
				{
					if (searchResults[i].ContainsKey("Title"))
					{
						lstMovies.Add(new MovieList
							{
								Title = searchResults[i]["Title"],
								Year = searchResults[i]["Year"],
								Type = searchResults[i]["Type"],
								ImdbID = searchResults[i]["imdbID"],
							});
					}
				}
			}
			MoviesTableView.ReloadData ();
			MoviesTableView.Source = dataSource =  new MoviesItemDataSource (this, lstMovies);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}

		#endregion
}

}