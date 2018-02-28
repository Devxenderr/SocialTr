using SocialTrading.Vipers.Entity;
using SocialTrading.DTO.Response.UserSettings;

namespace SocialTrading.Vipers.EditContact.Interfaces
{
    public interface IPresenterForInteractorEditContact
    {
        void SetData(EditContactEntity entity);
        void EditContactState(EUserSettingsResponseState status);

        void GoBack();
        void GoToCountrySelection();
        void ShowHideSpinner(bool isShow);

        void InvalidSkypeInput();
        void InvalidPhoneInput();
        void InvalidCityInput();
    }
}
