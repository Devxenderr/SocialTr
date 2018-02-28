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
    [Register ("OptionsTableViewCell")]
    partial class OptionsTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SocialTrading.iOS.OptionCellView _optionsCellView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_optionsCellView != null) {
                _optionsCellView.Dispose ();
                _optionsCellView = null;
            }
        }
    }
}