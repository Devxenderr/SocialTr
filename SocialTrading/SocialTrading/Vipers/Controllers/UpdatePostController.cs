using System;
using System.Net;

using SocialTrading.DTO;
using SocialTrading.DTO.Response;
using SocialTrading.Vipers.CreatePost;
using SocialTrading.DTO.Response.Post;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Service.Interfaces.Notifications;
using SocialTrading.Vipers.Controllers.Interfaces;

namespace SocialTrading.Vipers.Controllers
{
    public class UpdatePostController : CreatePostController, IUpdatePostController
    {
        private readonly IRepositoryPost _repositoryPost;

        public UpdatePostController(IContactCreator connectionController, Func<string, DataModelPost> parseResponseFunc, INotificationCenterQc notificationCenterQc, 
            IRepositoryQcPrice repositoryQc, IRepositoryPost repositoryPost) : base(connectionController, parseResponseFunc, notificationCenterQc, repositoryQc)
        {
            _repositoryPost = repositoryPost;
        }

        public new event Action<IModel> OnRecieveModel;

        public override void Send(IModelSend senderModel)
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

        public override void SetMessage(IModelResponse responseModel)
        {
            DataModelUpdatePost result = new DataModelUpdatePost();

            if (responseModel.Status.Equals(HttpStatusCode.OK))
            {
                ParseCheck(() =>
                {
                    result.ModelPost = ParseResponse(responseModel.Body);
                    result.Status = EPostResponseStatus.Success;
                    result.ControllerStatus = EControllerStatus.Ok;
                    _repositoryPost.UpdatePost(result.ModelPost);
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

            CurrentRecieveStatus = EControllerStatus.None;
            OnRecieveModel?.Invoke(result);
        }

    }
}
