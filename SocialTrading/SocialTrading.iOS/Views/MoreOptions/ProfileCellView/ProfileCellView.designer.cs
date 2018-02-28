// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace SocialTrading.iOS
{
    [Register ("ProfileCellView")]
    partial class ProfileCellView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView _avatarImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _rootView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _userNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _yourProfileLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_avatarImageView != null) {
                _avatarImageView.Dispose ();
                _avatarImageView = null;
            }

            if (_rootView != null) {
                _rootView.Dispose ();
                _rootView = null;
            }

            if (_userNameLabel != null) {
                _userNameLabel.Dispose ();
                _userNameLabel = null;
            }

            if (_yourProfileLabel != null) {
                _yourProfileLabel.Dispose ();
                _yourProfileLabel = null;
            }
        }
    }
}