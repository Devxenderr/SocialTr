using Android.OS;
using Android.App;
using Android.Views;

using SocialTrading.Theme;
using SocialTrading.Service;
using SocialTrading.Droid.Views;
using SocialTrading.Droid.Routers;
using SocialTrading.Droid.Theme;
using SocialTrading.ThemesStyles;
using SocialTrading.Tools.Validation;
using SocialTrading.Vipers.Registration.Name.Interfaces;
using SocialTrading.Vipers.Registration.Name.Implementation;

namespace SocialTrading.Droid.Fragments.RegistrationFragments
{
    public class RegistrationNameFragment : Fragment
    {
        private View _view;
        
        private IPresenterRegName _presenter;


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _view = inflater.Inflate(Resource.Layout.RegNameFragment, container, false);

            var viewRegName = _view.FindViewById<RegNameView>(Resource.Id.reg_name_view);
            _presenter = new PresenterRegName(viewRegName, new InteractorRegName(DataService.RepositoryController.RepositoryRA, new ValidationRA()), 
                new RouterRegName(Activity), new RegNameStylesHolderDroid<GlobalControlsTheme>(new ThemeParser<GlobalControlsTheme>()), DataService.RepositoryController.RepositoryRA.LangRA);               

            return _view;
        }


        public override void OnResume()
        {
            base.OnResume();
            _presenter.LoadData();
            _presenter.SetConfig();
        }

        public override void OnPause()
        {
            base.OnPause();
            _presenter.SaveData();
        }
    }
}