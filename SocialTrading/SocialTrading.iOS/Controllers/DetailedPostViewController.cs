using UIKit;
using Foundation;

using System;

using SocialTrading.Theme;
using SocialTrading.Service;
using SocialTrading.iOS.Cells;
using SocialTrading.iOS.Theme;
using SocialTrading.iOS.Tools;
using SocialTrading.iOS.Routers;
using SocialTrading.iOS.Routers.MoreOptions;
using SocialTrading.iOS.Views.MoreOptions;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Vipers.MoreOptions.ToolBar.Implementation;
using SocialTrading.Vipers.Post.Interfaces;
using SocialTrading.Vipers.Post.Implementation;
using SocialTrading.Vipers.Post.Implementation.Body;
using SocialTrading.Vipers.Post.Implementation.Header;
using SocialTrading.Vipers.Post.Implementation.Social;
using SocialTrading.Tools.Enumerations;

namespace SocialTrading.iOS
{
    public partial class DetailedPostViewController : UITableViewController
    {
        public string PostId { get; set; }

        public Action<int, nfloat> PostHeightCounted;
        
        private IInteractorPost _interactor;
        private DetailedPostView _detailedPostView;
        private DetailedPostTableViewCell _cell;
        private GlobalTimer _globalTimer;

        public DetailedPostViewController()
        {
        }

        public DetailedPostViewController (IntPtr handle) : base (handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _rootTableView.AllowsSelection = false;
            _rootTableView.RegisterNibForCellReuse(DetailedPostTableViewCell.Nib, DetailedPostTableViewCell.Key);
            _rootTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            
            NavigationController.NavigationBar.Hidden = false;
            var toolbarBackView = new ToolBarBackView(NavigationItem, NavigationController.NavigationBar);
            var routerToolBarBack = new RouterToolBarBack(NavigationController);
            var stylesHolderToolBarBack = new ToolBarBackStylesHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser);
            var title = "";
            var presenterToolBarBack = new PresenterToolBarBack(toolbarBackView, routerToolBarBack, stylesHolderToolBarBack, title);
            presenterToolBarBack.SetConfig();

            _rootTableView.EstimatedRowHeight = 400;
            _rootTableView.RowHeight = UITableView.AutomaticDimension;

            _globalTimer = GlobalTimer.GetInstance();
        }

        private void DetailedPostHeightCounted(int id, nfloat bodyHeight)
        {
            //var wholeHeight = bodyHeight + (_detailedPostView.ViewPostHeader as PostHeaderView)?.Frame.Height +
            //               (_detailedPostView.ViewPostSocial as PostSocialView)?.Frame.Height;
            //_cell.PostHeightConstraint.Constant= wholeHeight ?? _detailedPostView.Frame.Height;
        }

        public override void ViewDidUnload()
        {
            base.ViewDidUnload();
            _interactor?.Dispose();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            _globalTimer.OnChangeSecondLeft += Tick;
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            _globalTimer.OnChangeSecondLeft -= Tick;
        }

        private void Tick(DateTime nowTime)
        {
            _interactor.ChangeTime(nowTime);
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return 1;
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            _cell = _rootTableView.DequeueReusableCell(DetailedPostTableViewCell.Key, indexPath) as DetailedPostTableViewCell;

            _detailedPostView = _cell.DetailedPostView;
            (_cell.DetailedPostView.ViewPostBody as PostBodyView).Width = (int)_rootTableView.Frame.Width;

            var post = DataService.RepositoryController.RepositoryPost.GetOnePostById(PostId);
            var market = post.ModelPost.Market;
            _detailedPostView.SetPostMarket((EMarketTypes)Enum.Parse(typeof(EMarketTypes), market));
            
            _interactor = new InteractorPost(PostId, new OnePostController(DataService.RepositoryController.RepositoryPost), DataService.NotificationCenter, 
                DataService.RepositoryController.RepositoryPost, DataService.RepositoryController.RepoQc);
            var presenter = new PresenterPost(
                view:               _cell.DetailedPostView,
                interactor:         _interactor,
                router:             new RouterPost(this),
                otherThemeStrings:  ThemeHolder.PostOtherThemeStrings,
                headerStylesHolder: new PostHeaderStylesHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser),
                socialStylesHolder: new PostSocialStylesHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser),
                bodyStylesHolder:   new PostBodyStylesHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser),
                postLocale:         DataService.RepositoryController.RepositoryPost.LangPost,
                isPostDetailed:     true
            );

            PostHeightCounted = DetailedPostHeightCounted;
            (_cell.DetailedPostView.ViewPostBody as PostBodyView)?.SetActionOnCountingHeight(PostHeightCounted, 0);

            _cell.DetailedPostView.Presenter = presenter;
            (_interactor as InteractorPost).SendRequestForPosts();
            presenter.SetConfigToolbar();

            return _cell;
        }
    }
}
