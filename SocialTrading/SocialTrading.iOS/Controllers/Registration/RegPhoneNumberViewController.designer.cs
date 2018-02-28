// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SocialTrading.iOS
{
    [Register ("RegPhoneNumberViewController")]
    partial class RegPhoneNumberViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SocialTrading.iOS.RegistrationPhoneNumberView _registrationPhoneNumber { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_registrationPhoneNumber != null) {
                _registrationPhoneNumber.Dispose ();
                _registrationPhoneNumber = null;
            }
        }
    }
}