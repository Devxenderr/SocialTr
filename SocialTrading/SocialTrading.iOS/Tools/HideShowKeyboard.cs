using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace SocialTrading.iOS.Tools
{
    public class HideShowKeyboard
    {
        private UIView activeview;                 
		private float scroll_amount = 0.0f;   
		private float bottom = 0.0f;  
          
		private bool moveViewUp = false;


        public HideShowKeyboard(UIView view)
        {
            activeview = view;
        }

        public void KeyBoardUpNotification(NSNotification notification)
		{
			var val = (NSValue)notification.UserInfo.ValueForKey(UIKeyboard.FrameEndUserInfoKey);
			CGRect r = val.CGRectValue;

            bottom = (float)(activeview.Frame.Y + activeview.Frame.Height );

			scroll_amount = (float)(r.Height - (activeview.Frame.Size.Height - bottom));

			if (scroll_amount > 0)
			{
				moveViewUp = true;
				ScrollTheView(moveViewUp);
			}
			else
			{
				moveViewUp = false;
			}
		}

        public void KeyBoardDownNotification(NSNotification notification)
		{
			if (moveViewUp) 
            { 
                ScrollTheView(false); 
            }
		}

		private void ScrollTheView(bool move)
		{
			UIView.BeginAnimations(string.Empty, System.IntPtr.Zero);
			UIView.SetAnimationDuration(0.3);

			CGRect frame = activeview.Frame;
			if (move)
			{
				frame.Y -= scroll_amount;
			}
			else
			{
				frame.Y += scroll_amount;
				scroll_amount = 0;
			}

			activeview.Frame = frame;
			UIView.CommitAnimations();
		}
    }
}
