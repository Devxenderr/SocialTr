using SocialTrading.Service;
using SocialTrading.Locale.Modules;
using SocialTrading.Theme.ThemeStrings;
using SocialTrading.Vipers.Post.Interfaces;
using SocialTrading.Vipers.Post.Interfaces.Body;
using SocialTrading.Vipers.Post.Interfaces.Header;
using SocialTrading.Vipers.Post.Interfaces.Social;
using SocialTrading.Vipers.Post.Implementation.Body;
using SocialTrading.Vipers.Post.Implementation.Header;
using SocialTrading.Vipers.Post.Implementation.Social;

namespace SocialTrading.Vipers.Post.Implementation
{
    public class PresenterPost : IPresenterPost
    {
        private readonly IViewPost _view;
        private readonly IRouterPost _router;
        private readonly IInteractorPost _interactor;

        private readonly IPost _postLocale;
        private readonly bool _isPostDetailed;

        private readonly PostOtherThemeStrings _otherThemeStrings;


        public PresenterPost(IViewPost view, IInteractorPost interactor, IRouterPost router, PostOtherThemeStrings otherThemeStrings, IPostHeaderStylesHolder headerStylesHolder, 
            IPostSocialStylesHolder socialStylesHolder, IPostBodyStylesHolder bodyStylesHolder, IPost postLocale, bool isPostDetailed)
        {
            _view = view;
            _router = router;
            _interactor = interactor;
            _postLocale = postLocale;
            _isPostDetailed = isPostDetailed;
            _otherThemeStrings = otherThemeStrings;

            IPresenterPostHeader presenterPostHeader = new PresenterPostHeader(view.ViewPostHeader, interactor.InteractorPostHeader, router, DataService.RepositoryController.RepositoryPost.LangPost, headerStylesHolder);
            IPresenterPostBody presenterPostBody = new PresenterPostBody(view.ViewPostBody, interactor.InteractorPostBody, router, bodyStylesHolder, isPostDetailed);
            IPresenterPostSocial presenterPostSocial = new PresenterPostSocial(view.ViewPostSocial, interactor.InteractorPostSocial, router, DataService.RepositoryController.RepositoryPost.LangPost, socialStylesHolder);
            
            interactor.InteractorPostBody.Presenter = presenterPostBody;
            interactor.InteractorPostHeader.Presenter = presenterPostHeader;
            interactor.InteractorPostSocial.Presenter = presenterPostSocial;

            _view.SetConfig();

            presenterPostHeader.SetConfig();
            presenterPostSocial.SetConfig();
        }


        public void SetConfigToolbar()
        {
            _view.SetTheme();

            if (_isPostDetailed)
            {
                (_view as IViewDetailedPost)?.SetToolbarTheme(_otherThemeStrings, _postLocale.DetailedPostTitle);
                (_view as IViewDetailedPost)?.SetActions();
            }
        }

        public void Back()
        {
            _router.OnBack();
        }


        public void DisposeRepositoryPost()
        {
            _interactor.DisposeRepositoryPost();
        }
    }
}
