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
		UIImageView imagePoster { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelActorName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelActors { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelAwards { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelAwardsName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelDirectors { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelDirectorsName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelGenre { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelGenreName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelIMDBRating { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelIMDBRatingName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelLanguage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelLanguageName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelReleaseDate { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelReleaseDateName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelTitle { get; set; }

		[Action ("BackButton_TouchupInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BackButton_TouchupInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnBack != null) {
				btnBack.Dispose ();
				btnBack = null;
			}
			if (imagePoster != null) {
				imagePoster.Dispose ();
				imagePoster = null;
			}
			if (labelActorName != null) {
				labelActorName.Dispose ();
				labelActorName = null;
			}
			if (labelActors != null) {
				labelActors.Dispose ();
				labelActors = null;
			}
			if (labelAwards != null) {
				labelAwards.Dispose ();
				labelAwards = null;
			}
			if (labelAwardsName != null) {
				labelAwardsName.Dispose ();
				labelAwardsName = null;
			}
			if (labelDirectors != null) {
				labelDirectors.Dispose ();
				labelDirectors = null;
			}
			if (labelDirectorsName != null) {
				labelDirectorsName.Dispose ();
				labelDirectorsName = null;
			}
			if (labelGenre != null) {
				labelGenre.Dispose ();
				labelGenre = null;
			}
			if (labelGenreName != null) {
				labelGenreName.Dispose ();
				labelGenreName = null;
			}
			if (labelIMDBRating != null) {
				labelIMDBRating.Dispose ();
				labelIMDBRating = null;
			}
			if (labelIMDBRatingName != null) {
				labelIMDBRatingName.Dispose ();
				labelIMDBRatingName = null;
			}
			if (labelLanguage != null) {
				labelLanguage.Dispose ();
				labelLanguage = null;
			}
			if (labelLanguageName != null) {
				labelLanguageName.Dispose ();
				labelLanguageName = null;
			}
			if (labelReleaseDate != null) {
				labelReleaseDate.Dispose ();
				labelReleaseDate = null;
			}
			if (labelReleaseDateName != null) {
				labelReleaseDateName.Dispose ();
				labelReleaseDateName = null;
			}
			if (labelTitle != null) {
				labelTitle.Dispose ();
				labelTitle = null;
			}
		}
	}
}
