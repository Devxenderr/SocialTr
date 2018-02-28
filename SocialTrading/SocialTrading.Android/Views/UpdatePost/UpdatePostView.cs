using System;
using System.Collections.Generic;

using Square.Picasso;

using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;

using SocialTrading.Tools;
using SocialTrading.Droid.Theme;
using SocialTrading.Droid.Tools;
using SocialTrading.Tools.Enumerations;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Vipers.UpdatePost.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SocialTrading.Droid.Views.UpdatePost
{
    public class UpdatePostView : RelativeLayout, IViewUpdatePost
    {
        public IPresenterUpdatePost Presenter { get; set; }

        private Holder _holder;
        private const string SpinnerConst = "SpinnerTag";

        private List<string> _access;

        private LayoutInflater _inflater;

        public string AttachmentImage
        {
            private set => Presenter.SaveAttachedImage(value);
            get => Presenter.LoadAttachedImage() ?? string.Empty;
        }


        #region For RelatineLayout

        public UpdatePostView(Context context) : base(context)
        {
            Init(context);
        }

        public UpdatePostView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context);
        }

        public UpdatePostView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs,
            defStyleAttr)
        {
            Init(context);
        }

        public UpdatePostView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context,
            attrs, defStyleAttr, defStyleRes)
        {
            Init(context);
        }

        private void Init(Context context)
        {
            _inflater = ((Activity) context).LayoutInflater;
            _inflater.Inflate(Resource.Layout.UpdatePostView, this, true);

            _holder = new Holder(this);
            SetButtonsActions();

            InitSelectedItems();
        }

        private void InitSelectedItems()
        {
            _access = new List<string>
            {
                EAccessMode.Public.GetLocaleStringFromEnum(),
                EAccessMode.Private.GetLocaleStringFromEnum()
            };
        }

        private void SetButtonsActions()
        {
            _holder.ForecastTimeTextView.Focusable = false;
            _holder.BuySellTextView.Focusable = false;
            _holder.AccessModeTextView.Focusable = false;

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
                    Presenter.UpdatePost(
                        comment: _holder.CommentEditText.Text,
                        image: AttachmentImage,
                        access: _holder.AccessModeTextView.Text.GetAccessEnum());
                };
            }

            if (!_holder.ToolBarBackImageButton.HasOnClickListeners)
            {
                _holder.ToolBarBackImageButton.Click += (s, e) =>
                {
                    Presenter.BackClick();
                };
            }

            if (!_holder.AttachmentCancelImageView.HasOnClickListeners)
            {
                _holder.AttachmentCancelImageView.Click += (s, e) =>
                {
                    Presenter.DeleteImageClick();
                };
            }

            if (!_holder.CommentEditText.HasOnClickListeners)
            {
                _holder.CommentEditText.AfterTextChanged += (s, e) =>
                {
                    Presenter.CommentInput(_holder.CommentEditText.Text);
                };
                _holder.CommentEditText.Click += (s, e) =>
                {
                    (Context as Activity)?.RunOnUiThread(() =>
                    {
                        _holder.Scroll.Post(() => _holder.Scroll.FullScroll(FocusSearchDirection.Down));
                    });
                };
            }

            if (!_holder.AccessModeTextView.HasOnClickListeners)
            {
                _holder.AccessModeTextView.Click += (s, e) =>
                {
                    (Context as Activity)?.RunOnUiThread(() =>
                    {
                        Presenter.AccessModeClick();
                    });
                };
            }
        }

        #endregion
        
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

        public void ShowSuccessAlert(string message, string buttonTitle)
        {
            Toast.MakeText(Context, message, ToastLength.Long).Show();
            Presenter.GoToMain();
        }

        public void ShowFailAlert(string message, string buttonTitle)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                var alert = new AlertDialog.Builder(Context);

                alert.SetMessage(message)
                    .SetPositiveButton(buttonTitle, (senderAlert, args) => { });

                Dialog dialog = alert.Create();
                dialog.Show();
            });
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

            spinnerViewAuth.Touch += (sender, args) => { };
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


        public void SetComment(string enterCommentLabel)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.CommentEditText.Text = enterCommentLabel;
            });
        }

        public void SetCommentHint(string enterCommentLabel)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.CommentEditText.Hint = enterCommentLabel;
            });
        }

        public void SetForecastTime(string timeTextView)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.ForecastTimeTextView.Text = timeTextView;
            });
        }

        public void SetAccessMode(string accessModeTextView)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.AccessModeTextView.Text = accessModeTextView;
            });
        }

        public void SetBuySell(string buySellTextView)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.BuySellTextView.Text = buySellTextView;
            });
        }

        public void SetTools(string toolsButton)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.ToolsTextView.Text = toolsButton;
            });
        }

        public void SetPrice(string priceLabel)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PriceTextView.Text = priceLabel;
            });
        }

        public void SetToolBarPublishButtonLocale(string publishButton)
        {
            _holder.ToolBarPublishButton.Text = publishButton;
        }

        public void SetToolBarTitleTextViewLocale(string activityTitle)
        {
            _holder.ToolBarTitleTextView.Text = activityTitle;
        }

        public void SetImageLink(string imageLink)
        {
            Picasso.With(Context).Load(imageLink).Into(new Target(SetImage));
        }

        public void SetImage(string image)
        {
            ShowSelectedImage(image);
            AttachmentImage = image;
        }
        
        private void ShowSelectedImage(string image)
        {
            var bitmap = image.FromBase64();
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

        public void ImageDeleted()
        {
            AttachmentImage = string.Empty;   
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.AttachmentImageView.SetImageBitmap(null);
                _holder.AttachmentCancelImageView.Visibility = ViewStates.Invisible;
            });
        }

        public void AccessModeSelection(string alertTitle, string cancelTitle, string okTitle = null)
        {
            ShowItemsAlert(alertTitle, cancelTitle, _access);
        }

        private void ShowItemsAlert(string title, string cancel, IReadOnlyList<string> items)
        {
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
                .SetNegativeButton(cancel, (o, e) => { });

            dialog = builder.Show();
        }

        private void SelectedItemClick(object sender, EventArgs e)
        {
            var selectedItem = (sender as TextView)?.Text;
            
            _holder.AccessModeTextView.Text = selectedItem;
            Presenter.AccessModeSelected(_holder.AccessModeTextView.Text.GetAccessEnum());
        }

        public void NeedToSaveData()
        {
            Presenter.SaveData(_holder.AccessModeTextView.Text.GetAccessEnum(), _holder.CommentEditText.Text, AttachmentImage);
        }

        private class Holder
        {
            public Holder(View viewGroup)
            {
                PhotoImageView = viewGroup.FindViewById<ImageView>(Resource.Id.updatePost_profilePhoto_imageView);
                NameTextView = viewGroup.FindViewById<TextView>(Resource.Id.updatePost_profileName_textView);
                PriceTextView = viewGroup.FindViewById<TextView>(Resource.Id.updatePost_price_textView);
                CommentEditText = viewGroup.FindViewById<EditText>(Resource.Id.updatePost_comment_editText);
                ToolsTextView = viewGroup.FindViewById<TextView>(Resource.Id.updatePost_tools_textView);
                AddImageButton = viewGroup.FindViewById<ImageButton>(Resource.Id.updatePost_addImage_button);
                AttachmentImageView = viewGroup.FindViewById<ImageView>(Resource.Id.updatePost_attachment_imageView);
                AttachmentCancelImageView =
                    viewGroup.FindViewById<ImageView>(Resource.Id.updatePost_attachmentCancel_imageView);
                ForecastTimeTextView = viewGroup.FindViewById<TextView>(Resource.Id.updatePost_time_textView);
                AccessModeTextView = viewGroup.FindViewById<TextView>(Resource.Id.updatePost_accessMode_textView);
                BuySellTextView = viewGroup.FindViewById<TextView>(Resource.Id.updatePost_buySell_textView);

                Scroll = viewGroup.FindViewById<ScrollView>(Resource.Id.updatePost_scroll_scrollView);

                ToolBar = viewGroup.FindViewById<Toolbar>(Resource.Id.updatePost_toolbar_toolbarOneButtonBack);
                ToolBarTitleTextView =
                    viewGroup.FindViewById<TextView>(Resource.Id.toolbarOneButtonBack_title_textView);
                ToolBarPublishButton = viewGroup.FindViewById<Button>(Resource.Id.toolbarOneButtonBack_button);
                ToolBarBackImageButton =
                    viewGroup.FindViewById<ImageButton>(Resource.Id.toolbarOneButtonBack_back_imageButton);

                CommentAreaRelativeLayout =
                    viewGroup.FindViewById<RelativeLayout>(Resource.Id.updatePost_commentArea_relativeLayout);

                DividingLineComment = viewGroup.FindViewById<View>(Resource.Id.updatePost_dividingLineComment_view);
                DividingLineHeader = viewGroup.FindViewById<View>(Resource.Id.updatePost_dividingLineHeader_view);
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

        private class Target : Java.Lang.Object, ITarget
        {
            private readonly Action<string> _setImage;


            public Target(Action<string> setImage)
            {
                _setImage = setImage;
            }


            public void OnBitmapFailed(Drawable p0)
            {
                _setImage?.Invoke(string.Empty);
            }

            public void OnBitmapLoaded(Bitmap p0, Picasso.LoadedFrom p1)
            {
                _setImage?.Invoke(p0.GetImageBase64());
            }


            public void OnPrepareLoad(Drawable p0) { }
        }
    }
}