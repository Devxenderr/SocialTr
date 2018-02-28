using System;

using SocialTrading.Locale;
using SocialTrading.Locale.Modules;
using SocialTrading.Vipers.Post.ToolBar.Intarfaces;

namespace SocialTrading.Vipers.Post.ToolBar.Implementation
{
    public class PresenterToolBarPosts : IPresenterToolBarPosts
    {
        private readonly IViewToolBarPosts _view;
        private readonly IRouterToolBarPosts _router;
        private readonly IToolBarPostsStylesHolder _stylesHolder;
        private readonly IPost _locale;

        public PresenterToolBarPosts(IViewToolBarPosts view, IRouterToolBarPosts router, IToolBarPostsStylesHolder stylesHolder, IPost locale)
        {
            _stylesHolder = stylesHolder;
            _locale = locale ?? throw new ArgumentNullException(nameof(_locale));
            _view = view ?? throw new ArgumentNullException(nameof(_view));
            _router = router ?? throw new ArgumentNullException(nameof(_router));

            _view.Presenter = this;
        }

        public void SetConfig()
        {
            if (_stylesHolder != null)
            {
                _view.SetTitleTheme(_stylesHolder.TitleTheme);
                _view.SetViewTheme(_stylesHolder.ToolbarViewTheme);
                _view.SetMoreButtonTheme(_stylesHolder.MoreButtonTheme);
                _view.SetCreatePostTheme(_stylesHolder.CreatePostButton);
            }

            _view.SetTitle(_locale.PostsTitle);
            _view.SetCreatePostString(_locale.PostsButtonCreatePost);
        }

        public void MoreClick()
        {
            _router.GoToMoreOptions();
        }

        public void CreatePostClick()
        {
            _router.GoToCreatePost();
        }
    }
}
