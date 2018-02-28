using Android.OS;
using Android.App;
using Android.Views;
using Android.Content;
using Android.Content.PM;

using SocialTrading.Locale;
using SocialTrading.Service;
using SocialTrading.Connection;
using SocialTrading.Droid.Theme;
using SocialTrading.Droid.Tools;
using SocialTrading.ThemesStyles;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Droid.Activities.Base;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.Droid.Views.UpdatePost;
using SocialTrading.Droid.Routers.UpdatePost;
using SocialTrading.Vipers.UpdatePost.Interfaces;
using SocialTrading.Vipers.UpdatePost.Implementation;

namespace SocialTrading.Droid.Activities
{
    [Activity(Label = "UpdatePostActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class UpdatePostActivity : BaseActivity
    {
        private string _postId;

        private IPresenterUpdatePost _presenter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.UpdatePostActivity);

            _postId = Intent.GetStringExtra("id");

            IViewUpdatePost updatePostView = FindViewById<UpdatePostView>(Resource.Id.updatePost_view);

            IInteractorUpdatePost interactor = new InteractorUpdatePost(_postId, new UpdatePostController(ConnectionController.GetInstance(), WebMsgParser.ParseResponseCreatePost,
                    DataService.NotificationCenter, DataService.RepositoryController.RepoQc, DataService.RepositoryController.RepositoryPost),
                DataService.RepositoryController.RepositoryUpdatePost, DataService.RepositoryController.RepositoryPost, DataService.RepositoryController.RepositoryUserAuth);

            _presenter = new PresenterUpdatePost(updatePostView, interactor, new RouterUpdatePost(this), new UpdatePostStylesHolderDroid<GlobalControlsTheme>(new ThemeParser<GlobalControlsTheme>()), Localization.Lang);
        }
        

        protected override void OnResume()
        {
            base.OnResume();

            _presenter.SetTheme(new UpdatePostStylesHolderDroid<GlobalControlsTheme>(new ThemeParser<GlobalControlsTheme>()));
            _presenter.SetLocale(Localization.Lang);
            _presenter.SetConfig();
        }

        protected override void OnPause()
        {
            base.OnPause();
            _presenter.NeedToSaveData();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _presenter.Dispose();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                _presenter.ImageSelected(data.Data.ToString().GetBase64());
            }
        }
    }
}