using System;
using System.Net;

using SocialTrading.DTO;
using SocialTrading.Service;
using SocialTrading.DTO.Response;
using SocialTrading.DTO.Response.RA;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Authorization;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Tools.Exceptions.Parse;
using SocialTrading.Vipers.Controllers.Interfaces;

namespace SocialTrading.Vipers.Controllers
{
    public class AuthController : IAuthController
    {
        private readonly Func<string, DataModelAuth> _parseResponseAuth;
        private EControllerStatus _currentRecieveStatus = EControllerStatus.None;

        public event Action<IModel> OnRecieveModel;

        public IContactCreator ContactCreator { private get; set; }


        public AuthController(IContactCreator contactCreator, Func<string, DataModelAuth> parseResponseAuth)
        {
            ContactCreator = contactCreator;
            _parseResponseAuth = parseResponseAuth;
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
            DataModelAuth result = null;

            if (responseModel.Status.Equals(HttpStatusCode.OK))
            {
                ParseCheck(() =>
                {
                    result = _parseResponseAuth(responseModel.Body);
                    result.Status = EAuthResponseStatus.Success;
                    result.ControllerStatus = EControllerStatus.Ok;
                    DataService.RepositoryController.RepositoryRA.ModelAuth = result;
                }); 
            }
            else if (responseModel.Status.Equals(HttpStatusCode.Unauthorized))
            {
                ParseCheck(() =>
                {
                    result = _parseResponseAuth(responseModel.Body);
                    result.Status = EAuthResponseStatus.Unauthorized;
                    result.ControllerStatus = EControllerStatus.Error;
                });                
            }
            else if (responseModel.Status.Equals(HttpStatusCode.RequestTimeout))
            {
                ParseCheck(() =>
                {
                    result = _parseResponseAuth(responseModel.Body);
                    result.Status = EAuthResponseStatus.Error;
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
            else if (responseModel.Status.Equals((HttpStatusCode)422))
            {
                result = _parseResponseAuth(responseModel.Body);
                result.Status = EAuthResponseStatus.UnprocessableEntity;
                result.ControllerStatus = EControllerStatus.Error;
            }
            else
            {
                ParseCheck(() =>
                {
                    result = _parseResponseAuth(responseModel.Body);
                    result.Status = EAuthResponseStatus.Error;
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
                   new DataModelMock()
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
