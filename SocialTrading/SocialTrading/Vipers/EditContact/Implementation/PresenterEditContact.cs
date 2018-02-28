using System;

using SocialTrading.Vipers.Entity;
using SocialTrading.Locale.Modules;
using SocialTrading.DTO.Response.UserSettings;
using SocialTrading.Vipers.EditContact.Interfaces;

namespace SocialTrading.Vipers.EditContact.Implementation
{
    public class PresenterEditContact : IPresenterEditContact
    {
        private readonly IViewEditContact _view;
        private readonly IInteractorEditContact _interactor;
        private readonly IRouterEditContact _router;
        private IEditContactStyleHolder _styleHolder;
        private IEditContact _locale;

        public PresenterEditContact(IViewEditContact view, IInteractorEditContact interactor, IRouterEditContact router)
        {
            _view = view ?? throw new NullReferenceException(nameof(_view));
            _interactor = interactor ?? throw new NullReferenceException(nameof(_interactor));
            _router = router ?? throw new NullReferenceException(nameof(_router));
            _interactor.Presenter = this;
            _view.Presenter = this;
        }


        public void SkypeTextChanged(string text)
        {
            var valid = _interactor.SkypeTextChanged(text);
            if (_styleHolder == null)
            {
                return;
            }

            if (valid)
            {
                _view.SetSkypeEditTextTheme(_styleHolder.EditTextNoneTheme);
            }
            else
            {
                _view.SetSkypeEditTextTheme(_styleHolder.EditTextFailTheme);
            }
        }

        public void PhoneTextChanged(string text)
        {
            var valid = _interactor.PhoneTextChanged(text);
            if (_styleHolder == null)
            {
                return;
            }

            if (valid)
            {
                _view.SetPhoneEditTextTheme(_styleHolder.EditTextNoneTheme);
            }
            else
            {
                _view.SetPhoneEditTextTheme(_styleHolder.EditTextFailTheme);
            }
        }

        public void CityTextChanged(string text)
        {
            var valid = _interactor.CityTextChanged(text);
            if (_styleHolder == null)
            {
                return;
            }

            if (valid)
            {
                _view.SetCityEditTextTheme(_styleHolder.EditTextNoneTheme);
            }
            else
            {
                _view.SetCityEditTextTheme(_styleHolder.EditTextFailTheme);
            }
        }


        public void InvalidSkypeInput()
        {
            _view.SetSkypeEditTextTheme(_styleHolder.EditTextFailTheme);
        }

        public void InvalidPhoneInput()
        {
            _view.SetPhoneEditTextTheme(_styleHolder.EditTextFailTheme);
        }

        public void InvalidCityInput()
        {
            _view.SetCityEditTextTheme(_styleHolder.EditTextFailTheme);
        }


        public void SaveClick(string email, string skype, string country, string city, string phone)
        {
            _interactor.SaveClick(new EditContactEntity(email, skype, country, city, phone));
        }

        public void CancelClick()
        {
            _interactor.CancelClick();
        }

        public void AlertOkClick()
        {
            _interactor.AlertOkClick();
        }

        public void CountryClick()
        {
            _interactor.CountryClick();
        }

        public void SetConfig()
        {
            _interactor.SetConfig();
        }

        public void SetSelectedCountry(string selectedKey)
        {
            _view.SetCountry(selectedKey);
        }

        public void SetLocale(IEditContact locale)
        {
            _locale = locale;

            if (_locale != null)
            {
                _view.SetCancelButtonLocale(_locale.EditContactCancel);
                _view.SetSaveButtonLocale(_locale.EditContactSave);

                _view.SetEmailLabelLocale(_locale.EditContactEmail);
                _view.SetCityLabelLocale(_locale.EditContactCity);
                _view.SetSkypeLabelLocale(_locale.EditContactSkype);
                _view.SetCountryLabelLocale(_locale.EditContactCountry);
                _view.SetPhoneLabelLocale(_locale.EditContactPhone);
            }
        }

        public void SetTheme(IEditContactStyleHolder styleHolder)
        {
            _styleHolder = styleHolder;

            if (_styleHolder != null)
            {
                _view.SetCountryTextViewTheme(_styleHolder.TextViewTheme);
                _view.SetCityTextViewTheme(_styleHolder.TextViewTheme);
                _view.SetEmailTextViewTheme(_styleHolder.TextViewTheme);
                _view.SetPhoneTextViewTheme(_styleHolder.TextViewTheme);
                _view.SetSkypeTextViewTheme(_styleHolder.TextViewTheme);

                _view.SetEmailEditTextTheme(_styleHolder.UnEditableTextNoneTheme);
                _view.SetSkypeEditTextTheme(_styleHolder.EditTextNoneTheme);
                _view.SetCityEditTextTheme(_styleHolder.EditTextNoneTheme);
                _view.SetCountryEditTextTheme(_styleHolder.EditTextNoneTheme);
                _view.SetPhoneEditTextTheme(_styleHolder.EditTextNoneTheme);

                _view.SetSaveButtonTheme(_styleHolder.SaveButtonTheme);
                _view.SetCancelButtonTheme(_styleHolder.CancelButtonTheme);
            }
        }

        public void SetData(EditContactEntity entity)
        {
            _view.SetCity(entity.City);
            _view.SetCountry(entity.Country);
            _view.SetEmail(entity.Email);
            _view.SetSkype(entity.Skype);
            _view.SetPhone(entity.Phone);
        }

        public void EditContactState(EUserSettingsResponseState status)
        {
            switch (status)
            {
                case EUserSettingsResponseState.Success:
                    _view.ShowSuccessAlert(_locale.EditContactAlertSuccess, _locale.EditContactAlertOk);
                    break;
                case EUserSettingsResponseState.Error:
                    _view.ShowFailAlert(_locale.EditContactAlertFail, _locale.EditContactAlertOk);
                    break;
                case EUserSettingsResponseState.NoConnection:
                    _view.ShowFailAlert(_locale.EditContactAlertFail + ". " + _locale.NoConnection, _locale.EditContactAlertOk);
                    break;
                case EUserSettingsResponseState.UnprocessableEntity:
                    _view.ShowFailAlert(_locale.EditContactAlertFail + ". " + _locale.UnprocessableEntity, _locale.EditContactAlertOk);
                    break;
                case EUserSettingsResponseState.Unauthorized:
                    _view.ShowFailAlert(_locale.EditContactAlertFail + ". " + _locale.Unauthorized, _locale.EditContactAlertOk);
                    break;

                default:
                    break;
            }
        }

        public void GoBack()
        {
            _router.GoBack();
        }

        public void GoToCountrySelection()
        {
            _router.ToCountrySelection();
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

    }
}
