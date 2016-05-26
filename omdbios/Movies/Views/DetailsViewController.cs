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
using System.Drawing;

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
			ResizeHeightWithText (labelAwards);

			labelDirectors.Text = GetLines( movieDetails.Director).ToString();
			ResizeHeightWithText (labelDirectors);

			labelGenre.Text = GetLines(movieDetails.Genre).ToString();
			ResizeHeightWithText (labelGenre);

			labelIMDBRating.Text = movieDetails.IMDBRating;

			labelLanguage.Text = GetLines(movieDetails.Language).ToString();
			ResizeHeightWithText (labelLanguage);

			labelTitle.Text = movieDetails.Title;

			labelReleaseDate.Text = movieDetails.Released;

			labelActors.Text=GetLines(movieDetails.Actors).ToString();
			ResizeHeightWithText (labelActors);

			if (movieDetails.Poster.ToUpper () != "N/A") {
				imagePoster.Image = await LoadImage (movieDetails.Poster);
			}
		}

		/// <summary>
		/// Resizes the height with text.For Dynamic Resizing of the controls height.
		/// </summary>
		/// <param name="label">Current label</param>
		/// <param name="maxHeight">Max height.</param>
		void ResizeHeightWithText(UILabel label,float maxHeight = 960f) 
		{
			float width = (float)label.Frame.Width; 
			SizeF size = (SizeF)((NSString)label.Text).StringSize(label.Font,constrainedToSize:new SizeF(width,maxHeight),
				lineBreakMode:UILineBreakMode.WordWrap);

			if (label.IsEqual (labelActors))
					this.constraintLblActorsHeight.Constant = size.Height;
			if (label.IsEqual(labelDirectors))
				this.constraintLblDirectorsHeight.Constant = size.Height;
			if (label.IsEqual(labelGenre))
				this._constraintlblGenreHeight.Constant = size.Height;
			if (label.IsEqual(labelLanguage))
				this.constraintLblLanguagesHeight.Constant = size.Height;
			if (label.IsEqual(labelAwards))
				this.constraintlblAwardsHeight.Constant = size.Height;
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

		/// <summary>
		/// Back button touch Event
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void BackButton_TouchupInside (UIButton sender)
		{
			MoviesViewController ctrlr = (MoviesViewController)this.Storyboard.InstantiateViewController("MoviesViewController") as MoviesViewController;
			this.PresentViewController (ctrlr, false, null);
		}
		#endregion
	}

}
