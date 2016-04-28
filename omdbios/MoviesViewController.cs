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

namespace MoviesDirectory
{
	public partial class MoviesViewController : UIViewController
	{
		#region Member

		ObservableCollection<Movie> Movies=new ObservableCollection<Movie>();
		MoviesItemDataSource dataSource;
		string text=string.Empty;
		string filename=string.Empty;

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

			MoviesTableView.SeparatorInset = new UIEdgeInsets (10, 4, 250, 2);
			MoviesTableView.SeparatorEffect = UIBlurEffect.FromStyle (UIBlurEffectStyle.ExtraLight);
			MoviesTableView.SeparatorStyle = UITableViewCellSeparatorStyle.DoubleLineEtched;
			MoviesTableView.Source = dataSource = new MoviesItemDataSource (this,Movies);
			SearchTextField.Text = "man";
			SearchTextField.Enabled = false;
			SearchTextField.TextColor = UIColor.Gray;

				var data = new Dictionary<string, string>();
				data.Add("s", "man");
			if (string.IsNullOrEmpty(filename)) {
				JsonValue result = await OMDBService.getInstanse ().get (RequestType.FIND_MOVIE, data);

				if (result.ContainsKey ("Search")) {
					Movies.Clear ();
					var searchResults = result ["Search"];

					for (int i = 0; i < searchResults.Count; i++) {
						if (searchResults [i].ContainsKey ("imdbID")) {
							Movies.Add (new Movie {
								Title = searchResults [i] ["Title"],
								Year = 	searchResults [i] ["Year"],
								Type = searchResults [i] ["Type"],
								ImdbID = searchResults [i] ["imdbID"],
								Poster = searchResults [i] ["Poster"]
							});
						}
					}
				}
	
				MoviesTableView.ReloadData ();
				MoviesTableView.Source = dataSource = new MoviesItemDataSource (this, Movies);
				var documents = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
				filename = Path.Combine (documents, "movies.json");
				var cc = File.Open (filename,FileMode.Create,FileAccess.Write);
				using (var stream = new StreamWriter (cc)) {
					stream.Write (cc);
				}
				File.WriteAllText (filename, JsonConvert.SerializeObject (Movies));
			}
			else {
				string jsondata=File.ReadAllText (filename);

			}

		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}
			
		#endregion
}

}