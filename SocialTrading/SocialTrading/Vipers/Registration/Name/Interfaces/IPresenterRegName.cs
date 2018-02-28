using SocialTrading.Tools.Enumerations;
using SocialTrading.Tools.Interfaces;

namespace SocialTrading.Vipers.Registration.Name.Interfaces
{
    public interface IPresenterRegName : ISetConfig
    {
        void NameInput();
        void LastNameInput();

        void SetNameState(EState state);
        void SetLastNameState(EState state);

        void NextClick();
        void BackClick();

        void SaveData();
        void LoadData();

        void SetLocale();
    }
}
