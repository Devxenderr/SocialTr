using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAST_UI_Portable
{
    static class ApplicationPath
    {
        // For Local test
        //public const string ApkPath = @"D:\apk\MAST_UI.apk";
        //public const string ApkPath = @"../../../SocialTrading/SocialTrading.Android/bin/Release/SocialTrading.Android.apk";
        //private const string AppPath = @" / Users/Mac/Downloads/buildAgent/work/e735f8a608aeff97/SocialTrading/SocialTrading.iOS/bin/iPhoneSimulator/Release/SocialTrading.iOS.app";
        //private const string AppPath = @"/Volumes/Disk C/Projects/social_trading/SocialTrading/SocialTrading.iOS/bin/iPhoneSimulator/Release/SocialTrading.iOS.app";

        // For TC
        //public const string AppPath = @"/Users/Mac/Downloads/buildAgent/work/e735f8a608aeff97/SocialTrading/SocialTrading.iOS/bin/iPhoneSimulator/Release/SocialTrading.iOS.app";
        //public const string ApkPath = @"/Users/Mac/Downloads/buildAgent/work/e735f8a608aeff97/SocialTrading/SocialTrading.Android/bin/Release/SocialTrading.Android.apk";
        public const string AppPath = @"../../../SocialTrading/SocialTrading.iOS/bin/iPhoneSimulator/BuildUITestCI/SocialTrading.iOS.app";
        public const string ApkPath = @"../../../SocialTrading/SocialTrading.Android/bin/BuildUITestCI/com.investarena.app.apk";

    }
}
