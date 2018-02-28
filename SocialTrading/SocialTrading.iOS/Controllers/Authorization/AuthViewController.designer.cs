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
    [Register ("AuthViewController")]
    partial class AuthViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SocialTrading.iOS.AuthView _authView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_authView != null) {
                _authView.Dispose ();
                _authView = null;
            }
        }
    }
}