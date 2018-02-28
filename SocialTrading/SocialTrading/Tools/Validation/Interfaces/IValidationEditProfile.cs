namespace SocialTrading.Tools.Validation.Interfaces
{
    public interface IValidationEditProfile
    {
        bool CheckName(string name);
        bool CheckStatus(string status);
    }
}