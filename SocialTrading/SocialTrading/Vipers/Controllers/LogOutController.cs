using System;
using System.Net;
using SocialTrading.Connection.Interfaces;
using SocialTrading.DTO;
using SocialTrading.DTO.Response;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Controllers.Interfaces;

namespace SocialTrading.Vipers.Controllers
{
    public class LogOutController : ILogOutController
    {
        public IContactCreator ContactCreator { private get; set; }

        private readonly IRepositoryController _repoController;
        private EControllerStatus _currentRecieveStatus;

        public event Action<IModel> OnRecieveModel;

        public LogOutController(IContactCreator contactCreator, IRepositoryController repoController)
        {
            ContactCreator = contactCreator;
            _repoController = repoController;
        }

        public void Send(IModelSend senderModel)
        {
            var contact = ContactCreator.CreateContact(senderModel);
            contact.Reciever = this;

            if (_currentRecieveStatus != EControllerStatus.Processing)
            {
                var processingModel = new Response
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
            if (responseModel.Status.Equals(HttpStatusCode.OK))
            {
                _repoController.Init();
                (ContactCreator as ISocketConnector)?.DisconnectSockets();
                OnRecieveModel?.Invoke(new Response { ControllerStatus = EControllerStatus.Ok });
            }
            else if (responseModel.Status.Equals(HttpStatusCode.NotFound))
            {
                OnRecieveModel?.Invoke(new Response { ControllerStatus = EControllerStatus.Error });
            }
            else if (responseModel.Status.Equals(HttpStatusCode.ExpectationFailed))
            {
                OnRecieveModel?.Invoke(new Response { ControllerStatus = EControllerStatus.NoConnection });
            }
            else
            {
                OnRecieveModel?.Invoke(new Response { ControllerStatus = EControllerStatus.Error });
            }
            _currentRecieveStatus = EControllerStatus.None;
        }

        private class Response : IModel
        {
            public EControllerStatus ControllerStatus { get; set; }
        }
    }
}
