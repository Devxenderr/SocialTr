using Android.App;
using Android.Content;
using Android.Views.InputMethods;

using SocialTrading.Droid.Fragments.CreatePost;
using SocialTrading.Vipers.CreatePost.Interfaces;

namespace SocialTrading.Droid.Routers
{
    public class RouterCreatePost : IRouterCreatePost
    {
        private readonly Fragment _fragment;
        
        public RouterCreatePost(Fragment fragment)
        {
            _fragment = fragment;
        }


        public void ToGallery()
        {
            var imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);
            _fragment.StartActivityForResult(Intent.CreateChooser(imageIntent, "Select photo"), 0);
        }

        public void ToPostsFeed()
        {
            InputMethodManager manager =
                    (InputMethodManager)_fragment.Activity.GetSystemService(Activity.InputMethodService);
            manager.HideSoftInputFromWindow(_fragment.Activity.CurrentFocus?.WindowToken, 0);
            _fragment.Activity.Finish();
            
        }

        public void ToToolSelection()
        {
            var fm = _fragment.FragmentManager.BeginTransaction();
            fm.Replace(Resource.Id.createPost_fragment_container, new CreatePostToolsFragment());
            fm.AddToBackStack(null);
            fm.Commit();
        }
    }
}