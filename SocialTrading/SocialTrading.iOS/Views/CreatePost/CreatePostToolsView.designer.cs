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
    [Register ("CreatePostToolsView")]
    partial class CreatePostToolsView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _rootView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchBar _searchBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SocialTrading.iOS.ToolTableView _toolsCollectionView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_rootView != null) {
                _rootView.Dispose ();
                _rootView = null;
            }

            if (_searchBar != null) {
                _searchBar.Dispose ();
                _searchBar = null;
            }

            if (_toolsCollectionView != null) {
                _toolsCollectionView.Dispose ();
                _toolsCollectionView = null;
            }
        }
    }
}