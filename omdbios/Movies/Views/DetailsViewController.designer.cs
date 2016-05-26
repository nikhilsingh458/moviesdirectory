// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MoviesDirectory
{
	[Register ("DetailsViewController")]
	partial class DetailsViewController
	{
		[Outlet]
		UIKit.NSLayoutConstraint _constraintlblGenreHeight { get; set; }

		[Outlet]
		UIKit.UIButton btnBack { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint constraintLblActorsHeight { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint constraintlblAwardsHeight { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint constraintLblDirectorsHeight { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint constraintLblLanguagesHeight { get; set; }

		[Outlet]
		UIKit.UIImageView imagePoster { get; set; }

		[Outlet]
		UIKit.UILabel labelActorName { get; set; }

		[Outlet]
		UIKit.UILabel labelActors { get; set; }

		[Outlet]
		UIKit.UILabel labelAwards { get; set; }

		[Outlet]
		UIKit.UILabel labelAwardsName { get; set; }

		[Outlet]
		UIKit.UILabel labelDirectors { get; set; }

		[Outlet]
		UIKit.UILabel labelDirectorsName { get; set; }

		[Outlet]
		UIKit.UILabel labelGenre { get; set; }

		[Outlet]
		UIKit.UILabel labelGenreName { get; set; }

		[Outlet]
		UIKit.UILabel labelIMDBRating { get; set; }

		[Outlet]
		UIKit.UILabel labelIMDBRatingName { get; set; }

		[Outlet]
		UIKit.UILabel labelLanguage { get; set; }

		[Outlet]
		UIKit.UILabel labelLanguageName { get; set; }

		[Outlet]
		UIKit.UILabel labelReleaseDate { get; set; }

		[Outlet]
		UIKit.UILabel labelReleaseDateName { get; set; }

		[Outlet]
		UIKit.UILabel labelTitle { get; set; }

		[Action ("BackButton_TouchupInside:")]
		partial void BackButton_TouchupInside (UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (_constraintlblGenreHeight != null) {
				_constraintlblGenreHeight.Dispose ();
				_constraintlblGenreHeight = null;
			}

			if (constraintlblAwardsHeight != null) {
				constraintlblAwardsHeight.Dispose ();
				constraintlblAwardsHeight = null;
			}

			if (btnBack != null) {
				btnBack.Dispose ();
				btnBack = null;
			}

			if (constraintLblActorsHeight != null) {
				constraintLblActorsHeight.Dispose ();
				constraintLblActorsHeight = null;
			}

			if (constraintLblDirectorsHeight != null) {
				constraintLblDirectorsHeight.Dispose ();
				constraintLblDirectorsHeight = null;
			}

			if (constraintLblLanguagesHeight != null) {
				constraintLblLanguagesHeight.Dispose ();
				constraintLblLanguagesHeight = null;
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
