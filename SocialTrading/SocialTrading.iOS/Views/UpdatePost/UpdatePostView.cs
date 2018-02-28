using UIKit;
using Foundation;

using System;
using System.ComponentModel;
using System.Collections.Generic;
using CoreAnimation;
using SDWebImage;

using SocialTrading.Tools;
using SocialTrading.iOS.Theme;
using SocialTrading.iOS.Tools;
using SocialTrading.iOS.Views;
using SocialTrading.Tools.Interfaces;
using SocialTrading.Tools.Enumerations;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Vipers.UpdatePost.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

namespace SocialTrading.iOS
{
    public partial class UpdatePostView : UIView, IComponent, IViewUpdatePost, ISubscriber
    {
        public IPresenterUpdatePost Presenter { get; set; }
        public UINavigationItem NavigationItem { private get; set; }
        public UINavigationBar NavigationBar { private get; set; }

        public string AttachmentImage
        {
            private set => Presenter.SaveAttachedImage(value);
            get => Presenter.LoadAttachedImage() ?? string.Empty;
        }

        private List<string> _access;
        private UISpinnerView _spinner = null;
        private UIBarButtonItem _backButton;
        private UIBarButtonItem _publishButton;
        private const string NibName = "UpdatePostView";
        private EnhancedToolbar _enhancedToolbar;

        public UpdatePostView(IntPtr handle) : base(handle)
        {
        }


        #region IComponent realization
        public ISite Site { get; set; }
        public event EventHandler Disposed;
        #endregion

        #region EventHandlers
        private void Comment_TextChanged(object sender, EventArgs e)
        {
            Presenter.CommentInput(_commentTextView.Text);

            _commentTextView.Alpha = string.IsNullOrEmpty(_commentTextView.Text) ? 0.5f : 1f;
        }

        partial void AddImageButton_TouchUpInside(UIButton sender)
        {
            Presenter.GoToSelectingImage();
        }

        partial void AccessModeButton_TouchUpInside(UIButton sender)
        {
            Presenter.AccessModeClick();
        }

        partial void AttachmentCancelButton_TouchUpInside(UIButton sender)
        {
            Presenter.DeleteImageClick();
            _enhancedToolbar.HideKeyboard();
        }

        partial void PickerDoneButton_TouchUpInside(UIButton sender)
        {
            var selectedItem = (_pickerPickerView.Model as PickerDataModel).SelectedItem;

            if (_access.Contains(selectedItem))
            {
                SetAccessMode(selectedItem);
                Presenter.AccessModeSelected(selectedItem.GetAccessEnum());
            }

            PickerCancelButton_TouchUpInside(sender);
        }

        partial void PickerCancelButton_TouchUpInside(UIButton sender)
        {
            _pickerView.Hidden = true;
            _pickerPickerView.Model = null;
        }
        #endregion

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            if (Site != null)
            {
                return;
            }

            NSBundle.MainBundle.LoadNib(NibName, this, null);

            InvokeOnMainThread(() =>
            {
                var frame = _rootView.Frame;
                frame.Height = Frame.Height;
                frame.Width = Frame.Width;
                _rootView.Frame = frame;
                AddSubview(_rootView);
            });

            InitSelectedItems();

            MakeAvatarRound();

            _enhancedToolbar = new EnhancedToolbar(_commentTextView);
            _commentTextView.InputAccessoryView = _enhancedToolbar;
        }

        private void InitSelectedItems()
        {
            _access = new List<string>
            {
                EAccessMode.Public.GetLocaleStringFromEnum(),
                EAccessMode.Private.GetLocaleStringFromEnum()
            };
        }

        public void SetConfigToolbar()
        {
            _backButton = new UIBarButtonItem(new UIImage(), UIBarButtonItemStyle.Plain, (sender, e) => { Presenter.BackClick(); Presenter.Dispose(); });
            NavigationItem.SetLeftBarButtonItem(_backButton, true);

            _publishButton = new UIBarButtonItem("", UIBarButtonItemStyle.Plain, (sender, e) => {
                Presenter.UpdatePost(
                    comment: _commentTextView.Text,
                    image: AttachmentImage,
                    access: _accessModeButton.CurrentTitle.GetAccessEnum());
            });
            NavigationItem.SetRightBarButtonItem(_publishButton, true);
        }

        public void SetUserAvatar(string image)
        {
            if (string.IsNullOrWhiteSpace(image))
            {
                return;
            }

            InvokeOnMainThread(() =>
            {
                _photoImageView.SetImage(new NSUrl(image));//
            });
        }

        private void MakeAvatarRound()
        {
            _photoImageView.Layer.MasksToBounds = true;
            var maskLayer = new CAShapeLayer
            {
                Path = UIBezierPath.FromOval(_photoImageView.Bounds).CGPath
            };
            _photoImageView.Layer.Mask = maskLayer;
        }

        public void SetUserName(string name)
        {
            InvokeOnMainThread(() =>
            {
                _nameLabel.Text = name;
            });
        }

        public void ShowSuccessAlert(string message, string buttonTitle)
        {
            var alert = new UIAlertView
            {
                Message = message
            };

            alert.AddButton(buttonTitle);
            alert.Show();
            alert.Clicked += (s, e) => { Presenter.GoToMain(); Presenter.Dispose(); };
        }

        public void ShowFailAlert(string message, string buttonTitle)
        {
            var alert = new UIAlertView
            {
                Message = message
            };

            alert.AddButton(buttonTitle);
            alert.Show();
            alert.Clicked += (s, e) => { };
        }

        public void ShowSpinner()
        {
            InitSpinner();
            _spinner.StartAnimating();
            InvokeOnMainThread(() =>
            {
                _commentTextView.Editable = false;
            });
        }

        public void HideSpinner()
        {
            _spinner.StopAnimating();
            InvokeOnMainThread(() =>
            {
                _commentTextView.Editable = true;
            });
        }

        private void InitSpinner()
        {
            if (_spinner != null)
            {
                return;
            }
            _spinner = new UISpinnerView(_rootView.Frame);

            _rootView.AddSubview(_spinner);
        }

        public void SetDividingLineTheme(IViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _headerDividingLineLabel.SetTheme(theme);
                _commentDividingLineLabel.SetTheme(theme);
            });
        }

        public void SetNameTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _nameLabel.SetTheme(theme);
            });
        }


        #region Toolbar
        public void SetTitleTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                var strAttr = new UIStringAttributes
                {
                    ForegroundColor = (UIColor) theme.TextColor
                };
                NavigationBar.TitleTextAttributes = strAttr;
            });
        }

        public void SetBackButtonTheme(IImageButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _backButton.TintColor = (UIColor)theme.TintColor;
                _backButton.Image = (UIImage)theme.Image;
            });
        }

        public void SetPublishTextViewTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                var strAttr = new UITextAttributes
                {
                    TextColor = (UIColor) theme.TextColor
                };
                _publishButton.SetTitleTextAttributes(strAttr, UIControlState.Normal);
            });
        }

        public void SetToolbarTheme(IViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                NavigationBar.Translucent = false;
                NavigationBar.BarTintColor = (UIColor)theme.BackgroundColor;
            });
        }

        public void SetToolBarPublishButtonLocale(string locale)
        {
            InvokeOnMainThread(() =>
            {
                _publishButton.Title = locale;
            });
        }

        public void SetToolBarTitleTextViewLocale(string locale)
        {
            InvokeOnMainThread(() =>
            {
                NavigationItem.Title = locale;
            });
        }
        #endregion

        #region IViewThemes
        public void SetAvatarTheme(IImageViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _photoImageView.SetTheme(theme);
            });
        }

        public void SetAttachImageButtonTheme(IImageButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _addImageButton.SetTheme((IImageViewTheme)theme);
            });
        }

        public void SetCancelAttachButtonTheme(IImageButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _attachmentCancelButton.SetTheme((IImageViewTheme)theme);
            });
        }

        public void SetToolsTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _toolsButton.SetTheme(theme);
            });
        }

        public void SetPriceTextViewTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _priceButton.SetTheme(theme);
                _priceButton.TitleEdgeInsets = new UIEdgeInsets(0, 15, 0, 0);
            });
        }

        public void SetBuySellTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _buySellButton.SetTheme(theme);
                _buySellButton.TitleEdgeInsets = new UIEdgeInsets(0, 15, 0, 0);
            });
        }

        public void SetAccessModeTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _accessModeButton.SetTheme(theme);
                _accessModeButton.TitleEdgeInsets = new UIEdgeInsets(0, 7, 0, 0);
            });
        }

        public void SetForecastTimeTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _forecastTimeButton.SetTheme(theme);
                _forecastTimeButton.TitleEdgeInsets = new UIEdgeInsets(0, 15, 0, 0);
            });
        }

        public void SetCommentTheme(IEditTextTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _commentTextView.SetTheme((IViewTheme)theme);
                _commentBackgroundView.SetTheme((IViewTheme)theme);
            });
        }
        #endregion


        public void SetComment(string enterCommentLabel)
        {
            InvokeOnMainThread(() =>
            {
                _commentTextView.Text = enterCommentLabel;
            });
        }

        public void SetCommentHint(string enterCommentLabel)
        {
            InvokeOnMainThread(() =>
            {
                _commentHeaderLabel.Text = enterCommentLabel;
            });
        }

        public void SetForecastTime(string timeTextView)
        {
            InvokeOnMainThread(() =>
            {
                _forecastTimeButton.SetTitle(timeTextView, UIControlState.Normal);
                
            });
        }

        public void SetAccessMode(string accessModeTextView)
        {
            InvokeOnMainThread(() =>
            {
                _accessModeButton.SetTitle(accessModeTextView, UIControlState.Normal);
                //_accessModeButton.TitleEdgeInsets = new UIEdgeInsets(0, 7, 0, 0);
            });
        }

        public void SetBuySell(string buySellTextView)
        {
            InvokeOnMainThread(() =>
            {
                _buySellButton.SetTitle(buySellTextView, UIControlState.Normal);
                //_buySellButton.TitleEdgeInsets = new UIEdgeInsets(0, 15, 0, 0);
            });
        }

        public void SetTools(string toolsButton)
        {
            InvokeOnMainThread(() =>
            {
                _toolsButton.SetTitle(toolsButton, UIControlState.Normal);
            });
        }

        public void SetPrice(string priceLabel)
        {
            InvokeOnMainThread(() =>
            {
                _priceButton.SetTitle(priceLabel, UIControlState.Normal);
                //_priceButton.TitleEdgeInsets = new UIEdgeInsets(0, 15, 0, 0);
            });
        }

        public void SetImageLink(string imageLink)
        {
            using (var url = new NSUrl(imageLink))
            using (var data = NSData.FromUrl(url))
            {
                SetImage(data.GetBase64EncodedString(NSDataBase64EncodingOptions.None));
            }
        }

        public void SetImage(string image)
        {
            ShowSelectedImage(image);
            AttachmentImage = image;
        }

        private void ShowSelectedImage(string attachmentImage)
        {
            using (var image = attachmentImage.FromBase64())
            {
                var aspectRatio = image.Size.Width / image.Size.Height;
                var height = _attachmentImageView.Bounds.Height;
                var width = image.Size.Width != image.Size.Height ? (height * aspectRatio) : height;

                _attachmentImageView.Image = image.Scale(new CoreGraphics.CGSize(width, height));
                _attachmentImageView.Hidden = false;
                _attachmentCancelButton.Hidden = false;
            }

            Presenter.AttachmentCancelImage();
        }

        public void ImageDeleted()
        {
            AttachmentImage = string.Empty;
            InvokeOnMainThread(() =>
            {
                _attachmentImageView.Image = null;

                _attachmentImageView.Hidden = true;
                _attachmentCancelButton.Hidden = true;
            });
        }

        public void AccessModeSelection(string alertTitle, string cancelTitle, string okTitle = null)
        {
            InvokeOnMainThread(() =>
            {
                ShowItemsAlert(alertTitle, cancelTitle, okTitle, _access);
            });
        }

        private void ShowItemsAlert(string alertTitle, string cancelTitle, string okTitle, List<string> items)
        {
            _pickerTitleLabel.Text = alertTitle;
            _pickerCancelButton.SetTitle(cancelTitle, UIControlState.Normal);
            _pickerDoneButton.SetTitle(okTitle, UIControlState.Normal);
            _pickerView.Hidden = false;
            _pickerPickerView.Model = new PickerDataModel(items);
        }

        public void NeedToSaveData()
        {
            Presenter.SaveData(_accessModeButton.CurrentTitle.GetAccessEnum(), _commentTextView.Text, AttachmentImage);
        }


        public void Subscribe()
        {
            _commentTextView.Changed += Comment_TextChanged;
        }

        public void UnSubscribe()
        {
            _commentTextView.Changed -= Comment_TextChanged;
        }
    }
}