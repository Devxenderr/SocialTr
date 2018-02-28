using UIKit;

using System;

using SocialTrading.Service;
using SocialTrading.iOS.Tools;
using SocialTrading.iOS.Theme;
using SocialTrading.DTO.Request;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.iOS.Views.MoreOptions;
using SocialTrading.iOS.Routers.MoreOptions;
using SocialTrading.Vipers.MoreOptions.ToolBar.Implementation;

namespace SocialTrading.iOS
{
    public partial class MoreOptionsViewController : UIViewController
    {
        public MoreOptionsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            new MoreOptionsController(Connection.ConnectionController.GetInstance(),
                DataService.RepositoryController.RepositoryUserSettings, DataService.RepositoryController.RepositoryUserAuth,
                WebMsgParser.ParseResponseUserSettings).Send(new UserInfoRequestModel(DataService.RepositoryController.RepositoryUserSettings.UserId
                ?? throw new NullReferenceException(nameof(DataService.RepositoryController.RepositoryUserSettings.UserId))));

            _moreOptionsView.SetDataSource(new DataForMoreOptions(), this);
        }

        public override void ViewDidLoad()
		{
			base.ViewDidLoad();

            _moreOptionsView.NavigationBar = NavigationController?.NavigationBar;
            _moreOptionsView.NavigationItem = NavigationItem;

            _moreOptionsView.SetDataSource(new DataForMoreOptions(), this);

            NavigationController.NavigationBar.Hidden = false;

            _moreOptionsView.SetCellAutoHeight();
            _moreOptionsView.SetConfig();
            
            var toolbarBackView = new ToolBarBackView(NavigationItem, NavigationController.NavigationBar);
            var routerToolBarBack = new RouterToolBarBack(NavigationController);
            var stylesHolderToolBarBack = new ToolBarBackStylesHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser);
            var title = DataService.RepositoryController.RepositoryToolbar.LangToolbar.ToolbarTitle;
            var presenterToolBarBack = new PresenterToolBarBack(toolbarBackView, routerToolBarBack, stylesHolderToolBarBack, title);
            presenterToolBarBack.SetConfig();
 		}
    }
}