using System;
using System.ComponentModel;
using System.Threading;
using UIKit;
using Foundation;
using CoreAnimation;
using CoreGraphics;
using SocialTrading.iOS.Theme;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.Vipers.MoreOptions.OptionsCell.Interfaces;

namespace SocialTrading.iOS
{
    [DesignTimeVisible(true)]
    public partial class OptionCellView : UIView, IComponent, IViewOptionsCell
    {
        public IPresenterOptionsCellForView Presenter { get; set; }

        #region IComponent realization
        public ISite Site { get; set; }
        public event EventHandler Disposed;
        #endregion


        public OptionCellView (IntPtr handle) : base (handle)
        {
        }


        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            if (Site != null)
            {
                return;
            }

            NSBundle.MainBundle.LoadNib("OptionCellView", this, null);

            InvokeOnMainThread(() =>
            {
                var frame = _rootView.Frame;
                frame.Height = Frame.Height;
                frame.Width = Frame.Width;
                _rootView.Frame = frame;
                AddSubview(_rootView);
            });
            
            SetActions();
        }

        private void SetActions()
        {
            var gesture = new UITapGestureRecognizer(() =>
            {
                Presenter.CellClick();
            });
            AddGestureRecognizer(gesture);
            _optionLabel.UserInteractionEnabled = true;
            _optionImageView.UserInteractionEnabled = true;
            _rootView.UserInteractionEnabled = true;
            _backgroundView.UserInteractionEnabled = true;
        }

        public void SetBackgroundTheme(IViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _rootView.SetTheme(theme);
            });
        }

        public void SetImageTheme(IImageViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _backgroundView.SetTheme((IViewTheme)theme);
            });
        }

        public void SetTextTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _optionLabel.SetTheme(theme);
            });
        }

        public void SetImage(string imageName)
        {
            InvokeOnMainThread(() =>
            {
                _optionImageView.Image = UIImage.FromBundle(imageName);
            });
        }

        public void SetText(string localeString)
        {
            InvokeOnMainThread(() =>
            {
                _optionLabel.Text = localeString;
            });
        }
    }
}