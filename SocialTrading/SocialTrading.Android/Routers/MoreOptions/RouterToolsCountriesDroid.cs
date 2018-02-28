using SocialTrading.Droid.Fragments.MoreOptions;
using SocialTrading.Vipers.Tools.Interfaces.Router;

namespace SocialTrading.Droid.Routers.MoreOptions
{
    public class RouterToolsCountriesDroid : IRouterTools
    {
        private readonly CountriesFragment _fragment;

        public RouterToolsCountriesDroid(CountriesFragment fragment)
        {
            _fragment = fragment;
        }

        public void GoBack(string selectedKey)
        {
             _fragment.FragmentManager.FindFragmentByTag<EditContactFragment>(nameof(EditContactFragment)).SelectedKey = selectedKey;

             _fragment.FragmentManager.PopBackStack();
        }
    }
}