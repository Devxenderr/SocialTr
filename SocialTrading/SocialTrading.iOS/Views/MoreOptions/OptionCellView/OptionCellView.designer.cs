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
    [Register ("OptionCellView")]
    partial class OptionCellView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _backgroundView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView _optionImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _optionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _rootView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_backgroundView != null) {
                _backgroundView.Dispose ();
                _backgroundView = null;
            }

            if (_optionImageView != null) {
                _optionImageView.Dispose ();
                _optionImageView = null;
            }

            if (_optionLabel != null) {
                _optionLabel.Dispose ();
                _optionLabel = null;
            }

            if (_rootView != null) {
                _rootView.Dispose ();
                _rootView = null;
            }
        }
    }
}