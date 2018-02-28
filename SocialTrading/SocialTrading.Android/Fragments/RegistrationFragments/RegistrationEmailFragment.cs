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
using SocialTrading.Vipers.Registration.Email.Interfaces;
using SocialTrading.Vipers.Registration.Email.Implementation;

namespace SocialTrading.Droid.Fragments.RegistrationFragments
{
    public class RegistrationEmailFragment : Fragment
    {
        private View _view;

        private IViewRegEmail _viewRegEmail;
        private IPresenterRegEmail _presenter;

        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _view = inflater.Inflate(Resource.Layout.RegEmailFragment, container, false);

            _viewRegEmail = _view.FindViewById<RegEmailView>(Resource.Id.reg_email_view);
            _presenter = new PresenterRegEmail(_viewRegEmail, new InteractorRegEmail(DataService.RepositoryController.RepositoryRA, 
                new ValidationRA()), new RouterRegEmail(Activity), new RegEmailStylesHolderDroid<GlobalControlsTheme>(new ThemeParser<GlobalControlsTheme>()), 
                DataService.RepositoryController.RepositoryRA.LangRA);
            
            
            return _view;
        }

        public override void OnResume()
        {
            base.OnResume();
            _viewRegEmail.ShowConnectedEmails();
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