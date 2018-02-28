using System;
using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Runtime;
using SocialTrading.Theme;
using SocialTrading.Droid.Theme;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Post.Interfaces;
using SocialTrading.Vipers.Trade.Interfaces;
using SocialTrading.Vipers.Post.Interfaces.Body;
using SocialTrading.Vipers.Post.Interfaces.Chart;
using SocialTrading.Vipers.Post.Interfaces.Header;
using SocialTrading.Vipers.Post.Interfaces.Social;
using SocialTrading.Vipers.Post.Interfaces.Statistics;

namespace SocialTrading.Droid.Views.Post
{
    public class PostView : RelativeLayout, IViewPost
    {
        private LayoutInflater _inflater;

        public IPresenterPost Presenter { get; set; }

        public IViewPostBody ViewPostBody { get; protected set; }
        public IViewPostChart ViewPostChart { get; protected set; }
        public IViewPostHeader ViewPostHeader { get; protected set; }
        public IViewPostSocial ViewPostSocial { get; protected set; }
        public IViewPostStatistics ViewPostStatistics { get; protected set; }
        public IViewTrade ViewTrade { get; protected set; }


        public PostView(Context context) : base(context)
        {
        }

        public PostView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public PostView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public PostView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected PostView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        protected override void OnFinishInflate()
        {
            base.OnFinishInflate();
            _inflater = (LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService);
            _inflater.Inflate(Resource.Layout.PostView, this, true);
            FindViews();
        }

        public void SetPostMarket(EMarketTypes type)
        {
            var headerContainer = FindViewById(Resource.Id.post_postHeader_container) as ViewGroup;

            switch (type)
            {
                case EMarketTypes.Simple:
                    if (headerContainer?.ChildCount == 0)
                    {
                        _inflater.Inflate(Resource.Layout.PostSimpleHeaderView, headerContainer);
                        ViewPostHeader = FindViewById<PostSimpleHeaderView>(Resource.Id.post_postHeader_simplelayout);
                    }
                    break;
                case EMarketTypes.Currency:
                case EMarketTypes.Stock:
                case EMarketTypes.Crypto:
                case EMarketTypes.Commodity:
                case EMarketTypes.Index:
                default:

                    if (headerContainer?.ChildCount == 0)
                    {
                        _inflater.Inflate(Resource.Layout.PostHeaderView, headerContainer);
                        ViewPostHeader = FindViewById<PostHeaderView>(Resource.Id.post_postHeader_layout);
                    }

                    break;
            }
            FindViews();
        }

        private void FindViews()
        {
            ViewPostBody = FindViewById<PostBodyView>(Resource.Id.post_postBody);
            ViewPostSocial = FindViewById<PostSocialView>(Resource.Id.post_postSocial);
            //ViewPostStatistics = FindViewById<PostStatisticsView>(Resource.Id.post_postStatistics);
            //ViewTrade = FindViewById<TradeView>(Resource.Id.post_postTrade);
            //ViewPostChart = FindViewById<PostChartView>(Resource.Id.post_postChart);
        }

        public void SetConfig()
        {
            ThemesHelper.PerformTheme(Application.Context, Themes.GetPostTheme());       
        }

        public void SetTheme()
        {
            //TODO find dividing lines, set themes
        }
    }
}