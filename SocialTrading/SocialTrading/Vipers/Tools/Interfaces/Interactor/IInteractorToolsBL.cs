using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Vipers.Tools.Interfaces.Interactor
{
    public interface IInteractorToolsBL
    {
        IRepositoryNames RepoQcNames { set; }
    }
}
