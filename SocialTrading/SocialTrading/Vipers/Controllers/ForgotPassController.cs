using System;
using System.Net;

using SocialTrading.DTO;
using SocialTrading.DTO.Response;
using SocialTrading.DTO.Response.RA;
using SocialTrading.Vipers.ForgotPass;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Tools.Exceptions.Parse;
using SocialTrading.Vipers.Controllers.Interfaces;

namespace SocialTrading.Vipers.Controllers
{
    public class ForgotPassController : IForgotPassController
    {
        public IContactCreator ContactCreator { private get; set; }
        public event Action<IModel> OnRecieveModel;
        private EControllerStatus _currentRecieveStatus = EControllerStatus.None;

        private readonly Func<string, DataRecoveryPasswordResponse> _parseResponseForgotPass;


        public ForgotPassController(IContactCreator contactCreator, Func<string, DataRecoveryPasswordResponse> parseResponseForgotPass)
        {
            ContactCreator = contactCreator;
            _parseResponseForgotPass = parseResponseForgotPass;
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
            DataRecoveryPasswordResponse result = null;

            if (responseModel.Status.Equals(HttpStatusCode.OK))
            {
                ParseCheck(() =>
                {
                    result = _parseResponseForgotPass(responseModel.Body);
                    result.Status = EForgotPassStatus.RecoverySuccess;
                    result.ControllerStatus = EControllerStatus.Ok;
                });

            }
            else if (responseModel.Status.Equals(HttpStatusCode.Unauthorized))
            {
                ParseCheck(() =>
                {
                    result = _parseResponseForgotPass(responseModel.Body);
                    result.Status = EForgotPassStatus.UserNotFound;
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
                    result = _parseResponseForgotPass(responseModel.Body);
                    result.Status = EForgotPassStatus.Error;
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
