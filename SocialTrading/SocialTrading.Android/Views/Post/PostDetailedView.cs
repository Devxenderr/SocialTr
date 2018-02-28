using System;
using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Runtime;
using SocialTrading.Theme;
using SocialTrading.Droid.Theme;
using SocialTrading.Theme.ThemeStrings;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Post.Implementation;
using SocialTrading.Vipers.Post.Interfaces;
using SocialTrading.Vipers.Trade.Interfaces;
using SocialTrading.Vipers.Post.Interfaces.Body;
using SocialTrading.Vipers.Post.Interfaces.Chart;
using SocialTrading.Vipers.Post.Interfaces.Header;
using SocialTrading.Vipers.Post.Interfaces.Social;
using SocialTrading.Vipers.Post.Interfaces.Statistics;

using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SocialTrading.Droid.Views.Post
{
    public class PostDetailedView : RelativeLayout, IViewPost, IViewDetailedPost
    {
        private LayoutInflater _inflater;
        public IPresenterPost Presenter { protected get; set; }

        public IViewPostBody ViewPostBody { get; protected set; }
        public IViewPostChart ViewPostChart { get; protected set; }
        public IViewPostHeader ViewPostHeader { get; protected set; }
        public IViewPostSocial ViewPostSocial { get; protected set; }
        public IViewPostStatistics ViewPostStatistics { get; protected set; }
        public IViewTrade ViewTrade { get; protected set; }

        public PostDetailedView(Context context) : base(context)
        {
        }

        public PostDetailedView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public PostDetailedView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public PostDetailedView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected PostDetailedView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }


        protected override void OnFinishInflate()
        {
            base.OnFinishInflate();
            _inflater = (LayoutInflater) Context.GetSystemService(Context.LayoutInflaterService);
            _inflater.Inflate(Resource.Layout.DetailedPostView, this, true);
            FindViews();
        }

        private void FindViews()
        {
            ViewPostBody = FindViewById<PostBodyView>(Resource.Id.detailedPost_postBody);
            ViewPostSocial = FindViewById<PostSocialView>(Resource.Id.detailedPost_postSocial);
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

        public void SetPostMarket(EMarketTypes type)
        {
            var headerContainer = FindViewById(Resource.Id.detailPost_postHeader_container) as ViewGroup;

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


        public void SetToolbarTheme(PostOtherThemeStrings otherThemeStrings, string title)
        {
            FrameLayout toolbarContainer = FindViewById<FrameLayout>(Resource.Id.detailedPost_postToolbar_frameLayout);
            Inflate(Context, Resource.Layout.ToolBarBackButtonTitle, toolbarContainer);

            var imageButton = FindViewById<ImageButton>(Resource.Id.toolbarBackButtonTitle_back_imageButton);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarBackButtonTitle_toolbar);
            var textView = FindViewById<TextView>(Resource.Id.toolbarBackButtonTitle_title_textView);


            textView.Text = title;
            textView.SetTheme(textColor: otherThemeStrings.ToolBarTitleColor);
            imageButton.SetTheme(otherThemeStrings.ToolBarBackImage, "");
            toolbar.SetTheme(otherThemeStrings.ToolBarBackground, 0);
        }

        public void SetActions()
        {
            var imageButton = FindViewById<ImageButton>(Resource.Id.toolbarBackButtonTitle_back_imageButton);
            if (!imageButton.HasOnClickListeners)
            {
                imageButton.Click += (o,e) =>
                {
                    (Presenter as PresenterPost)?.Back();
                };
            }
        }

    }
}