using SocialTrading.Theme.ThemeStrings;
using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Theme
{
    public static class ThemeHolder
    {
        public static AuthThemeStrings AuthThemeStrings { get; private set; }
        public static RegThemeStrings RegThemeStrings { get; private set; }
        public static CreatePostThemeStrings CreatePostThemeStrings { get; private set; }
        public static PostBodyThemeStrings PostBodyThemeStrings { get; private set; }
        public static PostHeaderThemeStrings PostHeaderThemeStrings { get; private set; }
        public static PostSocialThemeStrings PostSocialThemeStrings { get; private set; }
        public static PostStatisticsThemeStrings PostStatisticsThemeStrings { get; private set; }
        public static PostOtherThemeStrings PostOtherThemeStrings { get; private set; }
        public static ToolsThemeStrings ToolsThemeStrings { get; private set; }
        

        private static bool _isInitialized;

        public static void Init(IRepositoryThemes repositoryThemes)
        {
            if (!_isInitialized)
            {
                _isInitialized = true;

                var repository = repositoryThemes;

                #region AuthThemeStringsRegion

                AuthThemeStrings = new AuthThemeStrings
                {
                    HeaderLabelFont = repository.AuthThemeKeyStrings.AuthText,
                    HeaderLabelColor = repository.AuthThemeKeyStrings.AuthSloganText,
                    HeaderLabelSize = repository.AuthThemeKeyStrings.AuthSlogan,
                    EmailLabelFont = repository.AuthThemeKeyStrings.AuthText,
                    EmailLabelColor = repository.AuthThemeKeyStrings.AuthLabelText,
                    EmailLabelSize = repository.AuthThemeKeyStrings.AuthLabelHint,
                    PasswordLabelFont = repository.AuthThemeKeyStrings.AuthText,
                    PasswordLabelColor = repository.AuthThemeKeyStrings.AuthLabelText,
                    PasswordLabelSize = repository.AuthThemeKeyStrings.AuthLabelHint,
                    NoAccountLabelFont = repository.AuthThemeKeyStrings.AuthText,
                    NoAccountLabelColor = repository.AuthThemeKeyStrings.AuthLabelText,
                    NoAccountLabelSize = repository.AuthThemeKeyStrings.AuthLabel,
                    SocialNetworksLabelFont = repository.AuthThemeKeyStrings.AuthText,
                    SocialNetworksLabelColor = repository.AuthThemeKeyStrings.AuthLabelText,
                    SocialNetworksLabelSize = repository.AuthThemeKeyStrings.AuthLabel,
                    LogInButtonColor = repository.AuthThemeKeyStrings.AuthButtonBackground,
                    LogInButtonTitleColor = repository.AuthThemeKeyStrings.AuthButtonText,
                    RegistrationButtonColor = repository.AuthThemeKeyStrings.AuthButtonBackground,
                    RegistrationButtonTitleColor = repository.AuthThemeKeyStrings.AuthButtonText,
                    ForgetPassLinkColor = repository.AuthThemeKeyStrings.AuthLinkText,
                    ForgetPassLinkSize = repository.AuthThemeKeyStrings.AuthLink,
                    ForgetPassLinkTitle = Locale.Localization.Lang.ForgetPasswordLink,
                    ForgetPassLinkFontStyle = repository.AuthThemeKeyStrings.AuthLink,
                    ViewBackgroundImage = repository.AuthThemeKeyStrings.AuthBackground,
                    FbAuthButtonImage = repository.AuthThemeKeyStrings.AuthFbLogin,
                    FbAuthButtonTint = repository.AuthThemeKeyStrings.AuthSocialNetworkTint,
                    OkAuthButtonImage = repository.AuthThemeKeyStrings.AuthOkLogin,
                    OkAuthButtonTint = repository.AuthThemeKeyStrings.AuthSocialNetworkTint,
                    VkAuthButtonImage = repository.AuthThemeKeyStrings.AuthVkLogin,
                    VkAuthButtonTint = repository.AuthThemeKeyStrings.AuthSocialNetworkTint,
                    GoogleAuthButtonImage = repository.AuthThemeKeyStrings.AuthGoogleLogin,
                    GoogleAuthButtonTint = repository.AuthThemeKeyStrings.AuthSocialNetworkTint,
                    BackImageButtonBackgroundImage = repository.AuthThemeKeyStrings.AuthBackButton,
                    LogoImage = repository.AuthThemeKeyStrings.AuthLogo,
                    EditTextBorderFailColor = repository.AuthThemeKeyStrings.AuthEditTextBorderFail,
                    EditTextBorderSuccessColor = repository.AuthThemeKeyStrings.AuthEditTextBorderNone,
                    EditTextTextFailColor = repository.AuthThemeKeyStrings.AuthEditTextTextFail,
                    EditTextTextSuccessColor = repository.AuthThemeKeyStrings.AuthEditTextTextSuccess,
                    HeaderLabelBackgroundColor = repository.AuthThemeKeyStrings.AuthSloganBackground,
                    NoAccountBackgroundColor = repository.AuthThemeKeyStrings.AuthLabelBackground,
                    SocialNetworksBackgroundColor = repository.AuthThemeKeyStrings.AuthLabelBackground,
                    ForgetPassLinkBackgroundColor = repository.AuthThemeKeyStrings.AuthLinkBackground,
                    EditTextBackgroundColor = repository.AuthThemeKeyStrings.AuthEditTextBackground,
                    EditTextHintColor = repository.AuthThemeKeyStrings.AuthEditTextHint,
                    EditTextDrawableFail = repository.AuthThemeKeyStrings.AuthEnterTextFail,
                    EditTextDrawableSuccess = repository.AuthThemeKeyStrings.AuthEnterTextSuccess,
                    EditTextBorderNoneColor = repository.AuthThemeKeyStrings.AuthEditTextBorderNone,
                    EditTextTextNoneColor = repository.AuthThemeKeyStrings.AuthEditTextTextNone
                };

                #endregion

                #region RegThemeStringsRegion

                RegThemeStrings = new RegThemeStrings
                {
                    EditTextBorderFailColor = repository.RegThemeKeyStrings.RegEditTextBorderFail,
                    EditTextBorderSuccessColor = repository.RegThemeKeyStrings.RegEditTextBorderNone,
                    EditTextBorderNoneColor = repository.RegThemeKeyStrings.RegEditTextBorderNone,
                    EditTextTextFailColor = repository.RegThemeKeyStrings.RegEditTextTextFail,
                    EditTextTextSuccessColor = repository.RegThemeKeyStrings.RegEditTextTextSuccess,
                    EditTextTextNoneColor = repository.RegThemeKeyStrings.RegEditTextTextNone,
                    EditTextHintColor = repository.RegThemeKeyStrings.RegEditTextHint,
                    EditTextBackgroundColor = repository.RegThemeKeyStrings.RegEditTextBackground,
                    EditTextDrawableSuccess = repository.RegThemeKeyStrings.RegEnterTextSuccess,
                    EditTextDrawableFail = repository.RegThemeKeyStrings.RegEnterTextFail,
                    ViewBackgroundImage = repository.RegThemeKeyStrings.RegBackground,
                    LogoImage = repository.RegThemeKeyStrings.RegLogo,
                    ButtonColor = repository.RegThemeKeyStrings.RegButtonBackground,
                    ButtonTitleColor = repository.RegThemeKeyStrings.RegButtonText,
                    BackImageButtonBackgroundImage = repository.RegThemeKeyStrings.RegBackButton,
                    HeaderLabelFont = repository.RegThemeKeyStrings.RegText,
                    HeaderLabelColor = repository.RegThemeKeyStrings.RegTitleText,
                    HeaderLabelSize = repository.RegThemeKeyStrings.RegTitle,
                    HeaderLabelBackgroundColor = repository.RegThemeKeyStrings.RegTitleBackground,
                    LabelTextColor = repository.RegThemeKeyStrings.RegLabelText,
                    LabelTextSize = repository.RegThemeKeyStrings.RegLabelHint,
                    LabelTextFont = repository.RegThemeKeyStrings.RegText,
                    LinkTextColor = repository.RegThemeKeyStrings.RegLinkTextBackground,
                    LinkTextSize = repository.RegThemeKeyStrings.RegLink,
                    LinkFontStyle = repository.RegThemeKeyStrings.RegLink,
                    LinkBackgroundColor = repository.RegThemeKeyStrings.RegLinkBackground,
                    UserAgreementInfoBackgroundColor = repository.RegThemeKeyStrings.RegLabelBackground,
                    UserAgreementInfoTextColor = repository.RegThemeKeyStrings.RegLabelText,
                    UserAgreementInfoTextSize = repository.RegThemeKeyStrings.RegLabel,
                    UserAgreementInfoFontStyle = repository.RegThemeKeyStrings.RegText,
                    UserAgreementInfoTitle = Locale.Localization.Lang.RegUserAgreementTextView,
					FeatureLabelTextFont = repository.RegThemeKeyStrings.RegFeatureTextFont,
					FeatureLabelTextSize = repository.RegThemeKeyStrings.RegFeatureTextSize,
					FeatureLabelTextColor = repository.RegThemeKeyStrings.RegFeatureTextColor,
                    FeatureImageName = repository.RegThemeKeyStrings.RegNameFeatureImage,
                    FeatureImagePhone = repository.RegThemeKeyStrings.RegPhoneFeatureImage,					                             
                    FeatureImagePass = repository.RegThemeKeyStrings.RegPassFeatureImage,
                    FeatureImageEmail = repository.RegThemeKeyStrings.RegEmailFeatureImage
                };

                #endregion

                #region CreatePostThemeStringsRegion

                CreatePostThemeStrings = new CreatePostThemeStrings
                {
                    CommentEditTextBackgroundColorFail = repository.CreatePostThemeKeyStrings.CreatePostCommentBackgroundFail,
                    CommentEditTextBackgroundColorNone = repository.CreatePostThemeKeyStrings.CreatePostCommentBackground,
                    CommentEditTextBorderColorFail = repository.CreatePostThemeKeyStrings.CreatePostCommentBackgroundFail,
                    CommentEditTextBorderColorNone = repository.CreatePostThemeKeyStrings.CreatePostCommentBackground,
                    CommentEditTextHintColor = repository.CreatePostThemeKeyStrings.CreatePostCommentHint,
                    CommentEditTextTextColor = repository.CreatePostThemeKeyStrings.CreatePostCommentText,
                    FieldsBackgroundColorFail = repository.CreatePostThemeKeyStrings.CreatePostFieldsBackgroundFail,
                    FieldsBackgroundColorNone = repository.CreatePostThemeKeyStrings.CreatePostFieldsBackground,
                    FieldsTextSize = repository.CreatePostThemeKeyStrings.CreatePostFieldsText,
                    FieldsTextColor = repository.CreatePostThemeKeyStrings.CreatePostFieldsText,
                    FieldsFontStyle = repository.CreatePostThemeKeyStrings.CreatePostFieldsText,
                    ForecastTimeNotChoosenColor = repository.CreatePostThemeKeyStrings.CreatePostForecastTimeNotChoosen,
                    ForecastTimeChoosenColor = repository.CreatePostThemeKeyStrings.CreatePostForecastTimeChoosen,
                    ToolBackgroundColorFail = repository.CreatePostThemeKeyStrings.CreatePostToolsBackgroundFail,
                    ToolBackgroundColorNone = repository.CreatePostThemeKeyStrings.CreatePostToolsBackground,
                    ToolTextSize = repository.CreatePostThemeKeyStrings.CreatePostFieldsText,
                    ToolTextColor = repository.CreatePostThemeKeyStrings.CreatePostToolsText,
                    ToolFontStyle = repository.CreatePostThemeKeyStrings.CreatePostFieldsText,
                    DividingLineHeaderColor = repository.CreatePostThemeKeyStrings.CreatePostDividingLine,
                    DividingLineCommentColor = repository.CreatePostThemeKeyStrings.CreatePostDividingLine,
                    AddImageButtonDrawable = repository.CreatePostThemeKeyStrings.CreatePostAttachedImage,
                    NameLabelBackgroundColor = repository.CreatePostThemeKeyStrings.CreatePostFirstLastNameBackground,
                    NameLabelTextColor = repository.CreatePostThemeKeyStrings.CreatePostFirstLastNameText,
                    NameLabelFontStyle = repository.CreatePostThemeKeyStrings.CreatePostFirstLastNameText,
                    NameLabelTextSize = repository.CreatePostThemeKeyStrings.CreatePostFieldsText,
                    ToolBarPublishButtonBackgroundColor = repository.CreatePostThemeKeyStrings.CreatePostPublishBackground,
                    ToolBarPublishButtonTextColor = repository.CreatePostThemeKeyStrings.CreatePostPublishText,
                    ToolBarBackground = repository.CreatePostThemeKeyStrings.CreatePostToolBarBackground,
                    AttachmentCancelDrawable = repository.CreatePostThemeKeyStrings.CreatePostCancelAttach,
                    DefaultAvatarDrawable = repository.CreatePostThemeKeyStrings.CreatePostDefaultAvatarImage,
                    ImageButtonTintWhite = repository.CreatePostThemeKeyStrings.CreatePostImagesTint,
                    ImageButtonTintBlack = repository.CreatePostThemeKeyStrings.CreatePostImagesBlackTint,
                    PickerHeaderViewBackgroundColor = repository.CreatePostThemeKeyStrings.CreatePostFieldsBackground,
                    ArrowDownDrawableBlack = repository.CreatePostThemeKeyStrings.CreatePostArrowDownBlack,
                    ArrowDownDrawableWhite = repository.CreatePostThemeKeyStrings.CreatePostArrowDownWhite,
					ToolBarBackImage = repository.CreatePostThemeKeyStrings.CreatePostBackButton,
					ToolBarTitleColor = repository.CreatePostThemeKeyStrings.CreatePostTitleText
				};

                #endregion

                #region PostBodyThemeStringsRegion
                
                PostBodyThemeStrings = new PostBodyThemeStrings
                {
                    ContentTextSize = repository.PostBodyKeyStrings.PostBodyContentTextSize,
                    ContentBackgroundColor = repository.PostBodyKeyStrings.PostBodyContentBackgroundColor,
                    ContentFontStyle = repository.PostBodyKeyStrings.PostBodyContentFontStyle,
                    ContentTextColor = repository.PostBodyKeyStrings.PostBodyContentTextColor,
                    ReadMoreTextColor = repository.PostBodyKeyStrings.PostBodyReadMoreTextColor,
                    ReadMoreFontStyle = repository.PostBodyKeyStrings.PostBodyReadMoreFontStyle
                };

                #endregion

                #region PostHeaderThemeStringsRegion

                PostHeaderThemeStrings = new PostHeaderThemeStrings()
                {
                    AvatarImage = repository.PostHeaderKeyStrings.PostHeaderAvatarImage,
                    MoreOptionsButtonImage = repository.PostHeaderKeyStrings.PostHeaderMoreOptionsButtonImage,
                    FavoriteButtonImageActive = repository.PostHeaderKeyStrings.PostHeaderFavoriteButtonImageActive,
                    FavoriteButtonImageNone = repository.PostHeaderKeyStrings.PostHeaderFavoriteButtonImageNone,
                    BuySellImageRed = repository.PostHeaderKeyStrings.PostHeaderBuySellImageRed,
                    BuySellImageGreen = repository.PostHeaderKeyStrings.PostHeaderBuySellImageGreen,
                    CurrentPriceUpImage = repository.PostHeaderKeyStrings.PostHeaderCurrentPriceUpImage,
                    CurrentPriceDownImage = repository.PostHeaderKeyStrings.PostHeaderCurrentPriceDownImage,
                    UserStatusOnlineImage = repository.PostHeaderKeyStrings.PostHeaderUserStatusOnlineImage,
                    UserStatusOfflineImage = repository.PostHeaderKeyStrings.PostHeaderUserStatusOfflineImage,
                    FirstLastNameTextColor = repository.PostHeaderKeyStrings.PostHeaderFirstLastNameTextColor,
                    FirstLastNameTextSize = repository.PostHeaderKeyStrings.PostHeaderFirstLastNameTextSize,
                    FirstLastNameTextFontStyle = repository.PostHeaderKeyStrings.PostHeaderFirstLastNameTextFontStyle,
                    DateTextColor = repository.PostHeaderKeyStrings.PostHeaderDateTextColor,
                    DateTextSize = repository.PostHeaderKeyStrings.PostHeaderDateTextSize,
                    DateTextFontStyle = repository.PostHeaderKeyStrings.PostHeaderDateTextFontStyle,
                    QuoteTextFontStyle = repository.PostHeaderKeyStrings.PostHeaderQuoteTextFontStyle,
                    QuoteTextColor = repository.PostHeaderKeyStrings.PostHeaderQuoteTextColor,
                    QuoteTextSize = repository.PostHeaderKeyStrings.PostHeaderQuoteTextSize,
                    BuySellTextFontStyle = repository.PostHeaderKeyStrings.PostHeaderBuySellTextFontStyle,
                    BuySellTextColor = repository.PostHeaderKeyStrings.PostHeaderBuySellTextColor,
                    BuySellTextSize = repository.PostHeaderKeyStrings.PostHeaderBuySellTextSize,
                    ForecastTextFontStyle = repository.PostHeaderKeyStrings.PostHeaderForecastTextFontStyle,
                    ForecastTextColor = repository.PostHeaderKeyStrings.PostHeaderForecastTextColor,
                    ForecastTextSize = repository.PostHeaderKeyStrings.PostHeaderForecastTextSize,
                    CurrentPriceTextFontStyle = repository.PostHeaderKeyStrings.PostHeaderCurrentPriceTextFontStyle,
                    CurrentPriceTextColor = repository.PostHeaderKeyStrings.PostHeaderCurrentPriceTextColor,
                    CurrentPriceTextSize = repository.PostHeaderKeyStrings.PostHeaderCurrentPriceTextSize,
                    DiffTextFontStyle = repository.PostHeaderKeyStrings.PostHeaderDiffTextFontStyle,
                    DiffTextColor = repository.PostHeaderKeyStrings.PostHeaderDiffTextColor,
                    DiffTextSize = repository.PostHeaderKeyStrings.PostHeaderDiffTextSize,
                    DiffValueTextFontStyle = repository.PostHeaderKeyStrings.PostHeaderDiffValueTextFontStyle,
                    DiffValueTextColorPositive = repository.PostHeaderKeyStrings.PostHeaderDiffValueTextColorPositive,
                    DiffValueTextColorNegative = repository.PostHeaderKeyStrings.PostHeaderDiffValueTextColorNegative,
                    DiffValueTextSize = repository.PostHeaderKeyStrings.PostHeaderDiffValueTextSize,
                    PostTextBackground = repository.PostHeaderKeyStrings.PostHeaderPostTextBackground,
                    PostHeaderBuyBackground = repository.PostHeaderKeyStrings.PostHeaderBuyBackground,
                    PostHeaderSellBackground = repository.PostHeaderKeyStrings.PostHeaderSellBackground,
                };

                #endregion

                #region PostSocialThemeStringsRegion

                PostSocialThemeStrings = new PostSocialThemeStrings
                {
                    LikeBackgroundColor = repository.PostSocialKeyStrings.PostSocialLikeBackgroundColor,
                    LikeDrawableLiked = repository.PostSocialKeyStrings.PostSocialLikeDrawableLiked,
                    LikeDrawableNotLiked = repository.PostSocialKeyStrings.PostSocialLikeDrawableNotLiked,
                    LikeTextColor = repository.PostSocialKeyStrings.PostSocialLikeTextColor,
                    LikeTextFont = repository.PostSocialKeyStrings.PostSocialLikeTextFont,
                    LikeTextSize = repository.PostSocialKeyStrings.PostSocialLikeTextSize,
                    CommentBackgroundColor = repository.PostSocialKeyStrings.PostSocialCommentBackgroundColor,
                    CommentDrawable = repository.PostSocialKeyStrings.PostSocialCommentDrawable,
                    CommentTextColor = repository.PostSocialKeyStrings.PostSocialCommentTextColor,
                    CommentTextFont = repository.PostSocialKeyStrings.PostSocialCommentTextFont,
                    CommentTextSize = repository.PostSocialKeyStrings.PostSocialCommentTextSize,
                    ShareBackgroundColor = repository.PostSocialKeyStrings.PostSocialShareBackgroundColor,
                    ShareDrawable = repository.PostSocialKeyStrings.PostSocialShareDrawable,
                    ShareTextColor = repository.PostSocialKeyStrings.PostSocialShareTextColor,
                    ShareTextFont = repository.PostSocialKeyStrings.PostSocialShareTextFont,
                    ShareTextSize = repository.PostSocialKeyStrings.PostSocialShareTextSize
                };

                #endregion

                #region PostStatisticsThemeStringsRegion

                PostStatisticsThemeStrings = new PostStatisticsThemeStrings
                {

                };

                #endregion

                #region PostThemeStringsRegion

                PostOtherThemeStrings = new PostOtherThemeStrings
                {
                    ToolBarBackImage = repository.PostOtherKeyStrings.PostToolBarBackImage,
                    ToolBarTitleColor = repository.PostOtherKeyStrings.PostToolBarTitleColor,
                    ToolBarBackground = repository.PostOtherKeyStrings.PostToolBarBackground
                };

                #endregion

                #region ToolsThemeStringsRegion

                ToolsThemeStrings = new ToolsThemeStrings
                {
                    ToolBarBackgoundColorKey = repository.ToolsThemeKeyStrings.ToolBarBackgoundColorKey,
                    ArrowBackImageKey = repository.ToolsThemeKeyStrings.ArrowBackImageKey,
                    ToolBarTextFontStyleKey = repository.ToolsThemeKeyStrings.ToolBarTextFontStyleKey,
                    ToolBarTextColorKey = repository.ToolsThemeKeyStrings.ToolBarTextColorKey,
                    ToolBarTextSizeKey = repository.ToolsThemeKeyStrings.ToolBarTextSizeKey,
                    SearchBacgroundColorKey = repository.ToolsThemeKeyStrings.SearchBacgroundColorKey,
                    SearchTextColorKey = repository.ToolsThemeKeyStrings.SearchTextColorKey,
                    SearchTextSizeKey = repository.ToolsThemeKeyStrings.SearchTextSizeKey,
                    SearchTextFontStyleKey = repository.ToolsThemeKeyStrings.SearchTextFontStyleKey,
                    SelectedCellColorKey = repository.ToolsThemeKeyStrings.SelectedCellColorKey,
                    SelectedCellTextFontStyleKey = repository.ToolsThemeKeyStrings.SelectedCellTextFontStyleKey,
                    SelectedCellTextColorKey = repository.ToolsThemeKeyStrings.SelectedCellTextColorKey,
                    SelectedCellTextSizeKey = repository.ToolsThemeKeyStrings.SelectedCellTextSizeKey,
                    DividingLineColorKey = repository.ToolsThemeKeyStrings.DividingLineColorKey,
                    DividingLineSizeKey = repository.ToolsThemeKeyStrings.DividingLineSizeKey,
                    DividingLineTypeKey = repository.ToolsThemeKeyStrings.DividingLineTypeKey,
                    CellColorKey = repository.ToolsThemeKeyStrings.CellColorKey,
                    CellTextFontStyleKey = repository.ToolsThemeKeyStrings.CellTextFontStyleKey,
                    CellTextColorKey = repository.ToolsThemeKeyStrings.CellTextColorKey,
                    CellTextSizeKey = repository.ToolsThemeKeyStrings.CellTextSizeKey
                };

                #endregion

            }
        }
    }
}
