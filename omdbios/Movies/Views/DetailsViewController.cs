using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using System.Json;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Linq;

namespace MoviesDirectory
{
	/// <summary>
	/// View controller to show the details of selected movie.
	/// </summary>
	partial class DetailsViewController : UIViewController
	{
		#region Properties

		public Movie MovieDetailItem { get; set; }
		public Movie movieDetails{ get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="MoviesDirectory.DetailsViewController"/> class.
		/// </summary>
		/// <param name="handle">Handle.</param>
		public DetailsViewController (IntPtr handle) : base (handle)
		{
		}

		#endregion

		#region Overridden Methods

		/// <summary>
		/// Called after the controller's view is loaded into memory.
		/// </summary>
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.Title = "Movie Details";
			UIBarButtonItem backbutton = new UIBarButtonItem("Back", UIBarButtonItemStyle.Done, null);
			this.NavigationItem.BackBarButtonItem = backbutton;
			this.NavigationItem.BackBarButtonItem.Enabled = true;
			ConfigureView (MovieDetailItem);
		}

		#endregion

		#region Methods

		/// <summary>
		/// Sets the detail item.
		/// </summary>
		/// <param name="newMovieItem">New movie item.</param>
		public void SetDetailItem (Movie newMovieItem)
		{
			if (MovieDetailItem != newMovieItem) {
				MovieDetailItem = newMovieItem;
				ConfigureView (MovieDetailItem);
			}
		}

		/// <summary>
		/// Configures the view and the controls Associated
		/// </summary>
		/// <param name="newDetailItem">New detail item.</param>
		async void ConfigureView (Movie newDetailItem)
		{
			if (!IsViewLoaded)
				return;
			
			OMDBService service = new OMDBService ();
			var moviedetail=await service.GetMovie (newDetailItem.Title, "");
			movieDetails = (Movie)moviedetail;
				
			labelAwards.Text = GetLines(movieDetails.Awards).ToString();
			labelDirectors.Text = GetLines( movieDetails.Director).ToString();
			labelGenre.Text = GetLines(movieDetails.Genre).ToString();
			labelIMDBRating.Text = string.Concat (movieDetails.IMDBRating);
			labelLanguage.Text = GetLines(movieDetails.Language).ToString();
			labelTitle.Text = movieDetails.Title;
			labelReleaseDate.Text = movieDetails.Released;
			labelActors.Text=GetLines(movieDetails.Actors).ToString();
			imagePoster.Image = await LoadImage (movieDetails.Poster);
		}

		/// <summary>
		/// Loads the image asynchronously
		/// </summary>
		/// <returns>The image.</returns>
		/// <param name="imageUrl">Image URL.</param>
		public async Task<UIImage> LoadImage (string imageUrl)
		{
			var httpClient = new HttpClient();

			Task<byte[]> contentsTask = httpClient.GetByteArrayAsync (imageUrl);

			// await! control returns to the caller and the task continues to run on another thread
			var contents = await contentsTask;

			// load from bytes
			return UIImage.LoadFromData (NSData.FromArray (contents));
		}

		/// <summary>
		/// Split the text after comma(,) and display that in different line
		/// </summary>
		/// <returns>string with new lines</returns>
		/// <param name="strvalue">string value with comma's</param>
		public StringBuilder GetLines(string strvalue)
		{
			StringBuilder appendstring = new StringBuilder();
			List<string> strwords = strvalue.Split(',').Select(p => p.Trim()).ToList();

			for (int wordscount = 0; wordscount < (strwords.Count - 1); wordscount++)
			{
				appendstring.Append(strwords[wordscount] + "\n");
			}
			appendstring.Append(strwords[strwords.Count - 1]);

			return appendstring;
		}

		partial void BackButton_TouchupInside (UIButton sender)
		{
			MoviesViewController ctrlr = (MoviesViewController)this.Storyboard.InstantiateViewController("MoviesViewController") as MoviesViewController;
			IntPtr intpr = IntPtr.Zero;
			this.PresentViewController (ctrlr, false, null);
		}
		#endregion
	}

}
