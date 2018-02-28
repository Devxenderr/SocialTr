using System;
using System.Collections.Generic;

using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Graphics;
using Android.Provider;

using Square.Picasso;

using SocialTrading.Theme;
using SocialTrading.Tools;
using SocialTrading.Droid.Theme;
using SocialTrading.Droid.Tools;
using SocialTrading.Vipers.Entity;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.CreatePost.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

using Uri = Android.Net.Uri;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SocialTrading.Droid.Views
{
    public class CreatePostView : RelativeLayout, IViewCreatePost, IViewCreatePostToolBar
    {
        private Holder _holder;
        private const string SpinnerConst = "SpinnerTag";

        private List<string> _iRecommend;
        private List<string> _timePeriod;
        private List<string> _access;

        private LayoutInflater _inflater;

        public IPresenterCreatePost Presenter { private get; set; }

        public string AttachmentImage
        {
            private set => Presenter.SaveAttachedImage(value);
            get => Presenter.LoadAttachedImage() ?? string.Empty;
        }

        
        #region For RelatineLayout

        public CreatePostView(Context context) : base(context)
        {
            Init(context);
        }

        public CreatePostView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context);
        }

        public CreatePostView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init(context);
        }

        public CreatePostView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Init(context);
        }

        private void Init(Context context)
        {
            _inflater = ((Activity)context).LayoutInflater;
            _inflater.Inflate(Resource.Layout.CreatePostView, this, true);

            _holder = new Holder(this);
            SetButtonsActions();

            InitSelectedItems();
        }

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

        private void SetButtonsActions()
        {
            if (!_holder.AddImageButton.HasOnClickListeners)
            {
                _holder.AddImageButton.Click += (s, e) =>
                {
                    Presenter.GoToSelectingImage();
                };
            }

            if (!_holder.ToolBarPublishButton.HasOnClickListeners)
            {
                _holder.ToolBarPublishButton.Click += (s, e) =>
                {
                    if (_holder.ForecastTimeTextView.Text.GetTimePeriodEnum() == EForecastTime.Other)
                    {
                        Presenter.AddPost(
                            price: _holder.PriceTextView.Text,
                            tool: _holder.ToolsTextView.Text,
                            comment: _holder.CommentEditText.Text,
                            img: AttachmentImage.GetBase64(),
                            timePeriod: _holder.ForecastTimeTextView.Text,
                            recommend: _holder.BuySellTextView.Text.GetRecommendEnum(),
                            access: _holder.AccessModeTextView.Text.GetAccessEnum()
                            );
                    }
                    else
                    {
                        Presenter.AddPost(
                            price: _holder.PriceTextView.Text,
                            tool: _holder.ToolsTextView.Text,
                            comment: _holder.CommentEditText.Text,
                            img: AttachmentImage.GetBase64(),
                            timePeriod: _holder.ForecastTimeTextView.Text.GetTimePeriodEnum(),
                            recommend: _holder.BuySellTextView.Text.GetRecommendEnum(),
                            access: _holder.AccessModeTextView.Text.GetAccessEnum()
                        );
                    }
                };
            }

            if (!_holder.ToolBarBackImageButton.HasOnClickListeners)
            {
                _holder.ToolBarBackImageButton.Click += (s, e) =>
                {
                    Presenter.GoToMain();
                };
            }

            if (!_holder.ToolsTextView.HasOnClickListeners)
            {
                _holder.ToolsTextView.Click += (s, e) =>
                {
                    Presenter.GoToSelectingTool();
                };
            }

            if (!_holder.AttachmentCancelImageView.HasOnClickListeners)
            {
                _holder.AttachmentCancelImageView.Click += (s, e) =>
                {
                    Presenter.DeleteAttachmentImage();
                };
            }

            if (!_holder.CommentEditText.HasOnClickListeners)
            {
                _holder.CommentEditText.AfterTextChanged += (s, e) =>
                {
                    Presenter.CommentInput(!string.IsNullOrWhiteSpace(_holder.CommentEditText.Text));
                };
                _holder.CommentEditText.Click += (s, e) =>
                {
                    (Context as Activity)?.RunOnUiThread(() =>
                    {
                        _holder.Scroll.Post(() => _holder.Scroll.FullScroll(FocusSearchDirection.Down));
                    });
                };
            }

            if (!_holder.BuySellTextView.HasOnClickListeners)
            {
                _holder.BuySellTextView.Click += (s, e) =>
                {
                    (Context as Activity)?.RunOnUiThread(() =>
                    {
                        ShowItemsAlert(Presenter.GetRecommendAlertTitleLocale(), _iRecommend);
                    });
                };

                _holder.BuySellTextView.AfterTextChanged += (s, e) =>
                {
                    // TODO: this check need move to presenter
                    if (!_holder.BuySellTextView.Text.Equals(Presenter.GetBuySellLocale()) && !_holder.ToolsTextView.Text.Equals(Presenter.GetToolsButtonLocale()))
                    {
                        Presenter.ReadyToSetPrice(_holder.ToolsTextView.Text, _holder.BuySellTextView.Text.GetRecommendEnum());
                    }
                };
            }

            if (!_holder.AccessModeTextView.HasOnClickListeners)
            {
                _holder.AccessModeTextView.Click += (s, e) =>
                {
                    (Context as Activity)?.RunOnUiThread(() =>
                    {
                        ShowItemsAlert(Presenter.GetAccessModeAlertTitleLocale(), _access);
                    });
                };
            }

            if (!_holder.ForecastTimeTextView.HasOnClickListeners)
            {
                _holder.ForecastTimeTextView.Click += (s, e) =>
                {
                    (Context as Activity)?.RunOnUiThread(() =>
                    {
                        ShowItemsAlert(Presenter.GetForecastTimeAlertTitleLocale(), _timePeriod);
                    });
                };
            }
        }

        #endregion

        #region IViewCreatePost

        public string AccessModeText
        {
            get => _holder.AccessModeTextView.Text;
            set
            {
                (Context as Activity)?.RunOnUiThread(() =>
                {
                    _holder.AccessModeTextView.Text = value;
                });
            }
        }

        public string BuySellText
        {
            get => _holder.BuySellTextView.Text;
            set
            {
                (Context as Activity)?.RunOnUiThread(() =>
                {
                    _holder.BuySellTextView.Text = value;
                });
            }
        }

        public string ForecastTimeText
        {
            get => _holder.ForecastTimeTextView.Text;
            set
            {
                (Context as Activity)?.RunOnUiThread(() =>
                {
                    _holder.ForecastTimeTextView.Text = value;
                });
            }
        }

        public string CommentText
        {
            get => _holder.CommentEditText.Text;
            set
            {
                (Context as Activity)?.RunOnUiThread(() =>
                {
                    _holder.CommentEditText.Text = value;
                });
            }
        }

        public string Price
        {
            get => _holder.PriceTextView.Text;
            set
            {
                (Context as Activity)?.RunOnUiThread(() =>
                {
                    _holder.PriceTextView.Text = value;
                });
            }
        }

        public void ShowErrorAlert(string message)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                var alert = new AlertDialog.Builder(Context);

                alert.SetTitle(Presenter.GetErrorLocale())
                .SetMessage(message)
                .SetNeutralButton(Presenter.GetOkLocale(), (senderAlert, args) => { });

                Dialog dialog = alert.Create();
                dialog.Show();
            });
        }

        public void AddPostSuccess()
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                Toast.MakeText(Context, Presenter.GetCreatePostSuccessLocale(), ToastLength.Long).Show();
            });
        }

        public void SetAttachment()
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                ShowSelectedImage(AttachmentImage);
                
            });
        }

        public void ImageSelected(string image)
        {
            AttachmentImage = image;
            Presenter.ImageSelected();
        }

        public void ImageDeleted()
        {
            AttachmentImage = string.Empty;
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.AttachmentImageView.SetImageBitmap(null);
                _holder.AttachmentCancelImageView.Visibility = ViewStates.Invisible;
            });
        }

        private void ShowSelectedImage(string image)
        {
            var imageUri = Uri.Parse(image);

            var bitmap = MediaStore.Images.Media.GetBitmap(Context.ApplicationContext.ContentResolver, imageUri);
            var aspectRatio = (float)bitmap.Width / (float)bitmap.Height;
            var height = Convert.ToInt32(Resources.GetDimension(Resource.Dimension.attachmentImageViewHeight));
            var width = bitmap.Width != bitmap.Height ? (int)(height * aspectRatio) : height;

            using (var bitmapScaled = Bitmap.CreateScaledBitmap(bitmap, width, height, true))
            {
                bitmap.Recycle();
                bitmap.Dispose();
                
                _holder.AttachmentImageView.SetImageBitmap(bitmapScaled);
            }

            Presenter.AttachmentCancelImage();
        }

        public void SetSelectedTool(string tool)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.ToolsTextView.Text = tool;
            });
            
            if (!_holder.BuySellTextView.Text.Equals(Presenter.GetBuySellLocale()))
            {
                Presenter.ReadyToSetPrice(_holder.ToolsTextView.Text, _holder.BuySellTextView.Text.GetRecommendEnum());
            }
        }
        
        public void SetConfig()
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                SetConfigToolbar();
                FillViews();
            });
        }
        

        private void FillViews()
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                Presenter.SetLocale();

                _holder.ForecastTimeTextView.Focusable = false;
                _holder.BuySellTextView.Focusable = false;
                _holder.AccessModeTextView.Focusable = false;
            }
            );
            if (!string.IsNullOrEmpty(AttachmentImage))
            {
                ShowSelectedImage(AttachmentImage);
            }
        }
        
        public void SetUserAvatar(string image)
        {            
            RequestCreator picassoRequest;
            try
            {
                picassoRequest = Picasso.With(Context).Load(image);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Application.SynchronizationContext.Post(_ =>
            {
                picassoRequest.Placeholder(Resource.Drawable.defaultAvatar)
                .Transform(new Transformation())
                .Into(_holder.PhotoImageView);
            }, null);
        }

        public void SetUserName(string name)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.NameTextView.Text = name;
            });
        }
       
        public void SetCommentLocale(string enterCommentLabel)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.CommentEditText.Hint = enterCommentLabel;
            });
        }

        public void SetForecastTimeLocale(string timeTextView)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.ForecastTimeTextView.Text = timeTextView;
            });
        }

        public void SetAccessModeLocale(string accessModeTextView)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.AccessModeTextView.Text = accessModeTextView;
            });
        }

        public void SetBuySellLocale(string buySellTextView)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.BuySellTextView.Text = buySellTextView;
            });
        }

        public void SetToolsLocale(string toolsButton)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.ToolsTextView.Text = toolsButton;
            });
        }

        public void SetPriceLocale(string priceLabel)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PriceTextView.Text = priceLabel;
            });
        }

        private void ShowItemsAlert(string title, IReadOnlyList<string> items)
        {
           // var inflater = ((Activity)Context).LayoutInflater;
            var view = _inflater.Inflate(Resource.Layout.CustomAlert, null);

            var viewGroup = view.FindViewById<LinearLayout>(Resource.Id.ll_alert);
            viewGroup.SetPadding(80, 20, 10, 20);

            var builder = new AlertDialog.Builder(Context);
            AlertDialog dialog = null;
            
            for (var i = 0; i < items.Count; i++)
            {
                var textView = new TextView(Context)
                {
                    Text = items[i],
                    TextSize = 20,
                    Id = i
                };
                var lparams = new LinearLayout.LayoutParams(
                    ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
                lparams.SetMargins(0, 10, 0, 10);
                textView.LayoutParameters = lparams;
                textView.Click += (s, e) =>
                {
                    SelectedItemClick(s, e);
                    dialog?.Dismiss();
                };
                viewGroup.AddView(textView);
            }

            builder.SetTitle(title)
                .SetView(view)
                .SetCancelable(true)
                .SetNegativeButton(Presenter.GetCancelLocale(), (o, e) => { });

            dialog = builder.Show();
        }       
        
        private void SelectedItemClick(object sender, EventArgs e)
        {
            var selectedItem = (sender as TextView)?.Text;

            if (_access.Contains(selectedItem))
            {
                _holder.AccessModeTextView.Text = selectedItem;
                Presenter.AccessModeSelected(_holder.AccessModeTextView.Text.GetAccessEnum());
            }
            else if (_timePeriod.Contains(selectedItem))
            {
                if (selectedItem != null && selectedItem.Equals(Presenter.GetOtherLocale()))
                {
                    ShowForecastAnotherTimeAlert(Presenter.GetForecastTimeModel());
                }
                else
                {
                    _holder.ForecastTimeTextView.Text = selectedItem;
                    Presenter.ForecastTimeSelected(_holder.ForecastTimeTextView.Text.GetTimePeriodEnum());
                }
            }
            else if (_iRecommend.Contains(selectedItem))
            {
                _holder.BuySellTextView.Text = selectedItem;
                Presenter.BuySellSelected(_holder.BuySellTextView.Text.GetRecommendEnum());
            }
        }



        public void SetInteractionUnavailable()
        {
            SetInteraction(false);
        }
        
        public void SetInteractionAvailable()
        {
            SetInteraction(true);
        }

        public void ShowSpinner()
        {
            _inflater.Inflate(Resource.Layout.Spinner, this, true);
            FindViewById(Resource.Id.LayoutForDelete).Tag = SpinnerConst;
            var spinnerViewAuth = FindViewById<View>(Resource.Id.SpinnerView);

            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.CommentEditText.Enabled = false;
            });
            
            spinnerViewAuth.SetOnTouchListener(new ClickToBlockBottomsElement());
        }

        private class ClickToBlockBottomsElement : Java.Lang.Object, View.IOnTouchListener
        {
            public bool OnTouch(View v, MotionEvent e)
            {
                return true;
            }
        }

        public void HideSpinner()
        {
            var spinner = FindViewWithTag(SpinnerConst) as ViewGroup;
            (Context as Activity)?.RunOnUiThread(() =>
            {
                if (spinner != null)
                {
                    RemoveView(spinner);
                    _holder.CommentEditText.Enabled = true;
                }
            });
        }

        private void SetInteraction(bool availability)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.AddImageButton.Enabled = availability;
                _holder.AttachmentCancelImageView.Enabled = availability;
                _holder.AccessModeTextView.Enabled = availability;
                _holder.BuySellTextView.Enabled = availability;
                _holder.ForecastTimeTextView.Enabled = availability;
                _holder.CommentEditText.Enabled = availability;
                _holder.ToolBarPublishButton.Enabled = availability;
                _holder.ToolBarBackImageButton.Enabled = availability;
                _holder.ToolsTextView.Enabled = availability;
            });
        }

        #endregion


        #region IViewThemesNEW

        public void SetDividingLineTheme(IViewTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.DividingLineComment.SetTheme(theme);
                _holder.DividingLineHeader.SetTheme(theme);
            });
        }

        public void SetNameTheme(ITextViewTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.NameTextView.SetTheme(theme);
            });
        }

        public void SetTitleTheme(ITextViewTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.ToolBarTitleTextView.SetTheme(theme);
            });
        }

        public void SetAvatarTheme(IImageViewTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PhotoImageView.SetTheme(theme);
            });
        }

        public void SetBackButtonTheme(IImageButtonTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.ToolBarBackImageButton.SetTheme(theme);
            });
        }

        public void SetAttachImageButtonTheme(IImageButtonTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.AddImageButton.SetTheme(theme);
                
            });
        }

        public void SetCancelAttachButtonTheme(IImageButtonTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.AttachmentCancelImageView.SetTheme((IImageViewTheme)theme);
                _holder.AttachmentCancelImageView.Visibility = ViewStates.Visible;
            });
        }

        public void SetPublishTextViewTheme(IButtonTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.ToolBarPublishButton.SetTheme(theme);
            });
        }

        public void SetToolbarTheme(IViewTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.ToolBar.SetTheme(theme);
            });
        }

        public void SetToolsTheme(IButtonTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.ToolsTextView.SetTheme((ITextViewTheme)theme);
            });
        }

        public void SetPriceTextViewTheme(IButtonTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PriceTextView.SetTheme((ITextViewTheme)theme);
            });
        }

        public void SetBuySellTheme(IButtonTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.BuySellTextView.SetTheme((ITextViewTheme)theme);
            });
        }

        public void SetAccessModeTheme(IButtonTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.AccessModeTextView.SetTheme((ITextViewTheme)theme);
            });
        }

        public void SetForecastTimeTheme(IButtonTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.ForecastTimeTextView.SetTheme((ITextViewTheme)theme);
            });
        }

        public void SetCommentTheme(IEditTextTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.CommentEditText.SetTheme(theme);
                _holder.CommentAreaRelativeLayout.SetTheme((IViewTheme)theme);
            });
        }


        #endregion

        #region IViewCreatePostToolBar

        public void SetConfigToolbar()
        {
            Presenter.SetToolBarLocale();
        }

        public void SetToolBarPublishButtonLocale(string publishButton)
        {
            _holder.ToolBarPublishButton.Text = publishButton;
        }

        public void SetToolBarTitleTextViewLocale(string createPostActivityTitle)
        {
            _holder.ToolBarTitleTextView.Text = createPostActivityTitle;
        }

        #endregion

        #region Another forecast time

        private void ShowForecastAnotherTimeAlert(ForecastTimeModel time)
        {
            var anotherTimeHolder = new AnotherForecastTime(Presenter, Context, time);
            
            var builder = new AlertDialog.Builder(Context);
            AlertDialog dialog = null;
            builder.SetTitle(Presenter.GetAnotherForecastTimeAlertTitleLocale())
                .SetView(anotherTimeHolder.AlertView)
                .SetCancelable(true)
                .SetNegativeButton(Presenter.GetCancelLocale(), (o, e) => { })
                .SetPositiveButton(Presenter.GetOkLocale(), (o, e) => 
                {
                    _holder.ForecastTimeTextView.Text = anotherTimeHolder.GetForecastTime();
                    Presenter.ForecastTimeSelected(_holder.ForecastTimeTextView.Text.GetTimePeriodEnum());
                });

            dialog = builder.Show();
        }

        private class AnotherForecastTime
        { 
            public View AlertView { get; }

            private readonly Context _context;
            private readonly IPresenterCreatePost _presenter;

            private readonly TextView _minutesTextView;
            private readonly TextView _yearTextView;
            private readonly TextView _monthTextView;
            private readonly TextView _dayTextView;
            private readonly TextView _hourTextView;

            private TextView _activeTextView;

            private readonly ForecastTimeModel _timeModel;
            
            public AnotherForecastTime(IPresenterCreatePost presenter, Context context, ForecastTimeModel time)
            {
                LayoutInflater inflater = ((Activity)context).LayoutInflater;
                AlertView = inflater.Inflate(Resource.Layout.ForecastTimeAlert, null);

                _presenter = presenter;
                _context = context;
                _timeModel = time;
                _hourTextView = AlertView.FindViewById<TextView>(Resource.Id.createPost_hours_textView);
                _minutesTextView = AlertView.FindViewById<TextView>(Resource.Id.createPost_minutes_textView);
                _yearTextView = AlertView.FindViewById<TextView>(Resource.Id.createPost_year_textView);
                _monthTextView = AlertView.FindViewById<TextView>(Resource.Id.createPost_month_textView);
                _dayTextView = AlertView.FindViewById<TextView>(Resource.Id.createPost_day_textView);

                SetActions();

                _minutesTextView.SetTextColor(Color.ParseColor("#80cbc4"));
                _activeTextView = _minutesTextView;
                SetPicker(GetMinutes(), _timeModel.Minutes.IndexOf(_timeModel.DefaultMinute));
                
                _dayTextView.Text = _timeModel.DefaultDay;
                _hourTextView.Text = _timeModel.DefaultHour;
                _minutesTextView.Text = _timeModel.DefaultMinute;
                _yearTextView.Text = _timeModel.DefaultYear;
                _monthTextView.Text = _timeModel.DefaultMonth;
            }

            private void SetActions()
            {
                if (!_minutesTextView.HasOnClickListeners)
                {
                    _minutesTextView.Click += (s, e) =>
                    {
                        (_context as Activity)?.RunOnUiThread(() =>
                        {
                            AnotherForecastTimeTextViewHandler(s as TextView, GetMinutes(), _timeModel.Minutes.IndexOf(_minutesTextView.Text));
                        });
                    };
                }
                if (!_hourTextView.HasOnClickListeners)
                {
                    _hourTextView.Click += (s, e) =>
                    {
                        (_context as Activity)?.RunOnUiThread(() =>
                        {
                            AnotherForecastTimeTextViewHandler(s as TextView, GetHours(), _timeModel.Hours.IndexOf(_hourTextView.Text));
                        });
                    };
                }
                if (!_yearTextView.HasOnClickListeners)
                {
                    _yearTextView.Click += (s, e) =>
                    {
                        (_context as Activity)?.RunOnUiThread(() =>
                        {
                            AnotherForecastTimeTextViewHandler(s as TextView, GetYears(), _timeModel.Years.IndexOf(_yearTextView.Text));
                        });
                    };
                    _yearTextView.TextChanged += (s, e) =>
                    {
                        _monthTextView.Text = _timeModel.GetMonthByYear(_timeModel.Years.IndexOf(_yearTextView.Text))[0];
                    };
                }
                if (!_dayTextView.HasOnClickListeners)
                {
                    _dayTextView.Click += (s, e) =>
                    {
                        (_context as Activity)?.RunOnUiThread(() =>
                        {
                            AnotherForecastTimeTextViewHandler(s as TextView, GetDay(), _timeModel.GetDaysByMonth(_timeModel.MonthBias(_timeModel.Years.IndexOf(_yearTextView.Text))
                                + GetMonths().IndexOf(_monthTextView.Text)).IndexOf(_dayTextView.Text));
                        });
                    };
                }
                if (!_monthTextView.HasOnClickListeners)
                {
                    _monthTextView.Click += (s, e) =>
                    {
                        (_context as Activity)?.RunOnUiThread(() =>
                        {
                            AnotherForecastTimeTextViewHandler(s as TextView, GetMonths(), GetMonths().IndexOf(_monthTextView.Text));
                        });
                    };
                    _monthTextView.TextChanged += (s, e) =>
                    {
                        _dayTextView.Text = _timeModel.GetDaysByMonth(_timeModel.MonthBias(_timeModel.Years.IndexOf(_yearTextView.Text))
                            + GetMonths().IndexOf(_monthTextView.Text))[0];
                    };
                }
            }

            private void AnotherForecastTimeTextViewHandler(TextView sender, List<string> items, int defaultValueIndex)
            {
                _dayTextView.SetTextColor(Color.WhiteSmoke);
                _monthTextView.SetTextColor(Color.WhiteSmoke);
                _yearTextView.SetTextColor(Color.WhiteSmoke);
                _hourTextView.SetTextColor(Color.WhiteSmoke);
                _minutesTextView.SetTextColor(Color.WhiteSmoke);

                sender.SetTextColor(Color.ParseColor("#80cbc4"));

                SetPicker(items, defaultValueIndex);

                _activeTextView = sender;
            }

            private List<string> GetMonths()
            {
                return _timeModel.GetMonthByYear(_timeModel.Years.IndexOf(_yearTextView.Text));
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
                return _timeModel.GetDaysByMonth(_timeModel.MonthBias(_timeModel.Years.IndexOf(_yearTextView.Text))
                    + GetMonths().IndexOf(_monthTextView.Text));
            }

            private void SetPicker(List<string> items, int defaultValueIndex) 
            {
                var аrameLayout = AlertView.FindViewById<FrameLayout>(Resource.Id.createPost_pickerContainer_frameLayout);
                аrameLayout.RemoveAllViews();
                var picker = new NumberPicker(_context);
                var lparams = new FrameLayout.LayoutParams(
                    ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
                picker.LayoutParameters = lparams;

                picker.SetDisplayedValues(items.ToArray());
                picker.MinValue = 0;
                picker.MaxValue = items.Count - 1;
                picker.Value = defaultValueIndex;
                picker.ScrollBarSize = 8;
                picker.ScaleX = 1.5f;
                picker.ScaleY = 1.5f;
                picker.DescendantFocusability = DescendantFocusability.BlockDescendants;

                picker.ValueChanged += (s, e) => { _activeTextView.Text = items[picker.Value]; };

                аrameLayout.AddView(picker);
            }

            public string GetForecastTime()
            {
                var result = DateTime.Now;
                var currentDate = DateTime.Now;
                var forecastDate = new DateTime( // TODO: check it
                    Convert.ToInt32(_yearTextView.Text),
                    Convert.ToInt32(new List<string>(_presenter.GetMonthsLocale()).IndexOf(_monthTextView.Text) + 1), 
                    Convert.ToInt32(_dayTextView.Text), 
                    Convert.ToInt32(_hourTextView.Text.Split(' ')[0]), 
                    Convert.ToInt32(_minutesTextView.Text.Split(' ')[0]), 
                    0);

                if ((forecastDate - currentDate).TotalMinutes < 15)                               // HARDCODE ASK TO ROR
                {
                    result = currentDate.AddMinutes(15);
                }
                else
                {
                    result = forecastDate;
                }

                return result.ToString("yyyy-MM-dd HH:mm");
            }
        }

        #endregion

        private class Holder
        {
            public Holder(View viewGroup)
            {
                PhotoImageView = viewGroup.FindViewById<ImageView>(Resource.Id.createPost_profilePhoto_imageView);
                NameTextView = viewGroup.FindViewById<TextView>(Resource.Id.createPost_profileName_textView);
                PriceTextView = viewGroup.FindViewById<TextView>(Resource.Id.createPost_price_textView);
                CommentEditText = viewGroup.FindViewById<EditText>(Resource.Id.createPost_comment_editText);
                ToolsTextView = viewGroup.FindViewById<TextView>(Resource.Id.createPost_tools_textView);
                AddImageButton = viewGroup.FindViewById<ImageButton>(Resource.Id.createPost_addImage_button);
                AttachmentImageView = viewGroup.FindViewById<ImageView>(Resource.Id.createPost_attachment_imageView);
                AttachmentCancelImageView = viewGroup.FindViewById<ImageView>(Resource.Id.createPost_attachmentCancel_imageView);
                ForecastTimeTextView = viewGroup.FindViewById<TextView>(Resource.Id.createPost_time_textView);
                AccessModeTextView = viewGroup.FindViewById<TextView>(Resource.Id.createPost_accessMode_textView);
                BuySellTextView = viewGroup.FindViewById<TextView>(Resource.Id.createPost_buySell_textView);

                Scroll = viewGroup.FindViewById<ScrollView>(Resource.Id.createPost_scroll_scrollView);

                ToolBar = viewGroup.FindViewById<Toolbar>(Resource.Id.createPost_toolbar_toolbarOneButtonBack);
                ToolBarTitleTextView = viewGroup.FindViewById<TextView>(Resource.Id.toolbarOneButtonBack_title_textView);
                ToolBarPublishButton = viewGroup.FindViewById<Button>(Resource.Id.toolbarOneButtonBack_button);
                ToolBarBackImageButton = viewGroup.FindViewById<ImageButton>(Resource.Id.toolbarOneButtonBack_back_imageButton);

                CommentAreaRelativeLayout = viewGroup.FindViewById<RelativeLayout>(Resource.Id.createPost_commentArea_relativeLayout);

                DividingLineComment = viewGroup.FindViewById<View>(Resource.Id.createPost_dividingLineComment_view);
                DividingLineHeader = viewGroup.FindViewById<View>(Resource.Id.createPost_dividingLineHeader_view);
            }

            public ImageView PhotoImageView { get; }
            public TextView NameTextView { get; }
            
            public TextView PriceTextView { get; }
            public TextView ForecastTimeTextView { get; }
            public TextView AccessModeTextView { get; }
            public TextView BuySellTextView { get; }

            public EditText CommentEditText { get; }
            public TextView ToolsTextView { get; }
            public ImageButton AddImageButton { get; }
            public ImageView AttachmentImageView { get; }
            public ImageView AttachmentCancelImageView { get; }
            
            public ScrollView Scroll { get; }

            public Toolbar ToolBar { get; }
            public Button ToolBarPublishButton { get; }
            public TextView ToolBarTitleTextView { get; }
            public ImageButton ToolBarBackImageButton { get; }

            public RelativeLayout CommentAreaRelativeLayout { get; }

            public View DividingLineComment { get; }
            public View DividingLineHeader { get; }
        }

        private class Transformation : Java.Lang.Object, ITransformation
        {
            public string Key => "circle";

            public Bitmap Transform(Bitmap source)
            {
                int size = Math.Min(source.Width, source.Height);

                int x = (source.Width - size) / 2;
                int y = (source.Height - size) / 2;

                Bitmap squaredBitmap = Bitmap.CreateBitmap(source, x, y, size, size);
                if (squaredBitmap != source)
                {
                    source.Recycle();
                }

                Bitmap bitmap = Bitmap.CreateBitmap(size, size, source.GetConfig());

                Canvas canvas = new Canvas(bitmap);
                Paint paint = new Paint();
                BitmapShader shader = new BitmapShader(squaredBitmap,
                        BitmapShader.TileMode.Clamp, BitmapShader.TileMode.Clamp);
                paint.SetShader(shader);
                paint.AntiAlias = true;

                float r = size / 2f;
                canvas.DrawCircle(r, r, r, paint);

                squaredBitmap.Recycle();
                return bitmap;
            }
        }
    }
}

