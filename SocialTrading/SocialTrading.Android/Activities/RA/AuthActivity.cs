using Android.OS;
using Android.App;
using Android.Views;
using Android.Runtime;
using Android.Content;
using Android.Graphics;
using Android.Content.PM;
using Android.Util;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;

using SocialTrading.Theme;
using SocialTrading.Service;
using SocialTrading.Connection;
using SocialTrading.Droid.Tools;
using SocialTrading.Droid.Theme;
using SocialTrading.Droid.Views;
using SocialTrading.ThemesStyles;
using SocialTrading.Droid.Routers;
using SocialTrading.Tools.Validation;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Authorization.Interfaces;
using SocialTrading.Vipers.Authorization.Implementation;

namespace SocialTrading.Droid.Activities
{
    [Activity(Label = "SocialTrading", Theme = "@style/AppTheme", Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait, WindowSoftInputMode = SoftInput.AdjustResize | SoftInput.StateHidden)]
    public class AuthActivity : Activity
    {
        private AuthView _view;

        private IPresenterAuth _presenter;
        private IInteractorAuth _interactor;

        private ICallbackManager _callbackManager;
        private FacebookCallback _facebookCallback;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.AuthActivity);
            DroidDAL.HockeyAppRegister(this);

            _view = FindViewById<AuthView>(Resource.Id.auth_view);

            InitStatusBar();

            ThemeHolder.Init(DataService.RepositoryController.RepositoryThemes);
            _interactor = new InteractorAuth(new AuthController(ConnectionController.GetInstance(), WebMsgParser.ParseResponseAuth), new ValidationRA());
#if MOCK            
            _presenter = new PresenterAuthMOCK(_view, _interactor, new RouterAuth(this), FacebookCallLoginAction, GoogleCallLoginAction, VkCallLoginAction, OkCallLoginAction,
                new AuthStylesHolderDroid<GlobalControlsTheme>(new ThemeParser<GlobalControlsTheme>()), DataService.RepositoryController.RepositoryRA.LangRA);
#else
            _presenter = new PresenterAuth(_view, _interactor, new RouterAuth(this), FacebookCallLoginAction, GoogleCallLoginAction, VkCallLoginAction, OkCallLoginAction, 
                new AuthStylesHolderDroid<GlobalControlsTheme>(new ThemeParser<GlobalControlsTheme>()), DataService.RepositoryController.RepositoryRA.LangRA);            
#endif
            _presenter.SetConfig();

            _callbackManager = CallbackManagerFactory.Create();
            _facebookCallback = new FacebookCallback(_interactor);
            LoginManager.Instance.RegisterCallback(_callbackManager, _facebookCallback);            
            _interactor.OnSocialLogOut += SocialLogOut;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _interactor.Dispose();
            _facebookCallback.Dispose();
            _interactor.OnSocialLogOut -= SocialLogOut;
        }

        protected override void OnResume()
        {
            base.OnResume();
            _presenter.DisposeRepositoryRA();
        }

        private void SocialLogOut(ESocialType type)
        {
            if (type == ESocialType.Facebook)
            {
                LoginManager.Instance.LogOut();
            }
        }

        private void InitStatusBar()
        {
            //for transperent status bar
            var uiOptions = (int)Window.DecorView.SystemUiVisibility;
            uiOptions ^= (int)SystemUiFlags.LayoutStable;
            uiOptions ^= (int)SystemUiFlags.LayoutFullscreen;
            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;

            Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Window.SetStatusBarColor(Color.Transparent);
            }
            else
            {
                Window.SetFlags(WindowManagerFlags.TranslucentStatus, WindowManagerFlags.TranslucentStatus);
            }
        }

        void FacebookCallLoginAction()
        {
            LoginManager.Instance.LogInWithReadPermissions(this, new[] { "email", "public_profile" });
        }

        void GoogleCallLoginAction()
        {
        }

        void VkCallLoginAction()
        {
        }

        void OkCallLoginAction()
        {
        }


        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            _callbackManager.OnActivityResult(requestCode, (int)resultCode, data);
        }
    }
}