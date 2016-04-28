using System;
using UIKit;
using Foundation;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MoviesDirectory
{
	public class MoviesItemDataSource: UITableViewSource
	{
		#region Members

		NSString CellIdentifier = new NSString ("Cell");
		ObservableCollection<Movie> lstMovieItems=new ObservableCollection<Movie>();
		MoviesViewController controller;
		SecondViewController scontroller;

		#endregion

		#region Constuctor

		public MoviesItemDataSource (MoviesViewController controller,ObservableCollection<Movie> items)
		{
			lstMovieItems = items;
			this.controller = controller;
		}

		public MoviesItemDataSource (SecondViewController controller,ObservableCollection<Movie> items)
		{
			lstMovieItems = items;
			this.scontroller = controller;
		}

		#endregion

		#region Overridden Methods

		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public ObservableCollection<Movie> Objects {
			get { return lstMovieItems; }
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return lstMovieItems.Count;
		}

		// Customize the appearance of table view cells.
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (CellIdentifier);
			cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
			cell.TextLabel.Text=lstMovieItems[indexPath.Row].Title;
			cell.DetailTextLabel.Text=string.Concat ("Type : ", lstMovieItems[indexPath.Row].Type, "  Year : ", lstMovieItems[indexPath.Row].Year);;
			if (!string.IsNullOrEmpty (lstMovieItems [indexPath.Row].Poster)) {
				NSUrl url = new NSUrl (lstMovieItems [indexPath.Row].Poster);
				NSError error = new NSError ();
				var data = NSData.FromUrl (url, NSDataReadingOptions.Uncached, out error);				cell.ImageView.Image = UIImage.LoadFromData (data);
			}
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
			try 
			{
				var index = indexPath.Row;
				DetailsViewController ctrlr = (DetailsViewController)controller.Storyboard.InstantiateViewController("DetailsViewController") as DetailsViewController;
				ctrlr.MovieDetailItem = lstMovieItems [index];
				IntPtr intpr = IntPtr.Zero;
				controller.PresentViewController (ctrlr, false, null);
			} 
			catch (Exception ex)    
			{
				string exep=ex.Message;
			}
		}

		#endregion

	}
}

