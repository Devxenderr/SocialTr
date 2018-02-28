// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace SocialTrading.iOS.Cells
{
    [Register ("DetailedPostTableViewCell")]
    partial class DetailedPostTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SocialTrading.iOS.DetailedPostView _detailedPostView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_detailedPostView != null) {
                _detailedPostView.Dispose ();
                _detailedPostView = null;
            }
        }
    }
}