using Android.OS;
using Android.App;
using Android.Views;
using Android.Content;

using SocialTrading.Locale;
using SocialTrading.Service;
using SocialTrading.Connection;
using SocialTrading.Droid.Views;
using SocialTrading.Droid.Theme;
using SocialTrading.ThemesStyles;
using SocialTrading.Droid.Routers;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.Vipers.CreatePost.Interfaces;
using SocialTrading.Vipers.CreatePost.Implementation;

namespace SocialTrading.Droid.Fragments.CreatePost
{
    public class CreatePostFragment : Fragment
    {
        private View _view;

        private IViewCreatePost _createPostView;
        private IPresenterCreatePost _presenter;
        private IInteractorCreatePost _interactor;

        public string SelectedKey { get; set; }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _view = inflater.Inflate(Resource.Layout.CreatePostFragment, container, false);
            _createPostView = _view.FindViewById<CreatePostView>(Resource.Id.createPost_view);

            _interactor = new InteractorCreatePost(new CreatePostController(ConnectionController.GetInstance(), WebMsgParser.ParseResponseCreatePost, DataService.NotificationCenter, 
                DataService.RepositoryController.RepoQc), DataService.RepositoryController.RepositoryCreatePost, DataService.RepositoryController.RepositoryUserAuth);
            
            _presenter = new PresenterCreatePost(_createPostView, _interactor, new RouterCreatePost(this), new CreatePostStylesHolderDroid<GlobalControlsTheme>(new ThemeParser<GlobalControlsTheme>()), Localization.Lang);

            _presenter.SetConfig();
            return _view;
        }

        public override void OnResume()
        {
            base.OnResume();

            if (!string.IsNullOrEmpty(SelectedKey))
            {
                _presenter.SaveSelectedTool(SelectedKey);
            }

            _presenter.LoadData();
        }

        public override void OnPause()
        {
            base.OnPause();
            _presenter.SaveData();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            _interactor.Dispose();
            _presenter.DisposeRepositoryCreatePost();
        }

        public override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                _createPostView.ImageSelected(data.Data.ToString());
            }
        }
    }
}