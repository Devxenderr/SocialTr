using System;

using UIKit;

using SocialTrading.Service;
using SocialTrading.iOS.Tools;
using SocialTrading.iOS.Theme;
using SocialTrading.Tools.Validation;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Vipers.ModelCreators;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.iOS.Views.MoreOptions;
using SocialTrading.iOS.Routers.MoreOptions;
using SocialTrading.Vipers.EditContact.Implementation;
using SocialTrading.Vipers.EditContact.Interfaces;
using SocialTrading.Vipers.MoreOptions.ToolBar.Implementation;

namespace SocialTrading.iOS.Controllers.MoreOptions
{
    public partial class EditContactViewController : UIViewController
    {
        public string SelectedKey { get; set; }

        private IPresenterEditContact _presenter;

        public EditContactViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _editContactView.GetViewController = iOS_DAL.GetViewControllerForView;

            var interactor = new InteractorEditContact(
                new EditContactController(Connection.ConnectionController.GetInstance(),
                    DataService.RepositoryController.RepositoryUserSettings, WebMsgParser.ParseResponsePersonalInfo),
                new EditContactModelCreator(DataService.RepositoryController.RepositoryUserSettings), new ValidationEditContact());

            _presenter = new PresenterEditContact(_editContactView, interactor, new RouterEditContact(NavigationController));
            _presenter.SetConfig();
            _presenter.SetLocale(Locale.Localization.Lang);
            _presenter.SetTheme(new EditContactStyleHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser));

            NavigationController.NavigationBar.Hidden = false;

            var toolbarBackView = new ToolBarBackView(NavigationItem, NavigationController.NavigationBar);
            var routerToolBarBack = new RouterToolBarBack(NavigationController);
            var stylesHolderToolBarBack = new ToolBarBackStylesHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser);
            var title = Locale.Localization.Lang.EditContactToolbarTitle;
            var presenterToolBarBack = new PresenterToolBarBack(toolbarBackView, routerToolBarBack, stylesHolderToolBarBack, title);
            presenterToolBarBack.SetConfig();
        }

        public override void ViewWillAppear(bool animated)
        {
            if (SelectedKey != null)
            {
                _presenter.SetSelectedCountry(SelectedKey);
            }
        }
    }
}