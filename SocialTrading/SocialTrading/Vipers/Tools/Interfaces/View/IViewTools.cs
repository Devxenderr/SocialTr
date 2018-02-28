using SocialTrading.Vipers.Tools.Interfaces.Presenter;

namespace SocialTrading.Vipers.Tools.Interfaces.View
{
    public interface IViewTools : IViewToolsTheme, IViewToolsBL
    {
        IPresenterToolsForView Presenter { set; }
    }
}
