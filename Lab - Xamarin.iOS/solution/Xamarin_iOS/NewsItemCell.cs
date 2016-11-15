using Foundation;
using System;
using UIKit;

namespace Xamarin_iOS
{
    public partial class NewsItemCell : UITableViewCell
    {
        public NewsItemCell (IntPtr handle) : base (handle)
        {
        }

        public void SetValues(string header, string text)
        {
            Header.Text = header;
            Text.Text = text;
        }
    }
}