using SocialTrading.Locale.Modules;

namespace SocialTrading.Locale
{
    public interface ILang : IRegAuth, IDeals, IFavorites, INotification, ICreatePost, IPost, 
        IMoreOptions, IProfileCellLocale, IToolbar, IEditContact, IEditProfile
    {
    }
}
