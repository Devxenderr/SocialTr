using System;

using SocialTrading.Vipers.Entity;
using SocialTrading.Locale.Modules;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Registration.Phone.Interfaces;

namespace SocialTrading.Vipers.Registration.Phone.Implementation
{
    public class PresenterRegPhone : IPresenterRegPhone 
    {
        private readonly IRouterRegPhone _router;
		private readonly IViewRegPhone _viewPhone;
		private readonly IInteractorRegPhone _interactor;
        
        private readonly IRegAuth _regLocaleStrings;
        private readonly IRegPhoneStylesHolder _styleHolder;

        public PresenterRegPhone(IViewRegPhone view, IInteractorRegPhone interactor, IRouterRegPhone router, IRegPhoneStylesHolder stylesHolder, IRegAuth regLocaleStrings)
        {
            if (view == null || interactor == null || router == null)
            {
                throw new NullReferenceException();
            }

            _styleHolder = stylesHolder;
            _regLocaleStrings = regLocaleStrings;
            _router = router;
			_viewPhone = view;
			_interactor = interactor;
			_viewPhone.Presenter = this;
			_interactor.Presenter = this;

			_viewPhone.SetConfig();
        }

        public void SetConfig()
        {
            _viewPhone.SetHeaderLabelTheme(_styleHolder.HeaderLabelTheme);
            _viewPhone.SetPhoneCountryLabelTheme(_styleHolder.PhoneCountryLabelTheme);
            _viewPhone.SetPhoneNumberLabelTheme(_styleHolder.PhoneNumberLabelTheme);
            _viewPhone.SetNextButtonTheme(_styleHolder.NextButtonTheme);
            _viewPhone.SetSkipButtonTheme(_styleHolder.SkipButtonTheme);
            _viewPhone.SetBackButtonTheme(_styleHolder.BackButtonTheme);
            _viewPhone.SetViewTheme(_styleHolder.ViewTheme);
            _viewPhone.SetLogoImageViewTheme(_styleHolder.LogoImageViewTheme);
            _viewPhone.SetPhoneCountryEditTextTheme(_styleHolder.PhoneCountryEditTextTheme);
            _viewPhone.SetPhoneNumberEditTextTheme(_styleHolder.PhoneNumberEditTextTheme);
			_viewPhone.SetFeatureTextTheme(_styleHolder.FeatureTextTheme);
			_viewPhone.SetFeatureImageTheme(_styleHolder.FeatureImageTheme);
        }

        public void SetLocale()
        {
            _viewPhone.SetPhoneCountryLocale(_regLocaleStrings.RegPhoneCountryHint);
            _viewPhone.SetPhoneNumberLocale(_regLocaleStrings.RegPhoneNumberHint);
            _viewPhone.SetNextButtonLocale(_regLocaleStrings.ButtonNext);
            _viewPhone.SetSkipButtonLocale(_regLocaleStrings.RegPhoneNumberButtonSkip);
            _viewPhone.SetTitleLocale(_regLocaleStrings.RegPhoneNumberHeader);
			_viewPhone.SetFeatureTextLocale(_regLocaleStrings.RegPhoneFeatureText);
		}

        public void NextClick()
        {
            if (_interactor.NextClick(new RegistrationPhoneStrings(_viewPhone.GetPhoneCountry(), _viewPhone.GetPhoneNumber())))
            {
                _router.ToRegEmail();
            }
        }
        
        public void SkipClick()
        {
            _router.ToRegEmail();
        }

        public void BackClick()
        {
            _router.ToRegName();
        }

        public void PhoneCountryInput()
        {
            _interactor.PhoneCountryInput(_viewPhone.GetPhoneCountry());
        }

        public void PhoneNumberInput()
        {
            _interactor.PhoneNumberInput(_viewPhone.GetPhoneNumber());
        }

        public void SetPhoneCountryState(EState state)
        {
			switch (state)
			{
				case EState.Success:
                    _viewPhone.SetPhoneCountryEditTextTheme(_styleHolder.PhoneCountryStateSuccess);
					break;
				case EState.Fail:
                    _viewPhone.SetPhoneCountryEditTextTheme(_styleHolder.PhoneCountryStateFail);
					break;

				default:
					break;
			}
        }

        public void SetPhoneNumberState(EState state)
        {
            switch (state)
            {
                case EState.Success:
                    _viewPhone.SetPhoneNumberEditTextTheme(_styleHolder.PhoneNumberStateSuccess);
                    break;
                case EState.Fail:
                    _viewPhone.SetPhoneNumberEditTextTheme(_styleHolder.PhoneNumberStateFail);
                    break;

                default:
                    break;
            }
        }

        public void SaveData()
		{
            _interactor.SaveData(new RegistrationPhoneStrings(_viewPhone.GetPhoneCountry(), _viewPhone.GetPhoneNumber()));
        }

        public void LoadData()
        {
            var data = _interactor.LoadData();

            if (!string.IsNullOrEmpty(data.PhoneCountry))
            {
                _viewPhone.SetPhoneCountry(data.PhoneCountry);
            }
            if (!string.IsNullOrEmpty(data.PhoneNumber))
            {
                _viewPhone.SetPhoneNumber(data.PhoneNumber);
            }
        }

    }
}
