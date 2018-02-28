using System;

using SocialTrading.Tools;
using SocialTrading.Theme;
using SocialTrading.Theme.Interfaces;
using SocialTrading.Theme.Interfaces.Post;
using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Service.Repositories
{
    public class RepositoryThemes : IRepositoryThemes
    {
        private readonly Lazy<ThemeKeyStrings> _themeKeyStrings;

        public RepositoryThemes()
        {
              _themeKeyStrings = new Lazy<ThemeKeyStrings>(() => DAL.ThemeKeyStrings);
        }

        public IThemeKeyStringsCreatePost CreatePostThemeKeyStrings => _themeKeyStrings.Value;
        public IThemeKeyStringsTools ToolsThemeKeyStrings => _themeKeyStrings.Value;
        public IThemeKeyStringsAuth AuthThemeKeyStrings => _themeKeyStrings.Value;
        public IThemeKeyStringsReg RegThemeKeyStrings => _themeKeyStrings.Value;
        public IThemeKeyStringsPostBody PostBodyKeyStrings => _themeKeyStrings.Value;
        public IThemeKeyStringsPostHeader PostHeaderKeyStrings => _themeKeyStrings.Value;
        public IThemeKeyStringsPostSocial PostSocialKeyStrings => _themeKeyStrings.Value;
        public IThemeKeyStringsPostOther PostOtherKeyStrings => _themeKeyStrings.Value;
    }
}
