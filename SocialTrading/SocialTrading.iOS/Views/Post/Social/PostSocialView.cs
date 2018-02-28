using UIKit;
using Foundation;

using System;
using System.ComponentModel;
using Accelerate;
using SocialTrading.iOS.Theme;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.Vipers.Post.Interfaces.Social;
using SocialTrading.ThemesStyles.Implementation;

namespace SocialTrading.iOS
{
    [DesignTimeVisible(true)]
    public partial class PostSocialView : UIView, IComponent, IViewPostSocial
    {
		public IPresenterPostSocial Presenter { set; get; }
        private Action<string> _setTheme;

        #region IComponent realization
        public ISite Site { get; set; }
        public event EventHandler Disposed;
        #endregion


        public PostSocialView (IntPtr handle) : base (handle)
        {
        }


		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			if (Site != null)
			{
				return;
			}

			NSBundle.MainBundle.LoadNib("PostSocialView", this, null);

			InvokeOnMainThread(() =>
			{
				var frame = _rootView.Frame;
				frame.Height = Frame.Height;
				frame.Width = Frame.Width;
				_rootView.Frame = frame;
				AddSubview(_rootView);
			});
		}

        private void CleanImageForSmallDevice(IButtonTheme theme, bool left = true)
        {
            var w = UIScreen.MainScreen.Bounds.Width;
            if(w == 320 || w == 568)
            {
                if(left)
                {
					theme.ImageLeft = null;
                }
                else
                {
                    theme.ImageRight = null;
                }
            }
        }

        #region Event handlers

        partial void LikeButtonTouchUpInside(UIButton sender)
        {
            InvokeOnMainThread(() =>
            {
                Presenter.LikeClick();
            });
        }

        partial void CommentButtonTouchUpInside(UIButton sender)
        {
            InvokeOnMainThread(() =>
            {
                Presenter.CommentClick();
            });
        }

        partial void ShareButtonTouchUpInside(UIButton sender)
        {
            InvokeOnMainThread(() =>
            {
                Presenter.ShareClick();
            });
        }

        #endregion

        #region IViewPostSocial realization

        public void ShowAlert(string title, string message)
        {
            InvokeOnMainThread(() =>
            {
                var alert = new UIAlertView()
                {
                    Title = title,
                    Message = message
                };
                alert.AddButton(Presenter.GetOkLocale());
                alert.Show();
            });
        }

        public void SetLikeText(string like)
        {
            InvokeOnMainThread(() =>
            {
                _likeButton.SetTitle(like, UIControlState.Normal);
            });
        }

        public void SetCommentText(string comment)
        {
            InvokeOnMainThread(() =>
            {
                _commentButton.SetTitle(comment, UIControlState.Normal);
            });
        }

        public void SetShareText(string share)
        {
            InvokeOnMainThread(() =>
            {
                _shareButton.SetTitle(share, UIControlState.Normal);
            });
        }

        public void SetLikeDrawable(IButtonTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                CleanImageForSmallDevice(themeName);
                _likeButton.SetTheme(themeName);
            });
        }

        public void SetLikeTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _likeButton.SetImage(null, UIControlState.Normal);
                CleanImageForSmallDevice(theme);
                _likeButton.SetTheme(theme);
            });
        }

        public void SetCommentTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                CleanImageForSmallDevice(theme);

                _commentButton.SetTheme(theme);
            });
        }

        public void SetShareTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                CleanImageForSmallDevice(theme);
                _shareButton.SetTheme(theme);
            });
        }

        public void SetInteractionAvailable()
        {
            InvokeOnMainThread(() =>
            {
                _likeButton.Enabled = true;
                _commentButton.Enabled = true;
                _shareButton.Enabled = true;
            });
        }

        public void SetInteractionUnavailable()
        {
            InvokeOnMainThread(() =>
            {
                _likeButton.Enabled = false;
                _commentButton.Enabled = false;
                _shareButton.Enabled = false;
            });
        }

        public void SetConfig()
        {
        }

        #endregion
    }
}