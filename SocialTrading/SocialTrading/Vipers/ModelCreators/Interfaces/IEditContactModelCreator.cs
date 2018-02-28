using SocialTrading.Vipers.Entity;
using SocialTrading.DTO.Interfaces;
using SocialTrading.DTO.Request.EditContact;

namespace SocialTrading.Vipers.ModelCreators.Interfaces
{
    public interface IEditContactModelCreator
    {
        EditContactEntity GetModel();
        UserInfoDTO GetRequestModel(IEditContactEntity entity);
    }
}