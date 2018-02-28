using System;
using System.Net;
using System.Collections.Generic;

using SocialTrading.DTO;
using SocialTrading.DTO.Response;
using SocialTrading.DTO.Response.Post;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Tools.Exceptions.Parse;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Service.Interfaces.Notifications;
using SocialTrading.Vipers.Post.Implementation.Header;

namespace SocialTrading.Vipers.Controllers
{
    public class PostHeaderController : IPostHeaderController
    {
        public IContactCreator ContactCreator { private get; set; }

        public event Action<IModel> OnRecieveModel;
        public event Action<IModel> OnQcModelUpdate;

        private readonly string _postQuote;
        private readonly IRepositoryQc _repositoryQc;
        private readonly INotificationCenterQc _notificationCenterQc;
        private readonly Func<string, DataModelDeletePost> _parseResponseDeletePost;


        public PostHeaderController(IContactCreator connectionController, Func<string, DataModelDeletePost> parseResponseDeletePost, 
            INotificationCenterQc notificationCenterQc, IRepositoryQc repositoryQc, string quote)
        {
            ContactCreator = connectionController;

            _postQuote = quote;
            _repositoryQc = repositoryQc;
            _notificationCenterQc = notificationCenterQc;
            _parseResponseDeletePost = parseResponseDeletePost;

            _notificationCenterQc.QcDataIncome += OnQcIncome;
        }


        public void Send(IModelSend senderModel)
        {
            var contact = ContactCreator.CreateContact(senderModel);
            contact.Reciever = this;
            contact.Sender.Send(senderModel);
        }

        public void SetMessage(IModelResponse responseModel)
        {
            DataModelDeletePost result = new DataModelDeletePost();

            if (responseModel.Status.Equals(HttpStatusCode.OK))
            {
                ParseCheck(() =>
                {
                    result.Status = EPostHeaderResponseStatus.Success;
                });

            }
            else if (responseModel.Status.Equals(HttpStatusCode.Unauthorized))
            {
                ParseCheck(() =>
                {
                    result = _parseResponseDeletePost(responseModel.Body);
                    result.Status = EPostHeaderResponseStatus.Unauthorized;
                });
            }
            else
            {
                ParseCheck(() =>
                {
                    result = _parseResponseDeletePost(responseModel.Body);
                    result.Status = EPostHeaderResponseStatus.Error;
                });
            }

            if (result != null)
            {
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


        private void OnQcIncome(HashSet<string> qcNames)
        {
            if (!qcNames.Contains(_postQuote))
            {
                return;
            }

            OnQcModelUpdate?.Invoke(_repositoryQc.GetQcData(_postQuote));
        }

        public void Dispose()
        {
            if (_notificationCenterQc != null)
            {
                _notificationCenterQc.QcDataIncome -= OnQcIncome;
            }
        }

        public void GetQc()
        {
            var qc = _repositoryQc.GetQcData(_postQuote);

            if (qc != null)
            {
                OnQcModelUpdate?.Invoke(qc);
            }
        }
    }
}
