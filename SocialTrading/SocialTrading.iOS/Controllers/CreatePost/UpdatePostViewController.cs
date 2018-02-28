using System;

using UIKit;
using Foundation;

using SocialTrading.Locale;
using SocialTrading.Service;
using SocialTrading.iOS.Theme;
using SocialTrading.iOS.Tools;
using SocialTrading.iOS.Views;
using SocialTrading.Connection;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.iOS.Routers.UpdatePost;
using SocialTrading.Vipers.UpdatePost.Interfaces;
using SocialTrading.Vipers.UpdatePost.Implementation;

namespace SocialTrading.iOS
{
    public partial class UpdatePostViewController : UIViewController
    {
        public ImagePickerDispatcher ImagePicker { get; private set; }
        public string PostId { get; set; }

        private IPresenterUpdatePost _presenter;
        private IInteractorUpdatePost _interactor;


        public UpdatePostViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _updatePostView.NavigationBar = NavigationController?.NavigationBar;
            _updatePostView.NavigationItem = NavigationItem;
            _updatePostView.SetConfigToolbar();

            _interactor = new InteractorUpdatePost(PostId, new UpdatePostController(ConnectionController.GetInstance(), WebMsgParser.ParseResponseCreatePost, DataService.NotificationCenter,
                DataService.RepositoryController.RepoQc, DataService.RepositoryController.RepositoryPost), DataService.RepositoryController.RepositoryUpdatePost, 
                DataService.RepositoryController.RepositoryPost, DataService.RepositoryController.RepositoryUserAuth);

            _presenter = new PresenterUpdatePost(_updatePostView, _interactor, new RouterUpdatePost(this), new UpdatePostStylesHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser), Localization.Lang);


            ImagePicker = new ImagePickerDispatcher
            {
                OnGetImageFromGallery = (imageString) =>
                {
                    _presenter.ImageSelected(imageString);
                }
            };
            
            HideShowKeyboard hideShowKeyboard = new HideShowKeyboard(_updatePostView);
            
            NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.DidShowNotification, hideShowKeyboard.KeyBoardUpNotification);
            NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, hideShowKeyboard.KeyBoardDownNotification);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            _updatePostView.Subscribe();
            _presenter.SetTheme(new UpdatePostStylesHolderIOS<GlobalControlsTheme>(iOS_DAL.ThemeParser));
            _presenter.SetLocale(Localization.Lang);
            _presenter.SetConfig();
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            _presenter.NeedToSaveData();
            _updatePostView.UnSubscribe();
        }
    }
}