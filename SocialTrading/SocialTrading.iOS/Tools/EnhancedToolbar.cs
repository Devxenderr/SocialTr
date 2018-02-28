using System;
using System.Drawing;
using UIKit;

namespace SocialTrading.iOS
{
    public class EnhancedToolbar : UIToolbar
    {
        public UIView currentTextFieldOrView { get; set; }

        public EnhancedToolbar() : base() 
        {
            SetupToolbar();
        }

        public EnhancedToolbar(UIView editTextView)
        {
            this.currentTextFieldOrView = editTextView;

            SetupToolbar();
        }

        void SetupToolbar()
        {
            Frame = new RectangleF(0.0f, 0.0f, 320, 32.0f);
            TintColor = UIColor.DarkGray;
            Translucent = false;
            Items = new UIBarButtonItem[]
            {
                new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
                new UIBarButtonItem(UIBarButtonSystemItem.Done, (s,e) => HideKeyboard())
            };
        }

        public void HideKeyboard()
        {
            currentTextFieldOrView.ResignFirstResponder();
        }
    }
}
