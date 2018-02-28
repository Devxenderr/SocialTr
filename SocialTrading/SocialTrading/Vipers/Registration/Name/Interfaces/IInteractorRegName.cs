using SocialTrading.Vipers.Entity;
using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Vipers.Registration.Name.Interfaces
{
    public interface IInteractorRegName
    {
        IPresenterRegName Presenter { set; }

        bool NameInput(string name);
        bool LastNameInput(string lastName);

        bool NextClick(RegistrationNamesStrings data);

        void SaveData(RegistrationNamesStrings data);
        RegistrationNamesStrings LoadData();

        IRepositoryRA GetRepository();
    }
}
