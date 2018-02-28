using UIKit;
using Foundation;

using System;

using SocialTrading.iOS.Cells;

namespace SocialTrading.iOS
{
    public partial class CollectionViewPosts : UICollectionView
    {
        public CollectionViewPosts (IntPtr handle) : base (handle)
        {
        }

        public void Initialize()
        {
            RegisterNibForCell(UINib.FromName(PostCardViewCell.Key, NSBundle.MainBundle), PostCardViewCell.Key);
        }
    }
}