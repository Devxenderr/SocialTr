namespace SocialTrading.Tools.Validation.Interfaces
{
    public interface IValidationEditContact
    {
        bool CheckSkype(string skype);
        bool CheckCity(string city);
        bool CheckPhone(string phone);
    }
}