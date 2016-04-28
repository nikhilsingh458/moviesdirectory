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
	[Register ("MoviesViewController")]
	partial class MoviesViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView MoviesTableView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISearchDisplayController searchDisplayController { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField SearchTextField { get; set; }

		[Action ("textview_Enter:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void textview_Enter (UITextField sender);

		void ReleaseDesignerOutlets ()
		{
			if (MoviesTableView != null) {
				MoviesTableView.Dispose ();
				MoviesTableView = null;
			}
			if (searchDisplayController != null) {
				searchDisplayController.Dispose ();
				searchDisplayController = null;
			}
			if (SearchTextField != null) {
				SearchTextField.Dispose ();
				SearchTextField = null;
			}
		}
	}
}
