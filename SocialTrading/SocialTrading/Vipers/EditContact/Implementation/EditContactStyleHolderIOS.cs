﻿using SocialTrading.ThemesStyles;
using SocialTrading.ThemesStyles.Implementation;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Vipers.EditContact.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;

namespace SocialTrading.Vipers.EditContact.Implementation
{
    public class EditContactStyleHolderIOS<T> : IEditContactStyleHolder where T : AGlobalControlsTheme
    {
        private string _backgroundTheme         => "EditContactBackgroundStyle";
        private string _editTextNoneTheme       => "EditContactEditTextNoneStyleIOS";
        private string _uneditableTextNoneTheme => "EditContactUneditableTextNoneStyleIOS";
        private string _editTextFailTheme       => "EditContactEditTextFailStyleIOS";
        private string _textViewTheme           => "EditContactTextViewStyleIOS";
        private string _saveButtonTheme         => "EditContactSaveButtonStyle";
        private string _cancelButtonTheme       => "EditContactCancelButtonStyle";

        public IViewTheme BackgroundTheme               { get; }
        public IEditTextTheme EditTextNoneTheme         { get; }
        public IEditTextTheme UnEditableTextNoneTheme   { get; }
        public IEditTextTheme EditTextFailTheme         { get; }
        public ITextViewTheme TextViewTheme             { get; }
        public IButtonTheme SaveButtonTheme             { get; }
        public IButtonTheme CancelButtonTheme           { get; }

        public EditContactStyleHolderIOS(ThemeParser<T> themeParser)
        {
            BackgroundTheme = themeParser.GetThemeByName<IViewTheme>(_backgroundTheme);
            UnEditableTextNoneTheme = themeParser.GetThemeByName<IEditTextTheme>(_uneditableTextNoneTheme);
            EditTextNoneTheme = themeParser.GetThemeByName<IEditTextTheme>(_editTextNoneTheme);
            EditTextFailTheme = themeParser.GetThemeByName<IEditTextTheme>(_editTextFailTheme);
            TextViewTheme = themeParser.GetThemeByName<ITextViewTheme>(_textViewTheme);
            SaveButtonTheme = themeParser.GetThemeByName<IButtonTheme>(_saveButtonTheme);
            CancelButtonTheme = themeParser.GetThemeByName<IButtonTheme>(_cancelButtonTheme);
        }
    }
}
