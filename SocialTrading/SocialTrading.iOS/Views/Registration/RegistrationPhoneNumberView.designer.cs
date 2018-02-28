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
    [Register ("RegistrationPhoneNumberView")]
    partial class RegistrationPhoneNumberView
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
        UIKit.UILabel _headerLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView _logoImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _nextButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _phoneCountryLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _phoneCountryTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _phoneNumberLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _phoneNumberTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _rootView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _skipButton { get; set; }

        [Action ("BackButtonTouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BackButtonTouchUpInside (UIKit.UIButton sender);

        [Action ("NextButtonTouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void NextButtonTouchUpInside (UIKit.UIButton sender);

        [Action ("PhoneCountryDidEnd:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PhoneCountryDidEnd (UIKit.UITextField sender);

        [Action ("PhoneCountryValueChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PhoneCountryValueChanged (UIKit.UITextField sender);

        [Action ("PhoneNumberDidEnd:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PhoneNumberDidEnd (UIKit.UITextField sender);

        [Action ("SkipButtonTouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SkipButtonTouchUpInside (UIKit.UIButton sender);

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

            if (_headerLabel != null) {
                _headerLabel.Dispose ();
                _headerLabel = null;
            }

            if (_logoImage != null) {
                _logoImage.Dispose ();
                _logoImage = null;
            }

            if (_nextButton != null) {
                _nextButton.Dispose ();
                _nextButton = null;
            }

            if (_phoneCountryLabel != null) {
                _phoneCountryLabel.Dispose ();
                _phoneCountryLabel = null;
            }

            if (_phoneCountryTextField != null) {
                _phoneCountryTextField.Dispose ();
                _phoneCountryTextField = null;
            }

            if (_phoneNumberLabel != null) {
                _phoneNumberLabel.Dispose ();
                _phoneNumberLabel = null;
            }

            if (_phoneNumberTextField != null) {
                _phoneNumberTextField.Dispose ();
                _phoneNumberTextField = null;
            }

            if (_rootView != null) {
                _rootView.Dispose ();
                _rootView = null;
            }

            if (_skipButton != null) {
                _skipButton.Dispose ();
                _skipButton = null;
            }
        }
    }
}