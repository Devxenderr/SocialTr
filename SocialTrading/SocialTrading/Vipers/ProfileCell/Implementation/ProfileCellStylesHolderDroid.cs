using SocialTrading.ThemesStyles;
using SocialTrading.ThemesStyles.Implementation;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Vipers.ProfileCell.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;

namespace SocialTrading.Vipers.ProfileCell.Implementation
{
    public class ProfileCellStylesHolderDroid<T> : IProfileCellStylesHolder where T : AGlobalControlsTheme
    {
        private string _cellBackgroundTheme     = "MoreOptionsProfileCellStyle";
        private string _avatarImageViewTheme    = "MoreOptionsProfileCellAvatarImageStyle";
        private string _nameLabelTheme          = "MoreOptionsNameStyle";
        private string _yourProfileLabelTheme   = "MoreOptionsYourProfileStyle";

        public IViewTheme       CellBackgroundTheme     { get; }
        public IImageViewTheme  AvatarImageViewTheme    { get; }
        public ITextViewTheme   NameLabelTheme          { get; }
        public ITextViewTheme   YourProfileLabelTheme   { get; }

        public ProfileCellStylesHolderDroid(ThemeParser<T> themeParser)
        {
            CellBackgroundTheme   = themeParser.GetThemeByName<IViewTheme>(_cellBackgroundTheme);
            AvatarImageViewTheme  = themeParser.GetThemeByName<IImageViewTheme>(_avatarImageViewTheme);
            NameLabelTheme        = themeParser.GetThemeByName<ITextViewTheme>(_nameLabelTheme);
            YourProfileLabelTheme = themeParser.GetThemeByName<ITextViewTheme>(_yourProfileLabelTheme);
        }
    }
}
