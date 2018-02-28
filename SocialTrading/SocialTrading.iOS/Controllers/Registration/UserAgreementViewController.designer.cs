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
    [Register ("UserAgreementViewController")]
    partial class UserAgreementViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SocialTrading.iOS.UserAgreementView _userAgreementView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_userAgreementView != null) {
                _userAgreementView.Dispose ();
                _userAgreementView = null;
            }
        }
    }
}