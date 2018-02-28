using SocialTrading.Droid.Fragments.CreatePost;
using SocialTrading.Vipers.Tools.Interfaces.Router;

namespace SocialTrading.Droid.Routers.CreatePost
{
    public class RouterToolsDroid : IRouterTools
    {
        private CreatePostToolsFragment _fragment;
        
        public RouterToolsDroid(CreatePostToolsFragment fragment)
        {
            _fragment = fragment;
        }

        public void GoBack(string selectedKey)
        {
            _fragment.FragmentManager.FindFragmentByTag<CreatePostFragment>("CreatePostFragment").SelectedKey = selectedKey;
            
            _fragment.FragmentManager.PopBackStack();
        }
    }
}