using Android.OS;
using Android.App;
using Android.Views;
using Android.Content.PM;

using SocialTrading.Tools.Interfaces;
using SocialTrading.Droid.Activities.Base;
using SocialTrading.Droid.Fragments.MoreOptions;

namespace SocialTrading.Droid.Activities
{
    [Activity(Label = "MoreOptionsActivity", Theme = "@style/NoTitleTheme", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MoreOptionsActivity : BaseActivity, ISpinneble
    {
        private const string _spinnerConst = "SpinnerTag";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.MoreOptionsActivity);

            var fragmentTransaction = FragmentManager.BeginTransaction();
            fragmentTransaction.Add(Resource.Id.moreOptions_fragment_container, new MoreOptionsFragment());
            fragmentTransaction.Commit();
        }

        public void ShowSpinner()
        {
            var rootElement = Window.DecorView.RootView as ViewGroup;

            if (rootElement == null)
            {
                return;
            }

            HideSpinner();
            ViewGroup.LayoutParams lParams = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            RunOnUiThread(() =>
            {
                var pb = LayoutInflater.Inflate(Resource.Layout.Spinner, null, false);
                pb.SetOnTouchListener(new ClickToBlockBottomsElement());
                pb.Tag = _spinnerConst;
                rootElement.AddView(pb, lParams);
                pb.BringToFront();
            });
        }

        public void HideSpinner()
        {
            var rootElement = Window.DecorView.RootView as ViewGroup;
            if (rootElement == null)
            {
                return;
            }
            for (int i = 0; i < rootElement.ChildCount; i++)
            {
                if (rootElement.GetChildAt(i).Tag?.ToString() == _spinnerConst)
                {
                    RunOnUiThread(() =>
                    {
                        rootElement.RemoveViewAt(i);
                    });
                }
            }
        }

        private class ClickToBlockBottomsElement : Java.Lang.Object, View.IOnTouchListener
        {
            public bool OnTouch(View v, MotionEvent e)
            {
                return true;
            }
        }
    }
}