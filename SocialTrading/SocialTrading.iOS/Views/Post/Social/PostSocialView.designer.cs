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
    [Register ("PostSocialView")]
    partial class PostSocialView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _commentButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _likeButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _rootView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _shareButton { get; set; }

        [Action ("CommentButtonTouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CommentButtonTouchUpInside (UIKit.UIButton sender);

        [Action ("LikeButtonTouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void LikeButtonTouchUpInside (UIKit.UIButton sender);

        [Action ("ShareButtonTouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ShareButtonTouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (_commentButton != null) {
                _commentButton.Dispose ();
                _commentButton = null;
            }

            if (_likeButton != null) {
                _likeButton.Dispose ();
                _likeButton = null;
            }

            if (_rootView != null) {
                _rootView.Dispose ();
                _rootView = null;
            }

            if (_shareButton != null) {
                _shareButton.Dispose ();
                _shareButton = null;
            }
        }
    }
}