using UIKit;
using Foundation;

using System;
using System.Collections.Generic;

using SocialTrading.iOS.Cells;

namespace SocialTrading.iOS
{
    public class PostsDelegate : UICollectionViewDelegateFlowLayout
    {
        public List<nfloat> PostsHeight { get; set; }


        public PostsDelegate(List<nfloat> postsHeight)
        {
            PostsHeight = postsHeight;
        }

        //public override void CellDisplayingEnded(UICollectionView collectionView, UICollectionViewCell cell, NSIndexPath indexPath)
        //{
        //    var newsCell = cell as PostCardViewCell;
        //    newsCell?.Dispose();
        //}

        public override CoreGraphics.CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            if (PostsHeight == null || PostsHeight.Count == 0 || PostsHeight.Count <= indexPath.Row)
            {
                return new CoreGraphics.CGSize(collectionView.Frame.Width, 220);
            }
            return new CoreGraphics.CGSize(collectionView.Frame.Width, PostsHeight[indexPath.Row]);
        }
    }
}
