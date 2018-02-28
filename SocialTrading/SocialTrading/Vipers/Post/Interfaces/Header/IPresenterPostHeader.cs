using SocialTrading.Tools.Interfaces;
using SocialTrading.DTO.Response.Post.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Post.Implementation.Header;
using SocialTrading.DTO.Response.Post.ConstituentParts;

namespace SocialTrading.Vipers.Post.Interfaces.Header
{
    public interface IPresenterPostHeader : ISetConfig
    {
        void SetHeader(IPostHeaderModel model, int position);
        void SetUserHeader(IPostHeaderModel model);

        void SetBrokerFields(PostHeaderBrokerModel model, int position);
        void UpdateTime(string time);
        void UpdateCreatedTime(string createdTime);
        void SetQuoteFavoriteState(bool isCheck);
        void SetLocale();

        IRepositoryPost GetRepository();

        void ProfileClick();
        void FavoriteClick(bool isFavorite);
		void OptionsClick();
		void DeleteClick();
		void EditClick();
        void ConfirmDeleteClick();

        double GetPreviousPrice();
        void SetOptionsButtonVisibility(bool isMyPost);
        void SaveCachedImage(string encodedImage);

        void CheckResponseState(EPostHeaderResponseStatus state);
    }
}
