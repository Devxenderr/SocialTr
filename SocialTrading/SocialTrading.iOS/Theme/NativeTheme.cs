﻿﻿using System;
using System.Collections.Generic;
using Foundation;
using SocialTrading.Theme;
using UIKit;

namespace SocialTrading.iOS.Theme
{
    public class NativeTheme
    {
		public Dictionary<string, UIColor> Colors { get; set; }
        public Dictionary<string, string> Images { get; set; }
		public Dictionary<string, int> FontSizes { get; set; }
        public Dictionary<string, UIFont> FontStyles { get; set; }
		public Dictionary<string, NSUnderlineStyle> UnderlineStyles { get; set; }
		public string Font { get; set; }

        public NativeTheme()
        {
			Colors = new Dictionary<string, UIColor>();
			Images = new Dictionary<string, string>();
			FontSizes = new Dictionary<string, int>();
			FontStyles = new Dictionary<string, UIFont>();
            UnderlineStyles = new Dictionary<string, NSUnderlineStyle>();
        }
    }
}
