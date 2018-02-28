using SocialTrading.Vipers.Interfaces;

namespace SocialTrading.Vipers.Registration.Interfaces
{
    public interface IViewRegPhone : ISetConfig
    {
        IPresenterRegPhone Presenter { set; }

        void SetPhoneStateSuccess();
        void SetPhoneStateFail();

        void SetPhone(string phone);
        string GetPhone();

    }
}
