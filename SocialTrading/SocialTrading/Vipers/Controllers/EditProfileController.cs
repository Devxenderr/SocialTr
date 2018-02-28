using System;
using System.Net;
using SocialTrading.DTO;
using SocialTrading.DTO.Response;
using SocialTrading.DTO.Response.UserSettings;

using SocialTrading.Connection.Interfaces;

using SocialTrading.Tools.Enumerations;
using SocialTrading.Tools.Exceptions.Parse;

using SocialTrading.Service.Interfaces.Repository;

using SocialTrading.Vipers.Controllers.Interfaces;

namespace SocialTrading.Vipers.Controllers
{
    public class EditProfileController : IEditProfileController
    {
        private readonly Func<string, DataModelUserInfo> _parseResponseEditProfile; //TODO change string to response Model
        private EControllerStatus _currentRecieveStatus = EControllerStatus.None;
        private readonly IRepositoryEditProfile _repository;

        public event Action<IModel> OnRecieveModel;
        public IContactCreator ContactCreator { get; set; }


        public EditProfileController(IContactCreator contactCreator, IRepositoryEditProfile repository, Func<string, DataModelUserInfo> parseResponseEditProfile)
        {
            _parseResponseEditProfile = parseResponseEditProfile;
            ContactCreator = contactCreator;
            _repository = repository;
        }

        public void Send(IModelSend senderModel)
        {
            var contact = ContactCreator.CreateContact(senderModel);
            contact.Reciever = this;
            
            if (_currentRecieveStatus != EControllerStatus.Processing)
            {
                var processingModel = new DataModelMock
                {
                    ControllerStatus = EControllerStatus.Processing
                };
                _currentRecieveStatus = processingModel.ControllerStatus;
                OnRecieveModel?.Invoke(processingModel);
                contact.Sender.Send(senderModel);
            }
        }

        public void SetMessage(IModelResponse responseModel)
        {
            DataModelUserInfo result = null;

            if (responseModel.Status.Equals(HttpStatusCode.OK))
            {
                ParseCheck(() =>
                {
                    result = _parseResponseEditProfile(responseModel.Body);
                    result.Status = EUserSettingsResponseState.Success;
                    result.ControllerStatus = EControllerStatus.Ok;
                    _repository.EditProfileUserInfo = result;
                });
            }
            else if (responseModel.Status.Equals(HttpStatusCode.Unauthorized))
            {
                ParseCheck(() =>
                {
                    result = _parseResponseEditProfile(responseModel.Body);
                    result.Status = EUserSettingsResponseState.Unauthorized;
                    result.ControllerStatus = EControllerStatus.Error;
                });
            }
            else if (responseModel.Status.Equals(HttpStatusCode.RequestTimeout))
            {
                ParseCheck(() =>
                {
                    result = _parseResponseEditProfile(responseModel.Body);
                    result.Status = EUserSettingsResponseState.Error;
                    result.ControllerStatus = EControllerStatus.Error;
                });
            }
            else if (responseModel.Status.Equals(HttpStatusCode.BadGateway))
            {
                _currentRecieveStatus = EControllerStatus.None;
                OnRecieveModel?.Invoke(new DataModelMock
                {
                    ControllerStatus = EControllerStatus.NoConnection

                });
                return;
            }
            else
            {
                ParseCheck(() =>
                {
                    result = _parseResponseEditProfile(responseModel.Body);
                    result.Status = EUserSettingsResponseState.Error;
                    result.ControllerStatus = EControllerStatus.Error;
                });
            }

            if (result != null)
            {
                _currentRecieveStatus = EControllerStatus.None;
                OnRecieveModel?.Invoke(result);
            }
        }

        private void ParseCheck(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch (ParseException)
            {
                _currentRecieveStatus = EControllerStatus.None;
                OnRecieveModel?.Invoke(
                    new DataModelMock
                    {
                        ControllerStatus = EControllerStatus.Error
                    }
                );
            }
        }

        private class DataModelMock : IModel
        {
            public EControllerStatus ControllerStatus { set; get; }
        }
    }
}