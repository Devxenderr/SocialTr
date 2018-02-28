using System;

using SocialTrading.Locale.Modules;
using SocialTrading.Vipers.ProfileCell.Interfaces;

namespace SocialTrading.Vipers.ProfileCell.Implementation
{
    public class PresenterProfileCell : IPresenterProfileCell
    {
        private readonly IProfileCellView _view;
        private readonly IInteractorProfileCell _interactor;
        private readonly IProfileCellStylesHolder _themeHolder;
        private readonly IProfileCellLocale _locale;

        public PresenterProfileCell(IProfileCellView view, IInteractorProfileCell interactor, IProfileCellStylesHolder themes, IProfileCellLocale locale)
        {
            _view = view ?? throw new ArgumentNullException("View cannot be a null!");
            _interactor = interactor ?? throw new ArgumentNullException("Interactor cannot be a null!");

            _themeHolder = themes;
            _locale = locale;
        }

        public void SetAvatar(string url)
        {
            _view.SetAvatar(url);
        }

        public void SetConfig()
        {
            _view.SetConfig();
            
            _view.SetAvatarTheme(_themeHolder.AvatarImageViewTheme);
            _view.SetBackgroundTheme(_themeHolder.CellBackgroundTheme);
            _view.SetNameTheme(_themeHolder.NameLabelTheme);
            _view.SetProfileLabelTheme(_themeHolder.YourProfileLabelTheme);

            _view.SetProfileLabel(_locale.YourProfile);
        }

        public void SetName(string name)
        {
            _view.SetName(name);
        }
    }
}
