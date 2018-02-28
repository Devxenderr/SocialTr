using Android.OS;
using Android.App;
using Android.Views;

using SocialTrading.Service;
using SocialTrading.Droid.Views;
using SocialTrading.Droid.Routers;
using SocialTrading.Droid.Theme;
using SocialTrading.ThemesStyles;
using SocialTrading.Tools.Validation;
using SocialTrading.Vipers.Registration.Phone.Interfaces;
using SocialTrading.Vipers.Registration.Phone.Implementation;

namespace SocialTrading.Droid.Fragments.RegistrationFragments
{
    public class RegistrationPhoneFragment : Fragment
    {
        private View _view;

        private IPresenterRegPhone _presenter;


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _view = inflater.Inflate(Resource.Layout.RegPhoneFragment, container, false);

            var viewRegPhone = _view.FindViewById<RegPhoneView>(Resource.Id.reg_phone_view);
            _presenter = new PresenterRegPhone(viewRegPhone, new InteractorRegPhone(DataService.RepositoryController.RepositoryRA, new ValidationRA()), 
                new RouterRegPhone(Activity), new RegPhoneStylesHolderDroid<GlobalControlsTheme>(new ThemeParser<GlobalControlsTheme>()), DataService.RepositoryController.RepositoryRA.LangRA);                
            
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