// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace SocialTrading.iOS.Views.EditContact
{
    [Register ("EditContactView")]
    partial class EditContactView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _cancelButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _cityLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _cityTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _countryLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _countryTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _emailLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _emailTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _phoneLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _phoneTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _rootView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _saveButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _skypeLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _skypeTextField { get; set; }

        [Action ("CancelTouchUp:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CancelTouchUp (UIKit.UIButton sender);

        [Action ("CityDidEndEditing:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CityDidEndEditing (UIKit.UITextField sender);

        [Action ("PhoneDidEndEditing:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PhoneDidEndEditing (UIKit.UITextField sender);

        [Action ("SaveTouchUp:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SaveTouchUp (UIKit.UIButton sender);

        [Action ("SkypeDidEndEditing:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SkypeDidEndEditing (UIKit.UITextField sender);

        void ReleaseDesignerOutlets ()
        {
            if (_cancelButton != null) {
                _cancelButton.Dispose ();
                _cancelButton = null;
            }

            if (_cityLabel != null) {
                _cityLabel.Dispose ();
                _cityLabel = null;
            }

            if (_cityTextField != null) {
                _cityTextField.Dispose ();
                _cityTextField = null;
            }

            if (_countryLabel != null) {
                _countryLabel.Dispose ();
                _countryLabel = null;
            }

            if (_countryTextField != null) {
                _countryTextField.Dispose ();
                _countryTextField = null;
            }

            if (_emailLabel != null) {
                _emailLabel.Dispose ();
                _emailLabel = null;
            }

            if (_emailTextField != null) {
                _emailTextField.Dispose ();
                _emailTextField = null;
            }

            if (_phoneLabel != null) {
                _phoneLabel.Dispose ();
                _phoneLabel = null;
            }

            if (_phoneTextField != null) {
                _phoneTextField.Dispose ();
                _phoneTextField = null;
            }

            if (_rootView != null) {
                _rootView.Dispose ();
                _rootView = null;
            }

            if (_saveButton != null) {
                _saveButton.Dispose ();
                _saveButton = null;
            }

            if (_skypeLabel != null) {
                _skypeLabel.Dispose ();
                _skypeLabel = null;
            }

            if (_skypeTextField != null) {
                _skypeTextField.Dispose ();
                _skypeTextField = null;
            }
        }
    }
}