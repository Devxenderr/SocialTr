using System.Collections.Generic;

using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.TextView;

namespace SocialTrading.Vipers.Tools.Interfaces.View
{
    public  interface IViewToolsBL
    {
        void SetEnableCell(int index, IViewTheme viewTheme, ITextViewTheme labelTheme);
        void SetDataSource(List<string> listTools, IToolsStylesHolder stylesHolder);
        void Scroll(int index);
    }
}
