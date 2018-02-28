using System;

using SocialTrading.DTO.Interfaces;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.DTO.Response.UserSettings;
using SocialTrading.Tools.Validation.Interfaces;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Vipers.ModelCreators.Interfaces;
using SocialTrading.Vipers.MoreOptions.EditProfile.Models;
using SocialTrading.Vipers.MoreOptions.EditProfile.Interfaces;

namespace SocialTrading.Vipers.MoreOptions.EditProfile.Implementation
{
    public class InteractorEditProfile : IInteractorEditProfile
    {
        public event Action<IEditProfileEntity> ReceiveUserData;
        public event Action<EEditProfileFields, bool> ValidationFieldResponse;
        public event Action<EUserSettingsResponseState> CheckEditProfileResponse;

        private readonly IValidationEditProfile _validation;
        private readonly IEditProfileController _controller;
        private readonly IEditProfileModelCreator _modelCreator;

        private EControllerStatus _currentRecieveStatus = EControllerStatus.None;


        public InteractorEditProfile(IValidationEditProfile validation, IEditProfileController controller, IEditProfileModelCreator modelCreator)
        {
            _validation = validation ?? throw new ArgumentNullException(nameof(validation));
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _modelCreator = modelCreator ?? throw new ArgumentNullException(nameof(modelCreator));

            _controller.OnRecieveModel += ControllerOnMessage;
        }


        private void ControllerOnMessage(IModel model)
        {
            _currentRecieveStatus = EControllerStatus.None;

            switch (model.ControllerStatus)
            {
                case EControllerStatus.Ok:
                    GetMessage(model);
                    break;
                case EControllerStatus.Processing:
                    CheckEditProfileResponse?.Invoke(EUserSettingsResponseState.Processing);
                    _currentRecieveStatus = EControllerStatus.Processing;
                    break;
                case EControllerStatus.NoConnection:
                    CheckEditProfileResponse?.Invoke(EUserSettingsResponseState.NoConnection);
                    break;

                case EControllerStatus.Error:
                case EControllerStatus.None:
                default:
                    CheckEditProfileResponse?.Invoke(EUserSettingsResponseState.Error);
                    break;
            }
        }

        private void GetMessage(IModel editProfileModel)
        {
            if (editProfileModel is DataModelUserInfo model && model.Status == EUserSettingsResponseState.Success)
            {
                _currentRecieveStatus = EControllerStatus.None;

                CheckEditProfileResponse?.Invoke(model.Status);
                ReceiveUserData?.Invoke(model);
            }
        }


        public bool NameWasInput(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            var result = _validation.CheckName(name);
            ValidationFieldResponse?.Invoke(EEditProfileFields.Name, result);
            return result;
        }

        public bool LastnameWasInput(string lastname)
        {
            if (lastname == null)
            {
                throw new ArgumentNullException(nameof(lastname));
            }

            var result = _validation.CheckName(lastname);
            ValidationFieldResponse?.Invoke(EEditProfileFields.LastName, result);
            return result;
        }

        public bool StatusWasInput(string status)
        {
            if (status == null)
            {
                throw new ArgumentNullException(nameof(status));
            }

            var result = _validation.CheckStatus(status);
            ValidationFieldResponse?.Invoke(EEditProfileFields.Status, result);
            return result;
        }


        public void SaveButtonClick(IEditProfileEntity userData)
        {
            if (_currentRecieveStatus != EControllerStatus.Processing)
            {
                if (userData == null) throw new ArgumentNullException(nameof(userData));

                if (LastnameWasInput(userData.LastName) && NameWasInput(userData.FirstName) && StatusWasInput(userData.UserStatus))
                {
                    _controller.Send(_modelCreator.GetRequestModel(userData));
                }
            }
        }

        public void SendRequestForUserData()
        {
            ReceiveUserData?.Invoke(_modelCreator.GetModel());
        }


        public void Dispose()
        {
            _controller.OnRecieveModel -= ControllerOnMessage;
        }
    }
}