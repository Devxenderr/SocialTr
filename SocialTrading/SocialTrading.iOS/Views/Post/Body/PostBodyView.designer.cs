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
    [Register ("PostBodyView")]
    partial class PostBodyView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint _contentDownConstraint { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _contentLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint _contentUpConstraint { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint _heightImageConstraint { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView _image { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _rootView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint _widthImageConstraint { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_contentDownConstraint != null) {
                _contentDownConstraint.Dispose ();
                _contentDownConstraint = null;
            }

            if (_contentLabel != null) {
                _contentLabel.Dispose ();
                _contentLabel = null;
            }

            if (_contentUpConstraint != null) {
                _contentUpConstraint.Dispose ();
                _contentUpConstraint = null;
            }

            if (_heightImageConstraint != null) {
                _heightImageConstraint.Dispose ();
                _heightImageConstraint = null;
            }

            if (_image != null) {
                _image.Dispose ();
                _image = null;
            }

            if (_rootView != null) {
                _rootView.Dispose ();
                _rootView = null;
            }

            if (_widthImageConstraint != null) {
                _widthImageConstraint.Dispose ();
                _widthImageConstraint = null;
            }
        }
    }
}