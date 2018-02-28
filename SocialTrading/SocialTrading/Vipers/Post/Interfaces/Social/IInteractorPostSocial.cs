using System;

using SocialTrading.DTO.Response.Post;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Vipers.Post.Interfaces.Social
{
    public interface IInteractorPostSocial : IConnectionMessage, IDisposable
    {
        IPresenterPostSocial Presenter { set; }

        void LikeClick();
        void ShareClick();

        int GetLikeCount();
        bool GetIsLiked();
        
        IRepositoryPost GetRepository();

        void RecieveModel(DataModelPost data);
    }
}
