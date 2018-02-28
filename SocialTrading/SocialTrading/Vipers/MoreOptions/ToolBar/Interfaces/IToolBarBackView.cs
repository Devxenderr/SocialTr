using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.View;

namespace SocialTrading.Vipers.MoreOptions.ToolBar.Interfaces
{
    public interface IToolBarBackView
    {
        IPresenterToolBarBack Presenter { set; }
        void SetTitle(string title);
        void SetBackButtonTheme(IImageButtonTheme theme);
        void SetTitleTheme(ITextViewTheme theme);
        void SetViewTheme(IViewTheme theme);
    }
}