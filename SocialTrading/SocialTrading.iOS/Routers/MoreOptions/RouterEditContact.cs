using UIKit;

using SocialTrading.Vipers.EditContact.Interfaces;

namespace SocialTrading.iOS.Routers.MoreOptions
{
    public class RouterEditContact : IRouterEditContact
    {
        UINavigationController _navigationController;

        public RouterEditContact(UINavigationController navigationController)
        {
            _navigationController = navigationController;
        }
        public void ToCountrySelection()
        {
            var editContactViewController = UIStoryboard.FromName("Main", null).InstantiateViewController("CountriesViewController");
            _navigationController?.PushViewController(editContactViewController, true);
        }

        public void GoBack()
        {
            _navigationController.PopViewController(true);
        }
    }
}