using SocialTrading.Vipers.Entity;
using SocialTrading.Locale.Modules;

namespace SocialTrading.Service.Interfaces.Repository
{
    public interface IRepositoryUpdatePost
    {
        ICreatePost LangPost { get; }
        UpdatePostModel UpdatePostModel { get; set; }
    }
}
