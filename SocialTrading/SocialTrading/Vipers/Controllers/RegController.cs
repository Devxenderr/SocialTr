using System;
using System.Net;

using SocialTrading.DTO;
using SocialTrading.DTO.Response;
using SocialTrading.DTO.Response.RA;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Tools.Exceptions.Parse;
using SocialTrading.Vipers.Registration.Password;
using SocialTrading.Vipers.Controllers.Interfaces;

namespace SocialTrading.Vipers.Controllers
{
    public class RegController : IRegController
    {
        public IContactCreator ContactCreator { get; set; }

        public event Action<IModel> OnRecieveModel;

        private readonly Func<string, DataModelReg> _parseResponseReg;
        private EControllerStatus _currentRecieveStatus = EControllerStatus.None;

        public RegController(IContactCreator contactCreator)
        {
            ContactCreator = contactCreator;
        }

        public RegController(IContactCreator connectionController, Func<string, DataModelReg> parseResponseReg)
        {
            ContactCreator = connectionController;
            _parseResponseReg = parseResponseReg;
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
            DataModelReg result = null;

            if (responseModel.Status.Equals(HttpStatusCode.OK))
            {
                ParseCheck(() =>
                {
                    result = _parseResponseReg(responseModel.Body);
                    result.Status = ERegResponseStatus.Success;
                    result.ControllerStatus = EControllerStatus.Ok;
                });

            }
            else if (responseModel.Status.Equals(HttpStatusCode.RequestTimeout))
            {
                ParseCheck(() =>
                {
                    result = _parseResponseReg(responseModel.Body);
                    result.Status = ERegResponseStatus.Error;
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
                    result = _parseResponseReg(responseModel.Body);
                    result.Status = ERegResponseStatus.Error;
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
