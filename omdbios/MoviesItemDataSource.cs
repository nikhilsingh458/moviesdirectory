using System;
using UIKit;
using Foundation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MoviesDirectory.Movies.Presenter;

namespace MoviesDirectory
{
	/// <summary>
	/// Movies item data source.TableView itemsource
	/// </summary>
	public class MoviesItemDataSource: UITableViewSource
	{
		#region Members

		NSString CellIdentifier = new NSString ("Cell");
		ObservableCollection<Movie> lstMovieItems=new ObservableCollection<Movie>();
		MoviesViewController controller;
		private MoviesListPresenter _presenter;

		#endregion

		#region Constuctor

		/// <summary>
		/// Initializes a new instance of the <see cref="MoviesDirectory.MoviesItemDataSource"/> class.
		/// </summary>
		/// <param name="controller">Controller.</param>
		/// <param name="items">Items.</param>
		public MoviesItemDataSource (MoviesViewController controller,ObservableCollection<Movie> items)
		{
			lstMovieItems = items;
			this.controller = controller;
			_presenter = new MoviesListPresenter (controller);
		}

		#endregion

		#region Overridden Methods

		/// <summary>
		/// Numbers the of sections.
		/// </summary>
		/// <returns>The of sections.</returns>
		/// <param name="tableView">Table view.</param>
		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		/// <summary>
		/// Gets the objects.
		/// </summary>
		/// <value>The objects.</value>
		public ObservableCollection<Movie> Objects {
			get { return lstMovieItems; }
		}

		/// <summary>
		/// Rowses the in section.
		/// </summary>
		/// <returns>The in section.</returns>
		/// <param name="tableview">Tableview.</param>
		/// <param name="section">Section.</param>
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return lstMovieItems.Count;
		}

		/// <summary>
		/// Gets the cell.Customize the appearance of table view cells.
		/// </summary>
		/// <returns>The cell.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (CellIdentifier);
			cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
			cell.TextLabel.Text=lstMovieItems[indexPath.Row].Title;
			cell.DetailTextLabel.Text=string.Concat ("Type : ", lstMovieItems[indexPath.Row].Type, "  Year : ", lstMovieItems[indexPath.Row].Year);
			if (lstMovieItems [indexPath.Row].Poster.ToUpper() != "N/A")
			{
				NSUrl url = new NSUrl (lstMovieItems [indexPath.Row].Poster);
				NSError error = new NSError ();
				var data = NSData.FromUrl (url, NSDataReadingOptions.Uncached, out error);				
				cell.ImageView.Image = UIImage.LoadFromData (data);
			}
			return cell;
		}

		/// <summary>
		/// Determines whether this instance can edit row the specified tableView indexPath.
		/// </summary>
		/// <returns><c>true</c> if this instance can edit row the specified tableView indexPath; otherwise, <c>false</c>.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
		public override bool CanEditRow (UITableView tableView, NSIndexPath indexPath)
		{
			return false;
		}

		/// <summary>
		/// Gets the selected row.
		/// </summary>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			try 
			{
				_presenter.GetMovieDetails(indexPath.Row);
			} 
			catch (Exception ex)    
			{
				string exep=ex.Message;
			}
		}

		#endregion

	}
}

