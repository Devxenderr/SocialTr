using UIKit;
using Foundation;

using System;
using System.ComponentModel;

using SocialTrading.Tools.Interfaces;

namespace SocialTrading.iOS
{
    [DesignTimeVisible(true)]
    public partial class UserAgreementView : UIView, IComponent, ISetConfig
    {
        public Action Segue { private get; set; }


        public UserAgreementView (IntPtr handle) : base (handle)
        {
        }


		#region IComponent realization
		public ISite Site { get; set; }
		public event EventHandler Disposed;
		#endregion


		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			if (Site != null)
			{
				return;
			}

			NSBundle.MainBundle.LoadNib("UserAgreementView", this, null);

			var frame = _rootView.Frame;
			frame.Height = Frame.Height;
			frame.Width = Frame.Width;
			_rootView.Frame = frame;
			AddSubview(_rootView);
		}

        public void SetConfig()
        {
            InvokeOnMainThread(() =>
          {
              FillView();
              SetTheme();
          });
        }

        private void SetTheme()
        {
			
		}

        private void FillView()
        {
            
        }

        public void ViewDidDisappear()
        {
            ReleaseDesignerOutlets();
        }


 		// TODO move to extensions for iOS
		private UIColor ColorFromHex(string hexString)
		{
			hexString = hexString.Replace("#", "");

			int red = Int32.Parse(hexString.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
			int green = Int32.Parse(hexString.Substring(2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
			int blue = Int32.Parse(hexString.Substring(4, 2), System.Globalization.NumberStyles.AllowHexSpecifier);

			return UIColor.FromRGB(red, green, blue);
		}

        partial void BackButtonTouchUpInside(UIButton sender)
        {
            Segue?.Invoke();
        }
    }
}