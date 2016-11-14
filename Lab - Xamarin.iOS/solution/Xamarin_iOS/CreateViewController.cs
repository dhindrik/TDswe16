using Foundation;
using System;
using UIKit;

namespace Xamarin_iOS
{
    public partial class CreateViewController : UIViewController
    {
        public CreateViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.NavigationItem.SetRightBarButtonItem(
            new UIBarButtonItem(UIBarButtonSystemItem.Save, (sender, args) => {

                var message = string.Format("Hello {0} {1}", FirstName.Text, LastName.Text);

                var dialog = new UIAlertView()
                {
                    Title = "Welcome",
                    Message = message
                };
                dialog.AddButton("OK");
                dialog.Show();

                var viewController = Storyboard.InstantiateViewController("MainTabs");

                NavigationController.ShowViewController(viewController, this);

            }), true);
        }
    }
}