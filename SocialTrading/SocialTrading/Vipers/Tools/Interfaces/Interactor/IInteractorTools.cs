using SocialTrading.Vipers.Tools.Interfaces.Presenter;

namespace SocialTrading.Vipers.Tools.Interfaces.Interactor
{
    public interface IInteractorTools : IInteractorToolForPresenter, IInteractorToolsBL
    {
        IPresenterToolsForInteractor Presenter { set; }
    }
}
