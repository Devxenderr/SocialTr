using System;
using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Runtime;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using SocialTrading.Droid.Theme;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.Vipers.MoreOptions;
using SocialTrading.Vipers.MoreOptions.ToolBar.Interfaces;

namespace SocialTrading.Droid.Views.MoreOptions
{
    [Register("socialTrading.droid.views.moreOptions.ToolBarBackView")]
    public class ToolBarBackView : Toolbar, IToolBarBackView
    {
        private Holder _holder;
        public ToolBarBackView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public ToolBarBackView(Context context) : base(context)
        {
            Init(context);
        }

        public ToolBarBackView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context);
        }

        public ToolBarBackView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init(context);
        }

        private void Init(Context context)
        {
            LayoutInflater inflater = ((Activity)context).LayoutInflater;
            inflater.Inflate(Resource.Layout.ToolBarBackView, this, true);

            _holder = new Holder(this);
            if (!_holder.ImageButton.HasOnClickListeners)
            {
                _holder.ImageButton.Click += BackImageButton_Click;
            }
        }

        private void BackImageButton_Click(object sender, EventArgs e)
        {
            if (sender is ImageButton)
            {
                Presenter.BackClick();
            }
        }

        public IPresenterToolBarBack Presenter { private get; set; }
        public void SetTitle(string title)
        {
            _holder.TitleTextView.Text = title;
        }

        public void SetBackButtonTheme(IImageButtonTheme theme)
        {
            _holder.ImageButton.SetTheme(theme);
        }

        public void SetTitleTheme(ITextViewTheme theme)
        {
            _holder.TitleTextView.SetTheme(theme);
        }

        public void SetViewTheme(IViewTheme theme)
        {
            this.SetTheme(theme);
        }

        private class Holder
        {
            public ImageButton ImageButton { get; }
            public TextView TitleTextView { get; }

            public Holder(ViewGroup viewGroup)
            {
                ImageButton = viewGroup.FindViewById<ImageButton>(Resource.Id.toolbar_back_imageButton);
                TitleTextView = viewGroup.FindViewById<TextView>(Resource.Id.toolbar_title_textView);
            }
        }
    }
}