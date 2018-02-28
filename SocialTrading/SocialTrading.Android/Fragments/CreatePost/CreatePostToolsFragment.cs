using Android.OS;
using Android.App;
using Android.Content;
using Android.Views;

using SocialTrading.Theme;
using SocialTrading.Tools;
using SocialTrading.Service;
using SocialTrading.Droid.Theme;
using SocialTrading.Droid.Tools;
using SocialTrading.Droid.Views.CreatePost;
using SocialTrading.Droid.Routers.CreatePost;
using SocialTrading.Droid.Views.MoreOptions;
using SocialTrading.Vipers.Tools.Implementation;
using SocialTrading.Vipers.Tools.Interfaces.View;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Tools.Interfaces.Presenter;
using SocialTrading.Vipers.Tools.Interfaces.Interactor;
using SocialTrading.Vipers.MoreOptions.ToolBar.Interfaces;
using SocialTrading.Vipers.Tools.Implementation.Presenter;
using SocialTrading.Vipers.MoreOptions.ToolBar.Implementation;

namespace SocialTrading.Droid.Fragments.CreatePost
{
    public class CreatePostToolsFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.CreatePostToolsFragment, container, false);

            IViewTools viewTools = view.FindViewById<CreatePostToolsView>(Resource.Id.createPost_tools_view);

            ThemesHelper.PerformTheme(container.Context, Themes.GetToolsTheme());

            IInteractorTools interactor = new InteractorTools(
                DataService.RepositoryController.RepoQc as IRepositoryNames, new SearchHelper<string>());
            IPresenterTools presenter = new PresenterTools(viewTools, interactor, new RouterToolsDroid(this),
                new ToolsStylesHolderDroid<GlobalControlsTheme>(DroidDAL.ThemeParser));

            presenter.SetTheme(ThemeHolder.ToolsThemeStrings);

            Holder holder = new Holder(view, this);

            var routerToolBarBack = new RouterToolBarBack(Activity);
            var stylesHolderToolBarBack = new ToolBarBackStylesHolderDroid<GlobalControlsTheme>(DroidDAL.ThemeParser);
            var title = DataService.RepositoryController.RepositoryCreatePost.LangCreatePost.CreatePostToolsActivityTitle;
            var presenterToolBarBack = new PresenterToolBarBack(holder.ToolBarBackView, routerToolBarBack,
                stylesHolderToolBarBack, title);
            presenterToolBarBack.SetConfig();

            return view;
        }

        private class Holder
        {
            public IToolBarBackView ToolBarBackView { get; private set; }

            public Holder(View view, CreatePostToolsFragment fragment)
            {
                Context context = fragment.Activity;

                ToolBarBackView = view.FindViewById<ToolBarBackView>(Resource.Id.toolbarBackButtonTitle_toolbar);
            }
        }
    }
}