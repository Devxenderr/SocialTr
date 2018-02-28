using SocialTrading.DTO.Interfaces;

namespace SocialTrading.Service.Interfaces.Repository
{
    public interface IRepositoryEditProfile
    {
        IEditProfileEntity EditProfileUserInfo { get; set; }
    }
}