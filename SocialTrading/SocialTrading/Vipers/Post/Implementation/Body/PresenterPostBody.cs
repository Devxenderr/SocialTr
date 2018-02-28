using System;

using SocialTrading.Vipers.Post.Interfaces.Body;
using SocialTrading.DTO.Response.Post.Interfaces;

namespace SocialTrading.Vipers.Post.Implementation.Body
{
    public class PresenterPostBody : IPresenterPostBody
    {
        private readonly IViewPostBody _view;
        private readonly IRouterPostBody _router;
        private readonly IInteractorPostBody _interactor;
        
        private readonly IPostBodyStylesHolder _stylesHolder;
        
        public bool IsPostDetailed => _interactor.IsPostDetailed;


        public PresenterPostBody(IViewPostBody view, IInteractorPostBody interactor, IRouterPostBody router, IPostBodyStylesHolder stylesHolder, bool isDetailedPost)
        {
            if (view == null || interactor == null || router == null)
            {
                throw new NullReferenceException();
            }

            _router = router;

            _interactor = interactor;
            _interactor.Presenter = this;
            _interactor.IsPostDetailed = isDetailedPost;

            _stylesHolder = stylesHolder;
            
            _view = view;
            _view.Presenter = this;

            _view.SetConfig();
        }


        public void ReadMoreClick()
        {
            _router.ToDetailedPost(_interactor.PostId);
        }

        public void SaveCachedImage(string base64)
        {
            _interactor.CacheImage(base64);
        }

        public void SetBody(IPostBodyModel model, int symbolsCount = 0)
        {
            if (!string.IsNullOrWhiteSpace(model.Image) && model.CachedImage == null)
            {
                _view.CacheImage(model.Image);
            }

            if (!IsPostDetailed && _interactor.GetRepository().MinimizedPostContentLength <= symbolsCount)
            {
                var minimizedContent = model.Content.Substring(0, symbolsCount) + "...";
                _view.SetContent(minimizedContent, _interactor.GetRepository().LangPost.ReadMore, _stylesHolder.ContentTheme, _stylesHolder.MoreTextTheme, minimizedContent.Length);
            }
            else
            {
                _view.SetContent(model.Content, _stylesHolder.ContentTheme);
            }

            _view.SetImage(model.CachedImage);
        }
    }
}
