using System;

using Foundation;
using UIKit;

namespace SocialTrading.iOS.Cells
{
    public partial class ToolCard : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("ToolCard");
        public static readonly UINib Nib;

        static ToolCard()
        {
            Nib = UINib.FromName("ToolCard", NSBundle.MainBundle);
        }

        protected ToolCard(IntPtr handle) : base(handle)
        {
            
        }


        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
        }

        public void SetData(String tool)
		{
            _toolLabel.Text = tool;		
		}
    }
}
