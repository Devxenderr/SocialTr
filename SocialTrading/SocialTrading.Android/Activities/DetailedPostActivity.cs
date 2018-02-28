using System;

using Android.OS;
using Android.App;
using Android.Views;
using Android.Content.PM;

using SocialTrading.Theme;
using SocialTrading.Service;
using SocialTrading.Droid.Theme;
using SocialTrading.Droid.Tools;
using SocialTrading.Droid.Routers;
using SocialTrading.Droid.Views.Post;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Droid.Activities.Base;
using SocialTrading.Vipers.Post.Interfaces;
using SocialTrading.Vipers.Post.Implementation;
using SocialTrading.Vipers.Post.Implementation.Body;
using SocialTrading.Vipers.Post.Implementation.Header;
using SocialTrading.Vipers.Post.Implementation.Social;

namespace SocialTrading.Droid.Activities
{
    [Activity(Label = "DetailedPostActivity", Theme = "@style/NoTitleTheme", ScreenOrientation = ScreenOrientation.Portrait)]
    public class DetailedPostActivity : BaseActivity
    {
        private string _postId;
        private IInteractorPost _interactor;
        private GlobalTimer _globalTimer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.PostDetailedActivity);

            var postView = FindViewById<PostDetailedView>(Resource.Id.detailedPost_postView);
            
            _postId = Intent.GetStringExtra("id");

            var post = DataService.RepositoryController.RepositoryPost.GetOnePostById(_postId);
            var market = post.ModelPost.Market;
            postView.SetPostMarket((EMarketTypes)Enum.Parse(typeof(EMarketTypes), market));

            _interactor = new InteractorPost(_postId, new OnePostController(DataService.RepositoryController.RepositoryPost), DataService.NotificationCenter, 
                DataService.RepositoryController.RepositoryPost, DataService.RepositoryController.RepoQc);
            var presenter = new PresenterPost(
                view:               postView,
                interactor:         _interactor,
                router:             new RouterPost(this),
                otherThemeStrings:  ThemeHolder.PostOtherThemeStrings,
                headerStylesHolder: new PostHeaderStylesHolderDroid<GlobalControlsTheme>(DroidDAL.ThemeParser),
                socialStylesHolder: new PostSocialStylesHolderDroid<GlobalControlsTheme>(DroidDAL.ThemeParser),
                bodyStylesHolder:   new PostBodyStylesHolderDroid<GlobalControlsTheme>(DroidDAL.ThemeParser),
                postLocale:         DataService.RepositoryController.RepositoryPost.LangPost,
                isPostDetailed:     true
            );

            postView.Presenter = presenter;

            ((InteractorPost) _interactor).SendRequestForPosts();
            presenter.SetConfigToolbar();

            _globalTimer = GlobalTimer.GetInstance();
        }

        protected override void OnResume()
        {
            base.OnResume();
            _globalTimer.OnChangeSecondLeft += Tick;
        }

        protected override void OnPause()
        {
            base.OnPause();
            _globalTimer.OnChangeSecondLeft -= Tick;
        }

        private void Tick(DateTime nowTime)
        {
            _interactor.InteractorPostHeader.ChangeTime(nowTime);
        }
    }
}