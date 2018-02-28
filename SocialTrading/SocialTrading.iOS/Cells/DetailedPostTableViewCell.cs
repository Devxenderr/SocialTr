using System;

using UIKit;
using Foundation;

namespace SocialTrading.iOS.Cells
{
    public partial class DetailedPostTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("DetailedPostTableViewCell");
        public static readonly UINib Nib;

        public DetailedPostView DetailedPostView => _detailedPostView;
        //public NSLayoutConstraint PostHeightConstraint => _detailedPostHeightConstraint;

        static DetailedPostTableViewCell()
        {
            Nib = UINib.FromName("DetailedPostTableViewCell", NSBundle.MainBundle);
        }

        protected DetailedPostTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
