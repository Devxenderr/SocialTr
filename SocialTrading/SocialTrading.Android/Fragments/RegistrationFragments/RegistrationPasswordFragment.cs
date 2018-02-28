using Android.OS;
using Android.App;
using Android.Views;

using SocialTrading.Service;
using SocialTrading.Connection;
using SocialTrading.Droid.Views;
using SocialTrading.Droid.Theme;
using SocialTrading.ThemesStyles;
using SocialTrading.Droid.Routers;
using SocialTrading.Tools.Validation;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Vipers.Registration.Password.Interfaces;
using SocialTrading.Vipers.Registration.Password.Implementation;

namespace SocialTrading.Droid.Fragments.RegistrationFragments
{
    public class RegistrationPasswordFragment : Fragment
    {
        private View _view;

        private IPresenterRegPass _presenter;
        private IInteractorRegPass _interactor;


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _view = inflater.Inflate(Resource.Layout.RegPassFragment, container, false);

            var viewRegPass = _view.FindViewById<RegPassView>(Resource.Id.reg_pass_view);
            
            _interactor = new InteractorRegPass(new RegController(ConnectionController.GetInstance(), WebMsgParser.ParseResponseReg), DataService.RepositoryController.RepositoryRA, new ValidationRA());            
            _presenter = new PresenterRegPass(viewRegPass, _interactor, new RouterRegPass(Activity), new RegPassStylesHolderDroid<GlobalControlsTheme>(new ThemeParser<GlobalControlsTheme>()), DataService.RepositoryController.RepositoryRA.LangRA);

            return _view;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            _interactor.Dispose();
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