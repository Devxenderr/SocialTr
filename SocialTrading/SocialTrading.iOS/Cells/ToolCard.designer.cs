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
    [Register ("ToolCard")]
    partial class ToolCard
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _toolLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_toolLabel != null) {
                _toolLabel.Dispose ();
                _toolLabel = null;
            }
        }
    }
}