using System;

using SocialTrading.Locale.Modules;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.ForgotPass.Interfaces;

namespace SocialTrading.Vipers.ForgotPass.Implementation
{
    public class PresenterForgotPass : IPresenterForgotPass
    {
        private readonly IViewForgotPass _view;
        private readonly IRouterForgotPass _router;
        private readonly IInteractorForgotPass _interactor;

        private readonly IRegAuth _forgotPassLocaleStrings;
        private readonly IForgotPassStylesHolder _stylesHolder;

        private EForgotPassStatus _eForgotPassLastState;


        public PresenterForgotPass(IViewForgotPass view, IInteractorForgotPass interactor, IRouterForgotPass router, IRegAuth forgotPassLocaleStrings, IForgotPassStylesHolder stylesHolder)
        {
            if (view == null || interactor == null || router == null || forgotPassLocaleStrings == null)
            {
                throw new NullReferenceException();
            }

            _forgotPassLocaleStrings = forgotPassLocaleStrings;

            _router = router;
            _view = view;
            _interactor = interactor;
            _view.Presenter = this;
            _interactor.Presenter = this;
            _stylesHolder = stylesHolder;

            _view.SetConfig();
        }


        public void EmailInput(string email)
        {
            _interactor.EmailInput(email);
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

        public void PassRecoveryClick(string email)
        {
            _interactor.PassRecoveryClick(email);
        }


        public void ShowAlertEmailRedirect(EForgotPassStatus eForgotPassState)
        {
            _eForgotPassLastState = eForgotPassState;
            switch (_eForgotPassLastState)
            {
                case EForgotPassStatus.RecoverySuccess:
                    _view.ShowAlertEmailRedirect(_forgotPassLocaleStrings.PasswordRecoverySuccess, _forgotPassLocaleStrings.OK);
                    break;

                case EForgotPassStatus.None:
                    break;
                case EForgotPassStatus.NoConnection:
                    _view.ShowAlertEmailRedirect(_forgotPassLocaleStrings.NoConnection, _forgotPassLocaleStrings.OK);
                    break;
                case EForgotPassStatus.Error:
                case EForgotPassStatus.UserNotFound:
                case EForgotPassStatus.ServerError:
                default:
                    _view.ShowAlertEmailRedirect(_forgotPassLocaleStrings.PasswordRecoveryError, _forgotPassLocaleStrings.OK);
                    break;
            }
        }

        public void BackButtonClick()
        {
            _router.ToAuth();
        }

        public void AlertButtonClick()
        {
            if (_eForgotPassLastState == EForgotPassStatus.RecoverySuccess)
            {
                _router.ToAuth();
            }
        }

        public void SetLocale()
        {
            var lang = _forgotPassLocaleStrings;

            _view.SetButtonLocale(lang.ButtonNext);
            _view.SetHeaderLabelLocale(lang.PasswordRecovery);
            _view.SetHintLocale(lang.EmailHint);
        }


        public void SetConfig()
        {
            _view.SetEmailEditTextTheme(_stylesHolder.EmailEditTextTheme);

            _view.SetRecoveryButtonTheme(_stylesHolder.RecoveryButtonTheme);
            _view.SetHeaderLabelTheme(_stylesHolder.HeaderLabelTheme);
            _view.SetLogoImageViewTheme(_stylesHolder.LogoImageViewTheme);
            _view.SetViewTheme(_stylesHolder.ViewTheme);
            _view.SetEmailLabelTheme(_stylesHolder.EmailLabelTheme);
            _view.SetEmailEditTextTheme(_stylesHolder.EmailEditTextTheme);
            _view.SetBackButtonTheme(_stylesHolder.BackButtonTheme);
        }
    }
}
