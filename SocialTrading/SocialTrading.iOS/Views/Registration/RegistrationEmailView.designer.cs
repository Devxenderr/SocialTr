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
    [Register ("RegistrationEmail")]
    partial class RegistrationEmailView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _backImageButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _emailEditText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _emailHeaderLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _emailLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView _featureImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _featureText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView _logoImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _nextButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _rootView { get; set; }

        [Action ("BackButtonTouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BackButtonTouchUpInside (UIKit.UIButton sender);

        [Action ("DidEndEmailEditText:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DidEndEmailEditText (UIKit.UITextField sender);

        [Action ("TouchUpInsideButtonNext:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TouchUpInsideButtonNext (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (_backImageButton != null) {
                _backImageButton.Dispose ();
                _backImageButton = null;
            }

            if (_emailEditText != null) {
                _emailEditText.Dispose ();
                _emailEditText = null;
            }

            if (_emailHeaderLabel != null) {
                _emailHeaderLabel.Dispose ();
                _emailHeaderLabel = null;
            }

            if (_emailLabel != null) {
                _emailLabel.Dispose ();
                _emailLabel = null;
            }

            if (_featureImage != null) {
                _featureImage.Dispose ();
                _featureImage = null;
            }

            if (_featureText != null) {
                _featureText.Dispose ();
                _featureText = null;
            }

            if (_logoImage != null) {
                _logoImage.Dispose ();
                _logoImage = null;
            }

            if (_nextButton != null) {
                _nextButton.Dispose ();
                _nextButton = null;
            }

            if (_rootView != null) {
                _rootView.Dispose ();
                _rootView = null;
            }
        }
    }
}