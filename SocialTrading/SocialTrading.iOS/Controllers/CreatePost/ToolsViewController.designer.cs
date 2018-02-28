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
    [Register ("ToolsViewController")]
    partial class ToolsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SocialTrading.iOS.CreatePostToolsView toolsView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (toolsView != null) {
                toolsView.Dispose ();
                toolsView = null;
            }
        }
    }
}