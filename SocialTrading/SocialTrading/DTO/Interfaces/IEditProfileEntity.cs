namespace SocialTrading.DTO.Interfaces
{
    public interface IEditProfileEntity : IUserInfo
    {
        string FirstName { get; }
        string LastName { get; }
        string UserStatus { get; }
    }
}