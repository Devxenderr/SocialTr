// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SocialTrading.iOS
{
    [Register ("DetailedPostViewController")]
    partial class DetailedPostViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView _rootTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_rootTableView != null) {
                _rootTableView.Dispose ();
                _rootTableView = null;
            }
        }
    }
}