using UIKit;
using Foundation;

using System;

using SocialTrading.Theme;
using SocialTrading.Locale;
using SocialTrading.Service;
using SocialTrading.iOS.Theme;
using SocialTrading.iOS.Views;
using SocialTrading.iOS.Tools;
using SocialTrading.Connection;
using SocialTrading.iOS.Routers;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.Vipers.CreatePost.Interfaces;
using SocialTrading.Vipers.CreatePost.Implementation;

namespace SocialTrading.iOS
{
    public partial class CreatePostViewController : UIViewController
    {
        public ImagePickerDispatcher ImagePicker { get; private set; }
        public string SelectedKey { get; set; }

        private IPresenterCreatePost _presenter;
        private IInteractorCreatePost _interactor;


        public CreatePostViewController (IntPtr handle) : base (handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _createPostView.NavigationBar = NavigationController?.NavigationBar;
            _createPostView.NavigationItem = NavigationItem;

            _interactor = new InteractorCreatePost(new CreatePostController(ConnectionController.GetInstance(), WebMsgParser.ParseResponseCreatePost, DataService.NotificationCenter, 
                DataService.RepositoryController.RepoQc), DataService.RepositoryController.RepositoryCreatePost, DataService.RepositoryController.RepositoryUserAuth);

            _presenter = new PresenterCreatePost(_createPostView, _interactor, new RouterCreatePost(this), new CreatePostStylesHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser), Localization.Lang); 

            ImagePicker = new ImagePickerDispatcher
            {
                OnGetImageFromGallery = (imageString) =>
                {
                    _createPostView.ImageSelected(imageString);
                }
            };


            HideShowKeyboard hideShowKeyboard = new HideShowKeyboard(_createPostView);


			NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.DidShowNotification, hideShowKeyboard.KeyBoardUpNotification);		
			NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, hideShowKeyboard.KeyBoardDownNotification);
        }


        public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
		    NavigationController.NavigationBar.Hidden = false;
            ThemeHelper.PerformTheme(Themes.GetCreatePostTheme());
            _createPostView.Subscribe();

		    if (SelectedKey != null)
		    {
                _presenter.SaveSelectedTool(SelectedKey);
		    }

            _presenter.LoadData();
            _presenter.SetConfig();
        }
        
        public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
            _presenter.SaveData();
            _createPostView.UnSubscribe();
		}

        public override void ViewDidUnload()
        {
            base.ViewDidUnload();
            ImagePicker.Dispose();
            _interactor.Dispose();
        }

        public override void DidMoveToParentViewController(UIViewController parent)
        {
            base.DidMoveToParentViewController(parent);
            _presenter.DisposeRepositoryCreatePost();
        }
    }
}