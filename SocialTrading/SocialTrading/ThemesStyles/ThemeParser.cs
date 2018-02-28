using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using SocialTrading.ThemesStyles.Implementation;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

namespace SocialTrading.ThemesStyles
{
    public class ThemeParser<T> where T : AGlobalControlsTheme 
    {
        private Dictionary<string, object> _themesDictionary = new Dictionary<string, object>();

        private Dictionary<string, Type> types = new Dictionary<string, Type>
        {
            { nameof(IViewTheme),      typeof(IViewTheme)},
            { nameof(ITextViewTheme),  typeof(ITextViewTheme)},
            { nameof(IEditTextTheme),  typeof(IEditTextTheme)},
            { nameof(IImageViewTheme), typeof(IImageViewTheme)},
            { nameof(IButtonTheme),    typeof(IButtonTheme)},
            { nameof(IImageButtonTheme), typeof(IImageButtonTheme)},
        };

        public ThemeParser()
        {
            foreach (var typeItem in types)
            {
                var themesJsonDictionary = GetStylesResource.GetJsonString(typeItem.Key);
                
                foreach (var theme in themesJsonDictionary)
                {
                    var filledTheme = ControlspPropertyFilling(theme.Value);

                    _themesDictionary.Add(theme.Key, filledTheme);
                }
            }
        }

        private T ControlspPropertyFilling(string values)
        {
            var classInstance = JsonConvert.DeserializeObject<T>(values);
            classInstance.GetNativeComponents();
            return classInstance;
        }

        public T1 GetThemeByName<T1>(string nameTheme)
        {
            object result;
            _themesDictionary.TryGetValue(nameTheme, out result);

            return (T1)result;
        }

    }
}