using System;
using SocialTrading.Vipers.MoreOptions.ToolBar.Interfaces;

namespace SocialTrading.Vipers.MoreOptions.ToolBar.Implementation
{
    public class PresenterToolBarBack : IPresenterToolBarBack
    {
        private readonly IToolBarBackView _view;
        private readonly IRouterToolBarBack _router;
        private readonly IToolBarBackStylesHolder _stylesHolder;
        private readonly string _title;

        public PresenterToolBarBack(IToolBarBackView view, IRouterToolBarBack router, IToolBarBackStylesHolder stylesHolder, string title)
        {
            _stylesHolder = stylesHolder;
            _title        = title        ?? throw new ArgumentNullException(nameof(_title));
            _view         = view         ?? throw new ArgumentNullException(nameof(_view));
            _router       = router       ?? throw new ArgumentNullException(nameof(_router));

            _view.Presenter = this;
        }

        public void SetConfig()
        {
            if (_stylesHolder != null)
            {
                _view.SetTitleTheme(_stylesHolder.TitleTheme);
                _view.SetViewTheme(_stylesHolder.ToolbarViewTheme);
                _view.SetBackButtonTheme(_stylesHolder.BackButtonTheme);
            }

            _view.SetTitle(_title);
        }

        public void BackClick()
        {
            _router.GoBack();
        }
    }
}