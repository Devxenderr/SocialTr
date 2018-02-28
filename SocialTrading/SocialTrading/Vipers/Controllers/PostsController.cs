using System;
using System.Net;
using System.Linq;
using System.Collections.Generic;

using SocialTrading.DTO;
using SocialTrading.DTO.Response;
using SocialTrading.DTO.Response.Post;
using SocialTrading.Vipers.CreatePost;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.DTO.Request.Posts;
using SocialTrading.Tools.Exceptions.Parse;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Controllers.Interfaces;

namespace SocialTrading.Vipers.Controllers
{
    public class PostsController : IPostsController
    {
        public IContactCreator ContactCreator { private get; set; }

        public event Action<IModel> OnRecieveModel;

        private EPostsRequestType _postsRequestType;
        private readonly IRepositoryPost _repositoryPost;
        private readonly Func<string, List<DataModelPost>> _parseResponsePost;


        public PostsController(IContactCreator contactCreator, Func<string, List<DataModelPost>> parseResponsePost, IRepositoryPost repositoryPost)
        {
            ContactCreator = contactCreator;
            _parseResponsePost = parseResponsePost;
            _repositoryPost = repositoryPost;

            _repositoryPost.OnAllPostsIncome += AllPostsIncome;
        }


        public void Send(IModelSend senderModel)
        {
            var contact = ContactCreator.CreateContact(senderModel);
            contact.Reciever = this;
            contact.Sender.Send(senderModel);

            if (senderModel is PostsRequestModel model)
            {
                _postsRequestType = model.RequestType;
            }
        }

        public void SetMessage(IModelResponse responseModel)
        {
            var result = new DataModelListPosts();
            
            if (responseModel.Status.Equals(HttpStatusCode.OK))
            {
                try
                {
                    ProccessResponse(responseModel.Body);
                    result.PostIds = _repositoryPost.GetPostIds();
                }
                catch (ParseException)
                {                
                    result.Status = EPostResponseStatus.Error;
                    result.ControllerStatus = EControllerStatus.Error;
                    OnRecieveModel?.Invoke(result);
                }
            }
            else if (responseModel.Status.Equals(HttpStatusCode.BadGateway))
            {
                result.ControllerStatus = EControllerStatus.NoConnection;
                OnRecieveModel?.Invoke(result);
            }
            else if (responseModel.Status.Equals(HttpStatusCode.Unauthorized))
            {               
                result.Status = EPostResponseStatus.Unauthorized;
                result.ControllerStatus = EControllerStatus.Error;
                OnRecieveModel?.Invoke(result);
            }
            else
            {
                result.Status = EPostResponseStatus.Error;
                result.ControllerStatus = EControllerStatus.Error;
                OnRecieveModel?.Invoke(result);
            }
        }


        private void ProccessResponse(string responseModelBody)
        {
            var posts = _parseResponsePost(responseModelBody).Distinct().ToDictionary(key => key.Id, value => value);
            switch (_postsRequestType)
            {
                case EPostsRequestType.InitialRequest:
                    _repositoryPost.SetPosts(posts);
                    break;
                case EPostsRequestType.PullToRefresh:
                    _repositoryPost.SetPosts(posts);
                    break;
                case EPostsRequestType.InfiniteScroll:
                    _repositoryPost.AddPosts(posts);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AllPostsIncome(List<string> obj)
        {
            if (obj != null && obj.Count != 0)
            {
                OnRecieveModel?.Invoke(new PostIds(obj)
                {
                    ControllerStatus = EControllerStatus.Ok
                });
            }
        }


        private class PostIds : List<string>, IModel
        {
            public PostIds(IEnumerable<string> collection) : base(collection)
            {
            }

            public EControllerStatus ControllerStatus { get; set; }
        }
    }
}
