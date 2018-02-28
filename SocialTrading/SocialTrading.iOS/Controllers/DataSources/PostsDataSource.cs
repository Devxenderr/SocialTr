using UIKit;
using Foundation;

using System;
using System.Collections.Generic;

using SocialTrading.iOS.Cells;
using SocialTrading.Theme.ThemeStrings;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Service.Interfaces.Notifications;

namespace SocialTrading.iOS
{
    public class PostsDataSource : UICollectionViewDataSource
    {
        public override nint GetItemsCount(UICollectionView collectionView, nint section) => _postIds?.Count ?? 0;

        public List<string> PostIds
        {
            get => _postIds;
            set
            {
                if (value != null && value.Count != 0)
                {
                    _postIds = value;
                }
            }
        }

        private List<string> _postIds;

        private readonly PostsViewController _viewController;

        private readonly IRepositoryQc _repositoryQc;
        private readonly IRepositoryPost _repository;
        private readonly INotificationCenter _notification;
        private readonly PostOtherThemeStrings _otherThemeStrings;

        private readonly Action<int, nfloat> _postHeightCounted;

        public PostsDataSource(Action<int, nfloat> postHeightCounted, PostsViewController viewController, INotificationCenter notification,
            IRepositoryPost repository, IRepositoryQc repositoryQc, PostOtherThemeStrings otherThemeStrings)
        {
            _viewController = viewController;

            _repository = repository;
            _repositoryQc = repositoryQc;
            _notification = notification;

            _otherThemeStrings = otherThemeStrings;

            _postHeightCounted = postHeightCounted;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var newsCell = collectionView.DequeueReusableCell(PostCardViewCell.Key, indexPath) as PostCardViewCell;

            newsCell.SetConfig(_repository, _repositoryQc, _notification, _otherThemeStrings, _viewController, _postIds[indexPath.Row],
                               (int)collectionView.Bounds.Width, indexPath.Row, _postHeightCounted, newsCell.Frame.Height);

            return newsCell;
        }
    }
}
