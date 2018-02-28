using System;

using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Graphics;

using Square.Picasso;

using SocialTrading.Droid.Theme;
using SocialTrading.Droid.Tools;
using SocialTrading.Vipers.Post.Interfaces.Body;
using SocialTrading.ThemesStyles.Interfaces.TextView;

namespace SocialTrading.Droid.Views
{
    public class PostBodyView : RelativeLayout, IViewPostBody
    {
        private Holder _holder;

        public IPresenterPostBody Presenter { set; private get; }
        

        #region For RelatineLayout

        public PostBodyView(Context context) : base(context)
        {
            Init(context);
        }

        public PostBodyView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context);
        }

        public PostBodyView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init(context);
        }

        public PostBodyView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Init(context);
        }
        
        private void Init(Context context)
        {
            LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            inflater.Inflate(Resource.Layout.PostBodyView, this, true);

            _holder = new Holder(this);
        }

        private void SetButtonsActions()
        {
            if (!Presenter.IsPostDetailed && !_holder.ContentTextView.HasOnClickListeners)
            {
                _holder.ContentTextView.Click += (s, e) =>
                {
                    Presenter.ReadMoreClick();
                };
            }
        }

        #endregion

        #region IViewPostBody

        public void SetContent(string content, string readMore, ITextViewTheme mainTheme, ITextViewTheme attrTheme, int position)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.ContentTextView.SetTheme(mainTheme, content, attrTheme, readMore, position);
            }, null);
        }

        public void SetContent(string content, ITextViewTheme theme)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.ContentTextView.SetTheme(theme);
                _holder.ContentTextView.Text = content;
            }, null);
        }

        public void SetImage(string image)
        {
            if (string.IsNullOrEmpty(image))
            {
                _holder.ImageImageView.SetImageBitmap(null);
                return;
            }

            Application.SynchronizationContext.Post(_ =>
            {
                SetImageFromUrl(image);
            }, null);
        }

        private void SetImageFromBase64(string image)
        {
            var data = Convert.FromBase64String(image);
            _holder.ImageImageView.SetImageBitmap(BitmapFactory.DecodeByteArray(data, 0, data.Length));
        }

        private void SetImageFromUrl(string image)
        {
            Picasso.With(Context)
                .Load(image)
                .Placeholder(Android.Resource.Drawable.ProgressIndeterminateHorizontal)
                .Transform(new Transformation(_holder.ImageImageView.Width))
                .Into(_holder.ImageImageView);
        }

        public void SetConfig()
        {
            SetButtonsActions();
        }

        public void CacheImage(string cachedImage)
        {
            Presenter.SaveCachedImage(cachedImage);
        }

        #endregion

        private class Holder
        {
            public Holder(ViewGroup viewGroup)
            {
                ContentTextView = viewGroup.FindViewById<TextView>(Resource.Id.postBody_comment_textView);
                ImageImageView = viewGroup.FindViewById<ImageView>(Resource.Id.postBody_image_imageView);
            }

            public TextView ContentTextView { get; }
            
            public ImageView ImageImageView { get; }
        }
    }
}