using System;

using SocialTrading.Connection;
using SocialTrading.DTO.Request.Posts;
using SocialTrading.DTO.Response.Post;
using SocialTrading.Vipers.CreatePost;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Vipers.Post.Interfaces;
using SocialTrading.Vipers.Trade.Interfaces;
using SocialTrading.Vipers.Trade.Implementation;
using SocialTrading.Vipers.Post.Interfaces.Body;
using SocialTrading.Vipers.Post.Interfaces.Chart;
using SocialTrading.Vipers.Post.Interfaces.Header;
using SocialTrading.Vipers.Post.Interfaces.Social;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Post.Implementation.Body;
using SocialTrading.Vipers.Post.Implementation.Chart;
using SocialTrading.Service.Interfaces.Notifications;
using SocialTrading.Vipers.Post.Interfaces.Statistics;
using SocialTrading.Vipers.Post.Implementation.Header;
using SocialTrading.Vipers.Post.Implementation.Social;

namespace SocialTrading.Vipers.Post.Implementation
{
    public class InteractorPost : IInteractorPost
    {
        public IInteractorTrade InteractorTrade { get; }
        public IInteractorPostBody InteractorPostBody { get; }
        public IInteractorPostChart InteractorPostChart { get; }
        public IInteractorPostHeader InteractorPostHeader { get; }
        public IInteractorPostSocial InteractorPostSocial { get; }
        public IInteractorPostStatistics InteractorPostStatistics { get; }

        private readonly IOnePostController _onePostController;
        private readonly IRepositoryPost _repository;

        private readonly string _postId;


        public InteractorPost(string postId, IOnePostController onePostsController, INotificationCenter notificationCenter, IRepositoryPost repository, IRepositoryQc repositoryQc)
        {
            _postId = postId;

            _repository = repository;

            _onePostController = onePostsController;
            _onePostController.OnRecieveModel += ControllerOnMessage;
            
            InteractorPostBody = new InteractorPostBody(_postId, notificationCenter, repository);
            InteractorPostChart = new InteractorPostChart(notificationCenter, repository);
            InteractorPostHeader = new InteractorPostHeader(_postId, new PostHeaderController(ConnectionController.GetInstance(), WebMsgParser.ParseResponseDeletePost, notificationCenter, repositoryQc, 
                repository.GetPostById(_postId).Quote), repository);
            InteractorPostSocial = new InteractorPostSocial(_postId, new PostSocialController(ConnectionController.GetInstance(), WebMsgParser.ParseResponsePostLike), notificationCenter, repository);
            //InteractorPostStatistics = new InteractorPostStatistics(notificationCenter, repository);
            InteractorTrade = new InteractorTrade(notificationCenter, repository);            
        }


        private void ControllerOnMessage(IModel postsModel)
        {
            if (!(postsModel is DataModelOnePost model))
            {
                return;
            }

            if (model.Status == EPostResponseStatus.Success)
            {
                FillPost(model);
                _onePostController.OnRecieveModel -= ControllerOnMessage;
            }
        }

        private void FillPost(DataModelOnePost postModel)
        {
            InteractorPostHeader.RecieveModel(postModel.ModelPost);
            InteractorPostBody.RecieveModel(postModel.ModelPost);
            InteractorPostSocial.RecieveModel(postModel.ModelPost);
        }


        public void DisposeRepositoryPost()
        {
            _repository.ConfigRepositoryPost();
        }

        public IRepositoryPost GetRepository()
        {
            return _repository;
        }

        public void ChangeTime(DateTime nowDateTime)
        {
            InteractorPostHeader.ChangeTime(nowDateTime);
        }

        public void Dispose()
        {
            InteractorPostHeader.Dispose();
            InteractorPostSocial.Dispose();

            _onePostController.OnRecieveModel -= ControllerOnMessage;
        }

        public void SendRequestForPosts()
        {
            _onePostController.Send(new CurrentPostIdRequest(_postId));
        }
    }
}
