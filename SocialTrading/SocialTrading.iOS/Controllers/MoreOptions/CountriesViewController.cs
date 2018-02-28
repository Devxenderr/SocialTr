using System;

using UIKit;

using SocialTrading.Tools;
using SocialTrading.Theme;
using SocialTrading.Service;
using SocialTrading.iOS.Theme;
using SocialTrading.iOS.Tools;
using SocialTrading.iOS.Views.MoreOptions;
using SocialTrading.iOS.Routers.CreatePost;
using SocialTrading.iOS.Routers.MoreOptions;
using SocialTrading.Vipers.Tools.Implementation;
using SocialTrading.Vipers.Tools.Interfaces.Presenter;
using SocialTrading.Vipers.Tools.Interfaces.Interactor;
using SocialTrading.Vipers.Tools.Implementation.Presenter;
using SocialTrading.Vipers.MoreOptions.ToolBar.Implementation;

namespace SocialTrading.iOS.Controllers.MoreOptions
{
    public partial class CountriesViewController : UIViewController
    {
        public CountriesViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ThemeHelper.PerformTheme(Themes.GetToolsTheme());
            _countriesView.SetConfig();

            IInteractorTools interactor = new InteractorTools(DataService.RepositoryController.RepositoryCountries, new SearchHelper<string>());
            IPresenterTools presenter = new PresenterTools(_countriesView, interactor, new RouterToolsCountriesIOS(NavigationController), new ToolsStylesHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser));

            presenter.SetTheme(ThemeHolder.ToolsThemeStrings);

            NavigationController.NavigationBar.Hidden = false;

            var toolbarBackView = new ToolBarBackView(NavigationItem, NavigationController.NavigationBar);
            var routerToolBarBack = new RouterToolBarBack(NavigationController);
            var stylesHolderToolBarBack = new ToolBarBackStylesHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser);
            var title = Locale.Localization.Lang.EditContactCountriesToolbar;
            var presenterToolBarBack = new PresenterToolBarBack(toolbarBackView, routerToolBarBack, stylesHolderToolBarBack, title);
            presenterToolBarBack.SetConfig();
        }
    }
}