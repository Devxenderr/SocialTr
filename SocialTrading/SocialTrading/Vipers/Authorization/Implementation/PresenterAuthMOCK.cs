using System;

using SocialTrading.Locale.Modules;
using SocialTrading.Vipers.Authorization.Interfaces;

namespace SocialTrading.Vipers.Authorization.Implementation
{
    public class PresenterAuthMOCK : PresenterAuth
    {
        public PresenterAuthMOCK(IViewAuth view, IInteractorAuth interactor, IRouterAuth router, 
            Action facebookCallLoginAction, Action googleCallLoginAction, Action vkCallLoginAction, Action okCallLoginAction, 
            IAuthStylesHolder stylesHolder, IRegAuth authLocaleStrings) 
            : base(view, interactor, router, facebookCallLoginAction, googleCallLoginAction, vkCallLoginAction, okCallLoginAction, stylesHolder, authLocaleStrings)
        {
        }
        
        public override void LoginClick(string email, string pass)
        {
            Service.DataService.RepositoryController.RepositoryRA.ModelAuth = new DTO.Response.RA.DataModelAuth(
                "111", "email", "tvma@i.ua", "tvma@i.ua", null, "2017-11-14T09:30:26.893Z", "https://pbs.twimg.com/profile_images/901947348699545601/hqRMHITj.jpg",
                null, "2017-11-17T08:43:17.669Z", "Jon", "Snow", null, "EN", false, 1510651826, 1510908197, 0, new []{""});
            _router.ToPostsFeed();
        }
    }
}
