using System;

using UIKit;

namespace omdbios
{
	public partial class SecondViewController : UIViewController
	{
		public SecondViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();	
			OMDBService service = new OMDBService ();
			var movies=service.GetEpisodesAndSeriesList("tr","");
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

