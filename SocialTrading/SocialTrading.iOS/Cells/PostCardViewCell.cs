using System;

using UIKit;
using Foundation;

using SocialTrading.Service;
using SocialTrading.iOS.Theme;
using SocialTrading.iOS.Tools;
using SocialTrading.iOS.Routers;
using SocialTrading.Theme.ThemeStrings;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Service.Interfaces.Timer;
using SocialTrading.Vipers.Post.Implementation;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Post.Implementation.Body;
using SocialTrading.Service.Interfaces.Notifications;
using SocialTrading.Vipers.Post.Implementation.Header;
using SocialTrading.Vipers.Post.Implementation.Social;
using SocialTrading.Tools.Enumerations;

namespace SocialTrading.iOS.Cells
{
    public partial class PostCardViewCell : UICollectionViewCell, ITickNotification, IDisposable
    {
        public static readonly NSString Key = new NSString("PostCardViewCell");
        public static readonly UINib Nib;

        static PostCardViewCell()
        {
            Nib = UINib.FromName("PostCardViewCell", NSBundle.MainBundle);
        }


        public PostView PostView => _postView;
        public InteractorPost PostInteractor;
        private EMarketTypes _market;

        private Action<int, nfloat> PostHeightCounted { get; set; }
        private Action<int, nfloat> PostBodyHeightCountedByView { get; set; }


        protected PostCardViewCell(IntPtr handle) : base(handle)
        {
        }


        public void SetConfig(IRepositoryPost repository, IRepositoryQc repositoryQc, INotificationCenter notification, PostOtherThemeStrings otherThemeStrings, 
            PostsViewController viewController, string id, int bodyWidth, int row, Action<int, nfloat> postHeightCounted, nfloat height)
        {
            var post = DataService.RepositoryController.RepositoryPost.GetOnePostById(id);
            _market =  (EMarketTypes)Enum.Parse(typeof(EMarketTypes), post.ModelPost.Market);
            PostView.SetPostMarket(_market);

            Console.WriteLine(_market + "   " + post.ModelPost.Content);

            PostInteractor = new InteractorPost(id, new OnePostController(DataService.RepositoryController.RepositoryPost), notification, repository, repositoryQc);
            var presenter = new PresenterPost(
                view:               PostView,
                interactor:         PostInteractor,
                router:             new RouterPost(viewController),
                otherThemeStrings:  otherThemeStrings,
                headerStylesHolder: new PostHeaderStylesHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser),
                socialStylesHolder: new PostSocialStylesHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser),
                bodyStylesHolder:   new PostBodyStylesHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser),
                postLocale:         DataService.RepositoryController.RepositoryPost.LangPost,
                isPostDetailed:     false
            );

            SetCellWidth(bodyWidth);
            TransfareActionToView(postHeightCounted, row);

            PostInteractor.SendRequestForPosts();

            var fr = PostView.Frame;
            fr.Height = height;
            PostView.Frame = fr;
        }


        private void TransfareActionToView(Action<int, nfloat> postHeightCounted, int postIndex)
        {
            PostHeightCounted = postHeightCounted;
            PostBodyHeightCountedByView = PostBodyHeightCounted;

            foreach (var item in Subviews)
            {
                foreach (var internalItem in item.Subviews)
                {
                    if (internalItem is PostView)
                    {
                        var postBody = (internalItem as PostView).ViewPostBody;
                        (postBody as PostBodyView).SetActionOnCountingHeight(PostBodyHeightCountedByView, postIndex);
                        return;
                    }
                }
            }
        }


        public void PostBodyHeightCounted(int index, nfloat height)
        {
            var emptySpaceAroundSeparator = 8;
            
            var a = PostView.HeightContainer.Constant;
            var b = (PostView.ViewPostSocial as PostSocialView)?.Frame.Height;
            var c = (PostView.AfterHeaderSeparatorView.Frame.Height + emptySpaceAroundSeparator);
            var d = (PostView.AfterBodySeparatorView.Frame.Height + emptySpaceAroundSeparator);

            var wholeHeight = height + a + b + c + d;

            if (wholeHeight != null) 
            {
                PostHeightCounted?.Invoke(index, wholeHeight.Value);
            };
        }


        private void SetCellWidth(int width)
        {
            foreach (var item in Subviews)
            {
                foreach (var internalItem in item.Subviews)
                {
                    if (internalItem is PostView)
                    {
                        var postBody = (internalItem as PostView).ViewPostBody;
                        (postBody as PostBodyView).Width = width;
                        return;
                    }
                }
            }
        }

        public void TickNotify(DateTime nowTime)
        {
            PostInteractor.ChangeTime(nowTime);
        }

        public new void Dispose()
        {
            PostInteractor.Dispose();
        }
    }
}
