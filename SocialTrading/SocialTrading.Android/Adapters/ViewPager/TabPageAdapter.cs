using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Runtime;
using Android.Support.V4.App;

using SocialTrading.Droid.Tools;
using SocialTrading.Droid.Fragments.MainTabFragments;

using Java.Lang;

using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace SocialTrading.Droid.Adapters
{
    internal class TabPageAdapter : FragmentPagerAdapter
    {
        public string[] Titles { get; set; }
        private readonly Context _context;

        public TabPageAdapter(Context context, FragmentManager fragmentManager) : base(fragmentManager)
        {
            _context = context;
        }

        //public override int Count { get { return DroidDAL.TabPageCount; } }
        public override int Count { get { return 1; } }                                 // Hardcode for one Tab in TabBar

        public override Fragment GetItem(int position)
        {
            Fragment frag = null;

            switch (position)
            {
                case 0:
                    frag = new PostsFragment();
                    break;
                case 1:
                    frag = new FavoritesFragment();
                    break;
                case 2:
                    frag = new DealsFragment();
                    break;
                case 3:
                    frag = new NotificationsFragment();
                    break;

                default:
                    break;
            }

            return frag;
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return CharSequence.ArrayFromStringArray(Titles)[position];
        }

        public View GetTabView(int position)
        {
            var tv = LayoutInflater.From(_context).Inflate(Resource.Layout.CustomTabHeader, null) as TextView;
            tv.Text = Titles[position];
            return tv;
        }
    }
}