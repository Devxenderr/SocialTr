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
    [Register ("EditProfileView")]
    partial class EditProfileView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _cancelButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _lastNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _lastNameTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _nameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _nameTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _rootView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _saveButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _statusLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _statusTextField { get; set; }

        [Action ("_cancelButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void _cancelButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("_lastNameTextField_DidEnd:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void _lastNameTextField_DidEnd (UIKit.UITextField sender);

        [Action ("_nameTextField_DidEnd:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void _nameTextField_DidEnd (UIKit.UITextField sender);

        [Action ("_saveButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void _saveButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("_statusTextField_DidEnd:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void _statusTextField_DidEnd (UIKit.UITextField sender);

        void ReleaseDesignerOutlets ()
        {
            if (_cancelButton != null) {
                _cancelButton.Dispose ();
                _cancelButton = null;
            }

            if (_lastNameLabel != null) {
                _lastNameLabel.Dispose ();
                _lastNameLabel = null;
            }

            if (_lastNameTextField != null) {
                _lastNameTextField.Dispose ();
                _lastNameTextField = null;
            }

            if (_nameLabel != null) {
                _nameLabel.Dispose ();
                _nameLabel = null;
            }

            if (_nameTextField != null) {
                _nameTextField.Dispose ();
                _nameTextField = null;
            }

            if (_rootView != null) {
                _rootView.Dispose ();
                _rootView = null;
            }

            if (_saveButton != null) {
                _saveButton.Dispose ();
                _saveButton = null;
            }

            if (_statusLabel != null) {
                _statusLabel.Dispose ();
                _statusLabel = null;
            }

            if (_statusTextField != null) {
                _statusTextField.Dispose ();
                _statusTextField = null;
            }
        }
    }
}