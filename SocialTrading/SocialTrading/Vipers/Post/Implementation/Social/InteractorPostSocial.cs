using SocialTrading.Connection;
using SocialTrading.DTO.Request;
using SocialTrading.DTO.Response.Post;
using SocialTrading.Connection.Interfaces;
using SocialTrading.DTO.Response.Post.Interfaces;
using SocialTrading.Vipers.Post.Interfaces.Social;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Service.Interfaces.Notifications;

namespace SocialTrading.Vipers.Post.Implementation.Social
{
    public class InteractorPostSocial : IInteractorPostSocial
    {
        public IPresenterPostSocial Presenter { set; private get; }

        private readonly IRepositoryPost _repository;
        private readonly IPostSocialController _postSocialController;

        private readonly string _postId;


        public InteractorPostSocial(string postId, IPostSocialController postSocialController, INotificationCenterPostSocial notificationCenter, IRepositoryPost repository)
        {
            _postId = postId;
            _repository = repository;
            _postSocialController = postSocialController;

            _postSocialController.OnRecieveModel += ControllerOnMessage;
        }

        public void LikeClick()
        {
            _postSocialController.Send(new PostLikeRequestModel(_postId));
        }

        public int GetLikeCount()
        {
            return _repository.GetPostSocialModelById(_postId).LikeCount;
        }

        public bool GetIsLiked()
        {
            return _repository.GetPostSocialModelById(_postId).IsLiked;
        }

        public void ShareClick()
        {
            Presenter.Share(ConnectionController.RorUri.Replace("api.", "") + "/posts/" + _postId);  //HARDCODE
        }


        public void ControllerOnMessage(IModel likeModel)
        {
            if (!(likeModel is DataModelPostLike model))
            {
                Presenter.CheckLikedState(EPostSocialResponseStatus.NoConnection);
                return;
            }

            if (model.Status.Equals(EPostSocialResponseStatus.Success) && _postId.Equals(_repository.PostLike?.PostId))
            {
                _repository.GetPostSocialModelById(_postId).LikeCount = model.CountLikes;
                _repository.GetPostSocialModelById(_postId).IsLiked = model.IsLiked;
            }

            Presenter.CheckLikedState(model.Status);
        }


        public IRepositoryPost GetRepository()
        {
            return _repository;
        }

        public void RecieveModel(DataModelPost data)
        {
            if (data is IPostSocialModel model)
            {
                Presenter.SetSocial(model);
            }
        }

        public void Dispose()
        {
            _postSocialController.OnRecieveModel -= ControllerOnMessage;
        }
    }
}
