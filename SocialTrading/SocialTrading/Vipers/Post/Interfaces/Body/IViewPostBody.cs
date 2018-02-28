using SocialTrading.Tools.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.TextView;

namespace SocialTrading.Vipers.Post.Interfaces.Body
{
    public interface IViewPostBody : ISetConfig
    {
        IPresenterPostBody Presenter { set; }

        void SetImage(string image);

        void SetContent(string content, string readMore, ITextViewTheme mainTheme, ITextViewTheme attrTheme, int position);
        void SetContent(string content, ITextViewTheme theme);

        void CacheImage(string cachedImage);
    }
}
