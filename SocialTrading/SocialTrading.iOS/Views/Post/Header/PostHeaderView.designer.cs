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
    [Register ("PostHeaderView")]
    partial class PostHeaderView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _avatarButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView _buySellImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _buySellLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _buySellValueLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _buySellView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _currentPriceValueLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _dateLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _diffImageButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _favoriteButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _forecastTimeValueLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _nameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _optionButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _profitLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _profitValueLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _quoteLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView _rootView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView _statusUserImageView { get; set; }

        [Action ("AvatarButtonTouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AvatarButtonTouchUpInside (UIKit.UIButton sender);

        [Action ("FavoriteButtonTouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void FavoriteButtonTouchUpInside (UIKit.UIButton sender);

        [Action ("OptionsButtonTouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void OptionsButtonTouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (_avatarButton != null) {
                _avatarButton.Dispose ();
                _avatarButton = null;
            }

            if (_buySellImageView != null) {
                _buySellImageView.Dispose ();
                _buySellImageView = null;
            }

            if (_buySellLabel != null) {
                _buySellLabel.Dispose ();
                _buySellLabel = null;
            }

            if (_buySellValueLabel != null) {
                _buySellValueLabel.Dispose ();
                _buySellValueLabel = null;
            }

            if (_buySellView != null) {
                _buySellView.Dispose ();
                _buySellView = null;
            }

            if (_currentPriceValueLabel != null) {
                _currentPriceValueLabel.Dispose ();
                _currentPriceValueLabel = null;
            }

            if (_dateLabel != null) {
                _dateLabel.Dispose ();
                _dateLabel = null;
            }

            if (_diffImageButton != null) {
                _diffImageButton.Dispose ();
                _diffImageButton = null;
            }

            if (_favoriteButton != null) {
                _favoriteButton.Dispose ();
                _favoriteButton = null;
            }

            if (_forecastTimeValueLabel != null) {
                _forecastTimeValueLabel.Dispose ();
                _forecastTimeValueLabel = null;
            }

            if (_nameLabel != null) {
                _nameLabel.Dispose ();
                _nameLabel = null;
            }

            if (_optionButton != null) {
                _optionButton.Dispose ();
                _optionButton = null;
            }

            if (_profitLabel != null) {
                _profitLabel.Dispose ();
                _profitLabel = null;
            }

            if (_profitValueLabel != null) {
                _profitValueLabel.Dispose ();
                _profitValueLabel = null;
            }

            if (_quoteLabel != null) {
                _quoteLabel.Dispose ();
                _quoteLabel = null;
            }

            if (_rootView != null) {
                _rootView.Dispose ();
                _rootView = null;
            }

            if (_statusUserImageView != null) {
                _statusUserImageView.Dispose ();
                _statusUserImageView = null;
            }
        }
    }
}