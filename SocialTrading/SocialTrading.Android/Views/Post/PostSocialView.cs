using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;

using SocialTrading.Droid.Theme;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.Vipers.Post.Interfaces.Social;

namespace SocialTrading.Droid.Views
{
    public class PostSocialView : RelativeLayout, IViewPostSocial
    {
        private Holder _holder;

        public IPresenterPostSocial Presenter { set; private get; }

        #region For RelatineLayout

        public PostSocialView(Context context) : base(context)
        {
            Init(context);
        }

        public PostSocialView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context);
        }

        public PostSocialView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init(context);
        }

        public PostSocialView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Init(context);
        }

        private void Init(Context context)
        {
            LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            inflater.Inflate(Resource.Layout.PostSocialView, this, true);

            _holder = new Holder(this);
            SetButtonsActions();
        }

        private void SetButtonsActions()
        {
            if (!_holder.LikeTextView.HasOnClickListeners)
            {
                _holder.LikeTextView.Click += (s, e) =>
                {
                    Presenter.LikeClick();
                };
            }

            if (!_holder.CommentTextView.HasOnClickListeners)
            {
                _holder.CommentTextView.Click += (s, e) =>
                {
                    Presenter.CommentClick();
                };
            }

            if (!_holder.ShareTextView.HasOnClickListeners)
            {
                _holder.ShareTextView.Click += (s, e) =>
                {
                    Presenter.ShareClick();
                };
            }
        }

        #endregion


        #region IViewPostSocial
       
        public void SetConfig()
        {
        }

        public void ShowAlert(string title, string message)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
            }, null);
        }

        public void SetLikeDrawable(IButtonTheme theme)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.LikeTextView.SetTheme((ITextViewTheme) theme);
            }, null);
        }

        public void SetLikeTheme(IButtonTheme theme)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.LikeTextView.SetTheme((ITextViewTheme) theme);
            }, null);
        }

        public void SetCommentTheme(IButtonTheme theme)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.CommentTextView.SetTheme((ITextViewTheme) theme);
            }, null);
        }

        public void SetShareTheme(IButtonTheme theme)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.ShareTextView.SetTheme((ITextViewTheme) theme);
            }, null);
        }

        public void SetInteractionAvailable()
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.LikeTextView.Enabled = true;
                _holder.CommentTextView.Enabled = true;
                _holder.ShareTextView.Enabled = true;
            }, null);
        }

        public void SetInteractionUnavailable()
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.LikeTextView.Enabled = false;
                _holder.CommentTextView.Enabled = false;
                _holder.ShareTextView.Enabled = false;
            }, null);
        }

        public void SetLikeText(string like)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.LikeTextView.Text = like;
            }, null);
        }

        public void SetCommentText(string comment)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.CommentTextView.Text = comment;
            }, null);
        }

        public void SetShareText(string share)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                _holder.ShareTextView.Text = share;
            }, null);
        }

        #endregion


        private class Holder
        {
            public Holder(ViewGroup viewGroup)
            {
                LikeTextView = viewGroup.FindViewById<TextView>(Resource.Id.postSocial_like_textView);
                CommentTextView = viewGroup.FindViewById<TextView>(Resource.Id.postSocial_comment_textView);
                ShareTextView = viewGroup.FindViewById<TextView>(Resource.Id.postSocial_share_textView);
            }

            public TextView LikeTextView { get; }
            public TextView CommentTextView { get; }
            public TextView ShareTextView { get; }
        }
    }
}