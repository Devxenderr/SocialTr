using UIKit;

using System;

namespace SocialTrading.iOS
{
    public partial class TableViewMoreOptions : UITableView
    {
        public TableViewMoreOptions(IntPtr handle) : base(handle)
        {
        }

        public void RegisterNib(string key, UINib nib)
        {
            RegisterNibForCellReuse(nib, key);
        }
    }
}