using Android.OS;
using Android.App;
using Android.Views;
using Android.Graphics;
using Android.Content.PM;

using SocialTrading.Theme;
using SocialTrading.Service;
using SocialTrading.Connection;
using SocialTrading.Droid.Views;
using SocialTrading.Droid.Theme;
using SocialTrading.Droid.Tools;
using SocialTrading.Droid.Routers;
using SocialTrading.Tools.Interfaces;
using SocialTrading.Tools.Validation;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.Vipers.ForgotPass.Interfaces;
using SocialTrading.Vipers.ForgotPass.Implementation;

namespace SocialTrading.Droid.Activities
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait, WindowSoftInputMode = SoftInput.AdjustResize | SoftInput.StateHidden)]
    public class ForgotPassActivity : Activity, ISetConfig
    {
        private InteractorForgotPass _interactor;
        private IViewForgotPass _view;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.ForgotPassActivity);

            InitStatusBar();

            SetConfig();

            _view = FindViewById<ForgotPassView>(Resource.Id.forgot_view);

            _interactor = new InteractorForgotPass(new ValidationRA(), new ForgotPassController(ConnectionController.GetInstance(), WebMsgParser.ParseResponseRecoveryPassword));
            var presenter = new PresenterForgotPass(_view, _interactor, new RouterForgotPass(this), DataService.RepositoryController.RepositoryRA.LangRA, 
                new ForgotPassStylesHolderDroid<GlobalControlsTheme>(DroidDAL.ThemeParser));

            presenter.SetConfig();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _interactor.Dispose();
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

        public void SetConfig()
        {
        }
    }
}