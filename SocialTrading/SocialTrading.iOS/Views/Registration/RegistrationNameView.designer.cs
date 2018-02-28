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
    [Register ("RegistrationName")]
    partial class RegistrationNameView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _backImageButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView _featureImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _featureText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _firstNameEditText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _lastNameEditText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _lastNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView _logoImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _nameHeader { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _nameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _nextButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _rootView { get; set; }

        [Action ("BackButtonTouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BackButtonTouchUpInside (UIKit.UIButton sender);

        [Action ("DidEndFirstNameEditText:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DidEndFirstNameEditText (UIKit.UITextField sender);

        [Action ("DidEndLastNameEditText:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DidEndLastNameEditText (UIKit.UITextField sender);

        [Action ("TouchUpInsideButtonNext:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TouchUpInsideButtonNext (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (_backImageButton != null) {
                _backImageButton.Dispose ();
                _backImageButton = null;
            }

            if (_featureImage != null) {
                _featureImage.Dispose ();
                _featureImage = null;
            }

            if (_featureText != null) {
                _featureText.Dispose ();
                _featureText = null;
            }

            if (_firstNameEditText != null) {
                _firstNameEditText.Dispose ();
                _firstNameEditText = null;
            }

            if (_lastNameEditText != null) {
                _lastNameEditText.Dispose ();
                _lastNameEditText = null;
            }

            if (_lastNameLabel != null) {
                _lastNameLabel.Dispose ();
                _lastNameLabel = null;
            }

            if (_logoImage != null) {
                _logoImage.Dispose ();
                _logoImage = null;
            }

            if (_nameHeader != null) {
                _nameHeader.Dispose ();
                _nameHeader = null;
            }

            if (_nameLabel != null) {
                _nameLabel.Dispose ();
                _nameLabel = null;
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