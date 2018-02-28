using System;
using System.Collections.Generic;

using Android.OS;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Support.Design.Widget;

using SocialTrading.Theme;
using SocialTrading.Locale;
using SocialTrading.Service;
using SocialTrading.Connection;
using SocialTrading.Droid.Tools;
using SocialTrading.Locale.Modules;
using SocialTrading.Droid.Adapters;
using SocialTrading.Droid.Activities;
using SocialTrading.DTO.Request.Posts;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Service.Interfaces.Timer;
using SocialTrading.Vipers.Controllers.Interfaces;

namespace SocialTrading.Droid.Fragments.MainTabFragments
{
    public class PostsFragment : Android.Support.V4.App.Fragment
    {
        private View _view;
        private Holder _holder;
        private Toast _toast;
        private GlobalTimer _globalTimer;
        private IPostsController _postsController;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
#if MOCK
            _postsController = new ConnectionControllerMOCK();
#else
            _postsController = new PostsController(ConnectionController.GetInstance(), WebMsgParser.ParseResponsePosts, DataService.RepositoryController.RepositoryPost);
#endif
            _globalTimer = GlobalTimer.GetInstance();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _view = inflater.Inflate(Resource.Layout.PostsFragment, null, false);
            _holder = new Holder(_view, Context, () =>
            {
                _postsController.Send(new MorePostsRequestModel(DataService.RepositoryController.RepositoryPost.GetLatestPostCreationDate()));
            });
            return _view;
        }

        public override void OnResume()
        {
            base.OnResume();
            _holder.FloatingButton.Click += FloatingButtonClick;
            _holder.MoreOptionsImageButton.Click += MoreOptionsImageButtonClick;
            _holder.RefreshLayout.Refresh += OnRefresh;
            _globalTimer.OnChangeSecondLeft += Tick;            
            _postsController.OnRecieveModel += ReciveModel;

            _holder.RefreshLayout.Refreshing = true;
            _postsController.Send(new PostsRequestModel(EPostsRequestType.InitialRequest));
        }

        public override void OnPause()
        {
            base.OnPause();
            _holder.FloatingButton.Click -= FloatingButtonClick;
            _holder.MoreOptionsImageButton.Click -= MoreOptionsImageButtonClick;
            _postsController.OnRecieveModel -= ReciveModel;
            _holder.RefreshLayout.Refresh -= OnRefresh;
            _globalTimer.OnChangeSecondLeft -= Tick;
        }


        private void OnRefresh(object sender, EventArgs e)
        {
            _postsController.Send(new PostsRequestModel(EPostsRequestType.PullToRefresh));
        }

        private void ReciveModel(IModel response)
        {
            var locale = Localization.Lang as IAlert;

            switch (response.ControllerStatus)
            {
                case EControllerStatus.Ok:
                    UpdateAdapter(response);
                    break;

                case EControllerStatus.NoConnection:
                    ShowToast(locale.NoConnection);
                    break;

                case EControllerStatus.Processing:
                case EControllerStatus.Error:
                case EControllerStatus.None:
                default:
                    break;
            }
        }

        private void UpdateAdapter(IModel response)
        {
            if (response is List<string> list)
            {
                _holder.UpdateAdapter(list);
                _holder.RefreshLayout.Refreshing = false;
            }
        }

        private void ShowToast(string message)
        {
            _toast?.Cancel();
            _toast = Toast.MakeText(Context, message, ToastLength.Short);
            _toast.Show();
        }

        private void Tick(DateTime nowTime)
        {
            for (int i = 0; i < _holder.RecyclerView.ChildCount; i++)
            {
                var child = _holder.RecyclerView.GetChildAt(i);
                var viewHolder = _holder.RecyclerView.GetChildViewHolder(child) as ITickNotification;
                viewHolder?.TickNotify(nowTime);
            }
        }

        private void MoreOptionsImageButtonClick(object sender, EventArgs e)
        {
            var intent = new Intent(Activity, typeof(MoreOptionsActivity));
            StartActivity(intent);
        }

        private void FloatingButtonClick(object sender, EventArgs e)
        {
            var intent = new Intent(Activity, typeof(CreatePostActivity));
            StartActivity(intent);
        }


        private class Holder
        {
            public Holder(View view, Context context, Action loadMoreEvent)
            {
                _context = context;

                RecyclerView = view.FindViewById<RecyclerView>(Resource.Id.postsRecyclerView);
                var layoutManager = new LinearLayoutManager(context);
                var scrollListener = new EndlessScrollOnScrollListener(layoutManager);
                scrollListener.LoadMoreEvent += loadMoreEvent;
                RecyclerView.AddOnScrollListener(scrollListener);
                RecyclerView.SetLayoutManager(layoutManager);

                PostsRecyclerAdapter = new PostsRecyclerAdapter(
                    notification:       DataService.NotificationCenter,
                    repository:         DataService.RepositoryController.RepositoryPost,
                    repositoryQc:       DataService.RepositoryController.RepoQc,
                    otherThemeStrings:  ThemeHolder.PostOtherThemeStrings
                );
                
                RecyclerView.SetAdapter(PostsRecyclerAdapter);

                FloatingButton = view.FindViewById<FloatingActionButton>(Resource.Id.posts_createPost_floatingActionButton);
                MoreOptionsImageButton = view.FindViewById<ImageButton>(Resource.Id.toolbarOneButton_moreOptions_imageButton);
                MoreOptionsImageButton.SetBackgroundResource(Resource.Drawable.menuWhite36);

                RefreshLayout = view.FindViewById<SwipeRefreshLayout>(Resource.Id.posts_swipeRefreshLayout);
            }

            public void UpdateAdapter(List<string> postIds)
            {
                (_context as Activity)?.RunOnUiThread(() =>
                {
                    if (PostsRecyclerAdapter != null)
                    {
                        PostsRecyclerAdapter.PostIds = postIds;
                    }
                });

                // TODO: NEED TO CHECK !GERASH!
                RecyclerView.SetRecycledViewPool(new RecyclerView.RecycledViewPool());
            }

            private readonly Context _context;

            public RecyclerView RecyclerView { get; }
            public FloatingActionButton FloatingButton { get; }
            public ImageButton MoreOptionsImageButton { get; }
            public SwipeRefreshLayout RefreshLayout { get; }
            public PostsRecyclerAdapter PostsRecyclerAdapter { get; private set; }
        }
    }
}