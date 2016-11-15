using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Xamarin_iOS
{
    public partial class NewsViewController : UITableViewController
    {
        private List<Tuple<string, string>> _items;

        public NewsViewController(IntPtr handle) : base(handle)
        {
            _items = new List<Tuple<string, string>>();

            _items.Add(new Tuple<string, string>("Microsoft köper Xamarin", "Nu är det klart att Microsoft köper det San Francisco baserade företaget Xamarin"));
            _items.Add(new Tuple<string, string>("Xamarin i topp", "Xamarin är än en gång i topp!"));
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("NewsCell") as NewsItemCell;

            //Not necessary when using storyboard
            if (cell == null)
            {
                cell = new NewsItemCell(Handle);
            }

            cell.SetValues(_items[indexPath.Row].Item1, _items[indexPath.Row].Item2);

            return cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _items.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var message = string.Format("You selected: {0}", _items[indexPath.Row].Item1);

            var dialog = new UIAlertView()
            {
                Title = "Hi",
                Message = message
            };

            dialog.AddButton("OK");
            dialog.Show();
        }
    }
}