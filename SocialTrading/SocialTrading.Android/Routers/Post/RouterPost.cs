using Android.App;
using Android.Content;

using SocialTrading.Droid.Activities;
using SocialTrading.Vipers.Post.Interfaces;

namespace SocialTrading.Droid.Routers
{
    public class RouterPost : IRouterPost
    {
        private Context _context;


        public RouterPost(Context context)
        {
            _context = context;
        }


        public void ToDetailedPost(string id)
        {
            Intent intent = new Intent(_context, typeof(DetailedPostActivity));
            intent.SetFlags(ActivityFlags.NewTask);
            intent.PutExtra("id", id);
            _context.StartActivity(intent);
        }

        public void ToProfile()
        {
            
        }

        public void ToComments()
        {
            
        }

        public void ToShare(string link)
        {
            Intent sharingIntent = new Intent(Intent.ActionSend);
            sharingIntent.SetType("text/plain");
            sharingIntent.PutExtra(Intent.ExtraText, link); // "https://www.investarena.com/post/3780d5c4-0192-4c25-b0fa-d813c75fed00"
            Intent chooser = Intent.CreateChooser(sharingIntent, "Share");
            chooser.SetFlags(ActivityFlags.NewTask);
            _context.StartActivity(chooser);
        }

        public void OnBack()
        {
            (_context as Activity)?.OnBackPressed();
        }

        public void ToEditPost(string postId)
        {
            Intent intent = new Intent(_context, typeof(UpdatePostActivity));
            intent.SetFlags(ActivityFlags.NewTask);
            intent.PutExtra("id", postId);
            _context.StartActivity(intent);
        }
    }
}