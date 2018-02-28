using System;

using Android.App;
using Android.Runtime;
using SocialTrading.Droid.Theme;
using SocialTrading.Droid.Tools;
using SocialTrading.ThemesStyles;


namespace SocialTrading.Droid
{
    [Application]
    internal class SocialTradingApplication : Application
    {
        protected SocialTradingApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            Websockets.Droid.WebsocketConnection.Link();
            DroidDAL.ThemeParser = new ThemeParser<GlobalControlsTheme>();
            ThemesHelperNew.ThemeParser = DroidDAL.ThemeParser; //TODO REMOVE
        }
    }
}