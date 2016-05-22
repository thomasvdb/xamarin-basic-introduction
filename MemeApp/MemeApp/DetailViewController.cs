using System;

using UIKit;
using FFImageLoading;

namespace MemeApp
{
    public partial class DetailViewController : UIViewController
    {
        public MemeApp.MasterViewController.MemeModel DetailItem { get; set; }

        public DetailViewController(IntPtr handle)
            : base(handle)
        {
        }

        public void SetDetailItem(MemeApp.MasterViewController.MemeModel newDetailItem)
        {
            if (DetailItem != newDetailItem)
            {
                DetailItem = newDetailItem;
				
                // Update the view
                ConfigureView();
            }
        }

        void ConfigureView()
        {
            // Update the user interface for the detail item
            if (IsViewLoaded && DetailItem != null)
            {
                ImageService.LoadUrl(DetailItem.ImageUrl).Into(ImageMeme);
                //  ScrollView.ContentSize = ImageMeme.Frame.Size;

            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            ConfigureView();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}


