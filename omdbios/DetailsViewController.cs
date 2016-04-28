using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using System.Json;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace MoviesDirectory
{
	partial class DetailsViewController : UIViewController
	{
		#region Properties

		public Movie MovieDetailItem { get; set; }
		public Movie movieDetails{ get; set; }

		#endregion

		#region Constructor

		public DetailsViewController (IntPtr handle) : base (handle)
		{
		}

		#endregion

		#region Overridden Methods

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.Title = "Movie Details";
			UIBarButtonItem backbutton = new UIBarButtonItem("Back", UIBarButtonItemStyle.Done, null);
			//BackNavigationItem.BackBarButtonItem = backbutton;
			//BackNavigationItem.BackBarButtonItem.Enabled = true;
			this.NavigationItem.BackBarButtonItem = backbutton;
			this.NavigationItem.BackBarButtonItem.Enabled = true;
			ConfigureView (MovieDetailItem);
		}

		#endregion

		#region Methods

		public void SetDetailItem (Movie newMovieItem)
		{
			if (MovieDetailItem != newMovieItem) {
				MovieDetailItem = newMovieItem;
				ConfigureView (MovieDetailItem);
			}
		}

		async void ConfigureView (Movie newDetailItem)
		{
			if (!IsViewLoaded)
				return;
			
			OMDBService service = new OMDBService ();
			var moviedetail=await service.GetMovie (newDetailItem.Title, "");
			movieDetails = (Movie)moviedetail;
				
			lblAwards.Text = String.Concat("Awards : ",movieDetails.Awards);
			lblDirector.Text = string.Concat ("Director : ", movieDetails.Director);
			lblGenre.Text = string.Concat ("Genre : ",movieDetails.Genre);
			lblIMDBRatingReviews.Text = string.Concat ("IMDB Rating : ",movieDetails.ImdbRating,"  IMDB Votes : ",movieDetails.ImdbVotes);
			lblLanguageCountry.Text = string.Concat ("Language : ",movieDetails.Country," Country : ",movieDetails.Country);
			lblTitle.Text = movieDetails.Title;
			lblYearReleased.Text = string.Concat ("Year Released : ",movieDetails.Released);
			lblActors.Text=String.Concat("Actor : ",movieDetails.Actors);
			imgPoster.Image = await LoadImage (movieDetails.Poster);
		}

		public async Task<UIImage> LoadImage (string imageUrl)
		{
			var httpClient = new HttpClient();

			Task<byte[]> contentsTask = httpClient.GetByteArrayAsync (imageUrl);

			// await! control returns to the caller and the task continues to run on another thread
			var contents = await contentsTask;

			// load from bytes
			return UIImage.LoadFromData (NSData.FromArray (contents));
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
