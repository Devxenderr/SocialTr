using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialTrading.Theme.Interfaces;
using SocialTrading.Theme.Interfaces.Post;

namespace SocialTrading.Service.Interfaces.Repository
{
    public interface IRepositoryThemes
    {
        IThemeKeyStringsCreatePost CreatePostThemeKeyStrings { get; }
        IThemeKeyStringsTools ToolsThemeKeyStrings { get; }
        IThemeKeyStringsAuth AuthThemeKeyStrings { get; }
        IThemeKeyStringsReg RegThemeKeyStrings { get; }
        IThemeKeyStringsPostBody PostBodyKeyStrings { get; }
        IThemeKeyStringsPostHeader PostHeaderKeyStrings { get; }
        IThemeKeyStringsPostSocial PostSocialKeyStrings { get; }
        IThemeKeyStringsPostOther PostOtherKeyStrings { get; }

    }
}
