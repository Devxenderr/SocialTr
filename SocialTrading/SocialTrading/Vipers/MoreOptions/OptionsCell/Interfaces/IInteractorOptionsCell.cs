using SocialTrading.Tools.Interfaces;

namespace SocialTrading.Vipers.MoreOptions.OptionsCell.Interfaces
{
    public interface IInteractorOptionsCell : ISetConfig
    {
        IPresenterOptionsCellForInteractor Presenter { set; }

        void CellClick();
    }
}
