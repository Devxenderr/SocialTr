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
    [Register ("CountriesViewController")]
    partial class CountriesViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SocialTrading.iOS.CreatePostToolsView _countriesView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_countriesView != null) {
                _countriesView.Dispose ();
                _countriesView = null;
            }
        }
    }
}