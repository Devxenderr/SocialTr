using System;
using System.Net;

using SocialTrading.DTO;
using SocialTrading.DTO.Response;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Tools.Exceptions.Parse;
using SocialTrading.DTO.Response.UserSettings;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Controllers.Interfaces;

namespace SocialTrading.Vipers.Controllers
{
    public class MoreOptionsController : IMoreOptionsController
    {
        public IContactCreator ContactCreator { get; set; }

        public event Action<IModel> OnRecieveModel;

        private EControllerStatus _currentRecieveStatus;
        private readonly IRepositoryUserSettings _repository;
        private readonly IRepositoryUserAuth _repositoryUserAuth;
        private readonly Func<string, DataModelUserInfo> _parseResponseUserInfo;


        public MoreOptionsController(IContactCreator contactCreator, IRepositoryUserSettings repository, IRepositoryUserAuth repositoryUserAuth, Func<string, DataModelUserInfo> parseResponseUserInfo)
        {
            ContactCreator = contactCreator ?? throw new ArgumentNullException(nameof(contactCreator));

            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _repositoryUserAuth = repositoryUserAuth ?? throw new ArgumentNullException(nameof(repositoryUserAuth));
            _parseResponseUserInfo = parseResponseUserInfo ?? throw new ArgumentNullException(nameof(parseResponseUserInfo));
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
                    result = _parseResponseUserInfo(responseModel.Body);
                    result.Status = EUserSettingsResponseState.Success;
                    result.ControllerStatus = EControllerStatus.Ok;
                    _repository.EditContactUserInfo = result;
                    _repository.EditProfileUserInfo = result;
                    _repositoryUserAuth.AuthData.Name = result.IsNickName ? result.Nickname : result.FirstName + " " + result.LastName;
                });
            }
            else if (responseModel.Status.Equals(HttpStatusCode.RequestTimeout))
            {
                ParseCheck(() =>
                {
                    result = _parseResponseUserInfo(responseModel.Body);
                    result.Status = EUserSettingsResponseState.Error;
                    result.ControllerStatus = EControllerStatus.Error;
                });
            }
            else if (responseModel.Status.Equals(HttpStatusCode.ExpectationFailed))
            {
                OnRecieveModel?.Invoke(new DataModelMock
                {
                    ControllerStatus = EControllerStatus.NoConnection
                });
                _currentRecieveStatus = EControllerStatus.None;
                return;
            }
            else if (responseModel.Status.Equals(HttpStatusCode.NotFound))
            {
                ParseCheck(() =>
                {
                    result = _parseResponseUserInfo(responseModel.Body);
                    result.Status = EUserSettingsResponseState.UserNotFound;
                    result.ControllerStatus = EControllerStatus.Error;
                });
            }
            else
            {
                ParseCheck(() =>
                {
                    result = _parseResponseUserInfo(responseModel.Body);
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