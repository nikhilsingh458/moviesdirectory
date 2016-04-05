using System;
using UIKit;
using Foundation;
using System.Collections.Generic;

namespace omdbios
{
	public class MoviesItemDataSource: UITableViewSource
	{
		static readonly string mainurl="https://sample-listings.herokuapp.com";
		NSString CellIdentifier = new NSString ("Cell");
		List<Movie> lstMovieItems = new List<Movie> ();
		string strUrl;
		readonly FirstViewController controller;

		public MoviesItemDataSource (FirstViewController controller,List<Movie> items,string domainname)
		{
			lstMovieItems = items;
			this.controller = controller;
			strUrl = domainname;
		}

		// Customize the number of sections in the table view.
		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public IList<Movie> Objects {
			get { return lstMovieItems; }
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return lstMovieItems.Count;
		}

		// Customize the appearance of table view cells.
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (CellIdentifier,indexPath);
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			//cell.TextLabel.Text = lstMovieItems[indexPath.Row].Address;
			//cell.DetailTextLabel.Text = string.Concat ("Beds:", lstMovieItems [indexPath.Row].Beds, " , Baths:", lstMovieItems [indexPath.Row].Baths);
			//NSUrl uri = new NSUrl($"{mainurl}{lstTableListingItems [indexPath.Row].Image}");
			//using (var data = NSData.FromUrl (uri))
			//cell.ImageView.Image = UIImage.LoadFromData (data);
			//cell.LayoutSubviews ();
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
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				//controller.ListingDetViewController.SetDetailItem (lstMovieItems [indexPath.Row]);
			}
		}
	}
}

