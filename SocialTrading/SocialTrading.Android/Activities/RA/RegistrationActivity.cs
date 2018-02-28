using Android.OS;
using Android.App;
using Android.Views;
using Android.Content.PM;
using Android.Graphics;
using SocialTrading.Droid.Fragments.RegistrationFragments;

namespace SocialTrading.Droid.Activities
{
    [Activity(Label = "Регистрация", Theme = "@style/AppTheme", ScreenOrientation = ScreenOrientation.Portrait, WindowSoftInputMode = SoftInput.AdjustResize | SoftInput.StateHidden)]
    public class RegistrationActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.RegActivity);

            InitStatusBar();

            var nameFragment = new RegistrationNameFragment();
            var ft = FragmentManager.BeginTransaction();
            ft.Add(Resource.Id.reg_fragment_container, nameFragment);
            ft.Commit();
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
    }  
}