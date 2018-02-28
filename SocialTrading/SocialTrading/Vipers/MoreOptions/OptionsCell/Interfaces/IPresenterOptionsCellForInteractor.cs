using SocialTrading.Tools.Enumerations;

namespace SocialTrading.Vipers.MoreOptions.OptionsCell.Interfaces
{
    public interface IPresenterOptionsCellForInteractor
    {
        void SetImage(string imageName);
        void SetText(string localeString);
        void GoTo(EItemsOptions option);
    }
}