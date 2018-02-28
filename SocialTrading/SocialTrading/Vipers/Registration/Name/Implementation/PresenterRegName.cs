using System;

using SocialTrading.Vipers.Entity;
using SocialTrading.Locale.Modules;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Registration.Name.Interfaces;

namespace SocialTrading.Vipers.Registration.Name.Implementation
{
    public class PresenterRegName : IPresenterRegName
    {
        private readonly IViewRegName _viewName;
        private readonly IRouterRegName _router;
        private readonly IInteractorRegName _interactor;
        
        private readonly IRegAuth _regLocaleStrings;
        private readonly IRegNameStylesHolder _styleHolder;

        public PresenterRegName(IViewRegName view, IInteractorRegName interactor, IRouterRegName router, IRegNameStylesHolder stylesHolder, IRegAuth regLocaleStrings)            
        {
            if (view == null || interactor == null || router == null)
            {
                throw new NullReferenceException();
            }

            _styleHolder = stylesHolder;
            _regLocaleStrings = regLocaleStrings;
            _router = router;
            _viewName = view;
            _interactor = interactor;
            _viewName.Presenter = this;
            _interactor.Presenter = this;

            _viewName.SetConfig();
        }

        public void SetConfig()
        {
            _viewName.SetHeaderLabelTheme(_styleHolder.HeaderLabelTheme);
            _viewName.SetNameLabelTheme(_styleHolder.NameLabelTheme);
            _viewName.SetLastNameLabelTheme(_styleHolder.LastNameLabelTheme);
            _viewName.SetNextButtonTheme(_styleHolder.NextButtonTheme);
            _viewName.SetBackButtonTheme(_styleHolder.BackButtonTheme);
            _viewName.SetViewTheme(_styleHolder.ViewTheme);
            _viewName.SetLogoImageViewTheme(_styleHolder.LogoImageViewTheme);
            _viewName.SetNameEditTextTheme(_styleHolder.NameEditTextTheme);
            _viewName.SetLastNameEditTextTheme(_styleHolder.LastNameEditTextTheme);
			_viewName.SetFeatureTextTheme(_styleHolder.FeatureTextTheme);
			_viewName.SetFeatureImageTheme(_styleHolder.FeatureImageTheme);
        }

        public void SetLocale()
        {
            _viewName.SetNameLocale(_regLocaleStrings.RegNameHint);
            _viewName.SetLastNameLocale(_regLocaleStrings.RegLastNameHint);
            _viewName.SetNextButtonLocale(_regLocaleStrings.ButtonNext);
            _viewName.SetTitleLocale(_regLocaleStrings.RegNameTextView);
            _viewName.SetFeatureTextLocale(_regLocaleStrings.RegNameFeatureText);
        }

        public void LastNameInput()
        {
            _interactor.LastNameInput(_viewName.GetLastName());
        }

        public void NameInput()
        {
            _interactor.NameInput(_viewName.GetFirstName());
        }


        public void SetLastNameState(EState state)
        {
            switch (state)
            {
                case EState.Success:
                    _viewName.SetLastNameEditTextTheme(_styleHolder.LastNameStateSuccess);
                    break;
                case EState.Fail:
                    _viewName.SetLastNameEditTextTheme(_styleHolder.LastNameStateFail);
                    break;

                default:
                    break;
            }
        }

        public void SetNameState(EState state)
        {
            switch (state)
            {
                case EState.Success:
                    _viewName.SetNameEditTextTheme(_styleHolder.NameStateSuccess);
                    break;
                case EState.Fail:
                    _viewName.SetNameEditTextTheme(_styleHolder.NameStateFail);
                    break;

                default:
                    break;
            }
        }


        public void NextClick()
        {
            if (_interactor.NextClick(new RegistrationNamesStrings(_viewName.GetFirstName(), _viewName.GetLastName())))
            {
                _router.ToRegPhone();
            }
        }
        
        public void BackClick()
        {
            _router.ToAuth();
        }

        public void SaveData()
        {			
            _interactor.SaveData(new RegistrationNamesStrings(_viewName.GetFirstName(), _viewName.GetLastName()));
        }

        public void LoadData()
        {
            var data = _interactor.LoadData();

            if (!string.IsNullOrEmpty(data.FirstName))
            {
                _viewName.SetFirstName(data.FirstName);
            }
            if (!string.IsNullOrEmpty(data.LastName))
            {
                _viewName.SetLastName(data.LastName);
            }
        }
    }
}
