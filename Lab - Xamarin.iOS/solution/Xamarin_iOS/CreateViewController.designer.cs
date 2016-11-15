// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Xamarin_iOS
{
    [Register ("CreateViewController")]
    partial class CreateViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField FirstName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField LastName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (FirstName != null) {
                FirstName.Dispose ();
                FirstName = null;
            }

            if (LastName != null) {
                LastName.Dispose ();
                LastName = null;
            }
        }
    }
}