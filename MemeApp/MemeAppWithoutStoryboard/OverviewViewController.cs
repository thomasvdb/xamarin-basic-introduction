using System;
using UIKit;
using Foundation;
using System.Collections.Generic;

namespace MemeAppWithoutStoryboard
{
    public class OverviewViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var tableView = new UITableView();
            tableView.RegisterClassForCellReuse(typeof(UITableViewCell), "Cell");
            tableView.Source = new DataSource(this);
            tableView.ReloadData();
            tableView.TranslatesAutoresizingMaskIntoConstraints = false;

            View.BackgroundColor = UIColor.White;
            View.Add(tableView);
            View.AddConstraints(new[]
                {
                    NSLayoutConstraint.Create(tableView, NSLayoutAttribute.Top, NSLayoutRelation.Equal, View, NSLayoutAttribute.Top, 1f, 20f),
                    NSLayoutConstraint.Create(tableView, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1f, 0f),
                    NSLayoutConstraint.Create(tableView, NSLayoutAttribute.Width, NSLayoutRelation.Equal, View, NSLayoutAttribute.Width, 1f, 0f),
                    NSLayoutConstraint.Create(tableView, NSLayoutAttribute.Height, NSLayoutRelation.Equal, View, NSLayoutAttribute.Height, 1f, 0f)
                });
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
        readonly OverviewViewController controller;

        public DataSource(OverviewViewController controller)
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
                //controller.TableView.DeleteRows(new [] { indexPath }, UITableViewRowAnimation.Fade);
            }
            else if (editingStyle == UITableViewCellEditingStyle.Insert)
            {
                // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
            }
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            // if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            this.controller.NavigationController.PushViewController(new DetailViewController(Objects[indexPath.Row]), false);
        }
    }
}

