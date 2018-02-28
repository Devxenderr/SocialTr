using SocialTrading.Vipers.Entity;
using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Vipers.Registration.Phone.Interfaces
{
    public interface IInteractorRegPhone 
    {
		IPresenterRegPhone Presenter { set; }

		bool PhoneCountryInput(string phoneCountry);
        bool PhoneNumberInput(string phoneNumber);

		bool NextClick(RegistrationPhoneStrings data);

        void SaveData(RegistrationPhoneStrings data);
        RegistrationPhoneStrings LoadData();

        IRepositoryRA GetRepository();
    }
}
