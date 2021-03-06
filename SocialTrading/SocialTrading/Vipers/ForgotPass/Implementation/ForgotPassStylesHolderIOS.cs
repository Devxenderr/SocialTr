﻿using System;
using SocialTrading.ThemesStyles;
using SocialTrading.ThemesStyles.Implementation;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Vipers.ForgotPass.Interfaces;

namespace SocialTrading.Vipers.ForgotPass.Implementation
{
    public class ForgotPassStylesHolderIOS<T> : IForgotPassStylesHolder where T : AGlobalControlsTheme
    {
        private string _emailEditTextTheme = "AuthEditTextStyle";
        
        private string _viewTheme = "AuthViewBackgroundStyleIOS";
        
        private string _recoveryButtonTheme = "AuthButtonStyleIOS";
        
        private string _headerLabelTheme = "AuthHeaderStyle";
        
        private string _logoImageViewTheme  = "AuthLogoImageViewStyle";
        
        private string _backButtonTheme = "AuthBackButtonStyle";
        
        private string _emailLabelTheme = "AuthLabelStyleIOS";
        
        private string _emailStateSuccess = "AuthEditTextSuccessStyleIOS";
        
        private string _emailStateFail = "AuthEditTextFailStyleIOS";


        public IEditTextTheme EmailEditTextTheme { get; }

        public IImageViewTheme ViewTheme { get; }

        public IButtonTheme RecoveryButtonTheme { get; }

        public ITextViewTheme HeaderLabelTheme { get; }

        public IImageViewTheme LogoImageViewTheme { get; }

        public IImageButtonTheme BackButtonTheme { get; }

        public ITextViewTheme EmailLabelTheme { get; }

        public IEditTextTheme EmailStateSuccess { get; }

        public IEditTextTheme EmailStateFail { get; }

        public ForgotPassStylesHolderIOS(ThemeParser<T> themeParser)
        {
            EmailEditTextTheme = themeParser.GetThemeByName<IEditTextTheme>(_emailEditTextTheme);
            ViewTheme = themeParser.GetThemeByName<IImageViewTheme>(_viewTheme);
            RecoveryButtonTheme = themeParser.GetThemeByName<IButtonTheme>(_recoveryButtonTheme);
            HeaderLabelTheme = themeParser.GetThemeByName<ITextViewTheme>(_headerLabelTheme);
            LogoImageViewTheme = themeParser.GetThemeByName<IImageViewTheme>(_logoImageViewTheme);
            BackButtonTheme = themeParser.GetThemeByName<IImageButtonTheme>(_backButtonTheme);
            EmailLabelTheme = themeParser.GetThemeByName<ITextViewTheme>(_emailLabelTheme);
            EmailStateSuccess = themeParser.GetThemeByName<IEditTextTheme>(_emailStateSuccess);
            EmailStateFail = themeParser.GetThemeByName<IEditTextTheme>(_emailStateFail);
        }
    }
}
