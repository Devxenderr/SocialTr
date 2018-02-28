using System;

using SocialTrading.DTO;
using SocialTrading.Vipers.CreatePost;
using SocialTrading.DTO.Request.Posts;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Controllers.Interfaces;

namespace SocialTrading.Vipers.Controllers
{
    public class OnePostController : IOnePostController
    {
        public event Action<IModel> OnRecieveModel;
        private readonly IRepositoryPost _repositoryPost;


        public OnePostController(IRepositoryPost repositoryPost)
        {
            _repositoryPost = repositoryPost;
        }


        public void Send(IModelSend senderModel)
        {
            if (!(senderModel is CurrentPostIdRequest model))
            {
                return;
            }

            var onePost = _repositoryPost.GetOnePostById(model.CurrentPostId);
            onePost.Status = EPostResponseStatus.Success;

            OnRecieveModel?.Invoke(onePost);
        }
    }
}
