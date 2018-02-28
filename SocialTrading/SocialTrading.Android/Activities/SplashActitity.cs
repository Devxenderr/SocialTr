using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace SocialTrading.Droid.Activities
{
    [Activity(Theme = "@style/MyTheme.Splash", Icon = "@drawable/icon_socialtrading", MainLauncher = true, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]

    public class SplashActitity : Activity
    {

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            FinishAffinity();
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                Window.AddFlags(WindowManagerFlags.LayoutNoLimits);
                Window.AddFlags(WindowManagerFlags.LayoutInScreen);
                Window.DecorView.SetFitsSystemWindows(true);
            }
            StartActivity(new Intent(Application.Context, typeof(AuthActivity)));
            Finish();
        }
    }
}