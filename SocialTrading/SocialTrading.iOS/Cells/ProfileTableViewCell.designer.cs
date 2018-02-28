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
    [Register ("ProfileTableViewCell")]
    partial class ProfileTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SocialTrading.iOS.ProfileCellView _profileCellView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_profileCellView != null) {
                _profileCellView.Dispose ();
                _profileCellView = null;
            }
        }
    }
}