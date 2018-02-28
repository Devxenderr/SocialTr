using Foundation;
using SocialTrading.iOS.Cells;
using System;
using UIKit;

namespace SocialTrading.iOS
{
    public partial class ToolTableView : UITableView
    {
        public ToolTableView (IntPtr handle) : base (handle)
        {
        }

        public void RegisterNib(string key, UINib nib)
        {
            RegisterNibForCellReuse(nib, key);
        }
    }
}