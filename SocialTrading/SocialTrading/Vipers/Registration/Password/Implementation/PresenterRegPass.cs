using System;

using SocialTrading.Vipers.Entity;
using SocialTrading.Locale.Modules;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Registration.Password.Interfaces;

namespace SocialTrading.Vipers.Registration.Password.Implementation
{
    public class PresenterRegPass : IPresenterRegPass
    {
        private readonly IViewRegPass _viewPass;
        private readonly IRouterRegPass _router;
        private readonly IInteractorRegPass _interactor;
        
        private readonly IRegAuth _regLocaleStrings;
        private readonly IRegPassStylesHolder _styleHolder;

        public PresenterRegPass(IViewRegPass view, IInteractorRegPass interactor, IRouterRegPass router, IRegPassStylesHolder stylesHolder, IRegAuth regLocaleStrings)
        {
            if (view == null || interactor == null || router == null)
            {
                throw new NullReferenceException();
            }

            _styleHolder = stylesHolder;
            _regLocaleStrings = regLocaleStrings;
            _router = router;
            _viewPass = view;
            _interactor = interactor;
            _viewPass.Presenter = this;
            _interactor.Presenter = this;
           
			_viewPass.SetConfig();
        }

        public void SetConfig()
        {
            _viewPass.SetHeaderLabelTheme(_styleHolder.HeaderLabelTheme);
            _viewPass.SetPasswordLabelTheme(_styleHolder.PasswordLabelTheme);
            _viewPass.SetConfirmPasswordLabelTheme(_styleHolder.ConfirmPasswordLabelTheme);
            _viewPass.SetRegButtonTheme(_styleHolder.RegButtonTheme);
            _viewPass.SetBackButtonTheme(_styleHolder.BackButtonTheme);
            _viewPass.SetViewTheme(_styleHolder.ViewTheme);
            _viewPass.SetLogoImageViewTheme(_styleHolder.LogoImageViewTheme);
			_viewPass.SetFeatureTextTheme(_styleHolder.FeatureTextTheme);
			_viewPass.SetFeatureImageTheme(_styleHolder.FeatureImageTheme);
            _viewPass.SetPasswordEditTextTheme(_styleHolder.PasswordEditTextTheme);
            _viewPass.SetConfirmPasswordEditTextTheme(_styleHolder.PasswordConfirmEditTextTheme);
            _viewPass.SetUserAgreementTheme(_styleHolder.UserAgreementMainTextTheme, _regLocaleStrings.RegUserAgreementTextView,
                _styleHolder.UserAgreementAttrTextTheme, _regLocaleStrings.RegUserAgreementLink, _regLocaleStrings.RegUserAgreementTextView.Length);
        }

        public void SetLocale()
        {
            _viewPass.SetPasswordLocale(_regLocaleStrings.PasswordHint);
            _viewPass.SetConfirmPasswordLocale(_regLocaleStrings.RegPassConfirmHint);
            _viewPass.SetRegButtonLocale(_regLocaleStrings.RegButton);
            _viewPass.SetUserAgreementLocale(_regLocaleStrings.RegUserAgreementTextView + "" + _regLocaleStrings.RegUserAgreementLink);
            _viewPass.SetTitleLocale(_regLocaleStrings.RegPassTextView);
			_viewPass.SetFeatureTextLocale(_regLocaleStrings.RegPassFeatureText);
		}

        public string GetOkLocale()
        {
            return _regLocaleStrings.OK;
        }

        public void PasswordConfirmInput()
        {
            _interactor.PasswordConfirmInput(_viewPass.GetPassword(), _viewPass.GetConfirmPassword());
        }

        public void PasswordInput()
        {
            _interactor.PasswordInput(_viewPass.GetPassword());
        }

        public void SetPasswordConfirmState(EState state)
        {
            switch (state)
            {
                case EState.Success:
                    _viewPass.SetConfirmPasswordEditTextTheme(_styleHolder.PasswordConfirmStateSuccess);
                    break;
                case EState.PassDoesNotMatch:
                    _viewPass.SetConfirmPasswordEditTextTheme(_styleHolder.PasswordConfirmStatePassNotMatch);
                    break;
                case EState.Fail:
                    _viewPass.SetConfirmPasswordEditTextTheme(_styleHolder.PasswordConfirmStateFail);
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
                    _viewPass.SetPasswordEditTextTheme(_styleHolder.PasswordStateSuccess);
                    break;
                case EState.Fail:
                    _viewPass.SetPasswordEditTextTheme(_styleHolder.PasswordStateFail);
                    break;

                default:
                    break;
            }
        }

        //public void CheckRegState(EResponseState state, string message)
        //{
        //    var repo = _interactor.GetRepository();

        //    switch (state)
        //    {
        //        case EResponseState.NoConnection:
        //            _viewPass.ShowRegFail(string.Empty, _interactor.GetRepository().LangRA.NoConnection);
        //            _viewPass.SetInteractionAvailable();
        //            break;
        //        case EResponseState.NoResponse:
        //            _viewPass.ShowRegFail(string.Empty, _interactor.GetRepository().LangRA.NoResponse);
        //            _viewPass.SetInteractionAvailable();
        //            break;
        //        case EResponseState.NotFound:
        //            _viewPass.ShowRegFail(string.Empty, _interactor.GetRepository().LangRA.NotFound);
        //            _viewPass.SetInteractionAvailable();
        //            break;
        //        case EResponseState.ServiceUnavailable:
        //            _viewPass.ShowRegFail(string.Empty, _interactor.GetRepository().LangRA.ServiceUnavailable);
        //            _viewPass.SetInteractionAvailable();
        //            break;
        //        case EResponseState.Unknown:
        //            _viewPass.ShowRegFail(string.Empty, _interactor.GetRepository().LangRA.Unknown);
        //            _viewPass.SetInteractionAvailable();
        //            break;

        //        case EResponseState.RegSuccess:
        //            _viewPass.ShowRegSuccess(string.Empty, message);
        //            _viewPass.SetInteractionAvailable();
        //            break;
        //        case EResponseState.RegError:
        //            _viewPass.ShowRegFail(string.Empty, message);
        //            _viewPass.SetInteractionAvailable();
        //            break;

        //        case EResponseState.Waiting:
        //            _viewPass.SetInteractionUnavailable();
        //            break;

        //        default:
        //            break;
        //    }
        //}

        public void RegStateSuccess(string email)
        {
            _viewPass.ShowRegSuccess(string.Empty, _regLocaleStrings.RegSuccess + Environment.NewLine + email);
            _viewPass.SetInteractionAvailable();
        }

        public void RegStateFail(ERegResponseStatus state)
        {
            switch (state)
            {
                case ERegResponseStatus.Error:
                    _viewPass.ShowRegFail(string.Empty, _regLocaleStrings.RegError);
                    _viewPass.SetInteractionAvailable();
                    break;
                case ERegResponseStatus.NoConnection:
                    _viewPass.ShowRegFail(string.Empty, _regLocaleStrings.NoConnection);
                    break;
                case ERegResponseStatus.Success:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        public void ShowHideSpinner(bool isShow)
        {
            if (isShow)
            {
                _viewPass.ShowSpinner();
            }
            else
            {
                _viewPass.HideSpinner();
            }
        }

        public void RegisterClick()
        {
            _interactor.RegistrationClick(new RegistrationPasswordStrings(_viewPass.GetPassword(), _viewPass.GetConfirmPassword()));
        }

        public void UserAgreementClick()
        {
            _router.ToUserAgreement();
        }

        public void AlertOkClick()
        {
            _router.ToAuth();
            _interactor.CleanRepositoryRA();
        }

        public void BackClick()
        {
            _router.ToRegEmail();
        }

        public void SaveData()
        {
            _interactor.SaveData(new RegistrationPasswordStrings(_viewPass.GetPassword(), _viewPass.GetConfirmPassword()));
        }

        public void LoadData()
        {
            var data = _interactor.LoadData();

            if (!string.IsNullOrEmpty(data.Password))
            {
                _viewPass.SetPassword(data.Password);
            }
            if (!string.IsNullOrEmpty(data.ConfirmPass))
            {
                _viewPass.SetConfirmPass(data.ConfirmPass);
            }
        }
    }
}
