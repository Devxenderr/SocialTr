using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MAST_UI_Portable
{
    public class AppInitializer
    {
        

        public static IApp StartApp(Platform platform, string simulatorName)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .EnableLocalScreenshots()
                    .DeviceSerial(simulatorName)
                    .ApkFile(ApplicationPath.ApkPath)
                    .StartApp();
            }
                return ConfigureApp
                    .iOS
                    .DeviceIdentifier(simulatorName)
                    .AppBundle(ApplicationPath.AppPath)
                    .StartApp();
            
        }
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .EnableLocalScreenshots()
                    .ApkFile(ApplicationPath.ApkPath)
                    .StartApp();
            }
            return ConfigureApp
                .iOS
                .AppBundle(ApplicationPath.AppPath)
                .StartApp();

        }
    }
}

