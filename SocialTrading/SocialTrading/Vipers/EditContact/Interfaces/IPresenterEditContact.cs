using SocialTrading.Locale.Modules;
using SocialTrading.Tools.Interfaces;

namespace SocialTrading.Vipers.EditContact.Interfaces
{
    public interface IPresenterEditContact : IPresenterForInteractorEditContact, IPresenterForViewEditContact, ISetConfig
    {
        void SetTheme(IEditContactStyleHolder styleHolder);
        void SetLocale(IEditContact locale);
        void SetSelectedCountry(string selectedKey);
    }
}
