using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Graphics;

using SocialTrading.Locale;
using SocialTrading.Vipers.Post.Interfaces.Statistics;

namespace SocialTrading.Droid.Views
{
    public class PostStatisticsView : RelativeLayout, IViewPostStatistics
    {
        private Holder _holder;

        public IPresenterPostStatistics Presenter { set; private get; }

        #region For RelatineLayout

        public PostStatisticsView(Context context) : base(context)
        {
            Init(context);
        }

        public PostStatisticsView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context);
        }

        public PostStatisticsView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init(context);
        }

        public PostStatisticsView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Init(context);
        }
        
        private void Init(Context context)
        {
            LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            inflater.Inflate(Resource.Layout.PostStatisticsView, this, true);

            _holder = new Holder(this);
        }

        #endregion


        #region IViewPostStatistics

        public void SetDeals(string actions)
        {
            
        }

        public void SetDealsStateNone()
        {
            
        }

        public void SetDealsStatePositive()
        {
            
        }

        public void SetLong(int size)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.RedLineTextView.SetHeight(size);
            });
        }

        public void SetLongPercent(string percent)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.LongPercentTextView.Text = percent;
            });
        }

        public void SetShortPercent(string percent)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.ShortPercentTextView.Text = percent;
            });
        }

        public void SetLongText(string value)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.LongTextView.Text = value;
            });
        }

        public void SetShortText(string value)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.ShortTextView.Text = value;
            });
        }

        public void SetPnL(string PnL)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PnLValueTextView.Text = PnL;
            });
        }

        public void SetPnLStateNegative()
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PnLValueTextView.SetTextColor(Color.Red);
            });
        }

        public void SetPnLStateNone()
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PnLValueTextView.SetTextColor(Color.Black);
            });
        }

        public void SetPnLStatePositive()
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PnLValueTextView.SetTextColor(Color.Green);
            });
        }

        public void SetConfig()
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PnLTextView.Text = Localization.Lang.PnL;
                _holder.DealsTextView.Text = Localization.Lang.DealsPost;
                _holder.ShortTextView.Text = Localization.Lang.ShortLabel;
                _holder.LongTextView.Text = Localization.Lang.LongLabel;

            });
        }

        public int GetStatisticsLineSize()
        {
            return _holder.GreenLineRelativeLayout.Width;
        }

        #endregion

        private class Holder
        {
            public Holder(ViewGroup viewGroup)
            {
                LongPercentTextView = viewGroup.FindViewById<TextView>(Resource.Id.postStatictics_longPercent_textView);
                ShortPercentTextView = viewGroup.FindViewById<TextView>(Resource.Id.postStatictics_shortPercent_textView);
                LongTextView = viewGroup.FindViewById<TextView>(Resource.Id.postStatictics_long_textView);
                ShortTextView = viewGroup.FindViewById<TextView>(Resource.Id.postStatictics_short_textView);
                DealsTextView = viewGroup.FindViewById<TextView>(Resource.Id.postStatictics_deals_textView);
                DealsValueTextView = viewGroup.FindViewById<TextView>(Resource.Id.postStatictics_dealsValue_textView);
                PnLTextView = viewGroup.FindViewById<TextView>(Resource.Id.postStatictics_pl_textView);
                PnLValueTextView = viewGroup.FindViewById<TextView>(Resource.Id.postStatictics_plValue_textView);
                GreenLineRelativeLayout = viewGroup.FindViewById<RelativeLayout>(Resource.Id.post_green_relativeLayout);
                RedLineTextView = viewGroup.FindViewById<TextView>(Resource.Id.post_red_textView);
            }

            public TextView LongPercentTextView { get; }
            public TextView ShortPercentTextView { get; }
            public TextView LongTextView { get; }
            public TextView ShortTextView { get; }
            public TextView DealsTextView { get; }
            public TextView DealsValueTextView { get; }
            public TextView PnLTextView { get; }
            public TextView PnLValueTextView { get; }
            public TextView RedLineTextView { get; }
            public RelativeLayout GreenLineRelativeLayout { get; }
        }
    }
}