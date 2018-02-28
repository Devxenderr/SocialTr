using System;

using Square.Picasso;

using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Runtime;
using Android.Graphics;

using SocialTrading.Droid.Theme;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Vipers.ProfileCell.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;

namespace SocialTrading.Droid.Views.MoreOptions
{
    [Register("socialTrading.droid.views.moreOptions.ProfileCellView")]
    public class ProfileCellView : RelativeLayout, IProfileCellView
    {
        private Holder _holder;

        public IPresenterProfileCellForView Presenter { private get; set; }

        #region Init
        public ProfileCellView(Context context) : base(context)
        {
        }
        public ProfileCellView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }
        public ProfileCellView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }
        public ProfileCellView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }
        protected ProfileCellView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        protected override void OnFinishInflate()
        {
            base.OnFinishInflate();
            Init(Context);
        }

        private void Init(Context context)
        {
            _holder = new Holder(this);
        }
        #endregion

        #region Theme
        public void SetAvatarTheme(IImageViewTheme theme)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.AvatarImageView.SetTheme(theme);
            }, null);
        }

        public void SetBackgroundTheme(IViewTheme theme)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                this.SetTheme(theme);
            }, null);
        }

        public void SetNameTheme(ITextViewTheme theme)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.NameTitleTextView.SetTheme(theme);
            }, null);
        }

        public void SetProfileLabelTheme(ITextViewTheme theme)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.ProfileLabelTextView.SetTheme(theme);
            }, null);
        }
        #endregion

        public void SetAvatar(string avatarUrl)
        {
            RequestCreator picassoRequest;
            try
            {
                picassoRequest = Picasso.With(Context).Load(avatarUrl);
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

        public void SetConfig()
        {

        }

        public void SetName(string name)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.NameTitleTextView.Text = name;
            }, null);
        }

        public void SetProfileLabel(string name)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.ProfileLabelTextView.Text = name;
            }, null);
        }

        private class Holder
        {
            public ImageView AvatarImageView { get; }
            public TextView NameTitleTextView { get; }
            public TextView ProfileLabelTextView { get; }

            public Holder(ViewGroup viewGroup)
            {
                AvatarImageView = viewGroup.FindViewById<ImageView>(Resource.Id.moreOptions_profile_imageView);
                NameTitleTextView = viewGroup.FindViewById<TextView>(Resource.Id.moreOptions_nameTitle_textView);
                ProfileLabelTextView = viewGroup.FindViewById<TextView>(Resource.Id.moreOptions_yourProfileLabel_textView);
            }
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