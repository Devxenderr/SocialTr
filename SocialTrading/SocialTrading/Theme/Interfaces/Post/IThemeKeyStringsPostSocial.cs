namespace SocialTrading.Theme.Interfaces.Post
{
    public interface IThemeKeyStringsPostSocial
    {
        string PostSocialLikeTextFont { get; }
        string PostSocialLikeTextColor { get; }
        string PostSocialLikeTextSize { get; }
        string PostSocialLikeBackgroundColor { get; }
        string PostSocialLikeDrawableLiked { get; }
        string PostSocialLikeDrawableNotLiked { get; }

        string PostSocialCommentTextFont { get; }
        string PostSocialCommentTextColor { get; }
        string PostSocialCommentTextSize { get; }
        string PostSocialCommentBackgroundColor { get; }
        string PostSocialCommentDrawable { get; }

        string PostSocialShareTextFont { get; }
        string PostSocialShareTextColor { get; }
        string PostSocialShareTextSize { get; }
        string PostSocialShareBackgroundColor { get; }
        string PostSocialShareDrawable { get; }
    }
}