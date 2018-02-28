using System;

using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.MoreOptions.OptionsCell.Interfaces;

namespace SocialTrading.Vipers.MoreOptions.OptionsCell.Implementation
{
    public class PresenterOptionsCell : IPresenterOptionsCell
    {
        private readonly IViewOptionsCell _view;
        private readonly IInteractorOptionsCell _interactor;
        private readonly IRouterOptionsCell _router;
        private readonly IOptionsCellStyleHolder _styleHolder;

        public PresenterOptionsCell(IViewOptionsCell view, IInteractorOptionsCell interactor, IRouterOptionsCell router, IOptionsCellStyleHolder styleHolder)
        {
            _view = view ?? throw new NullReferenceException(nameof(_view));
            _interactor = interactor ?? throw new NullReferenceException(nameof(_interactor));
            _router = router ?? throw  new NullReferenceException(nameof(_router));
            _interactor.Presenter = this;
            _view.Presenter = this;

            _styleHolder = styleHolder;
        }

        public void CellClick()
        {
            _interactor.CellClick();
        }

        public void GoTo(EItemsOptions option)
        {
            _router.GoTo(option);
        }

        public void SetConfig()
        {
            if (_styleHolder != null)
            {
                _view.SetImageTheme(_styleHolder.ImageViewTheme);
                _view.SetBackgroundTheme(_styleHolder.BackgroundTheme);
                _view.SetTextTheme(_styleHolder.TextTheme);
            }

            _interactor.SetConfig();
        }

        public void SetImage(string imageName)
        {
            _view.SetImage(imageName);
        }

        public void SetText(string localeString)
        {
            _view.SetText(localeString);
        }
    }
}
