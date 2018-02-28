using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Vipers.Registration.Email.Interfaces
{
    public interface IInteractorRegEmail 
    {
        IPresenterRegEmail Presenter { set; }

        bool EmailInput(string email);

        bool NextClick(string email);

        void SaveData(string email);
        string LoadData();

        IRepositoryRA GetRepository();
    }
}
