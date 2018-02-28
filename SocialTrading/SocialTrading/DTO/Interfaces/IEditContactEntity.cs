namespace SocialTrading.DTO.Interfaces
{
    public interface IEditContactEntity : IUserInfo
    {
        string Email { get; set; }
        string Skype { get; set; }
        string Country { get; set; }
        string City { get; set; }
        string Phone { get; set; }
    }
}