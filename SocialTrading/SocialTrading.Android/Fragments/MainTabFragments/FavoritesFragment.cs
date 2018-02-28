using Android.OS;
using Android.Views;

namespace SocialTrading.Droid.Fragments.MainTabFragments
{
    public class FavoritesFragment : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.FavoritesFragment, null, false);

            return view;
        }
    }
}