using System;
using UIKit;
using Foundation;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace omdbios
{
	public class MoviesItemDataSource: UITableViewSource
	{
		#region Members

		NSString CellIdentifier = new NSString ("Cell");
		ObservableCollection<MovieList> lstMovieItems=new ObservableCollection<MovieList>();
		MoviesViewController controller;

		#endregion

		#region Constuctor

		public MoviesItemDataSource (MoviesViewController controller,ObservableCollection<MovieList> items)
		{
			lstMovieItems = items;
			this.controller = controller;
		}

		#endregion

		#region Overridden Methods

		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public ObservableCollection<MovieList> Objects {
			get { return lstMovieItems; }
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return lstMovieItems.Count;
		}

		// Customize the appearance of table view cells.
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (CellIdentifier);
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			cell.TextLabel.Text = lstMovieItems[indexPath.Row].Title;
			cell.TextLabel.Lines = 2;
			cell.TextLabel.LineBreakMode = UILineBreakMode.WordWrap;
			cell.TextLabel.AdjustsFontSizeToFitWidth = true;
			cell.DetailTextLabel.Text = string.Concat ("Type : ", lstMovieItems[indexPath.Row].Type, "  Year : ", lstMovieItems[indexPath.Row].Year);
			return cell;
		}

		public override bool CanEditRow (UITableView tableView, NSIndexPath indexPath)
		{
			return false;
		}

		public override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
		{
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var index = indexPath.Row;
			DetailsViewController ctrlr = (DetailsViewController)controller.Storyboard.InstantiateViewController("DetailsViewController") as DetailsViewController;
			ctrlr.MovieDetailItem = lstMovieItems [index];
			IntPtr intpr = IntPtr.Zero;
			controller.PresentViewController (ctrlr, false, null);
		}

		#endregion

	}
}

