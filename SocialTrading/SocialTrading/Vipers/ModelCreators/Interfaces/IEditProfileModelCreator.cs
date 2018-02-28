using SocialTrading.DTO.Interfaces;
using SocialTrading.DTO.Request.EditContact;

namespace SocialTrading.Vipers.ModelCreators.Interfaces
{
    public interface IEditProfileModelCreator
    {
        IEditProfileEntity GetModel();
        UserInfoDTO GetRequestModel(IEditProfileEntity entity);
    }
}