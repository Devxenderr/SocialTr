using Android.OS;
using Android.App;
using Android.Views;
using Android.Content.PM;
using Android.Support.V4.View;
using Android.Support.Design.Widget;

using SocialTrading.Service;
using SocialTrading.Connection;
using SocialTrading.Droid.Tools;
using SocialTrading.Droid.Adapters;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Connection.Markers;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.Droid.Activities.Base;

namespace SocialTrading.Droid.Activities
{
    [Activity(Theme = "@style/NoTitleTheme", ScreenOrientation = ScreenOrientation.Portrait, WindowSoftInputMode = SoftInput.AdjustResize | SoftInput.StateHidden)]
    public class TabbedActivity : BaseAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.TabbedActivity);

            new QuotationsController(ConnectionController.GetInstance(), DataService.RepositoryController.RepoQc, WebMsgParser.ParseResponseWidget, WebMsgParser.ParseResponseQuotations, typeof(WidgetSocketMarker));
            
            var pager = FindViewById<ViewPager>(Resource.Id.mainViewPager);
            var tabLayout = FindViewById<TabLayout>(Resource.Id.mainTabLayout);
            tabLayout.Visibility = ViewStates.Gone;                                         // Hardcode for hide TabBar
            var adapter = new TabPageAdapter(this, SupportFragmentManager)
            {
                Titles = DroidDAL.mainTabTitles.ToArray()
            };

            pager.Adapter = adapter;
            pager.OffscreenPageLimit = 3;
            
            tabLayout.SetupWithViewPager(pager); 
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            ConnectionController.GetInstance().DisconnectSockets();
        }

        public override void OnBackPressed()
        {
            FinishAffinity();
        }
    }
}