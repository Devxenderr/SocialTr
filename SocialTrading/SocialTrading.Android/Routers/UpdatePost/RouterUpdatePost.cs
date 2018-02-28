using Android.App;
using Android.Content;
using Android.Views.InputMethods;

using SocialTrading.Vipers.UpdatePost.Interfaces;

namespace SocialTrading.Droid.Routers.UpdatePost
{
    public class RouterUpdatePost : IRouterUpdatePost
    {
        private readonly Activity _activity;


        public RouterUpdatePost(Activity activity)
        {
            _activity = activity;
        }


        public void ToGallery()
        {
            var imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);
            _activity.StartActivityForResult(Intent.CreateChooser(imageIntent, "Select photo"), 0);
        }

        public void ToPostsFeed()
        {
            var manager = (InputMethodManager)_activity.GetSystemService(Activity.InputMethodService);
            manager.HideSoftInputFromWindow(_activity.CurrentFocus?.WindowToken, 0);
            _activity.Finish();
        }
    }
}