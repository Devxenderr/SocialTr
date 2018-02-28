using UIKit;

using System;
using System.Collections.Generic;

using SocialTrading.Theme;
using SocialTrading.Service;
using SocialTrading.iOS.Theme;
using SocialTrading.iOS.Tools;
using SocialTrading.Connection;
using SocialTrading.iOS.Routers;
using SocialTrading.iOS.Views.Post;
using SocialTrading.DTO.Request.Posts;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Connection.Markers;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Service.Interfaces.Timer;
using SocialTrading.Service.Interfaces.Notifications;
using SocialTrading.Vipers.Post.ToolBar.Implementation;

namespace SocialTrading.iOS
{
    public partial class PostsViewController : UIViewController, INotificationMessage
    {
        public Action<int, nfloat> PostHeightCounted { get; set; }

        private readonly object _locker = new object();
        private UIRefreshControl _refreshControl;
        private List<nfloat> _postsHeights;
        private GlobalTimer _globalTimer;

        private PostsController _postsController;
        private PresenterToolBarPosts _presenterToolBarPosts;

        public List<nfloat> PostsHeights
        {
            get
            {
                lock (_locker)
                {
                    return _postsHeights;
                }
            }
            set
            {
                lock (_locker)
                {
                    _postsHeights = value;
                }
            }
        }


        public PostsViewController(IntPtr handle) : base(handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _postsCollectionView.Initialize();

            //DataService.NotificationCenter.PostsIncome = OnNotificationIncome;
#if MOCK
#else
            new QuotationsController(ConnectionController.GetInstance(), DataService.RepositoryController.RepoQc, WebMsgParser.ParseResponseWidget, WebMsgParser.ParseResponseQuotations, typeof(WidgetSocketMarker));

            _postsController = new PostsController(ConnectionController.GetInstance(), WebMsgParser.ParseResponsePosts, DataService.RepositoryController.RepositoryPost);
            _postsController.Send(new PostsRequestModel(EPostsRequestType.InitialRequest));
#endif

            PostHeightCounted = SetPostHeight;
            PostsHeights = new List<nfloat>();
            _postsCollectionView.Delegate = new PostsDelegate(PostsHeights);
            _postsCollectionView.AlwaysBounceVertical = true;
            _postsCollectionView.AllowsSelection = false;
            _postsCollectionView.AllowsMultipleSelection = false;

            _refreshControl = new UIRefreshControl();
            _postsCollectionView.RefreshControl = _refreshControl;
            _refreshControl.BackgroundColor = UIColor.Clear;
            _refreshControl.BeginRefreshing();
            
            _globalTimer = GlobalTimer.GetInstance();

            CreateDataSourse();

            NavigationController.NavigationBar.Hidden = false;

            var toolbarPostsView = new ToolBarPostsView(NavigationItem, NavigationController.NavigationBar);
            var routerToolBarPosts = new RouterToolBarPosts(NavigationController);
            var stylesHolderToolBarPosts = new ToolBarPostsStylesHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser);
            _presenterToolBarPosts = new PresenterToolBarPosts(toolbarPostsView, routerToolBarPosts, stylesHolderToolBarPosts, Locale.Localization.Lang);
        }

        private void SetPostHeight(int id, nfloat height)
        {
            if(PostsHeights.Count == id)
            {
                PostsHeights.Add(height);
            }
            else if(PostsHeights[id] != height)
            {
                PostsHeights[id] = height;
            }
            InvokeOnMainThread(() =>
            {
                _postsCollectionView.CollectionViewLayout.InvalidateLayout();
            });
        }

        private void CreateDataSourse()
        {
            _postsCollectionView.DataSource = new PostsDataSource(
                postHeightCounted:  PostHeightCounted,
                viewController:     this,
                notification:       DataService.NotificationCenter,
                repository:         DataService.RepositoryController.RepositoryPost,
                repositoryQc:       DataService.RepositoryController.RepoQc,
                otherThemeStrings:  ThemeHolder.PostOtherThemeStrings
            );

            _postsHeights.Clear();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

#if MOCK
            new ConnectionControllerMOCK().Send(new PostsRequestModel());
#endif

            _refreshControl.ValueChanged += OnRefresh;
            _globalTimer.OnChangeSecondLeft += Tick;

            _postsController.OnRecieveModel += ReceiveModel;

            _refreshControl.BeginRefreshing();
            OnRefresh(this, EventArgs.Empty);

            _presenterToolBarPosts.SetConfig();
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            _refreshControl.ValueChanged -= OnRefresh;
            _globalTimer.OnChangeSecondLeft -= Tick;

            _postsController.OnRecieveModel -= ReceiveModel;
        }

        private void ReceiveModel(IModel obj)
        {
            if (obj is List<string> list)
            {
                UpdatePosts(list);
                InvokeOnMainThread(() =>
                {
                    _refreshControl.EndRefreshing();
                });
            }
        }

        private void UpdatePosts(List<string> list)
        {
            if (_postsCollectionView.DataSource is PostsDataSource dataSource)
            {
                dataSource.PostIds = list;
                _postsCollectionView.ReloadData();
            }
        }

        private void Tick(DateTime nowTime)
        {
            InvokeOnMainThread(() =>
            {
                foreach (var cell in _postsCollectionView.VisibleCells)
                {
                    if (cell is ITickNotification uCell)
                    {
                        uCell.TickNotify(nowTime);
                    }
                }
            });       
        }

        private void OnRefresh(object sender, EventArgs e)
        {
            _postsController.Send(new PostsRequestModel(EPostsRequestType.PullToRefresh));
#if MOCK
            new ConnectionControllerMOCK().Send(new PostsRequestModel());
#else
        //    ConnectionController.GetInstance().Send(new PostsRequestModel());
#endif
        }


        public void OnNotificationIncome<T>(T data)
        {
            if (data is string)
            {
                Enum.TryParse(data as string, out EResponseState state);

                switch (state)
                {
                    case EResponseState.NoConnection:
                        break;
                    case EResponseState.NoResponse:
                        break;
                    case EResponseState.NotFound:
                        break;
                    case EResponseState.ServiceUnavailable:
                        break;
                    case EResponseState.Unknown:
                        break;

                    case EResponseState.GetPostsError:
                        break;
                    case EResponseState.GetPostsSuccess:
                        InvokeOnMainThread(() =>
                        {
                             _postsCollectionView.DataSource = new PostsDataSource(
                                postHeightCounted:  PostHeightCounted,
                                viewController:     this,
                                notification:       DataService.NotificationCenter,
                                repository:         DataService.RepositoryController.RepositoryPost,
                                repositoryQc:       DataService.RepositoryController.RepoQc,
                                otherThemeStrings:  ThemeHolder.PostOtherThemeStrings
                            );

                            _postsCollectionView.ReloadData();
                            _postsHeights.Clear();
                        });
                        break;
                        
                    default:
                        break;
                }
                InvokeOnMainThread(() =>
                {
                    _refreshControl.EndRefreshing();
                });
            }
        }
    }
}
