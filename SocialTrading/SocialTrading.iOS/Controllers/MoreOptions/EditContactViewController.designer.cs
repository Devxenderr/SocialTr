// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace SocialTrading.iOS.Controllers.MoreOptions
{
    [Register ("EditContactViewController")]
    partial class EditContactViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SocialTrading.iOS.Views.EditContact.EditContactView _editContactView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_editContactView != null) {
                _editContactView.Dispose ();
                _editContactView = null;
            }
        }
    }
}