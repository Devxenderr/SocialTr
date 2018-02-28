using System;

using SocialTrading.Vipers.Entity;
using SocialTrading.Locale.Modules;
using SocialTrading.DTO.Interfaces;
using SocialTrading.DTO.Response.UserSettings;
using SocialTrading.Vipers.MoreOptions.EditProfile.Models;
using SocialTrading.Vipers.MoreOptions.EditProfile.Interfaces;

namespace SocialTrading.Vipers.MoreOptions.EditProfile.Implementation
{
    public class PresenterEditProfile : IPresenterEditProfile
    {
        private readonly IViewEditProfile _view;
        private readonly IRouterEditProfile _router;
        private readonly IInteractorEditProfile _interactor;

        private readonly IEditProfile _localeStrings;
        private readonly IEditProfileStylesHolder _stylesHolder;


        public PresenterEditProfile(IViewEditProfile view, IInteractorEditProfile interactor, IRouterEditProfile router, IEditProfileStylesHolder stylesHolder, IEditProfile localeStrings)
        {
            _view = view ?? throw new ArgumentNullException(nameof(_view));
            _interactor = interactor ?? throw new ArgumentNullException(nameof(_interactor));
            _router = router ?? throw new ArgumentNullException(nameof(_router));

            _stylesHolder = stylesHolder;
            _localeStrings = localeStrings;

            SetConfig();

            _interactor.SendRequestForUserData();
        }


        public void SetConfig()
        {
            Subscribe();

            _view.SetLabelsTheme(_stylesHolder.LabelsTheme);
            _view.SetNameEditTextTheme(_stylesHolder.EditTextsTheme);
            _view.SetLastnameEditTextTheme(_stylesHolder.EditTextsTheme);
            _view.SetStatusEditTextTheme(_stylesHolder.EditTextsTheme);
            _view.SetSaveButtonTheme(_stylesHolder.SaveButtonTheme);
            _view.SetCancelButtonTheme(_stylesHolder.CancelButtonTheme);

            _view.SetNameLabel(_localeStrings.EditProfileNameTitle);
            _view.SetLastnameLabel(_localeStrings.EditProfileLastnameTitle);
            _view.SetStatusLabel(_localeStrings.EditProfileStatusTitle);
            _view.SetSaveButtonTitle(_localeStrings.EditProfileSaveButtonTitle);
            _view.SetCancelButtonTitle(_localeStrings.EditProfileCancelButtonTitle);
        }

        public void Subscribe()
        {
            _interactor.ReceiveUserData += OnReceiveUserData;
            _interactor.CheckEditProfileResponse += OnCheckEditProfileResponse;
            _interactor.ValidationFieldResponse += OnValidationFieldResponse;

            _view.SaveButtonClick += OnSaveButtonClick;
            _view.CancelButtonClick += OnCancelButtonClick;
            _view.AlertButtonClick += OnAlertButtonClick;

            _view.NameWasChanged += s => _interactor.NameWasInput(s);
            _view.LastNameWasChanged += s => _interactor.LastnameWasInput(s);
            _view.StatusWasChanged += s => _interactor.StatusWasInput(s);

        }

        public void UnSubscribe()
        {
            _view.SaveButtonClick -= OnSaveButtonClick;
            _view.CancelButtonClick -= OnCancelButtonClick;
            _view.AlertButtonClick -= OnAlertButtonClick;

            _interactor.ReceiveUserData -= OnReceiveUserData;
            _interactor.CheckEditProfileResponse -= OnCheckEditProfileResponse;
            _interactor.ValidationFieldResponse -= OnValidationFieldResponse;

            _view.NameWasChanged -= s => _interactor.NameWasInput(s);
            _view.LastNameWasChanged -= s => _interactor.LastnameWasInput(s);
            _view.StatusWasChanged -= s => _interactor.StatusWasInput(s);
        }


        private void OnReceiveUserData(IEditProfileEntity editProfileUserData)
        {
            if (editProfileUserData == null)
            {
                return;
            }

            _view.SetName(editProfileUserData.FirstName);
            _view.SetLastname(editProfileUserData.LastName);
            _view.SetStatus(editProfileUserData.UserStatus);
        }


        private void OnSaveButtonClick(string name, string lastname, string status)
        {
            var model = new EditProfileEntity(name, lastname, status);

            _interactor.SaveButtonClick(model);
        }

        private void OnAlertButtonClick(EEditProfileAlertType alertType)
        {
            if (alertType == EEditProfileAlertType.SuccessMessage)
            {
                _router.GoBack();
            }
        }

        private void OnCancelButtonClick()
        {
            _router.GoBack();
        }


        private void OnValidationFieldResponse(EEditProfileFields eEditProfileFields, bool result)
        {
            var theme = result ? _stylesHolder.EditTextsTheme : _stylesHolder.EditTextsFailTheme;
            switch (eEditProfileFields)
            {
                case EEditProfileFields.Name:
                    _view.SetNameEditTextTheme(theme);
                    break;
                case EEditProfileFields.LastName:
                    _view.SetLastnameEditTextTheme(theme);
                    break;
                case EEditProfileFields.Status:
                    _view.SetStatusEditTextTheme(theme);
                    break;
                default:
                    break;
            }
        }

        private void OnCheckEditProfileResponse(EUserSettingsResponseState status)
        {
            switch (status)
            {
                case EUserSettingsResponseState.Success:
                    _view.HideSpinner();
                    _view.ShowAlert(_localeStrings.EditProfileAlertSuccess, _localeStrings.OK, EEditProfileAlertType.SuccessMessage);
                    break;
                case EUserSettingsResponseState.Error:
                    _view.HideSpinner();
                    _view.ShowAlert(_localeStrings.Error, _localeStrings.OK, EEditProfileAlertType.FailMessage);
                    break;
                case EUserSettingsResponseState.Unauthorized:
                    _view.HideSpinner();
                    _view.ShowAlert(_localeStrings.Unauthorized, _localeStrings.OK, EEditProfileAlertType.FailMessage);
                    break;
                case EUserSettingsResponseState.UnprocessableEntity:
                    _view.HideSpinner();
                    _view.ShowAlert(_localeStrings.UnprocessableEntity, _localeStrings.OK, EEditProfileAlertType.FailMessage);
                    break;
                case EUserSettingsResponseState.NoConnection:
                    _view.HideSpinner();
                    _view.ShowAlert(_localeStrings.NoConnection, _localeStrings.OK, EEditProfileAlertType.FailMessage);
                    break;
                case EUserSettingsResponseState.Processing:
                    _view.ShowSpinner();
                    break;
                default:
                    break;
            }
        }


        public void Dispose()
        {
            UnSubscribe();
        }
    }
}