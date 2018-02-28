using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using SocialTrading.ThemesStyles.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.View;

namespace SocialTrading.ThemesStyles
{
    public class GetStylesResource
    {
        public static Dictionary<string, string> GetJsonString(string disiredInterface)
        {
            var resource = "";
            switch (disiredInterface)
            {
                case nameof(IViewTheme):
                    resource = ResourceStyles.ViewStyles;
                    break;
                case nameof(IButtonTheme):
                    resource = ResourceStyles.ButtonStyles;
                    break;
                case nameof(ITextViewTheme):
                    resource = ResourceStyles.TextViewStyles;
                    break;
                case nameof(IEditTextTheme):
                    resource = ResourceStyles.EditTextStyles;
                    break;
                case nameof(IImageViewTheme):
                    resource = ResourceStyles.ImageViewStyles;
                    break;
                case nameof(IImageButtonTheme):
                    resource = ResourceStyles.ImageButtonStyles;
                    break;
            }

            var assemb = JsonConvert.DeserializeObject<JContainer>(resource);

            var styleDict = new Dictionary<string, string>();

            if (assemb == null)
            {
                return styleDict;
            }


            var stylesArray = assemb[disiredInterface];
            foreach (var styleItem in stylesArray)
            {
                foreach (var style in styleItem)
                {
                    var styleName = ((JProperty)style).Name;
                    var theme = ((JProperty)style).Value.ToString();

                    styleDict.Add(styleName, theme);
                }
            }

            return styleDict;
        }
    }
}