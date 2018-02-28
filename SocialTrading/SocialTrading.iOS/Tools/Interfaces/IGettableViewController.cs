using UIKit;
using System;

namespace SocialTrading.iOS.Tools.Interfaces
{
    public interface IGettableViewController
    {
        Func<UIView, UIViewController> GetViewController { get; }
    }
}
