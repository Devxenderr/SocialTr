using UIKit;
using Foundation;

using System;
using System.ComponentModel;

using SocialTrading.Theme;
using SocialTrading.iOS.Theme;
using SocialTrading.Vipers.Post.Interfaces;
using SocialTrading.Vipers.Trade.Interfaces;
using SocialTrading.Vipers.Post.Interfaces.Body;
using SocialTrading.Vipers.Post.Interfaces.Chart;
using SocialTrading.Vipers.Post.Interfaces.Header;
using SocialTrading.Vipers.Post.Interfaces.Social;
using SocialTrading.Vipers.Post.Interfaces.Statistics;
using SocialTrading.Theme.ThemeStrings;
using SocialTrading.Tools.Enumerations;

namespace SocialTrading.iOS
{
    [DesignTimeVisible(true)]
    public partial class DetailedPostView : UIView, IComponent, IViewPost, IViewDetailedPost
    {
        private IViewPostHeader _headerView;

        public UIView HeaderContainer => _postHeaderContainer;

        public IViewPostBody ViewPostBody => _postBodyView;
        public IViewPostHeader ViewPostHeader => _headerView;
        public IViewPostSocial ViewPostSocial => _postSocialView;
        public IViewPostStatistics ViewPostStatistics { get; }
        public IViewPostChart ViewPostChart { get; }
        public IViewTrade ViewTrade { get; }
        
        public IPresenterPost Presenter { get; set; }

        #region IComponent realization

        public ISite Site { get; set; }
        public NSLayoutConstraint HeightContainer { get; private set; }

        public event EventHandler Disposed;

        #endregion


        public DetailedPostView(IntPtr handle) : base(handle)
        {
        }


        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            if (Site != null)
            {
                return;
            }

            NSBundle.MainBundle.LoadNib("DetailedPostView", this, null);

            InvokeOnMainThread(() =>
            {
                var frame = _rootView.Frame;
                frame.Height = Frame.Height;
                frame.Width = Frame.Width;
                _rootView.Frame = frame;
                AddSubview(_rootView);
            });
        }

        public void SetConfig()
        {
            ThemeHelper.PerformTheme(Themes.GetPostTheme());
        }

        public void SetTheme()
        {
            //TODO color dividing lines
        }

        public void SetToolbarTheme(PostOtherThemeStrings otherThemeStrings, string title)
        {
            
        }

        public void SetActions()
        {
            
        }

        public void SetPostMarket(EMarketTypes type)
        {
            InvokeOnMainThread(() =>
            {
                foreach (var item in _postHeaderContainer.Subviews)
                {
                    item.RemoveFromSuperview();
                }
                var constr = _postHeaderContainer.Constraints;
                _postHeaderContainer.RemoveConstraints(constr);
            });

            if (type == EMarketTypes.Simple)
            {
                CreateHeader(new PostSimpleHeaderView(), 80);                   // header height 80
            }
            else
            {
                CreateHeader(new PostHeaderView(), 160);                        // header height 160
            }
        }

        private void CreateHeader(UIView header, int height)
        {
            _headerView = header as IViewPostHeader;
            (_headerView as UIView).TranslatesAutoresizingMaskIntoConstraints = false;

            _postHeaderContainer.AddSubview(_headerView as UIView);

            //var heightHeader = NSLayoutConstraint.Create(_headerView as UIView, NSLayoutAttribute.Height, NSLayoutRelation.Equal, 1, height);
            HeightContainer = NSLayoutConstraint.Create(_postHeaderContainer, NSLayoutAttribute.Height, NSLayoutRelation.Equal, 1, height);
            var Width = NSLayoutConstraint.Create(_postHeaderContainer, NSLayoutAttribute.Width, NSLayoutRelation.Equal, 1, _postHeaderContainer.Frame.Width);
            var top = NSLayoutConstraint.Create(_headerView as UIView, NSLayoutAttribute.Top, NSLayoutRelation.Equal, _postHeaderContainer, NSLayoutAttribute.Top, 1, 0);
            var bottom = NSLayoutConstraint.Create(_headerView as UIView, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, _postHeaderContainer, NSLayoutAttribute.Bottom, 1, 0);
            var left = NSLayoutConstraint.Create(_headerView as UIView, NSLayoutAttribute.Left, NSLayoutRelation.Equal, _postHeaderContainer, NSLayoutAttribute.Left, 1, 0);
            var right = NSLayoutConstraint.Create(_headerView as UIView, NSLayoutAttribute.Right, NSLayoutRelation.Equal, _postHeaderContainer, NSLayoutAttribute.Right, 1, 0);

            InvokeOnMainThread(() =>
            {
                NSLayoutConstraint.ActivateConstraints(new NSLayoutConstraint[] { top, bottom, left, right, HeightContainer, Width/*, heightHeader*/ });
                LayoutIfNeeded();
            });
        }
    }
}