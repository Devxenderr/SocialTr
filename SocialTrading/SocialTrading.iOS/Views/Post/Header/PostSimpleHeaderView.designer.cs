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
    [Register ("PostSimpleHeaderView")]
    partial class PostSimpleHeaderView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _avatarButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _dateLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _nameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _optionButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _rootView { get; set; }

        [Action ("_avatarButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void _avatarButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("_optionButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void _optionButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (_avatarButton != null) {
                _avatarButton.Dispose ();
                _avatarButton = null;
            }

            if (_dateLabel != null) {
                _dateLabel.Dispose ();
                _dateLabel = null;
            }

            if (_nameLabel != null) {
                _nameLabel.Dispose ();
                _nameLabel = null;
            }

            if (_optionButton != null) {
                _optionButton.Dispose ();
                _optionButton = null;
            }

            if (_rootView != null) {
                _rootView.Dispose ();
                _rootView = null;
            }
        }
    }
}