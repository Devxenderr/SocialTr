using System;

using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Runtime;
using Android.Content;
using Android.Graphics;

using SocialTrading.Droid.Theme;
using SocialTrading.Vipers.Post.Interfaces.Header;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

using Square.Picasso;

namespace SocialTrading.Droid.Views
{
    [Register("socialTrading.droid.views.PostSimpleHeaderView")]
    public class PostSimpleHeaderView : RelativeLayout, IViewPostHeader
    {
        private Holder _holder;
        private bool isFavorite;

        public IPresenterPostHeader Presenter { get; set; }

        #region For RelatveLayout

        protected PostSimpleHeaderView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public PostSimpleHeaderView(Context context) : base(context)
        {
        }

        public PostSimpleHeaderView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public PostSimpleHeaderView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public PostSimpleHeaderView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        public void SetConfig()
        {
           
        }
        #endregion

        protected override void OnFinishInflate()
        {
            base.OnFinishInflate();

            _holder = new Holder(this);
            SetButtonsActions();
        }

        #region PostSimpleHeader
        private void SetButtonsActions()
        {

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

        public void SetName(string name)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.UserNameTextView.Text = name;
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

        public void CacheImage(string imageUrl)
        {
            Presenter.SaveCachedImage(imageUrl);
        }

        public void SetFirstLastNameTheme(ITextViewTheme theme)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.UserNameTextView.SetTheme(theme);
            }, null);
        }

        public void MoreOptionsButtonTheme(IImageButtonTheme theme)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.OptionsImageButton.SetTheme(theme);
            }, null);
        }

        public void SetDateTheme(ITextViewTheme theme)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.DateTextView.SetTheme(theme);
            }, null);
        }

        public void ShowDeletingDialog(string message, string title, string okButtonText, string cancelButtonText)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                var alert = new AlertDialog.Builder(Context);

                alert.SetTitle(title)
                    .SetMessage(message)
                    .SetNegativeButton(cancelButtonText, (senderAlert, args) => { })
                    .SetPositiveButton(okButtonText, (senderAlert, args) => { Presenter.ConfirmDeleteClick(); });

                Dialog dialog = alert.Create();
                dialog.Show();
            }, null);
        }
        #endregion

        private class Holder
        {
            public Holder(ViewGroup viewGroup)
            {
                UserNameTextView = viewGroup.FindViewById<TextView>(Resource.Id.postHeader_userFirstName_textView);
                DateTextView = viewGroup.FindViewById<TextView>(Resource.Id.postHeader_postDate_textView);
                AvatarImageView = viewGroup.FindViewById<ImageView>(Resource.Id.postHeader_userAvatar_imageView);
                OptionsImageButton = viewGroup.FindViewById<ImageButton>(Resource.Id.postHeader_options_button);
            }

            public TextView UserNameTextView { get; }
            public TextView DateTextView { get; }
            public ImageView AvatarImageView { get; }
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
        #region PostHeaderFullMethods

        public void SetStateOnline(IImageViewTheme theme)
        {

        }

        public void SetQuote(string quote)
        {
            
        }

        public void SetRecommend(string recommend)
        {
            
        }

        public void SetRecommendValue(string recommend, int position)
        {
           
        }

        public void SetRecommendBuySellImage(IImageViewTheme theme)
        {
            
        }

        public void SetFavoriteState(bool state, IImageButtonTheme theme)
        {
           
        }

        public void SetCurrentPrice(string currentPrice, int position)
        {
            
        }

        public void SetCurrentPriceImg(IImageViewTheme theme)
        {
            
        }

        public void SetDifference(string difference)
        {
            
        }

        public void SetDifferenceValue(ITextViewTheme theme)
        {
            
        }

        public void SetForecastTime(string time)
        {
            
        }

        public double GetPreviousPrice()
        {
            return 0;
        }

        public void SetQuoteTheme(ITextViewTheme theme)
        {
           
        }

        public void SetBuySellTheme(ITextViewTheme theme)

        {
           
        }

        public void SetBuySellValueTheme(ITextViewTheme theme)
        {

        }

        public void SetForecastTheme(ITextViewTheme theme)
        {

        }

        public void SetCurrentPriceTheme(ITextViewTheme theme)
        {

        }

        public void SetDiffTheme(ITextViewTheme theme)
        {
            
        }

        public void SetDiffValueTheme(ITextViewTheme theme)
        {
            
        }

        public void SetDifferenceLocale(string v)
        {
            
        }
        #endregion
    }
}