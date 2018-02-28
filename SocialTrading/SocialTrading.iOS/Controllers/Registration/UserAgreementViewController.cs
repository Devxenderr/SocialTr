using UIKit;

using System;
using SocialTrading.iOS.Tools;

namespace SocialTrading.iOS
{
    public partial class UserAgreementViewController : UIViewController
    {
        private event Action _segue;


        public UserAgreementViewController (IntPtr handle) : base (handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _userAgreementView.SetConfig();

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            _segue += OnSegue;
			_userAgreementView.Segue = _segue;
		}

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            _segue -= OnSegue;
        }

		private void OnSegue()
		{
            PerformSegue(iOS_DAL.SegueStrings.ToRegPassFromAgreement, this);
		}
    }
}