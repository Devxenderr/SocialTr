using System;
using SocialTrading.Theme.Interfaces;

namespace SocialTrading.Theme
{
    public class ThemeKeyStrings : IThemeKeyStringsAuth, IThemeKeyStringsReg, IThemeKeyStringsCreatePost, IThemeKeyStringsPost, IThemeKeyStringsTools
    {
		public string AuthButtonBackground    => "buttonBackground";
        public string AuthButtonText          => "buttonText";
        public string AuthBackground          => "background";
        public string AuthSloganText          => "sloganText";
        public string AuthSloganBackground    => "sloganBackground";
        public string AuthLabelText           => "labelText";
        public string AuthLabelBackground     => "labelBackground";
        public string AuthTitleText           => "titleText";
        public string AuthTitleBackground     => "titleBackground";
        public string AuthLinkText            => "linkText";
        public string AuthLinkBackground      => "linkBackground";
        public string AuthEditTextHint        => "editTextHint";
        public string AuthEditTextTextNone    => "editTextTextNone";
        public string AuthEditTextTextSuccess => "editTextTextSuccess";
        public string AuthEditTextTextFail    => "editTextTextFail";
        public string AuthEditTextBackground  => "editTextBackground";
        public string AuthEditTextBorderNone  => "editTextBorderNone";
        public string AuthEditTextBorderFail  => "editTextBorderFail";
        public string AuthLogo                => "logo";
        public string AuthFbLogin             => "fbLogin";
        public string AuthVkLogin             => "vkLogin";
        public string AuthOkLogin             => "okLogin";
        public string AuthGoogleLogin         => "googleLogin";
        public string AuthBackButton          => "backButton";
        public string AuthEnterTextSuccess    => "enterTextSuccess";
        public string AuthEnterTextFail       => "enterTextFail";
        public string AuthSlogan              => "slogan";
        public string AuthLabelHint           => "lableHint";
        public string AuthLabel               => "label";
        public string AuthLink                => "link";
        public string AuthSocialNetworkTint   => "socialnetworkTintColor";
        public string AuthText                => "text";
        public string AuthFacebookLetter      => "facebookLetter";


        public string RegTitleText            => "titleText";
        public string RegTitleBackground      => "titleBackground";
        public string RegBackground           => "background";
        public string RegLabelText            => "labelText";
        public string RegLabelBackground      => "labelBackground";
        public string RegEditTextHint         => "editTextHint";
        public string RegEditTextTextNone     => "editTextTextNone";
        public string RegEditTextTextSuccess  => "editTextTextSuccess";// Unused in Droid
        public string RegEditTextTextFail     => "editTextTextFail";
        public string RegEditTextBackground   => "editTextBackground";
        public string RegEditTextBorderNone   => "editTextBorderNone";
        public string RegEditTextBorderFail   => "editTextBorderFail";
        public string RegButtonBackground     => "buttonBackground";
        public string RegButtonText           => "buttonText";
        public string RegLinkTextBackground   => "linkText";
        public string RegLinkBackground       => "linkBackground";
        public string RegLogo                 => "logo";
        public string RegBackButton           => "backButton";
        public string RegEnterTextSuccess     => "enterTextSuccess";
        public string RegEnterTextFail        => "enterTextFail";
        public string RegTitle                => "title";
        public string RegLabelHint            => "lableHint";
        public string RegLabel                => "label";
        public string RegLink                 => "link";
        public string RegText                 => "text";// Unused in Droid
        public string RegNameFeatureImage     => "nameFeatureImage";
        public string RegPhoneFeatureImage    => "phoneFeatureImage";
        public string RegEmailFeatureImage    => "emailFeatureImage ";
        public string RegPassFeatureImage     => "passFeatureImage";
        public string RegFeatureTextSize      => "regFeatureTextSize";
        public string RegFeatureTextFont      => "regFeatureTextFont";
        public string RegFeatureTextColor     => "regFeatureTextColor";


        public string CreatePostTitleText               => "titleText";// Unused in Droid
        public string CreatePostPublishText             => "publishText";
        public string CreatePostPublishBackground       => "publishBackgroundColor";
        public string CreatePostToolBarBackground       => "toolBarBackground";
        public string CreatePostAttachesBackground      => "attachesBackgroundColor";// Unused in Droid
        public string CreatePostFirstLastNameText       => "firstLastNameText";
        public string CreatePostFirstLastNameBackground => "firstLastNameBackground";
        public string CreatePostToolsBackground         => "toolsBackground";
        public string CreatePostToolsBackgroundFail     => "toolsBackgroundFail";
        public string CreatePostToolsText               => "toolsText";
        public string CreatePostPriceText               => "priceText";
        public string CreatePostPriceBackground         => "priceBackground";
        public string CreatePostFieldsText              => "postFieldsText";
        public string CreatePostFieldsBackground        => "postFieldsBackground";
        public string CreatePostFieldsBackgroundFail    => "postFieldsBackgroundFail";
        public string CreatePostCommentHint             => "commentHint";
        public string CreatePostCommentText             => "commentText";
        public string CreatePostCommentBackground       => "commentBackground";
        public string CreatePostCommentBackgroundFail   => "commentBackgroundFail";
        public string CreatePostBackButton              => "backButton";// Unused in Droid
        public string CreatePostAttachedImage           => "attachedImage";
        public string CreatePostDefaultAvatarImage      => "defaultAvatarImage";
        public string CreatePostArrowDownBlack          => "arrowDownBlackCreatePost";
        public string CreatePostArrowDownWhite          => "arrowDownWhiteCreatePost";
        public string CreatePostCancelAttach            => "cancelAttach";
        public string CreatePostDividingLine            => "dividingLineColor";
        public string CreatePostImagesTint              => "imagesTintColor"; // Unused in Droid
        public string CreatePostForecastTimeChoosen     => "forecastTimeChoosen"; // Unused in Droid
        public string CreatePostForecastTimeNotChoosen  => "forecastTimeNotChoosen";// Unused in Droid
        public string CreatePostImagesWhiteTint         => "imagesWhiteColor";// Unused in Droid
        public string CreatePostImagesBlackTint         => "imagesBlackColor"; // Unused in Droid


        public string PostHeaderAvatarImage                => "avatarImage";
        public string PostHeaderMoreOptionsButtonImage     => "moreOptionsButtonImage";
        public string PostHeaderFavoriteButtonImageActive  => "favoriteButtonImageActive";
        public string PostHeaderFavoriteButtonImageNone    => "favoriteButtonImageNone";
        public string PostHeaderBuySellImageRed            => "buySellImageRed";
        public string PostHeaderBuySellImageGreen          => "buySellImageGreen";
        public string PostHeaderCurrentPriceUpImage        => "currentPriceUpImage";
        public string PostHeaderCurrentPriceDownImage      => "currentPriceDownImage";
        public string PostHeaderUserStatusOnlineImage      => "userStatusOnlineImage";
        public string PostHeaderUserStatusOfflineImage     => "userStatusOfflineImage";
        public string PostHeaderFirstLastNameTextColor     => "firstLastNameTextColor";
        public string PostHeaderFirstLastNameTextSize      => "firstLastNameTextSize";
        public string PostHeaderFirstLastNameTextFontStyle => "firstLastNameTextFontStyle";
        public string PostHeaderDateTextColor              => "dateTextColor";
        public string PostHeaderDateTextSize               => "dateTextSize";
        public string PostHeaderDateTextFontStyle          => "dateTextFontStyle";
        public string PostHeaderQuoteTextFontStyle         => "quoteTextFontStyle";
        public string PostHeaderQuoteTextColor             => "quoteTextColor";
        public string PostHeaderQuoteTextSize              => "quoteTextSize";
        public string PostHeaderBuySellTextFontStyle       => "buySellTextFontStyle";
        public string PostHeaderBuySellTextColor           => "buySellTextColor";
        public string PostHeaderBuySellTextSize            => "buySellTextSize";
        public string PostHeaderForecastTextFontStyle      => "forecastTextFontStyle";
        public string PostHeaderForecastTextColor          => "forecastTextColor";
        public string PostHeaderForecastTextSize           => "forecastTextSize";
        public string PostHeaderCurrentPriceTextFontStyle  => "currentPriceTextFontStyle";
        public string PostHeaderCurrentPriceTextColor      => "currentPriceTextColor";
        public string PostHeaderCurrentPriceTextSize       => "currentPriceTextSize";
        public string PostHeaderDiffTextFontStyle          => "diffTextFontStyle";
        public string PostHeaderDiffTextColor              => "diffTextColor";
        public string PostHeaderDiffTextSize               => "diffTextSize";
        public string PostHeaderDiffValueTextFontStyle     => "diffValueTextFontStyle";
        public string PostHeaderDiffValueTextColorPositive => "diffValueTextColorPositive";
        public string PostHeaderDiffValueTextColorNegative => "diffValueTextColorNegative";
        public string PostHeaderDiffValueTextSize          => "diffValueTextSize";
        public string PostHeaderPostTextBackground         => "postTextBackground";

        public string PostSocialLikeTextFont                => "likeTextFont";
        public string PostSocialLikeTextColor               => "likeTextColor";
        public string PostSocialLikeTextSize                => "likeTextSize";
        public string PostSocialLikeBackgroundColor         => "likeBackgroundColor";
        public string PostSocialLikeDrawableLiked           => "likeDrawableLiked";
        public string PostSocialLikeDrawableNotLiked        => "likeDrawableNotLiked";
        public string PostSocialCommentTextFont             => "commentTextFont";
        public string PostSocialCommentTextColor            => "commentTextColor";
        public string PostSocialCommentTextSize             => "commentTextSize";
        public string PostSocialCommentBackgroundColor      => "commentBackgroundColor";
        public string PostSocialCommentDrawable             => "commentDrawable";
        public string PostSocialShareTextFont               => "shareTextFont";
        public string PostSocialShareTextColor              => "shareTextColor";
        public string PostSocialShareTextSize               => "shareTextSize";
        public string PostSocialShareBackgroundColor        => "shareBackgroundColor";
        public string PostSocialShareDrawable               => "shareDrawable";

        public string PostBodyContentBackgroundColor       => "contentBackgroundColor";
        public string PostBodyContentTextSize              => "contentTextSize";
        public string PostBodyContentTextColor             => "contentTextColor";
        public string PostBodyContentFontStyle             => "contentFontStyle";
        public string PostBodyReadMoreTextColor            => "readMoreTextColor";
        public string PostBodyReadMoreFontStyle            => "readMoreFontStyle";

        public string PostToolBarBackImage                 => "toolBarBackButton";
        public string PostToolBarTitleColor                => "toolBarTitleColor";
        public string PostToolBarBackground                => "toolBarBackground";

        //Tools
        public string ToolBarBackgoundColorKey             => "toolBarBackgoundColor";
        public string ArrowBackImageKey                    => "arrowBackImage";
        public string ToolBarTextFontStyleKey              => "toolBarTextFontStyle";
        public string ToolBarTextColorKey                  => "toolBarTextColor";
        public string ToolBarTextSizeKey                   => "toolBarTextSize";
        public string SearchBacgroundColorKey              => "searchBacgroundColor";
        public string SearchTextColorKey                   => "searchTextColor";
        public string SearchTextSizeKey                    => "searchTextSize";
        public string SearchTextFontStyleKey               => "searchTextFontStyle";
        public string SelectedCellColorKey                 => "selectedCellColor";
        public string SelectedCellTextFontStyleKey         => "selectedCellTextFontStyle";
        public string SelectedCellTextColorKey             => "selectedCellTextColor";
        public string SelectedCellTextSizeKey              => "selectedCellTextSize";
        public string DividingLineColorKey                 => "dividingLineColor";
        public string DividingLineSizeKey                  => "dividingLineSize";
        public string DividingLineTypeKey                  => "dividingLineType";

        public string CellColorKey                         => "cellColorKey";
        public string CellTextFontStyleKey                 => "cellTextFontStyleKey";
        public string CellTextColorKey                     => "cellTextColorKey";
        public string CellTextSizeKey                      => "cellTextSizeKey";

        public string PostHeaderBuyBackground              => "buyBackground";
        public string PostHeaderSellBackground             => "sellBackground";
    }
}
