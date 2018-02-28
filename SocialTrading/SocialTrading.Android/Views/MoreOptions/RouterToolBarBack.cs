using Android.App;
using Android.Content;
using SocialTrading.Vipers.MoreOptions.ToolBar.Interfaces;

namespace SocialTrading.Droid.Views.MoreOptions
{
    public class RouterToolBarBack : IRouterToolBarBack
    {
        private readonly Context _context;

        public RouterToolBarBack(Context context)
        {
            _context = context;
        }

        public void GoBack()
        {
            FragmentManager fm = ((Activity)_context).FragmentManager;
            if (fm.BackStackEntryCount > 0)
            {
                fm.PopBackStack();
            }
            else
            {
                ((Activity)_context).OnBackPressed();
            }
        }
    }
}