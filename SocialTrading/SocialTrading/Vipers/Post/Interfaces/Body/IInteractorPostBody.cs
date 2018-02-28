using SocialTrading.DTO.Response.Post;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Service.Interfaces.Notifications;

namespace SocialTrading.Vipers.Post.Interfaces.Body
{
    public interface IInteractorPostBody/* : INotificationMessage*/
    {
        IPresenterPostBody Presenter { set; }

        bool IsPostDetailed { get; set; }
        string PostId { get; }

        IRepositoryPost GetRepository();
        void CacheImage(string base64);

        void RecieveModel(DataModelPost model);
    }
}
