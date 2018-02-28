using UIKit;

using System.Linq;
using SocialTrading.iOS.Controllers.MoreOptions;
using SocialTrading.Vipers.Tools.Interfaces.Router;

namespace SocialTrading.iOS.Routers.MoreOptions
{
    public class RouterToolsCountriesIOS : IRouterTools
    {
        private UINavigationController _navigationController;

        public RouterToolsCountriesIOS(UINavigationController navigationController)
        {
            _navigationController = navigationController;
        }

        void IRouterTools.GoBack(string selectedKey)
        {
            var previousController = _navigationController?.ViewControllers
                .FirstOrDefault(x => x is EditContactViewController) as EditContactViewController;

            if (previousController != null)
            {
                previousController.SelectedKey = selectedKey;
            }

            _navigationController?.PopViewController(true);
        }
    }
}