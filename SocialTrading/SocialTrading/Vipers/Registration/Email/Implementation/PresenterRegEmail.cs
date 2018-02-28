using System;

using SocialTrading.Locale.Modules;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Registration.Email.Interfaces;

namespace SocialTrading.Vipers.Registration.Email.Implementation
{
    public class PresenterRegEmail : IPresenterRegEmail
    {
        private readonly IRouterRegEmail _router;
        private readonly IViewRegEmail _viewEmail;
        private readonly IInteractorRegEmail _interactor;
        
        private readonly IRegAuth _regLocaleStrings;
        private readonly IRegEmailStylesHolder _styleHolder;
                
        public PresenterRegEmail(IViewRegEmail view, IInteractorRegEmail interactor, IRouterRegEmail router, IRegEmailStylesHolder stylesHolder, IRegAuth regLocaleStrings)
        {
            if (view == null || interactor == null || router == null)
            {
                throw new NullReferenceException();
            }

            _styleHolder = stylesHolder;
            _regLocaleStrings = regLocaleStrings;
            _router = router;
            _viewEmail = view;
            _interactor = interactor;
            _viewEmail.Presenter = this;
            _interactor.Presenter = this;

            _viewEmail.SetConfig();
        }

        public void SetEmailState(EState state)
        {
            switch (state)
            {
                case EState.Success:
                    _viewEmail.SetEmailEditTextTheme(_styleHolder.EmailStateSuccess);
                    break;
                case EState.Fail:
                    _viewEmail.SetEmailEditTextTheme(_styleHolder.EmailStateFail);
                    break;

                default:
                    break;
            }
        }

        public void EmailInput()
        {
            _interactor.EmailInput(_viewEmail.GetEmail());
        }

        public void NextClick()
        {            
            if( _interactor.NextClick(_viewEmail.GetEmail()))
            {
                _router.ToRegPassword();
            }
        }

        public void BackClick()
        {
            _router.ToRegPhone();
        }

        public void SaveData()
        {
            _interactor.SaveData(_viewEmail.GetEmail());
        }

        public void LoadData()
        {
            var email = _interactor.LoadData();

            if (!string.IsNullOrEmpty(email))
            {
                _viewEmail.SetEmail(email);
            }
        }

        public string GetShowEmailsAlertTitleLocale()
        {
            return _regLocaleStrings.ShowEmailsAlertTitle;
        }

        public string GetOkLocale()
        {
            return _regLocaleStrings.OK;
        }

        public string GetCancelLocale()
        {
            return _regLocaleStrings.Cancel;
        }


        public void SetConfig()
        {
            _viewEmail.SetHeaderLabelTheme(_styleHolder.HeaderLabelTheme);
            _viewEmail.SetEmailLabelTheme(_styleHolder.EmailLabelTheme);
            _viewEmail.SetNextButtonTheme(_styleHolder.NextButtonTheme);
            _viewEmail.SetBackButtonTheme(_styleHolder.BackButtonTheme);
            _viewEmail.SetViewTheme(_styleHolder.ViewTheme);
            _viewEmail.SetLogoImageViewTheme(_styleHolder.LogoImageViewTheme);
            _viewEmail.SetEmailEditTextTheme(_styleHolder.EmailEditTextTheme);
            _viewEmail.SetFeatureTextTheme(_styleHolder.FeatureTextTheme);
            _viewEmail.SetFeatureImageTheme(_styleHolder.FeatureImageTheme);
        }

        public void SetLocale()
        {
            _viewEmail.SetEmailLocale(_regLocaleStrings.EmailHint);
            _viewEmail.SetNextButtonLocale(_regLocaleStrings.ButtonNext);
            _viewEmail.SetTitleLocale(_regLocaleStrings.RegEmailTextView);
            _viewEmail.SetFeatureTextLocale(_regLocaleStrings.RegEmailFeatureText);
        }
    }
}
