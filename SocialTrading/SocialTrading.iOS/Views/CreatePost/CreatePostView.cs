﻿﻿﻿﻿using UIKit;
﻿﻿﻿﻿using Foundation;
using CoreAnimation;

using SDWebImage;

using System;
using System.ComponentModel;
using System.Collections.Generic;

using SocialTrading.Tools;
using SocialTrading.Theme;
using SocialTrading.iOS.Tools;
using SocialTrading.iOS.Views;
using SocialTrading.iOS.Theme;
using SocialTrading.Vipers.Entity;
using SocialTrading.Tools.Interfaces;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.CreatePost.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

namespace SocialTrading.iOS
{
    [DesignTimeVisible(true)]
    public partial class CreatePostView : UIView, IComponent, IViewCreatePost, IViewCreatePostToolBar, ISubscriber
    {
        private const string NibName = "CreatePostView";
        private UISpinnerView _spinner = null;

        public IPresenterCreatePost Presenter { get; set; }

        public string AttachmentImage
        {
            private set => Presenter.SaveAttachedImage(value);
            get => Presenter.LoadAttachedImage() ?? string.Empty;
        }

        private List<string> _iRecommend;
        private List<string> _timePeriod;
        private List<string> _access;

        private ForecastTimeModel _timeModel;
        private UIButton _activeButton;

        private readonly IntPtr _tokenObserveMonth = (IntPtr)1;
        private readonly IntPtr _tokenObserveYear = (IntPtr)2;
        private readonly IntPtr _tokenObserveBuySell = (IntPtr)3;

        public UINavigationItem NavigationItem { private get; set; }
        public UINavigationBar NavigationBar { private get; set; }
        public UITextView CommentTextView { get { return _commentTextView; } private set {} }


        private UIBarButtonItem _backButton;
        private UIBarButtonItem _publishButton;

        private EnhancedToolbar _enhancedToolbar;

        public CreatePostView(IntPtr handle) : base(handle)
        {
        }


        #region IComponent realization
        public ISite Site { get; set; }
        public event EventHandler Disposed;
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
		}


		public override void TouchesBegan(NSSet touches, UIEvent evt)
		{
            _commentTextView.ResignFirstResponder();
            //_rootView.ResignFirstResponder();


		}

        public override void ObserveValue(NSString keyPath, NSObject ofObject, NSDictionary change, IntPtr ctx)
        {
            if (ctx == _tokenObserveMonth)
            {
                _anotherForecastTimeDayButton.SetTitle(_timeModel.GetDaysByMonth(_timeModel.MonthBias(_timeModel.Years.IndexOf(_anotherForecastTimeYearButton.TitleLabel.Text))
                    + GetMonths().IndexOf(_anotherForecastTimeMonthButton.TitleLabel.Text))[0], UIControlState.Normal);
            }
            else if (ctx == _tokenObserveYear)
            {
                _anotherForecastTimeMonthButton.SetTitle(_timeModel.GetMonthByYear(_timeModel.Years.IndexOf(_anotherForecastTimeYearButton.TitleLabel.Text))[0], UIControlState.Normal);
            }
            else if (ctx == _tokenObserveBuySell)
            {
                if (!string.IsNullOrWhiteSpace(_buySellButton.TitleLabel.Text) && !_toolsButton.TitleLabel.Text.Equals(Presenter.GetToolsButtonLocale()))
                {
                    Presenter.ReadyToSetPrice(_toolsButton.TitleLabel.Text, _buySellButton.TitleLabel.Text.GetRecommendEnum());
                }
            }
            else
            {
                base.ObserveValue(keyPath, ofObject, change, ctx);
            }
        }

        public void Subscribe()
		{
            _commentTextView.Changed += Comment_TextChanged;
            _anotherForecastTimeMonthButton.AddObserver(this, "titleLabel.text", NSKeyValueObservingOptions.OldNew, _tokenObserveMonth);
            _anotherForecastTimeYearButton.AddObserver(this, "titleLabel.text", NSKeyValueObservingOptions.OldNew, _tokenObserveYear);
            _buySellButton.AddObserver(this, "titleLabel.text", NSKeyValueObservingOptions.OldNew, _tokenObserveBuySell);
           
        }

        public void UnSubscribe()
        {
            _commentTextView.Changed -= Comment_TextChanged;
            _anotherForecastTimeMonthButton.RemoveObserver(this, "titleLabel.text", _tokenObserveMonth);
            _anotherForecastTimeYearButton.RemoveObserver(this, "titleLabel.text", _tokenObserveYear);
            _buySellButton.RemoveObserver(this, "titleLabel.text", _tokenObserveBuySell);

        }

        #region Event handlers

        private void Comment_TextChanged(object sender, EventArgs e)
        {
            Presenter.CommentInput(!string.IsNullOrWhiteSpace(_commentTextView.Text));

            _commentTextView.Alpha = string.IsNullOrEmpty(_commentTextView.Text) ? 0.5f : 1f;
        }

        partial void ToolSelection_TouchUpInside(UIButton sender)
        {
            Presenter.GoToSelectingTool();
        }

        partial void AccessModeButton_TouchUpInside(UIButton sender)
        {
            InvokeOnMainThread(() =>
            {
                ShowItemsAlert(Presenter.GetAccessModeAlertTitleLocale(), _access);
            });
        }

        partial void BuySellButton_TouchUpInside(UIButton sender)
        {
            InvokeOnMainThread(() =>
            {
                ShowItemsAlert(Presenter.GetRecommendAlertTitleLocale(), _iRecommend);
            });
        }

        partial void ForecastTimeButton_TouchUpInside(UIButton sender)
        {
            InvokeOnMainThread(() =>
            {
                ShowItemsAlert(Presenter.GetForecastTimeAlertTitleLocale(), _timePeriod);
            });
        }

        private void AddPost()
        {
            if (_forecastTimeButton.TitleLabel.Text.GetTimePeriodEnum() == EForecastTime.Other)
            {
                Presenter.AddPost(
                    price: _priceButton.TitleLabel.Text,
                    tool: _toolsButton.TitleLabel.Text,
                    comment: _commentTextView.Text,
                    img: AttachmentImage,
                    timePeriod: _forecastTimeButton.TitleLabel.Text,
                    recommend: _buySellButton.TitleLabel.Text.GetRecommendEnum(),
                    access: _accessModeButton.TitleLabel.Text.GetAccessEnum()
                );
            }
            else
            {
                Presenter.AddPost(
                    price: _priceButton.TitleLabel.Text,
                    tool: _toolsButton.TitleLabel.Text,
                    comment: _commentTextView.Text,
                    img: AttachmentImage,
                    timePeriod: _forecastTimeButton.TitleLabel.Text.GetTimePeriodEnum(),
                    recommend: _buySellButton.TitleLabel.Text.GetRecommendEnum(),
                    access: _accessModeButton.TitleLabel.Text.GetAccessEnum()
                );
            }
        }

        partial void AddImageButton_TouchUpInside(UIButton sender)
        {
            Presenter.GoToSelectingImage();
        }

        partial void AttachmentCancelButton_TouchUpInside(UIButton sender)
        {
            Presenter.DeleteAttachmentImage();
            _enhancedToolbar.HideKeyboard();
        }


        partial void PickerDoneButton_TouchUpInside(UIButton sender)
        {
            var selectedItem = (_pickerPickerView.Model as PickerDataModel).SelectedItem;

            if (_access.Contains(selectedItem))
            {
                _accessModeButton.SetTitle(selectedItem, UIControlState.Normal);
                Presenter.AccessModeSelected(selectedItem.GetAccessEnum());
            }
            else if (_timePeriod.Contains(selectedItem))
            {
                if (selectedItem.Equals(Presenter.GetOtherLocale()))
                {
                    ShowForecastAnotherTimeAlert(Presenter.GetForecastTimeModel());
                }
                else
                {
                    _forecastTimeButton.SetTitle(selectedItem, UIControlState.Normal);
                    Presenter.ForecastTimeSelected(selectedItem.GetTimePeriodEnum());
                }
            }
            else if (_iRecommend.Contains(selectedItem))
            {
                _buySellButton.SetTitle(selectedItem, UIControlState.Normal);
                Presenter.BuySellSelected(selectedItem.GetRecommendEnum());
            }

            PickerCancelButton_TouchUpInside(sender);
        }

        partial void PickerCancelButton_TouchUpInside(UIButton sender)
        {
            _pickerView.Hidden = true;
            _pickerPickerView.Model = null;
        }


        partial void AnotherForecastTimeDoneButton_TouchUpInside(UIButton sender)
        {
            var forecastTimeTitle = GetForecastTime();
            _forecastTimeButton.SetTitle(forecastTimeTitle, UIControlState.Normal);
            Presenter.ForecastTimeSelected(forecastTimeTitle.GetTimePeriodEnum());

            AnotherForecastTimeCancelButton_TouchUpInside(sender);
        }

        partial void AnotherForecastTimeCancelButton_TouchUpInside(UIButton sender)
        {
            _anotherForecastTimeView.Hidden = true;
            _anotherForecastTimePickerView.Model = null;
        }

        partial void AnotherForecastTimeDayButton_TouchUpInside(UIButton sender)
        {
            AnotherForecastTimeButtonHandler(
                sender, GetDay(), _timeModel.GetDaysByMonth(_timeModel.MonthBias(_timeModel.Years.IndexOf(_anotherForecastTimeYearButton.TitleLabel.Text))
                    + GetMonths().IndexOf(_anotherForecastTimeMonthButton.TitleLabel.Text)).IndexOf(_anotherForecastTimeDayButton.TitleLabel.Text)
            );
        }

        partial void AnotherForecastTimeMonthButton_TouchUpInside(UIButton sender)
        {
            AnotherForecastTimeButtonHandler(sender, GetMonths(), GetMonths().IndexOf(_anotherForecastTimeMonthButton.TitleLabel.Text));
        }

        partial void AnotherForecastTimeYearButton_TouchUpInside(UIButton sender)
        {
            AnotherForecastTimeButtonHandler(sender, GetYears(), _timeModel.Years.IndexOf(_anotherForecastTimeYearButton.TitleLabel.Text));
        }

        partial void AnotherForecastTimeHourButton_TouchUpInside(UIButton sender)
        {
            AnotherForecastTimeButtonHandler(sender, GetHours(), _timeModel.Hours.IndexOf(_anotherForecastTimeHourButton.TitleLabel.Text));
        }

        partial void AnotherForecastTimeMinuteButton_TouchUpInside(UIButton sender)
        {
            AnotherForecastTimeButtonHandler(sender, GetMinutes(), _timeModel.Minutes.IndexOf(_anotherForecastTimeMinuteButton.TitleLabel.Text));
        }

        #endregion

        #region IViewCreatePost

        public string AccessModeText
        {
            get => _accessModeButton.CurrentTitle;
            set
            {
                InvokeOnMainThread(() =>
                {
                    _accessModeButton.SetTitle(value, UIControlState.Normal);
                });
            }
        }

        public string BuySellText
        {
            get => _buySellButton.CurrentTitle;
            set
            {
                InvokeOnMainThread(() =>
                {
                    _buySellButton.SetTitle(value, UIControlState.Normal);
                });
            }
        }

        public string ForecastTimeText
        {
            get => _forecastTimeButton.CurrentTitle;
            set
            {
                InvokeOnMainThread(() =>
                {
                    _forecastTimeButton.SetTitle(value, UIControlState.Normal);
                });
            }
        }

        public string CommentText
        {
            get => _commentTextView.Text;
            set
            {
                InvokeOnMainThread(() =>
                {
                    _commentTextView.Text = value;
                    _commentTextView.Alpha = string.IsNullOrEmpty(_commentTextView.Text) ? 0.5f : 1f;
                });
            }
        }

        public string Price
        {
            get => _priceButton.CurrentTitle;
            set
            {
                InvokeOnMainThread(() =>
                {
                    _priceButton.SetTitle(value, UIControlState.Normal);
                });
            }
        }


        public void SetAttachment()
        {
            InvokeOnMainThread(() =>
            {
                ShowSelectedImage(AttachmentImage);
            });
        }
        
        public void SetUserAvatar(string image)
        {
            if (string.IsNullOrWhiteSpace(image))
            {
                return;
            }

            InvokeOnMainThread(() =>
            {
                _photoImageView.SetImage(new NSUrl(image));// .Image = FromUrl(image);
            });
        }

        public void SetUserName(string name)
        {
            InvokeOnMainThread(() =>
            {
                _nameLabel.Text = name;
            });
        }

        private UIImage FromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }

        public void SetSelectedTool(string tool)
        {
            InvokeOnMainThread(() =>
            {
                _toolsButton.SetTitle(tool, UIControlState.Normal);
            });

            if (!_buySellButton.CurrentTitle.Equals(Presenter.GetBuySellLocale()) && !_toolsButton.CurrentTitle.Equals(Presenter.GetToolsButtonLocale()))
            {
                Presenter.ReadyToSetPrice(tool, _buySellButton.TitleLabel.Text.GetRecommendEnum());
            }
        }
        
        public void ImageSelected(string image)
        {
            AttachmentImage = image;
            Presenter.ImageSelected();
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


        public void ShowErrorAlert(string message)
        {
            ShowAlert(Presenter.GetErrorLocale(), message);
        }

        public void AddPostSuccess()
        {
            ShowAlert(string.Empty, Presenter.GetCreatePostSuccessLocale());
        }
        
        public void SetCommentLocale(string enterCommentLabel)
        {
            _commentHeaderLabel.Text = enterCommentLabel;
        }

        public void SetForecastTimeLocale(string timeTextView)
        {
            _forecastTimeButton.SetTitle(timeTextView, UIControlState.Normal);
        }

        public void SetAccessModeLocale(string accessModeTextView)
        {
            _accessModeButton.SetTitle(accessModeTextView, UIControlState.Normal);
        }

        public void SetBuySellLocale(string buySellTextView)
        {
            _buySellButton.SetTitle(buySellTextView, UIControlState.Normal);
        }

        public void SetToolsLocale(string toolsButton)
        {
            _toolsButton.SetTitle(toolsButton, UIControlState.Normal);
        }

        public void SetPriceLocale(string priceLabel)
        {
            _priceButton.SetTitle(priceLabel, UIControlState.Normal);
        }


        public void SetConfig()
        {
            InvokeOnMainThread(() =>
            {
                FillViews();
                ThemeHelper.PerformTheme(Themes.GetCreatePostTheme());
                Presenter.AttachmentCancelImage();
                SetConfigToolbar();
                MakeAvatarRound();

                _enhancedToolbar = new EnhancedToolbar(_commentTextView);
                _commentTextView.InputAccessoryView = _enhancedToolbar;
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

        private void FillViews()
        {
            Presenter.SetLocale();

            _pickerDoneButton.SetTitle(Presenter.GetOkLocale(), UIControlState.Normal);
            _pickerCancelButton.SetTitle(Presenter.GetCancelLocale(), UIControlState.Normal);

            _anotherForecastTimeTitleLabel.Text = Presenter.GetAnotherForecastTimeAlertTitleLocale();
            _anotherForecastTimeDoneButton.SetTitle(Presenter.GetOkLocale(), UIControlState.Normal);
            _anotherForecastTimeCancelButton.SetTitle(Presenter.GetCancelLocale(), UIControlState.Normal);

            var edgeInsets = new UIEdgeInsets(0, 10, 0, 30);

            _priceButton.ContentEdgeInsets = edgeInsets;
            _accessModeButton.ContentEdgeInsets = edgeInsets;
            _buySellButton.ContentEdgeInsets = edgeInsets;
            _forecastTimeButton.ContentEdgeInsets = edgeInsets;
        }



        public void SetInteractionUnavailable()
        {
            SetInteraction(false);
        }

        public void SetInteractionAvailable()
        {
            SetInteraction(true);
        }

        private void SetInteraction(bool availability)
        {
            InvokeOnMainThread(() =>
            {
                _accessModeButton.Enabled = availability;
                _addImageButton.Enabled = availability;
                _attachmentCancelButton.Enabled = availability;
                _buySellButton.Enabled = availability;
                _forecastTimeButton.Enabled = availability;
                _priceButton.Enabled = availability;
                _toolsButton.Enabled = availability;
                _priceButton.Enabled = availability;
            });
        }

        #endregion

        #region IViewCreatePostToolBar

        public void SetConfigToolbar()
        {
            _backButton = new UIBarButtonItem(new UIImage(), UIBarButtonItemStyle.Plain, (sender, e) => { Presenter.BackClick(); });
            NavigationItem.SetLeftBarButtonItem(_backButton, true);

            _publishButton = new UIBarButtonItem("", UIBarButtonItemStyle.Plain, (sender, e) => { AddPost(); });
            NavigationItem.SetRightBarButtonItem(_publishButton, true);

            Presenter.SetToolBarLocale();
        }

        public void SetToolBarTitleTextViewLocale(string createPostActivityTitle)
        {
            NavigationItem.Title = createPostActivityTitle;
        }

        public void SetToolBarPublishButtonLocale(string publishButton)
        {
            _publishButton.Title = publishButton;
        }

        #endregion

        #region IViewThemesNEW

        public void SetDividingLineTheme(IViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _commentDividingLineLabel.SetTheme(theme);
                _headerDividingLineLabel.SetTheme(theme);
            });
        }

        public void SetNameTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _nameLabel.SetTheme(theme);
            });
        }

        public void SetTitleTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                var strAttr = new UIStringAttributes();
                strAttr.ForegroundColor = (UIColor)theme.TextColor;
                NavigationBar.TitleTextAttributes = strAttr;
            });
        }

        public void SetAvatarTheme(IImageViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _photoImageView.SetTheme(theme);
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

        public void SetPublishTextViewTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                var strAttr = new UITextAttributes();
                strAttr.TextColor = (UIColor)theme.TextColor;
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
            });
        }

        public void SetBuySellTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _buySellButton.SetTheme(theme);
            });
        }

        public void SetAccessModeTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _accessModeButton.SetTheme(theme);
            });
        }

        public void SetForecastTimeTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _forecastTimeButton.SetTheme(theme);
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

        private void InitSelectedItems()
        {
            _iRecommend = new List<string>
            {
                EBuySell.Buy.GetLocaleStringFromEnum(),
                EBuySell.Sell.GetLocaleStringFromEnum()
            };

            _timePeriod = new List<string>
            {
                EForecastTime.Minute15.GetLocaleStringFromEnum(),
                EForecastTime.Minute30.GetLocaleStringFromEnum(),
                EForecastTime.Hour1.GetLocaleStringFromEnum(),
                EForecastTime.Hour4.GetLocaleStringFromEnum(),
                EForecastTime.Hour8.GetLocaleStringFromEnum(),
                EForecastTime.Hour24.GetLocaleStringFromEnum(),
                EForecastTime.Week1.GetLocaleStringFromEnum(),
                EForecastTime.Other.GetLocaleStringFromEnum()
            };

            _access = new List<string>
            {
                EAccessMode.Public.GetLocaleStringFromEnum(),
                EAccessMode.Private.GetLocaleStringFromEnum()
            };
        }

        private void ShowSelectedImage(string attachmentImage)
        {
            using (var image = AttachmentImage.FromBase64())
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

        private void ShowAlert(string title, string message)
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
                alert.Clicked += (s, e) => {};
            });
        }

        private void ShowItemsAlert(string title, List<string> items)
        {
            _pickerTitleLabel.Text = title;
            _pickerView.Hidden = false;
            _pickerPickerView.Model = new PickerDataModel(items);
        }

        #region Another forecast time

        private void ShowForecastAnotherTimeAlert(ForecastTimeModel timeModel)
        {
            _timeModel = timeModel;

            _anotherForecastTimeMinuteButton.SetThemeTitleColor(DAL.ThemeKeyStrings.CreatePostForecastTimeChoosen);
            _activeButton = _anotherForecastTimeMinuteButton;
            SetPicker(GetMinutes(), _timeModel.Minutes.IndexOf(_timeModel.DefaultMinute));

            _anotherForecastTimeDayButton.SetTitle(_timeModel.DefaultDay, UIControlState.Normal);
            _anotherForecastTimeMonthButton.SetTitle(_timeModel.DefaultMonth, UIControlState.Normal);
            _anotherForecastTimeYearButton.SetTitle(_timeModel.DefaultYear, UIControlState.Normal);
            _anotherForecastTimeHourButton.SetTitle(_timeModel.DefaultHour, UIControlState.Normal);
            _anotherForecastTimeMinuteButton.SetTitle(_timeModel.DefaultMinute, UIControlState.Normal);

            _anotherForecastTimeView.Hidden = false;
        }

        private void SetPicker(List<string> items, int defaultValueIndex)
        {
            _anotherForecastTimePickerView.Model = new PickerDataModel(items);
            _anotherForecastTimePickerView.Select(defaultValueIndex, 0, true);
            (_anotherForecastTimePickerView.Model as PickerDataModel).ValueChanged = (model) =>
            {
                _activeButton.SetTitle(model.SelectedItem, UIControlState.Normal);
            };
        }

        private string GetForecastTime()
        {
            return _anotherForecastTimeYearButton.TitleLabel.Text + "-"
                + (new List<string>(Presenter.GetMonthsLocale()).IndexOf(_anotherForecastTimeMonthButton.TitleLabel.Text) + 1) + "-"
                + _anotherForecastTimeDayButton.TitleLabel.Text + " " 
                + _anotherForecastTimeHourButton.TitleLabel.Text.Split(' ')[0] + ":"
                + _anotherForecastTimeMinuteButton.TitleLabel.Text.Split(' ')[0];
        }

        private List<string> GetMonths()
        {
            return _timeModel.GetMonthByYear(_timeModel.Years.IndexOf(_anotherForecastTimeYearButton.TitleLabel.Text));
        }

        private List<string> GetYears()
        {
            return _timeModel.Years;
        }

        private List<string> GetHours()
        {
            return _timeModel.Hours;
        }

        private List<string> GetMinutes()
        {
            return _timeModel.Minutes;
        }

        private List<string> GetDay()
        {
            return _timeModel.GetDaysByMonth(_timeModel.MonthBias(_timeModel.Years.IndexOf(_anotherForecastTimeYearButton.TitleLabel.Text))
                + GetMonths().IndexOf(_anotherForecastTimeMonthButton.TitleLabel.Text));
        }

        private void AnotherForecastTimeButtonHandler(UIButton sender, List<string> items, int defaultValueIndex)
        {
            _anotherForecastTimeDayButton.SetThemeTitleColor(DAL.ThemeKeyStrings.CreatePostForecastTimeNotChoosen);
			_anotherForecastTimeMonthButton.SetThemeTitleColor(DAL.ThemeKeyStrings.CreatePostForecastTimeNotChoosen);
			_anotherForecastTimeYearButton.SetThemeTitleColor(DAL.ThemeKeyStrings.CreatePostForecastTimeNotChoosen);
			_anotherForecastTimeHourButton.SetThemeTitleColor(DAL.ThemeKeyStrings.CreatePostForecastTimeNotChoosen);
			_anotherForecastTimeMinuteButton.SetThemeTitleColor(DAL.ThemeKeyStrings.CreatePostForecastTimeNotChoosen);
        
            sender.SetThemeTitleColor(DAL.ThemeKeyStrings.CreatePostForecastTimeChoosen);
            SetPicker(items, defaultValueIndex);

            _activeButton = sender;
        }

        public void ShowSpinner()
        {
            InitSpinner();
            _spinner.StartAnimating();
            _commentTextView.Editable = false;
        }

        public void HideSpinner()
        {
            _spinner.StopAnimating();
            _commentTextView.Editable = true;
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

        #endregion
    }
}