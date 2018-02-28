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
    [Register ("ForgotPassView")]
    partial class ForgotPassView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _backButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _emailEditText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _emailLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _forgotPassHeaderLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView _logoImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _passRecoveryButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _rootView { get; set; }

        [Action ("BackButtonTouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BackButtonTouchUpInside (UIKit.UIButton sender);

        [Action ("TouchUpInsideButtonPassRetrieval:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TouchUpInsideButtonPassRetrieval (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (_backButton != null) {
                _backButton.Dispose ();
                _backButton = null;
            }

            if (_emailEditText != null) {
                _emailEditText.Dispose ();
                _emailEditText = null;
            }

            if (_emailLabel != null) {
                _emailLabel.Dispose ();
                _emailLabel = null;
            }

            if (_forgotPassHeaderLabel != null) {
                _forgotPassHeaderLabel.Dispose ();
                _forgotPassHeaderLabel = null;
            }

            if (_logoImage != null) {
                _logoImage.Dispose ();
                _logoImage = null;
            }

            if (_passRecoveryButton != null) {
                _passRecoveryButton.Dispose ();
                _passRecoveryButton = null;
            }

            if (_rootView != null) {
                _rootView.Dispose ();
                _rootView = null;
            }
        }
    }
}