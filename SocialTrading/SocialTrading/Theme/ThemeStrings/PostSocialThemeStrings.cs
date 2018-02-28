namespace SocialTrading.Theme.ThemeStrings
{
    public class PostSocialThemeStrings
    {
        public string LikeTextFont { get; internal set; }
        public string LikeTextColor { get; internal set; }
        public string LikeTextSize { get; internal set; }
        public string LikeBackgroundColor { get; internal set; }
        public string LikeDrawableLiked { get; internal set; }
        public string LikeDrawableNotLiked { get; internal set; }

        public string CommentTextFont { get; internal set; }
        public string CommentTextColor { get; internal set; }
        public string CommentTextSize { get; internal set; }
        public string CommentBackgroundColor { get; internal set; }
        public string CommentDrawable { get; internal set; }

        public string ShareTextFont { get; internal set; }
        public string ShareTextColor { get; internal set; }
        public string ShareTextSize { get; internal set; }
        public string ShareBackgroundColor { get; internal set; }
        public string ShareDrawable { get; internal set; }


        public PostSocialThemeStrings()
        {
        }

        public PostSocialThemeStrings(string likeTextFont, string likeTextColor, string likeTextSize, string likeBackgroundColor, string likeDrawableLiked, string likeDrawableNotLiked, string commentTextFont, string commentTextColor, string commentTextSize, string commentBackgroundColor, string commentDrawable, string shareTextFont, string shareTextColor, string shareTextSize, string shareBackgroundColor, string shareDrawable)
        {
            LikeTextFont = likeTextFont;
            LikeTextColor = likeTextColor;
            LikeTextSize = likeTextSize;
            LikeBackgroundColor = likeBackgroundColor;
            LikeDrawableLiked = likeDrawableLiked;
            LikeDrawableNotLiked = likeDrawableNotLiked;
            CommentTextFont = commentTextFont;
            CommentTextColor = commentTextColor;
            CommentTextSize = commentTextSize;
            CommentBackgroundColor = commentBackgroundColor;
            CommentDrawable = commentDrawable;
            ShareTextFont = shareTextFont;
            ShareTextColor = shareTextColor;
            ShareTextSize = shareTextSize;
            ShareBackgroundColor = shareBackgroundColor;
            ShareDrawable = shareDrawable;
        }
    }
}
