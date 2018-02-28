using System;

using SocialTrading.Service;
using SocialTrading.Locale.Modules;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Authorization.Interfaces;

namespace SocialTrading.Vipers.Authorization.Implementation
{
    public class PresenterAuth : IPresenterAuth
    {
        protected IInteractorAuth _interactor;
        protected IRouterAuth _router;
        protected IViewAuth _view;

        private readonly IRegAuth _authLocaleStrings;

        private readonly Action _facebookCallLoginAction;
        private readonly Action _googleCallLoginAction;
        private readonly Action _vkCallLoginAction;
        private readonly Action _okCallLoginAction;
        private readonly IAuthStylesHolder _stylesHolder;


        public PresenterAuth(IViewAuth view, IInteractorAuth interactor, IRouterAuth router, 
            Action facebookCallLoginAction, Action googleCallLoginAction, Action vkCallLoginAction, Action okCallLoginAction, 
            IAuthStylesHolder stylesHolder, IRegAuth authLocaleStrings)
        {
            if (view == null || interactor == null || router == null )
            {
                throw new NullReferenceException();
            }

            _router = router;
            _view = view;
            _interactor = interactor;
            _view.Presenter = this;
            _interactor.Presenter = this;
            _authLocaleStrings = authLocaleStrings;

            _facebookCallLoginAction = facebookCallLoginAction;
            _googleCallLoginAction = googleCallLoginAction;
            _vkCallLoginAction = vkCallLoginAction;
            _okCallLoginAction = okCallLoginAction;
            _stylesHolder = stylesHolder;

            _view.SetConfig();
        }

        public void SetConfig()          
        {
            _view.SetHeaderLabelTheme(_stylesHolder.HeaderLabelTheme);
            _view.SetEmailLabelTheme(_stylesHolder.EmailLabelTheme);
            _view.SetPasswordLabelTheme(_stylesHolder.PasswordLabelTheme);
            _view.SetNoAccountLabelTheme(_stylesHolder.NoAccountLabelTheme);

            _view.SetSocialNetworkLabelTheme(_stylesHolder.SocialNetworkLabelTheme);

            _view.SetLogInButtonTheme(_stylesHolder.LogInButtonTheme);
            _view.SetFacebookButtonTheme(_stylesHolder.FacebookButtonTheme);
            _view.SetRegistrationButtonTheme(_stylesHolder.RegistrationButtonTheme);

            _view.SetForgetPassTheme(_stylesHolder.ForgetPassTheme);

            _view.SetEmailEditTextTheme(_stylesHolder.EmailEditTextTheme);

            _view.SetPasswordEditTextTheme(_stylesHolder.PasswordEditTextTheme);

            //_view.SetFbAuthTheme(_authThemeStrings.FbAuthButtonImage, _authThemeStrings.FbAuthButtonTint);
            //_view.SetGoogleAuthTheme(_authThemeStrings.GoogleAuthButtonImage, _authThemeStrings.GoogleAuthButtonTint);
            //_view.SetOkAuthTheme(_authThemeStrings.OkAuthButtonImage, _authThemeStrings.OkAuthButtonTint);
            //_view.SetVkAuthTheme(_authThemeStrings.VkAuthButtonImage, _authThemeStrings.VkAuthButtonTint);

            _view.SetLogoImageViewTheme(_stylesHolder.LogoImageViewTheme);
			_view.SetViewTheme(_stylesHolder.ViewTheme);
		}

        public void ShowHideSpinner(bool isShow)
        {
            if (isShow)
            {
                _view.ShowSpinner();
            }
            else
            {
                _view.HideSpinner();
            }
        }

        public void SetLocale()
        {
            var lang = DataService.RepositoryController.RepositoryRA.LangRA;

            _view.SetEmailLocale(lang.EmailHint);
            _view.SetPassLocale(lang.PasswordHint);
            _view.SetRegButtonLocale(lang.RegButton);
            _view.SetAuthButtonLocale(lang.LogInButton);
            _view.SetFacebookButtonLocale(lang.FacebookButton);
            _view.SetForgotPassLocale(lang.ForgetPasswordLink);
            _view.SetSloganLocale(lang.AuthSlogan);
            _view.SetNoAccountLocale(lang.AuthNoAccount);
            _view.SetSocialEnterLocale(lang.AuthSocialEnter);
        }

        public void EmailInput(string email)
        {
            _interactor.EmailInput(email);
        }

        public void PasswordInput(string pass)
        {
            _interactor.PasswordInput(pass);
        }


        public void RegistrationClick()
        {
            _router.ToRegistration();
        }

        public void ForgotPasswordClick()
        {
            _router.ToForgotPass();
        }

        public virtual void LoginClick(string email, string pass)
        {
            _interactor.LoginClick(email, pass);
        }


        public void SetEmailState(EState state)
        {
            switch (state)
            {
                case EState.Success:
                    _view.SetEmailEditTextTheme(_stylesHolder.EmailStateSuccess);
                    break;
                case EState.Fail:
                    _view.SetEmailEditTextTheme(_stylesHolder.EmailStateFail);
                    break;

                default:
                    break;
            }
        }

        public void SetPasswordState(EState state)
        {
            switch (state)
            {
                case EState.Success:
                    _view.SetPasswordEditTextTheme(_stylesHolder.PasswordStateSuccess);
                    break;
                case EState.Fail:
                    _view.SetPasswordEditTextTheme(_stylesHolder.PasswordStateFail);
                    break;
                default:
                    break;
            }
        }
        
        //public void CheckAuthState(EResponseState state)
        //{
        //    switch (state)
        //    {
        //        case EResponseState.NoConnection:
        //            _view.ShowAlert(string.Empty, _authLocaleStrings.NoConnection);
        //            _view.SetInteractionAvailable();
        //            break;
        //        case EResponseState.NoResponse:
        //            _view.ShowAlert(string.Empty, _authLocaleStrings.NoResponse);
        //            _view.SetInteractionAvailable();
        //            break;
        //        case EResponseState.NotFound:
        //            _view.ShowAlert(string.Empty, _authLocaleStrings.NotFound);
        //            _view.SetInteractionAvailable();
        //            break;
        //        case EResponseState.ServiceUnavailable:
        //            _view.ShowAlert(string.Empty, _authLocaleStrings.ServiceUnavailable);
        //            _view.SetInteractionAvailable();
        //            break;
        //        case EResponseState.Unknown:
        //            _view.ShowAlert(string.Empty, _authLocaleStrings.Unknown);
        //            _view.SetInteractionAvailable();
        //            break;

        //        case EResponseState.AuthSuccess:
        //            _router.ToPostsFeed();
        //            break;
        //        case EResponseState.AuthError:
        //            _view.ShowAlert(string.Empty, _authLocaleStrings.AuthError);
        //            _view.SetInteractionAvailable();
        //            break;

        //        case EResponseState.Waiting:
        //            _view.SetInteractionUnavailable();
        //            break;

        //        default:
        //            break;
        //    }
        //}

        public void CheckAuthState(EAuthResponseStatus state)
        {
            switch (state)
            {
                case EAuthResponseStatus.Success:
                    _router.ToPostsFeed();
                    break;
                case EAuthResponseStatus.Error:
                case EAuthResponseStatus.Unauthorized:
                    _view.ShowAlert(string.Empty, _authLocaleStrings.OK, _authLocaleStrings.AuthError);
                    _view.SetInteractionAvailable();
                    break;

                case EAuthResponseStatus.NoConnection:
                    _view.ShowAlert(string.Empty, _authLocaleStrings.OK, _authLocaleStrings.NoConnection);
                    break;
                case EAuthResponseStatus.UnprocessableEntity:
                    _view.ShowAlert(string.Empty, _authLocaleStrings.OK, _authLocaleStrings.FacebookAuthError);
                    break;
                default:
                    _view.ShowAlert(string.Empty, _authLocaleStrings.OK, _authLocaleStrings.AuthError);
                    break;
            }
        }


        public void DisposeRepositoryRA()
        {
            _interactor.DisposeRepositoryRA();
        }


        //public string GetOkLocale()
        //{
        //    return _authLocaleStrings.OK;
        //}

        //public string GetErrorLocale()
        //{
        //    return _authLocaleStrings.Error;
        //}

        //public string GetFacebookAuthErrorLocale()
        //{
        //    return _authLocaleStrings.FacebookAuthError;
        //} //TODO delete this???

        
        public void FacebookLoginClick()
        {
            _interactor.SocialLoginPerform(ESocialType.Facebook, _facebookCallLoginAction);
        }

        public void GoogleLoginClick()
        {
            _interactor.SocialLoginPerform(ESocialType.Google, _googleCallLoginAction);
        }

        public void VkLoginClick()
        {
            _interactor.SocialLoginPerform(ESocialType.Vk, _vkCallLoginAction);
        }

        public void OkLoginClick()
        {
            _interactor.SocialLoginPerform(ESocialType.Ok, _okCallLoginAction);
        }
    }
}
