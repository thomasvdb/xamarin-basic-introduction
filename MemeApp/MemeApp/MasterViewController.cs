using System;
using System.Collections.Generic;

using UIKit;
using Foundation;
using CoreGraphics;

namespace MemeApp
{
    public partial class MasterViewController : UITableViewController
    {
        public DetailViewController DetailViewController { get; set; }

        DataSource dataSource;

        public MasterViewController(IntPtr handle)
            : base(handle)
        {
            Title = NSBundle.MainBundle.LocalizedString("Master", "Master");
			
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                PreferredContentSize = new CGSize(320f, 600f);
                ClearsSelectionOnViewWillAppear = false;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            NavigationItem.LeftBarButtonItem = EditButtonItem;

            var addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, AddNewItem);
            addButton.AccessibilityLabel = "addButton";
            NavigationItem.RightBarButtonItem = addButton;

            DetailViewController = (DetailViewController)((UINavigationController)SplitViewController.ViewControllers[1]).TopViewController;

            TableView.Source = dataSource = new DataSource(this);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void AddNewItem(object sender, EventArgs args)
        {
            //  dataSource.Objects.Insert(0, DateTime.Now);

            using (var indexPath = NSIndexPath.FromRowSection(0, 0))
                TableView.InsertRows(new [] { indexPath }, UITableViewRowAnimation.Automatic);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "showDetail")
            {
                var indexPath = TableView.IndexPathForSelectedRow;
                var item = dataSource.Objects[indexPath.Row];
                var controller = (DetailViewController)((UINavigationController)segue.DestinationViewController).TopViewController;
                controller.SetDetailItem(item);
                controller.NavigationItem.LeftBarButtonItem = SplitViewController.DisplayModeButtonItem;
                controller.NavigationItem.LeftItemsSupplementBackButton = true;
            }
        }

        public class MemeModel
        {
            public string ImageUrl { get; set; }

            public string DisplayName { get; set; }
        }

        class DataSource : UITableViewSource
        {
            static readonly NSString CellIdentifier = new NSString("Cell");
            readonly MasterViewController controller;

            public DataSource(MasterViewController controller)
            {
                this.controller = controller;
            }

            public IList<MemeModel> Objects
            {
                get
                {
                    return new List<MemeModel>()
                    {
                        new MemeModel()
                        { 
                            DisplayName = "F*** your photo",
                            ImageUrl = "https://s-media-cache-ak0.pinimg.com/564x/f4/2d/db/f42ddb019bbd7dd42f4a26cad33cf644.jpg"
                        },
                        new MemeModel()
                        { 
                            DisplayName = "Shoo dino, shoo!",
                            ImageUrl = "https://s-media-cache-ak0.pinimg.com/564x/43/b0/44/43b04440726ecb43765358d58d908f74.jpg"
                        },
                        new MemeModel()
                        { 
                            DisplayName = "Pew, pew, pew!",
                            ImageUrl = "https://s-media-cache-ak0.pinimg.com/564x/7f/0c/88/7f0c88b92a4606fa04d4e09991879b6d.jpg"
                        },
                        new MemeModel()
                        { 
                            DisplayName = "Parkour",
                            ImageUrl = "https://s-media-cache-ak0.pinimg.com/564x/60/be/82/60be82518f049723467ace754be468eb.jpg"
                        },
                        new MemeModel()
                        { 
                            DisplayName = "Evil plan",
                            ImageUrl = "https://s-media-cache-ak0.pinimg.com/564x/5e/c9/23/5ec92387bf4b8546fb9693f3c3310b7c.jpg"
                        }
                    };
                }
            }

            // Customize the number of sections in the table view.
            public override nint NumberOfSections(UITableView tableView)
            {
                return 1;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return Objects.Count;
            }

            // Customize the appearance of table view cells.
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.DequeueReusableCell(CellIdentifier, indexPath);

                cell.TextLabel.Text = Objects[indexPath.Row].DisplayName;

                return cell;
            }

            public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
            {
                // Return false if you do not want the specified item to be editable.
                return true;
            }

            public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
            {
                if (editingStyle == UITableViewCellEditingStyle.Delete)
                {
                    // Delete the row from the data source.
                    // objects.RemoveAt(indexPath.Row);
                    controller.TableView.DeleteRows(new [] { indexPath }, UITableViewRowAnimation.Fade);
                }
                else if (editingStyle == UITableViewCellEditingStyle.Insert)
                {
                    // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
                }
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                    controller.DetailViewController.SetDetailItem(Objects[indexPath.Row]);
            }
        }
    }
}


