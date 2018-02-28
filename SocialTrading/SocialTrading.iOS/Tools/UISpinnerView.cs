using System;
using CoreGraphics;
using UIKit;

namespace SocialTrading.iOS.Tools
{
    public class UISpinnerView : UIView
    {
        private readonly UIActivityIndicatorView _activitySpinner;


        public UISpinnerView(CGRect frame) : base(frame)
        {
            BackgroundColor = UIColor.Black;
            Alpha = 0.5f;

            nfloat centerX = Frame.Width / 2;
            nfloat centerY = Frame.Height / 2;

            _activitySpinner = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.WhiteLarge);

            _activitySpinner.Frame = new CGRect(
                centerX - _activitySpinner.Frame.Width / 2,
                centerY - _activitySpinner.Frame.Height / 2,
                _activitySpinner.Frame.Width,
                _activitySpinner.Frame.Height);
            _activitySpinner.AutoresizingMask = UIViewAutoresizing.All;

            AddSubview(_activitySpinner);

            Hidden = true;
        }

        internal void StartAnimating()
        {
            _activitySpinner.StartAnimating();

            Hidden = false;

            Superview.BringSubviewToFront(this);
        }

        internal void StopAnimating()
        {
            _activitySpinner.StopAnimating();

            Hidden = true;

            Superview.SendSubviewToBack(this);
        }
    }
}