using SocialTrading.Tools.Enumerations;
using SocialTrading.Tools.Interfaces;

namespace SocialTrading.Vipers.Registration.Phone.Interfaces
{
    public interface IPresenterRegPhone : ISetConfig
    {
		void PhoneCountryInput();
		void PhoneNumberInput();

        void SetPhoneCountryState(EState state);
        void SetPhoneNumberState(EState state);

		void NextClick();
        void SkipClick();
        void BackClick();

		void SaveData();
		void LoadData();

        void SetLocale();
    }
}
