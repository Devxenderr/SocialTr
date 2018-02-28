using System;
using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;
using SocialTrading.Droid.Theme;
using SocialTrading.Vipers.Post.Interfaces.Header;
using Square.Picasso;
using SocialTrading.Droid.Tools;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.View;
using Android.Graphics;
using Android.Runtime;

namespace SocialTrading.Droid.Views
{
    [Register("socialTrading.droid.views.PostHeaderView")]
    public class PostHeaderView : RelativeLayout, IViewPostHeader
    {
        private Holder _holder;

        public IPresenterPostHeader Presenter { get; set; }
        private bool isFavorite;

        #region For RelatineLayout

        public PostHeaderView(Context context) : base(context)
        {
        }

        public PostHeaderView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public PostHeaderView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public PostHeaderView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected PostHeaderView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        #endregion

        protected override void OnFinishInflate()
        {
            base.OnFinishInflate();

            _holder = new Holder(this);
            SetButtonsActions();
            _holder.StatusImageView.Visibility = ViewStates.Gone;
            _holder.FavoriteImageButton.Visibility = ViewStates.Gone; //TODO remove hardcode
        }

        private void SetButtonsActions()
        {
            if (!_holder.FavoriteImageButton.HasOnClickListeners)
            {
                _holder.FavoriteImageButton.Click += (s, e) =>
                {
                    Presenter.FavoriteClick(isFavorite);
                };
            }

            if (!_holder.OptionsImageButton.HasOnClickListeners)
            {
                _holder.OptionsImageButton.Click += (s, e) =>
                {
                    Presenter.OptionsClick();
                };
            }

            if (!_holder.UserNameTextView.HasOnClickListeners)
            {
                _holder.UserNameTextView.Click += (s, e) =>
                {
                    Presenter.ProfileClick();
                };
            }

            if (!_holder.AvatarImageView.HasOnClickListeners)
            {
                _holder.AvatarImageView.Click += (s, e) =>
                {
                    Presenter.ProfileClick();
                };
            }
        }
      
        #region IViewPostHeader

        public void OptionsHide()
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.OptionsImageButton.Visibility = ViewStates.Invisible;
            }, null);
        }

        public void OptionsShow()
        {
            _holder.OptionsImageButton.Visibility = ViewStates.Visible;
        }

        public void ShowErrorAlert(string message, string title)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
            }, null);
        }


        public double GetPreviousPrice()
        {
            string currentPrice = _holder.CurrentPriceValueTextView.Text;
            if (string.IsNullOrEmpty(currentPrice))
            {
                return 0;
            }
            try
            {
                return Convert.ToDouble(currentPrice);
            }
            catch
            {
                return 0;
            }           
        }

        public void OptionsDialogShow(string title, string delete, string edit)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                Context wrapper = new ContextThemeWrapper(Context, Resource.Style.PostPopupMenu);
                PopupMenu menu = new PopupMenu(wrapper, _holder.OptionsImageButton);
            
                menu.MenuInflater.Inflate(Resource.Menu.postHeader_popupMenu, menu.Menu);
                menu.Menu.Add(Menu.None, 1, Menu.First, edit);
                menu.Menu.Add(Menu.None, 2, Menu.None, delete);
                menu.Show();

                menu.MenuItemClick += (sender, args) =>
                {
                    if (args.Item.ItemId == 1)
                    {
                        Presenter.EditClick();
                    }
                    if (args.Item.ItemId == 2)
                    {
                        Presenter.DeleteClick();
                    }

                };
            }, null);
        }

        public void SetAvatar(string avatar)
        {
            if (string.IsNullOrEmpty(avatar))
            {
                return;
            }

            Application.SynchronizationContext.Post(_ =>
            {
                SetImageFromUrl(avatar);
            }, null);
        }

        private void SetImageFromUrl(string image)
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
                .Into(_holder.AvatarImageView);
            }, null);
        }

        public void CacheImage(string imageUrl)
        {
            Presenter.SaveCachedImage(imageUrl);
        }

        public void SetDefaultAvatar(IImageViewTheme theme)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.AvatarImageView.SetTheme(theme);
            }, null);
        }

        public void SetCreateTime(string time)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                _holder.DateTextView.Text = time;
             }, null);
        }

        public void SetCurrentPrice(string currentPrice, int position)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                _holder.CurrentPriceValueTextView.SetThemeDifferentLetterSize(currentPrice, position);
             }, null);
        }

        public void SetCurrentPriceImg(IImageViewTheme theme)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                _holder.ArrowImageView.SetTheme(theme);
             }, null);
        }

        public void SetFavoriteState(bool state, IImageButtonTheme theme)
        {
             Application.SynchronizationContext.Post(_ =>
            {
               _holder.FavoriteImageButton.SetTheme(theme);
            }, null);
            isFavorite = state;
       }

        public void SetForecastTime(string time)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                _holder.ForecastTimeValueTextView.Text = time;
             }, null);
        }

        public void SetName(string name)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                _holder.UserNameTextView.Text = name;
             }, null);
        }

        public void SetDifference(string diff)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                _holder.DifferenceValueTextView.Text = diff;
             }, null);
        }

        public void SetDifferenceValue(ITextViewTheme theme)
        {
             Application.SynchronizationContext.Post(_ =>
             {
               _holder.DifferenceValueTextView.SetTheme(theme);
             }, null);
        }

        public void SetQuote(string quote)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                _holder.ToolTextView.Text = quote;
             }, null);
        }

        public void SetRecommend(string recommend)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                 _holder.BuySellTextView.Text = recommend;
             }, null);
        }

        public void SetRecommendValue(string recommend, int position)
        {
           // _holder.BuySellValueTextView.SetThemeDifferentLetterSize(recommend, position);
            _holder.BuySellValueTextView.Text = recommend;
        }

        public void SetRecommendBuySellImage(IImageViewTheme theme)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                _holder.BuySellImageView.SetTheme(theme);
                _holder.BuySellLayout.SetTheme((IViewTheme) theme);
             }, null);
        }

        public void SetStateOnline(IImageViewTheme theme)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                _holder.StatusImageView.SetTheme(theme);
             }, null);
        }

        public void ShowDeletingDialog(string message, string title, string okButtonText, string cancelButtonText)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                var alert = new AlertDialog.Builder(Context);

                alert.SetTitle(title)
                    .SetMessage(message)
                    .SetNegativeButton(cancelButtonText, (senderAlert, args) => {})
                    .SetPositiveButton(okButtonText, (senderAlert, args) => { Presenter.ConfirmDeleteClick();});

                Dialog dialog = alert.Create();
                dialog.Show();
             }, null);
        }  

        public void SetConfig()
        {
            Application.SynchronizationContext.Post(_ =>
            {
                
            }, null);
            Presenter.SetLocale();
        }

        public void MoreOptionsButtonTheme(IImageButtonTheme theme)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                _holder.OptionsImageButton.SetTheme(theme);
             }, null);
        }

        public void SetFirstLastNameTheme(ITextViewTheme theme)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                _holder.UserNameTextView.SetTheme(theme);
             }, null);
        }

        public void SetDateTheme(ITextViewTheme theme)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                _holder.DateTextView.SetTheme(theme);
             }, null);
        }

        public void SetQuoteTheme(ITextViewTheme theme)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                _holder.ToolTextView.SetTheme(theme);
             }, null);
        }

        public void SetBuySellTheme(ITextViewTheme theme)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                _holder.BuySellTextView.SetTheme(theme);
             }, null);
        }

        public void SetBuySellValueTheme(ITextViewTheme theme)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                _holder.BuySellValueTextView.SetTheme(theme);
             }, null);
        }

        public void SetForecastTheme(ITextViewTheme theme)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                _holder.ForecastTimeValueTextView.SetTheme(theme);
             }, null);
        }

        public void SetCurrentPriceTheme(ITextViewTheme theme)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                _holder.CurrentPriceValueTextView.SetTheme(theme);
             }, null);
        }

        public void SetDiffTheme(ITextViewTheme theme)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                _holder.DifferenceTextView.SetTheme(theme);
               }, null);
        }

        public void SetDiffValueTheme(ITextViewTheme theme)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                _holder.DifferenceValueTextView.SetTheme(theme);
             }, null);
        }

        public void SetDifferenceLocale(string diffText)
        {
             Application.SynchronizationContext.Post(_ =>
             {
                _holder.DifferenceTextView.Text = diffText;
             }, null);
        }

        #endregion


        private class Holder
        {
            public Holder(ViewGroup viewGroup)
            {
                UserNameTextView = viewGroup.FindViewById<TextView>(Resource.Id.postHeader_userFirstName_textView);
                DateTextView = viewGroup.FindViewById<TextView>(Resource.Id.postHeader_postDate_textView);
                ForecastTimeValueTextView = viewGroup.FindViewById<TextView>(Resource.Id.postHeader_forecastTimeValue_textView);
                ToolTextView = viewGroup.FindViewById<TextView>(Resource.Id.postHeader_tool_textView);
                BuySellTextView = viewGroup.FindViewById<TextView>(Resource.Id.postHeader_buySell_textView);
                CurrentPriceValueTextView = viewGroup.FindViewById<TextView>(Resource.Id.postHeader_currentPriceValue_textView);
                DifferenceTextView = viewGroup.FindViewById<TextView>(Resource.Id.postHeader_difference_textView);
                DifferenceValueTextView = viewGroup.FindViewById<TextView>(Resource.Id.postHeader_diffValue_textView);

                BuySellValueTextView = viewGroup.FindViewById<TextView>(Resource.Id.postHeader_buySellValue_textView);

                AvatarImageView = viewGroup.FindViewById<ImageView>(Resource.Id.postHeader_userAvatar_imageView);
                ArrowImageView = viewGroup.FindViewById<ImageView>(Resource.Id.postHeader_arrow_imageView);
                StatusImageView = viewGroup.FindViewById<ImageView>(Resource.Id.postHeader_userStatus_imageView);
                BuySellImageView = viewGroup.FindViewById<ImageView>(Resource.Id.postHeader_buySell_imageView);
                BuySellLayout = viewGroup.FindViewById<RelativeLayout>(Resource.Id.postHeader_BuySellLayout);

                FavoriteImageButton = viewGroup.FindViewById<ImageButton>(Resource.Id.postHeader_favorites_button);
                OptionsImageButton = viewGroup.FindViewById<ImageButton>(Resource.Id.postHeader_options_button);
            }

            public TextView UserNameTextView { get; }
            public TextView DateTextView { get; }
            public TextView ForecastTimeValueTextView { get; }
            public TextView ToolTextView { get; }
            public TextView BuySellTextView { get; }
            public TextView CurrentPriceValueTextView { get; }
            public TextView DifferenceTextView { get; }
            public TextView DifferenceValueTextView { get; }
            public TextView BuySellValueTextView { get; }

            public ImageView AvatarImageView { get; }
            public ImageView ArrowImageView { get; }
            public ImageView StatusImageView { get; }
            public ImageView BuySellImageView { get; }
            public RelativeLayout BuySellLayout { get; }
            
            public ImageButton FavoriteImageButton { get; }
            public ImageButton OptionsImageButton { get; }
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
