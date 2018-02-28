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
    [Register ("DetailedPostView")]
    partial class DetailedPostView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SocialTrading.iOS.PostBodyView _postBodyView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SocialTrading.iOS.PostHeaderView _postHeaderContainer { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SocialTrading.iOS.PostSocialView _postSocialView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _rootView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_postBodyView != null) {
                _postBodyView.Dispose ();
                _postBodyView = null;
            }

            if (_postHeaderContainer != null) {
                _postHeaderContainer.Dispose ();
                _postHeaderContainer = null;
            }

            if (_postSocialView != null) {
                _postSocialView.Dispose ();
                _postSocialView = null;
            }

            if (_rootView != null) {
                _rootView.Dispose ();
                _rootView = null;
            }
        }
    }
}