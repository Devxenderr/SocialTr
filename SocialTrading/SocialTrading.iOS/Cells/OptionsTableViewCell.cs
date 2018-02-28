using System;

using UIKit;
using Foundation;

using SocialTrading.Tools;
using SocialTrading.iOS.Theme;
using SocialTrading.iOS.Tools;
using SocialTrading.Tools.Interfaces;
using SocialTrading.Tools.Enumerations;
using SocialTrading.iOS.Routers.MoreOptions;
using SocialTrading.Vipers.MoreOptions.OptionsCell.Interfaces;
using SocialTrading.Vipers.MoreOptions.OptionsCell.Implementation;

namespace SocialTrading.iOS.Cells
{
    public partial class OptionsTableViewCell : UITableViewCell, IOptionCell
    {
        public static readonly NSString Key = new NSString("OptionsTableViewCell");
        public static readonly UINib Nib;

        private UIViewController _controller;

        static OptionsTableViewCell()
        {
            Nib = UINib.FromName("OptionsTableViewCell", NSBundle.MainBundle);
        }

        protected OptionsTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void SetViewController(UIViewController controller)
        {
            _controller = controller;
        }

        public void SetData(EItemsOptions data)
        {
            IPresenterOptionsCell presenter = new PresenterOptionsCell(_optionsCellView, new InteractorOptionsCell(DAL.DictionaryForOptions, data), new RouterOptionsCell(_controller, Locale.Localization.Lang), new OptionsCellStylesHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser));
            presenter.SetConfig();
        }
    }
}
