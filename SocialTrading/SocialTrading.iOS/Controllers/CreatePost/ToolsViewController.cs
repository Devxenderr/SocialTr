using UIKit;

using System;

using SocialTrading.Tools;
using SocialTrading.Theme;
using SocialTrading.Service;
using SocialTrading.iOS.Theme;
using SocialTrading.iOS.Tools;
using SocialTrading.iOS.Routers.CreatePost;
using SocialTrading.iOS.Routers.MoreOptions;
using SocialTrading.iOS.Views.MoreOptions;
using SocialTrading.Vipers.Tools.Implementation;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.MoreOptions.ToolBar.Implementation;
using SocialTrading.Vipers.Tools.Interfaces.Presenter;
using SocialTrading.Vipers.Tools.Interfaces.Interactor;
using SocialTrading.Vipers.Tools.Implementation.Presenter;

namespace SocialTrading.iOS
{
    public partial class ToolsViewController : UIViewController
    {
        public ToolsViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

            ThemeHelper.PerformTheme(Themes.GetToolsTheme());
            toolsView.SetConfig();

		    IInteractorTools interactor = new InteractorTools(DataService.RepositoryController.RepoQc as IRepositoryNames, new SearchHelper<string>());
		    IPresenterTools presenter = new PresenterTools(toolsView, interactor, new RouterToolsIOS(this), new ToolsStylesHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser));

		    presenter.SetTheme(ThemeHolder.ToolsThemeStrings);

            NavigationController.NavigationBar.Hidden = false;

            var toolbarBackView = new ToolBarBackView(NavigationItem, NavigationController.NavigationBar);
            var routerToolBarBack = new RouterToolBarBack(NavigationController);
            var stylesHolderToolBarBack = new ToolBarBackStylesHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser);
            var title = DataService.RepositoryController.RepositoryCreatePost.LangCreatePost.CreatePostToolsActivityTitle;
            var presenterToolBarBack = new PresenterToolBarBack(toolbarBackView, routerToolBarBack, stylesHolderToolBarBack, title);
            presenterToolBarBack.SetConfig();
        }
	}
}