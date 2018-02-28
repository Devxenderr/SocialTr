using UIKit;
using Foundation;

using System;
using System.ComponentModel;

using SDWebImage;

using SocialTrading.Locale;
using SocialTrading.iOS.Theme;
using SocialTrading.Vipers.Post.Interfaces.Header;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using CoreAnimation;

namespace SocialTrading.iOS
{
    [DesignTimeVisible(true)]
    public partial class PostSimpleHeaderView : UIView, IComponent, IViewPostHeader
    {
        public PostSimpleHeaderView(IntPtr handle) : base(handle)
        {
        }

        public PostSimpleHeaderView() : base()
        {
            NSBundle.MainBundle.LoadNib("PostSimpleHeaderView", this, null);

            InvokeOnMainThread(() =>
            {
                var frame = _rootView.Frame;
                frame.Height = Frame.Height;
                frame.Width = Frame.Width;
                _rootView.Frame = frame;
                AddSubview(_rootView);
            });

            SetNeedsLayout();
            SetNeedsUpdateConstraints();
        }

        public ISite Site { get; set; }
        public IPresenterPostHeader Presenter { private get; set; }

        public event EventHandler Disposed;

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            if (Site != null)
            {
                return;
            }
        }


        #region Actions
        partial void _optionButton_TouchUpInside(UIButton sender)
        {
            Presenter.OptionsClick();
        }

        partial void _avatarButton_TouchUpInside(UIButton sender)
        {
            Presenter.ProfileClick();
        }

        #endregion

        #region PostSimpleHeader

        public void SetConfig()
        {
            MakeAvatarRound();
        }

        public void ShowDeletingDialog(string message, string title, string okButtonText, string cancelButtonText)
        {
            ShowAlert(title, message, okButtonText, delegate { Presenter.ConfirmDeleteClick(); });
        }

        private void ShowAlert(string title, string message, string okButtonText, Action Act)
        {
            var alert = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

            alert.AddAction(UIAlertAction.Create(Localization.Lang.Cancel, UIAlertActionStyle.Cancel, null));
            alert.AddAction(UIAlertAction.Create(okButtonText, UIAlertActionStyle.Default, action => Act()));
            InvokeOnMainThread(() =>
            {
                UIApplication.SharedApplication.KeyWindow.RootViewController.ModalViewController.PresentViewController(alert, true, null);
            });
        }

        public void CacheImage(string imageUrl)
        {
            /* TODO
            using (var url = new NSUrl(imageUrl))
            using (var data = NSData.FromUrl(url))
            {
                if (data != null)
                {
                    NSData imageData = UIImage.LoadFromData(data).AsPNG();
                    string encodedImage = imageData.GetBase64EncodedData(NSDataBase64EncodingOptions.None).ToString();

                    Presenter.SaveCachedImage(encodedImage);
                }
            }
            */
        }


        public void MoreOptionsButtonTheme(IImageButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _optionButton.SetTheme((IImageViewTheme)theme);
            });
        }

        public void OptionsDialogShow(string title, string delete, string edit)
        {
            var alert = UIAlertController.Create(null, "", UIAlertControllerStyle.ActionSheet);

            alert.AddAction(UIAlertAction.Create(Localization.Lang.Cancel, UIAlertActionStyle.Cancel, null));
            alert.AddAction(UIAlertAction.Create(edit, UIAlertActionStyle.Default, action => Presenter.EditClick()));
            alert.AddAction(UIAlertAction.Create(delete, UIAlertActionStyle.Default, action => Presenter.DeleteClick()));
            InvokeOnMainThread(() =>
            {
                UIApplication.SharedApplication.KeyWindow.RootViewController.ModalViewController.PresentViewController(alert, true, null);
            });
        }

        public void OptionsHide()
        {
            _optionButton.Hidden = true;
        }

        public void OptionsShow()
        {
            _optionButton.Hidden = false;
        }

        public void SetAvatar(string urlAvatar)
        {
            if (string.IsNullOrEmpty(urlAvatar))
            {
                return;
            }

            _avatarButton.SetBackgroundImage(new NSUrl(urlAvatar), UIControlState.Normal);
        }

        public void SetCreateTime(string time)
        {
            InvokeOnMainThread(() =>
            {
                _dateLabel.Text = time;
            });
        }


        public void SetDateTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _dateLabel.SetTheme(theme);
            });
        }

        public void SetDefaultAvatar(IImageViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _avatarButton.SetTheme(theme);
            });
        }

        public void SetName(string name)
        {
            InvokeOnMainThread(() =>
            {
                _nameLabel.Text = name;
            });
        }

        public void SetFirstLastNameTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _nameLabel.SetTheme(theme);
            });
        }

        public void ShowErrorAlert(string message, string title)
        {
            var alert = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

            alert.AddAction(UIAlertAction.Create(Localization.Lang.Cancel, UIAlertActionStyle.Cancel, null));

            InvokeOnMainThread(() =>
            {
                UIApplication.SharedApplication.KeyWindow.RootViewController.ModalViewController.PresentViewController(alert, true, null);
            });
        }
        #endregion

        private void MakeAvatarRound()
        {
            _avatarButton.Layer.MasksToBounds = true;
            var maskLayer = new CAShapeLayer
            {
                Path = UIBezierPath.FromOval(_avatarButton.Bounds).CGPath
            };
            _avatarButton.Layer.Mask = maskLayer;
        }

        public void SetStateOnline(IImageViewTheme theme)
        {
        }

        public double GetPreviousPrice()
        {
            return 0;
            throw new NotImplementedException();
        }

        public void SetBuySellTheme(ITextViewTheme theme)
        {
            
        }

        public void SetBuySellValueTheme(ITextViewTheme theme)
        {
            
        }
        public void SetCurrentPrice(string currentPrice, int position)
        {
            
        }

        public void SetCurrentPriceImg(IImageViewTheme theme)
        {
            
        }

        public void SetCurrentPriceTheme(ITextViewTheme theme)
        {
            
        }
        public void SetDifference(string difference)
        {
            
        }

        public void SetDifferenceLocale(string v)
        {
            
        }

        public void SetDifferenceValue(ITextViewTheme theme)
        {
            
        }

        public void SetDiffTheme(ITextViewTheme theme)
        {
            
        }

        public void SetDiffValueTheme(ITextViewTheme theme)
        {
            
        }

        public void SetFavoriteState(bool state, IImageButtonTheme theme)
        {
            
        }

        public void SetForecastTheme(ITextViewTheme theme)
        {
            
        }

        public void SetForecastTime(string time)
        {
            
        }

        public void SetQuote(string quote)
        {
            
        }

        public void SetQuoteTheme(ITextViewTheme theme)
        {
            
        }

        public void SetRecommend(string recommend)
        {
            
        }

        public void SetRecommendBuySellImage(IImageViewTheme theme)
        {
            
        }

        public void SetRecommendValue(string recommend, int position)
        {
            
        }

    }
}