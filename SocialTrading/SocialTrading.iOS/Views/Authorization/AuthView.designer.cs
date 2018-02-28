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
    [Register ("AuthView")]
    partial class AuthView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _emailEditText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _emailLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _fbAuthButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _forgetPassButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _headerLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _logInButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView _logoImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _noAccountLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _passEditText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _passwordLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _registrationButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _rootView { get; set; }

        [Action ("EmailDidEndEditText:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void EmailDidEndEditText (UIKit.UITextField sender);

        [Action ("PassDidEndEditText:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PassDidEndEditText (UIKit.UITextField sender);

        [Action ("TouchUpInsideButtonAuth:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TouchUpInsideButtonAuth (UIKit.UIButton sender);

        [Action ("TouchUpInsideButtonFacebook:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TouchUpInsideButtonFacebook (UIKit.UIButton sender);

        [Action ("TouchUpInsideButtonForgot:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TouchUpInsideButtonForgot (UIKit.UIButton sender);

        [Action ("TouchUpInsideButtonReg:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TouchUpInsideButtonReg (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (_emailEditText != null) {
                _emailEditText.Dispose ();
                _emailEditText = null;
            }

            if (_emailLabel != null) {
                _emailLabel.Dispose ();
                _emailLabel = null;
            }

            if (_fbAuthButton != null) {
                _fbAuthButton.Dispose ();
                _fbAuthButton = null;
            }

            if (_forgetPassButton != null) {
                _forgetPassButton.Dispose ();
                _forgetPassButton = null;
            }

            if (_headerLabel != null) {
                _headerLabel.Dispose ();
                _headerLabel = null;
            }

            if (_logInButton != null) {
                _logInButton.Dispose ();
                _logInButton = null;
            }

            if (_logoImage != null) {
                _logoImage.Dispose ();
                _logoImage = null;
            }

            if (_noAccountLabel != null) {
                _noAccountLabel.Dispose ();
                _noAccountLabel = null;
            }

            if (_passEditText != null) {
                _passEditText.Dispose ();
                _passEditText = null;
            }

            if (_passwordLabel != null) {
                _passwordLabel.Dispose ();
                _passwordLabel = null;
            }

            if (_registrationButton != null) {
                _registrationButton.Dispose ();
                _registrationButton = null;
            }

            if (_rootView != null) {
                _rootView.Dispose ();
                _rootView = null;
            }
        }
    }
}