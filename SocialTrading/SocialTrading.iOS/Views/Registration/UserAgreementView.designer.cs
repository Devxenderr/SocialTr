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
    [Register ("UserAgreementView")]
    partial class UserAgreementView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _backButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _rootView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton acceptButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton declineButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView tf_user_agreement_userAgreement { get; set; }

        [Action ("BackButtonTouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BackButtonTouchUpInside (UIKit.UIButton sender);

        [Action ("TouchUpInsideButtonUserAgreementAccept:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TouchUpInsideButtonUserAgreementAccept (UIKit.UIButton sender);

        [Action ("TouchUpInsideButtonUserAgreementDecline:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TouchUpInsideButtonUserAgreementDecline (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (_backButton != null) {
                _backButton.Dispose ();
                _backButton = null;
            }

            if (_rootView != null) {
                _rootView.Dispose ();
                _rootView = null;
            }

            if (acceptButton != null) {
                acceptButton.Dispose ();
                acceptButton = null;
            }

            if (declineButton != null) {
                declineButton.Dispose ();
                declineButton = null;
            }

            if (tf_user_agreement_userAgreement != null) {
                tf_user_agreement_userAgreement.Dispose ();
                tf_user_agreement_userAgreement = null;
            }
        }
    }
}