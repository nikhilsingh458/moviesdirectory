using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using System.Json;

namespace omdbios
{
	partial class DetailsViewController : UIViewController
	{
		#region Properties

		public MovieList MovieDetailItem { get; set; }
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
			ConfigureView (MovieDetailItem);
		}

		#endregion

		#region Methods

		public void SetDetailItem (MovieList newMovieItem)
		{
			if (MovieDetailItem != newMovieItem) {
				MovieDetailItem = newMovieItem;
				ConfigureView (MovieDetailItem);
			}
		}

		async void ConfigureView (MovieList newDetailItem)
		{
			if (!IsViewLoaded)
				return;
			
			OMDBService service = new OMDBService ();
			var moviedetail=await service.GetMovie (newDetailItem.Title, "");
			movieDetails = (Movie)moviedetail;
				
			lblAwards.Text = String.Concat("Awards : ",movieDetails.Awards);
			lblDirectorActor.Text = string.Concat ("Director : ", movieDetails.Director);
			lblGenre.Text = string.Concat ("Genre : ",movieDetails.Genre);
			lblIMDBRatingReviews.Text = string.Concat ("IMDB Rating : ",movieDetails.imdbRating,"  IMDB Votes : ",movieDetails.imdbVotes);
			lblLanguageCountry.Text = string.Concat ("Language : ",movieDetails.Country," Country : ",movieDetails.Country);
			lblTitle.Text = string.Concat ("Title : ",movieDetails.Title);
			lblYearReleased.Text = string.Concat ("Year Released : ",movieDetails.Released);
			lblActor.Text=String.Concat("Actor : ",movieDetails.Actors);
			imgPoster.Image = FromUrl (movieDetails.Poster);
		}

		static UIImage FromUrl (string uri)
		{
			NSUrl url = new NSUrl (uri);
			NSError error = new NSError ();
			var data = NSData.FromUrl (url,NSDataReadingOptions.Uncached,out error);

			return UIImage.LoadFromData (data);
		}

		#endregion
	}
}
