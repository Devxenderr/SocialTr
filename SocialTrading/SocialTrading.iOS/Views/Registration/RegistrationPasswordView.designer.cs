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
    [Register ("RegistrationPassword")]
    partial class RegistrationPasswordView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _backImageButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _confirmPassEditText { get; set; }

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
        UIKit.UITextField _passEditText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _passwordConfirmLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _passwordHeader { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _passwordLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _registerButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _rootView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _userAgreementLink { get; set; }

        [Action ("BackButtonTouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BackButtonTouchUpInside (UIKit.UIButton sender);

        [Action ("ChangedEditTextConfirmPass:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ChangedEditTextConfirmPass (UIKit.UITextField sender);

        [Action ("ChangedEditTextPass:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ChangedEditTextPass (UIKit.UITextField sender);

        [Action ("DidEndEditTextPass:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DidEndEditTextPass (UIKit.UITextField sender);

        [Action ("TouchUpInsideButtonReg:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TouchUpInsideButtonReg (UIKit.UIButton sender);

        [Action ("TouchUpInsideButtonUserAgreement:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TouchUpInsideButtonUserAgreement (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (_backImageButton != null) {
                _backImageButton.Dispose ();
                _backImageButton = null;
            }

            if (_confirmPassEditText != null) {
                _confirmPassEditText.Dispose ();
                _confirmPassEditText = null;
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

            if (_passEditText != null) {
                _passEditText.Dispose ();
                _passEditText = null;
            }

            if (_passwordConfirmLabel != null) {
                _passwordConfirmLabel.Dispose ();
                _passwordConfirmLabel = null;
            }

            if (_passwordHeader != null) {
                _passwordHeader.Dispose ();
                _passwordHeader = null;
            }

            if (_passwordLabel != null) {
                _passwordLabel.Dispose ();
                _passwordLabel = null;
            }

            if (_registerButton != null) {
                _registerButton.Dispose ();
                _registerButton = null;
            }

            if (_rootView != null) {
                _rootView.Dispose ();
                _rootView = null;
            }

            if (_userAgreementLink != null) {
                _userAgreementLink.Dispose ();
                _userAgreementLink = null;
            }
        }
    }
}