// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MoviesDirectory
{
	[Register ("DetailsViewController")]
	partial class DetailsViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnBack { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imgPoster { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblActors { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblAwards { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblDirector { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblGenre { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblIMDBRatingReviews { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblLanguageCountry { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblTitle { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblYearReleased { get; set; }

		[Action ("BackButton_TouchupInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BackButton_TouchupInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnBack != null) {
				btnBack.Dispose ();
				btnBack = null;
			}
			if (imgPoster != null) {
				imgPoster.Dispose ();
				imgPoster = null;
			}
			if (lblActors != null) {
				lblActors.Dispose ();
				lblActors = null;
			}
			if (lblAwards != null) {
				lblAwards.Dispose ();
				lblAwards = null;
			}
			if (lblDirector != null) {
				lblDirector.Dispose ();
				lblDirector = null;
			}
			if (lblGenre != null) {
				lblGenre.Dispose ();
				lblGenre = null;
			}
			if (lblIMDBRatingReviews != null) {
				lblIMDBRatingReviews.Dispose ();
				lblIMDBRatingReviews = null;
			}
			if (lblLanguageCountry != null) {
				lblLanguageCountry.Dispose ();
				lblLanguageCountry = null;
			}
			if (lblTitle != null) {
				lblTitle.Dispose ();
				lblTitle = null;
			}
			if (lblYearReleased != null) {
				lblYearReleased.Dispose ();
				lblYearReleased = null;
			}
		}
	}
}
