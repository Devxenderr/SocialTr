using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.Tools.Interfaces;

namespace SocialTrading.Vipers.Post.Interfaces.Social
{
    public interface IViewPostSocial : ISetConfig
    {
        IPresenterPostSocial Presenter { set; }
        
        void ShowAlert(string title, string message);
        
        void SetLikeText(string like);
        void SetCommentText(string comment);
        void SetShareText(string share);

        void SetLikeDrawable(IButtonTheme theme);

        void SetLikeTheme(IButtonTheme theme);
        void SetCommentTheme(IButtonTheme theme);
        void SetShareTheme(IButtonTheme theme);

        void SetInteractionAvailable();
        void SetInteractionUnavailable();
    }
}
