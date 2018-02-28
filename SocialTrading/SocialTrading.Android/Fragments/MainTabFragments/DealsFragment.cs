using Android.OS;
using Android.Views;

namespace SocialTrading.Droid.Fragments.MainTabFragments
{
    public class DealsFragment : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.DealsFragment, null, false);

            return view;
        }
    }
}