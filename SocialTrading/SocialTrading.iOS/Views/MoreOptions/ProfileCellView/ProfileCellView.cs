using System;
using System.ComponentModel;

using UIKit;
using Foundation;
using CoreAnimation;

using SDWebImage;

using SocialTrading.iOS.Theme;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Vipers.ProfileCell.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;

namespace SocialTrading.iOS
{
    [DesignTimeVisible(true)]
    public partial class ProfileCellView : UIView, IComponent, IProfileCellView
    {
        public ProfileCellView (IntPtr handle) : base (handle)
        {
        }

        #region IComponent realization
        public ISite Site { get; set; }
        public IPresenterProfileCellForView Presenter { get; set; }

        public event EventHandler Disposed;
        #endregion

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            if (Site != null)
            {
                return;
            }

            NSBundle.MainBundle.LoadNib("ProfileCellView", this, null);

            InvokeOnMainThread(() =>
            {
                var frame = _rootView.Frame;
                frame.Height = Frame.Height;
                frame.Width = Frame.Width;
                _rootView.Frame = frame;
                AddSubview(_rootView);
            });

            MakeAvatarRound();
        }

        private void MakeAvatarRound()
        {
            _avatarImageView.Layer.MasksToBounds = true;
            var maskLayer = new CAShapeLayer
            {
                Path = UIBezierPath.FromOval(_avatarImageView.Bounds).CGPath
            };
            _avatarImageView.Layer.Mask = maskLayer;
        }

        public void SetConfig()
        {
            MakeAvatarRound();
        }

        public void SetAvatar(string image)
        {
            if (string.IsNullOrEmpty(image))
            {
                return;
            }
            _avatarImageView.SetImage(NSUrl.FromString(image));
        }

        public void SetAvatarTheme(IImageViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _avatarImageView.SetTheme(theme);
            });
        }

        public void SetBackgroundTheme(IViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _rootView.SetTheme(theme);
            });
        }

        public void SetName(string name)
        {
            InvokeOnMainThread(() =>
            {
                _userNameLabel.Text = name;
            });
        }

		public void SetProfileLabel(string data)
		{
            InvokeOnMainThread(() =>
            {
                _yourProfileLabel.Text = data;
            });
		}

        public void SetNameTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _userNameLabel.SetTheme(theme);
            });
        }

        public void SetProfileLabelTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _yourProfileLabel.SetTheme(theme);
            });
        }
    }
}