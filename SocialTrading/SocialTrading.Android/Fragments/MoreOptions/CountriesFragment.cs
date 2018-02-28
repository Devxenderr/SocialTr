using Android.OS;
using Android.App;
using Android.Views;

using SocialTrading.Tools;
using SocialTrading.Theme;
using SocialTrading.Service;

using SocialTrading.Droid.Theme;
using SocialTrading.Droid.Tools;
using SocialTrading.Droid.Views.CreatePost;
using SocialTrading.Droid.Views.MoreOptions;
using SocialTrading.Droid.Routers.MoreOptions;

using SocialTrading.Vipers.Tools.Implementation;
using SocialTrading.Vipers.Tools.Interfaces.View;
using SocialTrading.Vipers.Tools.Interfaces.Presenter;
using SocialTrading.Vipers.Tools.Interfaces.Interactor;
using SocialTrading.Vipers.Tools.Implementation.Presenter;
using SocialTrading.Vipers.MoreOptions.ToolBar.Interfaces;
using SocialTrading.Vipers.MoreOptions.ToolBar.Implementation;

namespace SocialTrading.Droid.Fragments.MoreOptions
{
    public class CountriesFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view = inflater.Inflate(Resource.Layout.CountriesFragment, null, false);

            IViewTools viewTools = view.FindViewById<CreatePostToolsView>(Resource.Id.countries_tools_view);

            ThemesHelper.PerformTheme(container.Context, Themes.GetToolsTheme());

            IInteractorTools interactor = new InteractorTools(
                DataService.RepositoryController.RepositoryCountries, new SearchHelper<string>());
            IPresenterTools presenter = new PresenterTools(viewTools, interactor, new RouterToolsCountriesDroid(this),
                new ToolsStylesHolderDroid<GlobalControlsTheme>(DroidDAL.ThemeParser));

            presenter.SetTheme(ThemeHolder.ToolsThemeStrings);

            Holder holder = new Holder(view);

            var routerToolBarBack = new RouterToolBarBack(Activity);
            var stylesHolderToolBarBack = new ToolBarBackStylesHolderDroid<GlobalControlsTheme>(DroidDAL.ThemeParser);

            var presenterToolBarBack = new PresenterToolBarBack(holder.ToolBarBackView, routerToolBarBack,
                stylesHolderToolBarBack, Locale.Localization.Lang.EditContactCountriesToolbar);
            presenterToolBarBack.SetConfig();

            return view;
        }

        private class Holder
        {
            public IToolBarBackView ToolBarBackView { get; private set; }

            public Holder(View view)
            {
                ToolBarBackView =
                    view.FindViewById<ToolBarBackView>(Resource.Id.toolbarBackButtonTitle_countries_toolbar);
            }
        }
    }
}