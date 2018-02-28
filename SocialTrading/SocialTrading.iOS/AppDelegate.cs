﻿using UIKit;
using Foundation;

using Facebook.CoreKit;
 using HockeyApp.iOS;
 using SocialTrading.iOS.Theme;
 using SocialTrading.iOS.Tools;
 using SocialTrading.ThemesStyles;

using SocialTrading.iOS.Theme;
using SocialTrading.iOS.Tools;
using SocialTrading.ThemesStyles;

namespace SocialTrading.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations

		string appId = "711561152361700";
		string appName = "SocialTrading";

		public override UIWindow Window {
			get;
			set;
		}

	    public override bool WillFinishLaunching(UIApplication application, NSDictionary launchOptions)
	    {
	        iOS_DAL.ThemeParser = new ThemeParser<GlobalControlsTheme>();
	        ThemesHelperNew.ThemeParser = iOS_DAL.ThemeParser; // TODO REMOVE

	        var manager = BITHockeyManager.SharedHockeyManager;
	        manager.Configure("d3eafd8162144700ad01c9877fac150c");
	        manager.StartManager();
	        manager.Authenticator.AuthenticateInstallation();

            return true;
	    }

	    public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
#if BuildUITestCI
            Xamarin.Calabash.Start(); //Added for UI_test. ( NuGet Xamarin.TestCloud.Agent ) - Don't delete. Author = MihayloKotlyar  
#endif
			// ...
			// Starts new view controller
		//	Window.RootViewController = UIStoryboard.FromName("Main", null).InstantiateViewController("MoreOptionsViewController");

            Websockets.Ios.WebsocketConnection.Link();

			// This method verifies if you have been logged into the app before, and keep you logged in after you reopen or kill your app.
			bool authFlag = ApplicationDelegate.SharedInstance.FinishedLaunching(application, launchOptions);
            return true;
		}


		public override void OnResignActivation (UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground (UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground (UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated (UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate (UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}

		public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			// We need to handle URLs by passing them to their own OpenUrl in order to make the SSO authentication works.
            var res = ApplicationDelegate.SharedInstance.OpenUrl(application, url, sourceApplication, annotation);
            return res;
		}

	}
}


