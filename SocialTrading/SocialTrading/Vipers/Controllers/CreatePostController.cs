using System;
using System.Net;
using System.Collections.Generic;

using SocialTrading.DTO;
using SocialTrading.DTO.Response;
using SocialTrading.DTO.Response.Post;
using SocialTrading.Vipers.CreatePost;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Tools.Exceptions.Parse;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Service.Interfaces.Notifications;

namespace SocialTrading.Vipers.Controllers
{
    public class CreatePostController : ICreatePostController
    {
        public IContactCreator ContactCreator { get; set; }

        protected string PostQuote { get; set; }
        protected IRepositoryQcPrice RepositoryQc { get; }
        protected INotificationCenterQc NotificationCenterQc { get; }
        protected Func<string, DataModelPost> ParseResponse { get; }
        protected EControllerStatus CurrentRecieveStatus { get; set; } = EControllerStatus.None;

        public event Action<IModel> OnRecieveModel;
        public event Action<IModel> OnQcModelUpdate;

        public CreatePostController(IContactCreator connectionController, Func<string, DataModelPost> parseResponse,
            INotificationCenterQc notificationCenterQc, IRepositoryQcPrice repositoryQc)
        {
            ContactCreator = connectionController;

            RepositoryQc = repositoryQc;
            NotificationCenterQc = notificationCenterQc;
            ParseResponse = parseResponse;

            NotificationCenterQc.QcDataIncome += OnQcIncome;
        }

        public void SetQuote(string quote)
        {
            if (string.IsNullOrEmpty(quote))
            {
                return;
            }

            PostQuote = quote;

            OnQcModelUpdate?.Invoke(RepositoryQc.GetQcBidAsk(PostQuote));
        }

        public virtual void Send(IModelSend senderModel)
        {
            if (CurrentRecieveStatus == EControllerStatus.Processing)
            {
                return;
            }

            var contact = ContactCreator.CreateContact(senderModel);
            contact.Reciever = this;

            var processingModel = new DataModelMock
            {
                ControllerStatus = EControllerStatus.Processing
            };
            CurrentRecieveStatus = processingModel.ControllerStatus;
            OnRecieveModel?.Invoke(processingModel);
            contact.Sender.Send(senderModel);
        }

        public virtual void SetMessage(IModelResponse responseModel)
        {
            DataModelCreatePost result = new DataModelCreatePost();

            if (responseModel.Status.Equals(HttpStatusCode.Created))
            {
                ParseCheck(() =>
                {
                    result.ModelPost = ParseResponse(responseModel.Body);
                    result.Status = EPostResponseStatus.Success;
                    result.ControllerStatus = EControllerStatus.Ok;
                });

            }
            else if (responseModel.Status.Equals(HttpStatusCode.Unauthorized))
            {
                ParseCheck(() =>
                {
                    result.ModelPost = ParseResponse(responseModel.Body);
                    result.Status = EPostResponseStatus.Unauthorized;
                    result.ControllerStatus = EControllerStatus.Error;
                });
            }
            else if (responseModel.Status.Equals(HttpStatusCode.BadRequest))
            {
                ParseCheck(() =>
                {
                    result.ModelPost = ParseResponse(responseModel.Body);
                    result.Status = EPostResponseStatus.BadRequest;
                    result.ControllerStatus = EControllerStatus.Error;
                });
            }
            else if (responseModel.Status.Equals(HttpStatusCode.RequestEntityTooLarge))
            {
                ParseCheck(() =>
                {
                    result.Status = EPostResponseStatus.TooLargeImage;
                    result.ControllerStatus = EControllerStatus.Error;
                });
            }
            else if (responseModel.Status.Equals(HttpStatusCode.BadGateway))
            {
                CurrentRecieveStatus = EControllerStatus.None;
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
                    result.ModelPost = ParseResponse(responseModel.Body);
                    result.Status = EPostResponseStatus.Error;
                    result.ControllerStatus = EControllerStatus.Error;
                });
            }

            if (result != null)
            {
                CurrentRecieveStatus = EControllerStatus.None;
                OnRecieveModel?.Invoke(result);
            }
        }

        protected void ParseCheck(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch (ParseException)
            {
                CurrentRecieveStatus = EControllerStatus.None;
                OnRecieveModel?.Invoke(
                    new DataModelMock()
                    {
                        ControllerStatus = EControllerStatus.Error
                    }
                );
            }
        }

        protected void OnQcIncome(HashSet<string> qcNames)
        {
            if (string.IsNullOrEmpty(PostQuote) || !qcNames.Contains(PostQuote))
            {
                return;
            }

            OnQcModelUpdate?.Invoke(RepositoryQc.GetQcBidAsk(PostQuote));
        }

        public void Dispose()
        {
            if (NotificationCenterQc != null)
            {
                NotificationCenterQc.QcDataIncome -= OnQcIncome;
            }
        }


        protected class DataModelMock : IModel
        {
            public EControllerStatus ControllerStatus { set; get; }
        }
    }
}
