using Android.OS;
using Android.App;
using Android.Views;
using Android.Content.PM;

using SocialTrading.Droid.Activities.Base;
using SocialTrading.Droid.Fragments.CreatePost;

namespace SocialTrading.Droid.Activities
{
    [Activity(Label = "CreatePostActivity", Theme = "@style/NoTitleTheme", ScreenOrientation = ScreenOrientation.Portrait, WindowSoftInputMode = SoftInput.AdjustResize | SoftInput.StateHidden)]
    public class CreatePostActivity : BaseActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.CreatePostActivity);

            var fragmentTransaction = FragmentManager.BeginTransaction();
            fragmentTransaction.Add(Resource.Id.createPost_fragment_container, new CreatePostFragment(), "CreatePostFragment");
            fragmentTransaction.AddToBackStack("CreatePostFragment");
            fragmentTransaction.Commit();
        }

        public override void OnBackPressed()
        {
            if (FragmentManager.BackStackEntryCount > 1)
            {
                FragmentManager.PopBackStack();
            }
            else
            {
                Finish();
            }
        }
    }
}