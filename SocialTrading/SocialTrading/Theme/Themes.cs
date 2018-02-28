using SocialTrading.Tools;
using SocialTrading.Theme.ThemeItems;

namespace SocialTrading.Theme
{
    public static class Themes
    {
        public static ThemeModel GetAuthTheme()
        {
            ThemeModel themeModel = new ThemeModel();

            GetAuthThemeColors(themeModel);
            GetAuthThemeFonts(themeModel);
            GetAuthThemeImages(themeModel);
            GetAuthThemeFontSizes(themeModel);
            GetAuthThemeFontStyles(themeModel);

            return themeModel;
        }

        public static ThemeModel GetRegTheme()
        {
            ThemeModel themeModel = new ThemeModel();

            GetRegThemeColors(themeModel);
            GetRegThemeFonts(themeModel);
            GetRegThemeImages(themeModel);
            GetRegThemeFontSizes(themeModel);
            GetRegThemeFontStyles(themeModel);

            return themeModel;
        }

        public static ThemeModel GetCreatePostTheme()
        {
            ThemeModel themeModel = new ThemeModel();

            GetCreatePostThemeColors(themeModel);
            GetCreatePostThemeFonts(themeModel);
            GetCreatePostThemeImages(themeModel);
            GetCreatePostThemeFontSizes(themeModel);
            GetCreatePostThemeFontStyles(themeModel);

            return themeModel;
        }

        public static ThemeModel GetPostTheme()
        {
            ThemeModel themeModel = new ThemeModel();

            GetPostThemeColors(themeModel);
            GetPostThemeFonts(themeModel);
            GetPostThemeImages(themeModel);
            GetPostThemeFontSizes(themeModel);
            GetPostThemeFontStyles(themeModel);

            return themeModel;
        }

        public static ThemeModel GetToolsTheme()
        {
            ThemeModel themeModel = new ThemeModel();

            GetToolsThemeColors(themeModel);
            GetToolsThemeFonts(themeModel);
            GetToolsThemeImages(themeModel);
            GetToolsThemeFontSizes(themeModel);
            GetToolsThemeFontStyles(themeModel);

            return themeModel;
        }

        #region AuthTheme

        private static void GetAuthThemeColors(ThemeModel themeModel)
        {
            themeModel.Colors.Add(DAL.ThemeKeyStrings.AuthBackground,          ThemeColors.Transparent);

            themeModel.Colors.Add(DAL.ThemeKeyStrings.AuthButtonBackground,    ThemeColors.RoyalBlue);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.AuthButtonText,          ThemeColors.White);

            themeModel.Colors.Add(DAL.ThemeKeyStrings.AuthSloganText,          ThemeColors.White);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.AuthSloganBackground,    ThemeColors.Transparent);

            themeModel.Colors.Add(DAL.ThemeKeyStrings.AuthLabelText,           ThemeColors.White);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.AuthLabelBackground,     ThemeColors.Transparent);
								  
            themeModel.Colors.Add(DAL.ThemeKeyStrings.AuthTitleText,           ThemeColors.White);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.AuthTitleBackground,     ThemeColors.Transparent);
								  
            themeModel.Colors.Add(DAL.ThemeKeyStrings.AuthLinkText,            ThemeColors.White);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.AuthLinkBackground,      ThemeColors.Transparent);
								   
            themeModel.Colors.Add(DAL.ThemeKeyStrings.AuthEditTextHint,        ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.AuthEditTextTextNone,    ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.AuthEditTextTextSuccess, ThemeColors.RoyalBlue);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.AuthEditTextTextFail,    ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.AuthEditTextBackground,  ThemeColors.White);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.AuthEditTextBorderNone,  ThemeColors.White);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.AuthEditTextBorderFail,  ThemeColors.Red);

            themeModel.Colors.Add(DAL.ThemeKeyStrings.AuthSocialNetworkTint,   ThemeColors.White);
        }

        private static void GetAuthThemeFonts(ThemeModel themeModel)
        {
            themeModel.Font = ThemeFonts.Default;
        }

        private static void GetAuthThemeImages(ThemeModel themeModel)
        {
            themeModel.Images.Add(DAL.ThemeKeyStrings.AuthBackground,          ThemeImages.BackgroundRA);
            themeModel.Images.Add(DAL.ThemeKeyStrings.AuthLogo,                ThemeImages.LogoInvestArena);
            themeModel.Images.Add(DAL.ThemeKeyStrings.AuthFbLogin,             ThemeImages.FacebookLogin);
            themeModel.Images.Add(DAL.ThemeKeyStrings.AuthVkLogin,             ThemeImages.VkontakteLogin);
            themeModel.Images.Add(DAL.ThemeKeyStrings.AuthOkLogin,             ThemeImages.OdnoklassnikiLogin);
            themeModel.Images.Add(DAL.ThemeKeyStrings.AuthGoogleLogin,         ThemeImages.GoogleLogin);
            themeModel.Images.Add(DAL.ThemeKeyStrings.AuthEnterTextSuccess,    ThemeImages.EnterTextSuccess);
            themeModel.Images.Add(DAL.ThemeKeyStrings.AuthEnterTextFail,       ThemeImages.EnterTextFail);
            themeModel.Images.Add(DAL.ThemeKeyStrings.AuthBackButton,          ThemeImages.ArrowBackWhite);
        }

        private static void GetAuthThemeFontSizes(ThemeModel themeModel)
        {
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.AuthSlogan,            ThemeFontSize.Font16);
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.AuthLabelHint,         ThemeFontSize.Font10);
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.AuthLabel,             ThemeFontSize.Font14);
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.AuthLink,              ThemeFontSize.Font14);
        }

        private static void GetAuthThemeFontStyles(ThemeModel themeModel)
        {
            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.AuthLink,            ThemeFontStyle.Underline);
			themeModel.FontStyles.Add(DAL.ThemeKeyStrings.AuthText,            ThemeFontStyle.Normal);
        }

        #endregion

        #region RegTheme

        private static void GetRegThemeColors(ThemeModel themeModel)
        {
            themeModel.Colors.Add(DAL.ThemeKeyStrings.RegTitleText,            ThemeColors.White);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.RegTitleBackground,      ThemeColors.Transparent);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.RegBackground,           ThemeColors.Transparent);
            
            themeModel.Colors.Add(DAL.ThemeKeyStrings.RegLabelText,            ThemeColors.White);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.RegLabelBackground,      ThemeColors.Transparent);
   
            themeModel.Colors.Add(DAL.ThemeKeyStrings.RegEditTextHint,         ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.RegEditTextTextNone,     ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.RegEditTextTextSuccess,  ThemeColors.RoyalBlue);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.RegEditTextTextFail,     ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.RegEditTextBackground,   ThemeColors.White);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.RegEditTextBorderNone,   ThemeColors.White);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.RegEditTextBorderFail,   ThemeColors.Red);

            themeModel.Colors.Add(DAL.ThemeKeyStrings.RegButtonBackground,     ThemeColors.RoyalBlue);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.RegButtonText,           ThemeColors.White);

            themeModel.Colors.Add(DAL.ThemeKeyStrings.RegLinkTextBackground,   ThemeColors.RoyalBlue);
			themeModel.Colors.Add(DAL.ThemeKeyStrings.RegLinkBackground,       ThemeColors.Transparent);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.RegFeatureTextColor,     ThemeColors.White);
        }

        private static void GetRegThemeFonts(ThemeModel themeModel)
        {
            themeModel.Font = ThemeFonts.Default;
        }

        private static void GetRegThemeImages(ThemeModel themeModel)
        {
            themeModel.Images.Add(DAL.ThemeKeyStrings.RegBackground,           ThemeImages.BackgroundRA);
            themeModel.Images.Add(DAL.ThemeKeyStrings.RegLogo,                 ThemeImages.LogoInvestArena);
            themeModel.Images.Add(DAL.ThemeKeyStrings.RegBackButton,           ThemeImages.ArrowBackWhite);
            themeModel.Images.Add(DAL.ThemeKeyStrings.RegEnterTextSuccess,     ThemeImages.EnterTextSuccess);
            themeModel.Images.Add(DAL.ThemeKeyStrings.RegEnterTextFail,        ThemeImages.EnterTextFail);

            themeModel.Images.Add(DAL.ThemeKeyStrings.RegNameFeatureImage,      ThemeImages.NameFeatureImage);
            themeModel.Images.Add(DAL.ThemeKeyStrings.RegPassFeatureImage,      ThemeImages.PassFeatureImage);
            themeModel.Images.Add(DAL.ThemeKeyStrings.RegPhoneFeatureImage,     ThemeImages.PhoneFeatureImage);
            themeModel.Images.Add(DAL.ThemeKeyStrings.RegEmailFeatureImage,     ThemeImages.EmailFeatureImage);
        }

        private static void GetRegThemeFontSizes(ThemeModel themeModel)
        {
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.RegTitle,              ThemeFontSize.Font16);
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.RegLabelHint,          ThemeFontSize.Font12);
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.RegLabel,              ThemeFontSize.Font12);
			themeModel.FontSizes.Add(DAL.ThemeKeyStrings.RegLink,               ThemeFontSize.Font8);
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.RegFeatureTextSize,    ThemeFontSize.Font14);
        }

        private static void GetRegThemeFontStyles(ThemeModel themeModel)
        {
            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.RegLink,             ThemeFontStyle.Underline);
            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.RegText,             ThemeFontStyle.Normal);
        }

        #endregion

        #region CreatePostTheme

        private static void GetCreatePostThemeColors(ThemeModel themeModel)
        {
            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostTitleText,                 ThemeColors.White);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostPublishText,               ThemeColors.RoyalBlue);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostPublishBackground,         ThemeColors.Transparent);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostToolBarBackground,         ThemeColors.MidnightExpress);

            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostFirstLastNameText,         ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostFirstLastNameBackground,   ThemeColors.Transparent);

            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostAttachesBackground,        ThemeColors.Transparent);

            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostToolsBackground,           ThemeColors.RoyalBlue);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostToolsBackgroundFail,       ThemeColors.Red);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostToolsText,                 ThemeColors.White);

            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostPriceText,                 ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostPriceBackground,           ThemeColors.WhiteSmoke);

            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostFieldsText,                ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostFieldsBackground,          ThemeColors.WhiteSmoke);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostFieldsBackgroundFail,      ThemeColors.MistyRose);

            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostCommentHint,               ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostCommentText,               ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostCommentBackground,         ThemeColors.White);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostCommentBackgroundFail,     ThemeColors.MistyRose);
            
            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostDividingLine,              ThemeColors.Nobel);

			themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostImagesTint,                ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostImagesWhiteTint,           ThemeColors.White);
			themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostImagesBlackTint,           ThemeColors.Black);

            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostForecastTimeNotChoosen,    ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.CreatePostForecastTimeChoosen,       ThemeColors.RoyalBlue);
        }

        private static void GetCreatePostThemeFonts(ThemeModel themeModel)
        {
            themeModel.Font = ThemeFonts.Default;
        }

        private static void GetCreatePostThemeImages(ThemeModel themeModel)
        {
            themeModel.Images.Add(DAL.ThemeKeyStrings.CreatePostBackButton,               ThemeImages.ArrowBackWhite);
            themeModel.Images.Add(DAL.ThemeKeyStrings.CreatePostAttachedImage,            ThemeImages.AttachImageCreatePost);
            themeModel.Images.Add(DAL.ThemeKeyStrings.CreatePostArrowDownBlack,           ThemeImages.ArrowDownBlackCreatePost);
            themeModel.Images.Add(DAL.ThemeKeyStrings.CreatePostArrowDownWhite,           ThemeImages.ArrowDownWhiteCreatePost);
            themeModel.Images.Add(DAL.ThemeKeyStrings.CreatePostCancelAttach,             ThemeImages.CancelAttach);
            themeModel.Images.Add(DAL.ThemeKeyStrings.CreatePostDefaultAvatarImage,       ThemeImages.PostAvatar);
        }

        private static void GetCreatePostThemeFontSizes(ThemeModel themeModel)
        {
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.CreatePostFieldsText,              ThemeFontSize.Font16);
        }

        private static void GetCreatePostThemeFontStyles(ThemeModel themeModel)
        {
            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.CreatePostFirstLastNameText,     ThemeFontStyle.Bold);
            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.CreatePostFieldsText,            ThemeFontStyle.Normal);
        }

        #endregion

        #region PostTheme

        private static void GetPostThemeColors(ThemeModel themeModel)
        {
            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostHeaderBuySellTextColor,       ThemeColors.White);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostHeaderCurrentPriceTextColor,  ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostHeaderDateTextColor,          ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostHeaderDiffTextColor,          ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostHeaderDiffValueTextColorPositive,     ThemeColors.Green);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostHeaderDiffValueTextColorNegative,     ThemeColors.Red);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostHeaderFirstLastNameTextColor, ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostHeaderForecastTextColor,      ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostHeaderQuoteTextColor,         ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostHeaderPostTextBackground,     ThemeColors.Transparent);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostHeaderBuyBackground,          ThemeColors.GreenBuy);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostHeaderSellBackground,         ThemeColors.RedSell);

            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostSocialLikeBackgroundColor,    ThemeColors.Transparent);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostSocialLikeTextColor,          ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostSocialCommentBackgroundColor, ThemeColors.Transparent);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostSocialCommentTextColor,       ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostSocialShareBackgroundColor,   ThemeColors.Transparent);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostSocialShareTextColor,         ThemeColors.Black);

            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostBodyContentBackgroundColor,   ThemeColors.Transparent);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostBodyContentTextColor,         ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostBodyReadMoreTextColor,        ThemeColors.RoyalBlue);

            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostToolBarBackground,            ThemeColors.MidnightExpress);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.PostToolBarTitleColor,            ThemeColors.White);
        }

        private static void GetPostThemeFonts(ThemeModel themeModel)
        {
            themeModel.Font = ThemeFonts.Default;
        }

        private static void GetPostThemeImages(ThemeModel themeModel)
        {
            themeModel.Images.Add(DAL.ThemeKeyStrings.PostHeaderBuySellImageGreen,         ThemeImages.PostBuyArrow);
            themeModel.Images.Add(DAL.ThemeKeyStrings.PostHeaderBuySellImageRed,           ThemeImages.PostSellArrow);
            themeModel.Images.Add(DAL.ThemeKeyStrings.PostHeaderCurrentPriceDownImage,     ThemeImages.PostPriceDecreaseArrow);
            themeModel.Images.Add(DAL.ThemeKeyStrings.PostHeaderCurrentPriceUpImage,       ThemeImages.PostPriceIncreaseArrow);
            themeModel.Images.Add(DAL.ThemeKeyStrings.PostHeaderFavoriteButtonImageActive, ThemeImages.PostFavoriteActive);
            themeModel.Images.Add(DAL.ThemeKeyStrings.PostHeaderFavoriteButtonImageNone,   ThemeImages.PostFavoriteNone);
            themeModel.Images.Add(DAL.ThemeKeyStrings.PostHeaderMoreOptionsButtonImage,    ThemeImages.PostMoreOptions);
            themeModel.Images.Add(DAL.ThemeKeyStrings.PostHeaderUserStatusOfflineImage,    ThemeImages.PostStatusOffline);
            themeModel.Images.Add(DAL.ThemeKeyStrings.PostHeaderUserStatusOnlineImage,     ThemeImages.PostStatusOnline);
            themeModel.Images.Add(DAL.ThemeKeyStrings.PostHeaderAvatarImage,               ThemeImages.PostAvatar);

            themeModel.Images.Add(DAL.ThemeKeyStrings.PostSocialLikeDrawableLiked,         ThemeImages.LikeLikedImage);
            themeModel.Images.Add(DAL.ThemeKeyStrings.PostSocialLikeDrawableNotLiked,      ThemeImages.LikeNotLikedImage);
            themeModel.Images.Add(DAL.ThemeKeyStrings.PostSocialCommentDrawable,           ThemeImages.CommentImage);
            themeModel.Images.Add(DAL.ThemeKeyStrings.PostSocialShareDrawable,             ThemeImages.ShareImage);

            themeModel.Images.Add(DAL.ThemeKeyStrings.PostToolBarBackImage,                ThemeImages.ArrowBackWhite);           
        }

        private static void GetPostThemeFontSizes(ThemeModel themeModel)
        {
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.PostHeaderBuySellTextSize,       ThemeFontSize.Font12);
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.PostHeaderCurrentPriceTextSize,  ThemeFontSize.Font12);
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.PostHeaderDateTextSize,          ThemeFontSize.Font12);
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.PostHeaderDiffTextSize,          ThemeFontSize.Font12);
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.PostHeaderDiffValueTextSize,     ThemeFontSize.Font16);
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.PostHeaderFirstLastNameTextSize, ThemeFontSize.Font16);
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.PostHeaderForecastTextSize,      ThemeFontSize.Font16);
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.PostHeaderQuoteTextSize,         ThemeFontSize.Font16);

            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.PostBodyContentTextSize,         ThemeFontSize.Font16);

            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.PostSocialLikeTextSize,          ThemeFontSize.Font12);
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.PostSocialCommentTextSize,       ThemeFontSize.Font12);
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.PostSocialShareTextSize,         ThemeFontSize.Font12);
        }

        private static void GetPostThemeFontStyles(ThemeModel themeModel)
        {
            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.PostHeaderBuySellTextFontStyle,       ThemeFontStyle.Normal);
            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.PostHeaderCurrentPriceTextFontStyle,  ThemeFontStyle.Normal);
            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.PostHeaderDateTextFontStyle,          ThemeFontStyle.Normal);
            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.PostHeaderDiffTextFontStyle,          ThemeFontStyle.Normal);
            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.PostHeaderDiffValueTextFontStyle,     ThemeFontStyle.Normal);
            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.PostHeaderFirstLastNameTextFontStyle, ThemeFontStyle.Normal);
            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.PostHeaderForecastTextFontStyle,      ThemeFontStyle.Normal);
            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.PostHeaderQuoteTextFontStyle,         ThemeFontStyle.Normal);

            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.PostBodyContentFontStyle,             ThemeFontStyle.Normal);
            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.PostBodyReadMoreFontStyle,            ThemeFontStyle.Underline);

            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.PostSocialLikeTextFont,               ThemeFontStyle.Normal);
            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.PostSocialShareTextFont,              ThemeFontStyle.Normal);
            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.PostSocialCommentTextFont,            ThemeFontStyle.Normal);
        }

        #endregion

        #region ToolsTheme

        private static void GetToolsThemeColors(ThemeModel themeModel)
        {
            themeModel.Colors.Add(DAL.ThemeKeyStrings.ToolBarBackgoundColorKey, ThemeColors.MidnightExpress);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.SearchBacgroundColorKey,  ThemeColors.White);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.SelectedCellColorKey,     ThemeColors.RoyalBlue); //?
            themeModel.Colors.Add(DAL.ThemeKeyStrings.DividingLineColorKey,     ThemeColors.MidnightExpress);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.ToolBarTextColorKey,      ThemeColors.White);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.SearchTextColorKey,       ThemeColors.Black);
            themeModel.Colors.Add(DAL.ThemeKeyStrings.SelectedCellTextColorKey, ThemeColors.White); //?
            themeModel.Colors.Add(DAL.ThemeKeyStrings.CellTextColorKey,         ThemeColors.Black); //?
            themeModel.Colors.Add(DAL.ThemeKeyStrings.CellColorKey,             ThemeColors.White);
        }

        private static void GetToolsThemeFontStyles(ThemeModel themeModel)
        {
            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.ToolBarTextFontStyleKey,      ThemeFontStyle.Normal);
            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.SearchTextFontStyleKey,       ThemeFontStyle.Normal);
            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.SelectedCellTextFontStyleKey, ThemeFontStyle.Normal);
            themeModel.FontStyles.Add(DAL.ThemeKeyStrings.CellTextFontStyleKey,         ThemeFontStyle.Normal);
        }

        private static void GetToolsThemeFontSizes(ThemeModel themeModel)
        {
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.ToolBarTextSizeKey,      ThemeFontSize.Font14);
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.SearchTextSizeKey,       ThemeFontSize.Font14);
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.SelectedCellTextSizeKey, ThemeFontSize.Font14);
            themeModel.FontSizes.Add(DAL.ThemeKeyStrings.CellTextSizeKey,         ThemeFontSize.Font14);
        }

        private static void GetToolsThemeImages(ThemeModel themeModel)
        {
            themeModel.Images.Add(DAL.ThemeKeyStrings.ArrowBackImageKey, ThemeImages.ArrowBackWhite);
        }

        private static void GetToolsThemeFonts(ThemeModel themeModel)
        {
            themeModel.Font = ThemeFonts.Default;
        }

        #endregion
    }
}