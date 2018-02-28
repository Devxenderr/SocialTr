using System;

using UIKit;
using Foundation;

using SocialTrading.iOS.Theme;
using SocialTrading.iOS.Cells.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.TextView;

namespace SocialTrading.iOS.Cells
{
    public partial class ToolViewCell : UITableViewCell, IToolViewCell
    {
        public static readonly NSString Key = new NSString("ToolViewCell");
        public static readonly UINib Nib;

        public UILabel ToolLabel { get => _toolLabel; private set => throw new NotImplementedException(); }

        static ToolViewCell()
        {
            Nib = UINib.FromName("ToolViewCell", NSBundle.MainBundle);
        }

        protected ToolViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void SetData(string tool)
        {
            _toolLabel.Text = tool;
        }

        public void SetThemes(IViewTheme viewTheme, ITextViewTheme labelTheme)
        {
            this.SetTheme(viewTheme);
            ToolLabel.SetTheme(labelTheme);
        }
    }
}
