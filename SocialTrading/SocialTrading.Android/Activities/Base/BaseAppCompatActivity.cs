using Android.App;
using Android.Content;
using Android.Support.V7.App;

using SocialTrading.Locale;
using SocialTrading.Service;
using SocialTrading.Connection;
using SocialTrading.Locale.Modules;

namespace SocialTrading.Droid.Activities.Base
{
    public class BaseAppCompatActivity : AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
            ConnectionController.GetInstance().OnTokenFail += LogOut;
        }

        protected override void OnPause()
        {
            base.OnPause();
            ConnectionController.GetInstance().OnTokenFail -= LogOut;
        }

        private void LogOut()
        {
            DataService.RepositoryController.Init();
            ConnectionController.GetInstance().DisconnectSockets();

            var locale = Localization.Lang as IAlert;
            Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);

            alert.SetMessage(locale.BadToken);

            alert.SetPositiveButton(locale.OK, (senderAlert, args) =>
            {
                FinishAffinity();
                Intent intent = new Intent(ApplicationContext, typeof(AuthActivity));
                intent.AddFlags(ActivityFlags.ClearTop);
                StartActivity(intent);
            });

            Dialog dialog = alert.Create();
            if (!IsFinishing)
            {
                RunOnUiThread(() =>
                {
                    dialog.Show();
                });
            }
        }
    }
}