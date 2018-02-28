using System;

using System.Net;
using SocialTrading.DTO;
using SocialTrading.Service;
using SocialTrading.DTO.Response;
using SocialTrading.DTO.Response.Post;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Tools.Exceptions.Parse;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Vipers.Post.Implementation.Social;

namespace SocialTrading.Vipers.Controllers
{
    public class PostSocialController : IPostSocialController
    {
        private readonly Func<string, DataModelPostLike> _parseResponseLikePost;

        public IContactCreator ContactCreator { get; set; }

        public event Action<IModel> OnRecieveModel;

        public PostSocialController(IContactCreator connectionController, Func<string, DataModelPostLike> parseResponseLikePost)
        {
            ContactCreator = connectionController;
            _parseResponseLikePost = parseResponseLikePost;
        }

        public void Send(IModelSend senderModel)
        {
            var contact = ContactCreator.CreateContact(senderModel);
            contact.Reciever = this;
            contact.Sender.Send(senderModel);
        }
        
        public void SetMessage(IModelResponse responseModel)
        {
            DataModelPostLike result = null;

            if (responseModel.Status.Equals(HttpStatusCode.OK))
            {
                ParseCheck(() =>
                {
                    result = _parseResponseLikePost(responseModel.Body);
                    result.Status = EPostSocialResponseStatus.Success;
                    DataService.RepositoryController.RepositoryPost.PostLike = result;
                });
            }
            else if (responseModel.Status.Equals(HttpStatusCode.Unauthorized))
            {
                ParseCheck(() =>
                {
                    result = _parseResponseLikePost(responseModel.Body);
                    result.Status = EPostSocialResponseStatus.Unauthorized;
                });
            }
            else
            {
                ParseCheck(() =>
                {
                    result = _parseResponseLikePost(responseModel.Body);
                    result.Status = EPostSocialResponseStatus.Error;
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

    }
}
