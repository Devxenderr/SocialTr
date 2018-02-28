using System;
using System.Drawing;

using UIKit;

namespace SocialTrading.iOS
{
    public class KeyboardToolbar : UIToolbar
    {
        public UIView prevTextFieldOrView { get; set; }
        public UIView currentTextFieldOrView { get; set; }

        public UIView nextTextFieldOrView { get; set; }

        public KeyboardToolbar() : base()
        {
            SetupToolbar();
        }

        public KeyboardToolbar(UIView textView)
        {
            this.currentTextFieldOrView = textView;

            SetupToolbar();
        }

        void SetupToolbar()
        {
            Frame = new RectangleF(0.0f, 0.0f, 320, 44.0f);
            TintColor = UIColor.DarkGray;
            Translucent = false;
            Items = new UIBarButtonItem[]
            {
        new
           UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
        new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate
                {
                    currentTextFieldOrView.ResignFirstResponder();
                })
            };

        }
    }
}
