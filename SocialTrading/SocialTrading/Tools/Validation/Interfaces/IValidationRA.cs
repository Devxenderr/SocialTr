namespace SocialTrading.Tools.Validation.Interfaces
{
    public interface IValidationRA
    {
        bool CheckEmail(string email);
        bool CheckPassword(string password);
        bool CheckName(string name);
        bool CheckNickname(string nickname);
        bool CheckPhoneCountry(string phone);
        bool CheckPhoneNumber(string phone);
    }
}