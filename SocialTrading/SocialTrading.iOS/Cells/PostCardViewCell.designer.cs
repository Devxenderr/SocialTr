// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace SocialTrading.iOS.Cells
{
    [Register ("PostCardViewCell")]
    partial class PostCardViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SocialTrading.iOS.PostView _postView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_postView != null) {
                _postView.Dispose ();
                _postView = null;
            }
        }
    }
}