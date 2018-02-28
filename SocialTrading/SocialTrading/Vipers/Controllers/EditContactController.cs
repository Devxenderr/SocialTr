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
    public class EditContactController : IEditContactController
    {
        public IContactCreator ContactCreator { get; set; }

        public event Action<IModel> OnRecieveModel;

        private readonly IRepositoryEditContact _repository;
        private readonly Func<string, DataModelUserInfo> _parseResponseUserInfo;
        private EControllerStatus _currentRecieveStatus = EControllerStatus.None;


        public EditContactController(IContactCreator contactCreator, IRepositoryEditContact repository, Func<string, DataModelUserInfo> parseResponseUserInfo)
        {
            ContactCreator = contactCreator ?? throw new ArgumentNullException(nameof(contactCreator));

            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
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
            else if (responseModel.Status.Equals(HttpStatusCode.BadGateway))
            {
                _currentRecieveStatus = EControllerStatus.None;
                OnRecieveModel?.Invoke(new DataModelMock
                {
                    ControllerStatus = EControllerStatus.NoConnection
                });
                return;
            }
            else if (responseModel.Status.Equals(HttpStatusCode.Unauthorized))
            {
                ParseCheck(() =>
                {
                    result = _parseResponseUserInfo(responseModel.Body);
                    result.Status = EUserSettingsResponseState.Unauthorized;
                    result.ControllerStatus = EControllerStatus.Error;
                });
            }
            else if (responseModel.Status.Equals((HttpStatusCode)422))
            {
                ParseCheck(() =>
                {
                    result = _parseResponseUserInfo(responseModel.Body);
                    result.Status = EUserSettingsResponseState.UnprocessableEntity;
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