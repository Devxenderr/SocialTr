using System;
using System.Reflection;

using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;

using SocialTrading.Droid.Theme;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.Vipers.MoreOptions.OptionsCell.Interfaces;

namespace SocialTrading.Droid.Views.MoreOptions
{
    public class OptionsCellView : LinearLayout, IViewOptionsCell
    {
        private Holder _holder;

        public IPresenterOptionsCellForView Presenter { private get; set; }


        #region ForRelativeLayout

        public OptionsCellView(Context context) : base(context)
        {
        }

        public OptionsCellView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public OptionsCellView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public OptionsCellView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected override void OnFinishInflate()
        {
            base.OnFinishInflate();

            _holder = new Holder(this);
            SetButtonsActions();
        }

        private void SetButtonsActions()
        {
            if (!HasOnClickListeners)
            {
                Click += (s, e) =>
                {
                    Presenter.CellClick();
                };

            }
        }

        #endregion


        public void SetBackgroundTheme(IViewTheme theme)
        {
            this.SetTheme(theme);
        }

        public void SetImageTheme(IImageViewTheme theme)
        {
            _holder.OptionImageView.SetTheme(theme);
            GradientDrawable shape = new GradientDrawable();
            shape.SetColor((Color)theme.BackgroundColor);
            shape.SetCornerRadius(1000);
            _holder.OptionImageView.Background = shape;
        }

        public void SetTextTheme(ITextViewTheme theme)
        {
            _holder.OptionTextView.SetTheme(theme);
        }

        public void SetImage(string imageName)
        {
            var field = typeof(Resource.Drawable).GetRuntimeField(imageName);
            var id = Convert.ToInt32(field.GetValue(field));
            _holder.OptionImageView.SetImageResource(id);
        }

        public void SetText(string localeString)
        {
            _holder.OptionTextView.Text = localeString;
        }

        private class Holder
        {
            public Holder(View viewGroup)
            {
                OptionImageView = viewGroup.FindViewById<ImageView>(Resource.Id.optionsCell_image_imageView);
                OptionTextView = viewGroup.FindViewById<TextView>(Resource.Id.optionsCell_text_textView);
            }

            public ImageView OptionImageView { get; }
            public TextView OptionTextView { get; }
        }
    }
}