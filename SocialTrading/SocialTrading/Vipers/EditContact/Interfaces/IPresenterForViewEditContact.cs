namespace SocialTrading.Vipers.EditContact.Interfaces
{
    public interface IPresenterForViewEditContact
    {
        void SkypeTextChanged(string text);
        void PhoneTextChanged(string text);
        void CityTextChanged(string text);

        void SaveClick(string email, string skype, string country, string city, string phone);
        void CancelClick();
        void CountryClick();

        void AlertOkClick();
    }
}
