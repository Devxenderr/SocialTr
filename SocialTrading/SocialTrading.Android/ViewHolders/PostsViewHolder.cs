using System;

using Android.App;
using Android.Views;
using Android.Support.V7.Widget;

using SocialTrading.Service;
using SocialTrading.Droid.Theme;
using SocialTrading.Droid.Tools;
using SocialTrading.Droid.Routers;
using SocialTrading.Droid.Views.Post;
using SocialTrading.Theme.ThemeStrings;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Service.Interfaces.Timer;
using SocialTrading.Vipers.Post.Implementation;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Post.Implementation.Body;
using SocialTrading.Service.Interfaces.Notifications;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Post.Implementation.Header;
using SocialTrading.Vipers.Post.Implementation.Social;

namespace SocialTrading.Droid.ViewHolders
{
    public class PostsViewHolder : RecyclerView.ViewHolder, ITickNotification
    {
        private PostView _postView;
        private readonly IRepositoryQc _repositoryQc;
        private readonly IRepositoryPost _repository;
        private readonly INotificationCenter _notification;
        private readonly PostOtherThemeStrings _otherThemeStrings;

        private InteractorPost _interactor;
        private View _itemView;

        public PostsViewHolder(View itemView, INotificationCenter notification, IRepositoryPost repository, IRepositoryQc repositoryQc, 
            PostOtherThemeStrings otherThemeStrings) : base(itemView)
        {
            _repository = repository;
            _repositoryQc = repositoryQc;
            _notification = notification;

            _otherThemeStrings = otherThemeStrings;

            _itemView = itemView;
        }


        public void CreateViper(string postId)
        {
            var post = DataService.RepositoryController.RepositoryPost.GetOnePostById(postId);
            var market = post.ModelPost.Market;
            _postView = _itemView.FindViewById<PostView>(Resource.Id.post_postView);
            _postView.SetPostMarket((EMarketTypes)Enum.Parse(typeof(EMarketTypes), market));
            _interactor = new InteractorPost(postId, new OnePostController(DataService.RepositoryController.RepositoryPost), _notification, _repository, _repositoryQc); //TODO remove _notification, _repository, _repositoryQc
           
            var presenter = new PresenterPost(
                view:                   _postView, 
                interactor:             _interactor, 
                router:                 new RouterPost(Application.Context), 
                otherThemeStrings:      _otherThemeStrings,
                headerStylesHolder:     new PostHeaderStylesHolderDroid<GlobalControlsTheme>(DroidDAL.ThemeParser),
                socialStylesHolder:     new PostSocialStylesHolderDroid<GlobalControlsTheme>(DroidDAL.ThemeParser),
                bodyStylesHolder:       new PostBodyStylesHolderDroid<GlobalControlsTheme>(DroidDAL.ThemeParser),
                postLocale:             DataService.RepositoryController.RepositoryPost.LangPost,
                isPostDetailed:         false
            );

            _interactor.SendRequestForPosts();
        }

        public void TickNotify(DateTime nowTime)
        {
            _interactor.ChangeTime(nowTime);
        }
    }
}