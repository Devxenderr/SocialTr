using UIKit;
﻿using Foundation;

using System;
using System.ComponentModel;

using SDWebImage;

using SocialTrading.Locale;
using SocialTrading.iOS.Theme;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Vipers.Post.Interfaces.Header;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using CoreAnimation;

namespace SocialTrading.iOS
{
	[DesignTimeVisible(true)]
	public partial class PostHeaderView : UIView, IComponent, IViewPostHeader
	{
		public PostHeaderView(IntPtr handle) : base(handle)
		{
		}

        public PostHeaderView() : base()
        {
            NSBundle.MainBundle.LoadNib("PostHeaderView", this, null);

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

        private bool isFavorite;
	

        public event EventHandler Disposed;

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
            if (Site != null)
            {
                return;
            }

            NSBundle.MainBundle.LoadNib("PostHeaderView", this, null);

            InvokeOnMainThread(() =>
            {
                var frame = _rootView.Frame;
                frame.Height = Frame.Height;
                frame.Width = Frame.Width;
                _rootView.Frame = frame;
                AddSubview(_rootView);
            });

		}

		public void SetConfig()
		{
            _statusUserImageView.Hidden = true; //TODO remove hardcode
            _favoriteButton.Hidden = true; //TODO remove hardcode
            MakeAvatarRound();
        }

		#region Actions

		partial void AvatarButtonTouchUpInside(UIButton sender)
		{
			Presenter.ProfileClick();
		}

        partial void FavoriteButtonTouchUpInside(UIButton sender)
        {
            Presenter.FavoriteClick(isFavorite);
        }

        partial void OptionsButtonTouchUpInside(UIButton sender)
        {
            Presenter.OptionsClick();
        }

		#endregion

		public void ShowDeletingDialog(string message, string title, string okButtonText, string cancelButtonText)
		{
            ShowAlert(title, message,okButtonText, delegate { Presenter.ConfirmDeleteClick(); });		
		}


		private void ShowAlert(string title, string message, string okButtonText,  Action Act)
        {
            var alert = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

            alert.AddAction(UIAlertAction.Create(Localization.Lang.Cancel, UIAlertActionStyle.Cancel, null));
            alert.AddAction(UIAlertAction.Create(okButtonText, UIAlertActionStyle.Default, action => Act()));
			InvokeOnMainThread(() =>
			{
				UIApplication.SharedApplication.KeyWindow.RootViewController.ModalViewController.PresentViewController(alert, true, null);
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

        public void ShowErrorAlert(string message, string title)
        {
            var alert = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

            alert.AddAction(UIAlertAction.Create(Localization.Lang.Cancel, UIAlertActionStyle.Cancel, null));
           
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


        #region SetText

        public void SetCreateTime(string time)
		{
			InvokeOnMainThread(() =>
			{
				_dateLabel.Text = time;
			});
		}

		public void SetDiff(string diff)
		{
			InvokeOnMainThread(() =>
			{
                _profitValueLabel.Text = diff;
			});
		}

		public void SetForecastTime(string time)
		{
			InvokeOnMainThread(() =>
			{
				_forecastTimeValueLabel.Text = time;
			});
		}

        public void SetName(string name)
		{
			InvokeOnMainThread(() =>
			{
                _nameLabel.Text = name;
			});
		}

		public void SetQuote(string quote)
		{
			InvokeOnMainThread(() =>
			{
				_quoteLabel.Text = quote;
			});
		}

		public void SetRecommend(string recommend)
		{
			InvokeOnMainThread(() =>
			{
				_buySellLabel.Text = recommend;
			});
		}


		public void SetRecommendValue(string recommend, int position)
		{
			InvokeOnMainThread(() =>
			  {
                  // _buySellValueLabel.SetThemeDifferentLetterSize(recommend, position);
			       _buySellValueLabel.Text = recommend;
              });
		}

		public void SetCurrentPrice(string currentPrice, int position)
		{
			InvokeOnMainThread(() =>
            {
				_currentPriceValueLabel.SetThemeDifferentLetterSize(currentPrice, position);
			});
		}

		public void SetDifference(string difference)
		{
			InvokeOnMainThread(() =>
			{
                _profitValueLabel.Text = difference;
			});
		}

		#endregion

        public void SetAvatar(string image)
		{
            if(string.IsNullOrEmpty(image))
            {
                return;
            }

            _avatarButton.SetBackgroundImage(new NSUrl(image), UIControlState.Normal);
		}

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
        }

        private void MakeAvatarRound()
        {
            _avatarButton.Layer.MasksToBounds = true;
            var maskLayer = new CAShapeLayer
            {
                Path = UIBezierPath.FromOval(_avatarButton.Bounds).CGPath
            };
            _avatarButton.Layer.Mask = maskLayer;
        }

        private UIImage FromBase64(string base64)
        {
            var encodedDataAsBytes = Convert.FromBase64String(base64);
            var data = NSData.FromArray(encodedDataAsBytes);

            return UIImage.LoadFromData(data);
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

        public void SetDefaultAvatar(IImageViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _avatarButton.SetTheme(theme);
            });
        }       

        public void SetRecommendBuySellImage(IImageViewTheme theme)
        {
			InvokeOnMainThread(() =>
            {
                _buySellImageView.SetTheme(theme);
                _buySellView.SetTheme((IViewTheme) theme);
			});
        }

        public void SetFavoriteState(bool state, IImageButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _favoriteButton.SetTheme((IButtonTheme) theme);
            });
            isFavorite = state;
        }

        public void SetStateOnline(IImageViewTheme theme)
        {
			InvokeOnMainThread(() =>
			{
                _statusUserImageView.SetTheme(theme);
			});
        }

        public void SetCurrentPriceImg(IImageViewTheme theme)
        {
			InvokeOnMainThread(() =>
			{
                _diffImageButton.SetTheme(theme);
			});
        }

        public void SetDifferenceValue(ITextViewTheme theme)
        {
			InvokeOnMainThread(() =>
			 {
                _profitValueLabel.SetTheme(theme);
			 });
        }

        public double GetPreviousPrice()
        {
            return Convert.ToDouble(_buySellValueLabel.Text);
        }

        #region SetTheme

        public void MoreOptionsButtonTheme(IImageButtonTheme theme)
        {
			InvokeOnMainThread(() =>
			 {
                _optionButton.SetTheme((IImageViewTheme) theme);
			 });
        }

        public void SetFirstLastNameTheme(ITextViewTheme theme)
        {
			InvokeOnMainThread(() =>
			{
                _nameLabel.SetTheme(theme);
			});
        }

        public void SetDateTheme(ITextViewTheme theme)
        {
			InvokeOnMainThread(() =>
			 {
                _dateLabel.SetTheme(theme);
			 });
        }

        public void SetQuoteTheme(ITextViewTheme theme)
        {
			InvokeOnMainThread(() =>
			{
                _quoteLabel.SetTheme(theme);
			});
        }

        public void SetBuySellTheme(ITextViewTheme theme)
        {
			InvokeOnMainThread(() =>
			{
                _buySellLabel.SetTheme(theme);
			});
        }

        public void SetBuySellValueTheme(ITextViewTheme theme)
        {
			InvokeOnMainThread(() =>
			{
                _buySellValueLabel.SetTheme(theme);
			});
        }

        public void SetForecastTheme(ITextViewTheme theme)
        {
			InvokeOnMainThread(() =>
			{
                _forecastTimeValueLabel.SetTheme(theme);
			});
        }

        public void SetCurrentPriceTheme(ITextViewTheme theme)
        {
			InvokeOnMainThread(() =>
			{
                _currentPriceValueLabel.SetTheme(theme);
			});
        }

        public void SetDiffTheme(ITextViewTheme theme)
        {
			InvokeOnMainThread(() =>
			 {
                _profitLabel.SetTheme(theme);
			 });
        }

        public void SetDiffValueTheme(ITextViewTheme theme)
        {
			InvokeOnMainThread(() =>
			 {
                _profitValueLabel.SetTheme(theme);
			 });
        }

        #endregion

        public void SetDifferenceLocale(string diff)
        {
			InvokeOnMainThread(() =>
			 {
                 _profitLabel.Text = diff;
			 });
        }
    }
}