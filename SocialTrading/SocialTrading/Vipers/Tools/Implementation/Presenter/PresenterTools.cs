using System;
using System.Collections.Generic;

using SocialTrading.Theme.Interfaces;
using SocialTrading.Vipers.Tools.Interfaces.View;
using SocialTrading.Vipers.Tools.Interfaces.Router;
using SocialTrading.Vipers.Tools.Interfaces.Presenter;
using SocialTrading.Vipers.Tools.Interfaces.Interactor;

namespace SocialTrading.Vipers.Tools.Implementation.Presenter
{
    public class PresenterTools : IPresenterTools
    {
        private readonly IViewTools _view;
        private readonly IRouterTools _router;
        private readonly IInteractorTools _interactor;
        private readonly IToolsStylesHolder _stylesHolder;

        public PresenterTools(IViewTools view, IInteractorTools interactor, IRouterTools router, IToolsStylesHolder stylesHolder)
        {
            _interactor = interactor ?? throw new ArgumentNullException("The interactor can't be a null");
            _router = router ?? throw new ArgumentNullException("The router can't be a null");
            _view = view ?? throw new ArgumentNullException("The view can't be a null");
            _stylesHolder = stylesHolder;

            _interactor.Presenter = this;
            _view.Presenter = this;
        }

        #region IPresenterTools

        public void CellClick(int index)
        {
            _interactor.CellClick(index);
        }

        public void GoBack(string selectedKey)
        {
            _router.GoBack(selectedKey);
        }

        public void SearchEdit(string str)
        {
            _interactor.SearchEdit(str);
        }

        public void SetDataSource(List<string> tooList)
        {
            _view.SetDataSource(tooList, _stylesHolder);
        }

        public void SetEnableCell(int index, bool isEnable)
        {
            if (isEnable)
            {
                _view.SetEnableCell(index, _stylesHolder.SelectedCellTheme, _stylesHolder.ToolNameTheme);
            }
            else
            {
                _view.SetEnableCell(index, _stylesHolder.UnselectedCellTheme, _stylesHolder.ToolNameTheme);
            }
        }

        public void SetScroll(int index)
        {
            _view.Scroll(index);
        }

        public void SetTheme(IThemeKeyStringsTools theme)
        {
            if (theme == null)
            {
                return;
            }
            
            _view.SetSearchTheme(theme.SearchBacgroundColorKey, theme.SearchTextColorKey, theme.SearchTextSizeKey, theme.SearchTextFontStyleKey);
            _view.SetCollectionViewTheme(theme.DividingLineColorKey, theme.DividingLineSizeKey, theme.DividingLineTypeKey);
        }

        #endregion
    }
}
