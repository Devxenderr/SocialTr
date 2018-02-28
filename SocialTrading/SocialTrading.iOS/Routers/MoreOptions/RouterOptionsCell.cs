using UIKit;

using SocialTrading.Locale; 
using SocialTrading.Service;
using SocialTrading.iOS.Tools;
using SocialTrading.DTO.Request.RA;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Controllers;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Vipers.Controllers.Interfaces;
using SocialTrading.Vipers.MoreOptions.OptionsCell.Interfaces;

namespace SocialTrading.iOS.Routers.MoreOptions
{
    public class RouterOptionsCell : IRouterOptionsCell
    {
        private UIViewController _viewController;
        private ILang _locale;
        private UISpinnerView _spinner;
        private ILogOutController _logOutController;

        public RouterOptionsCell(UIViewController viewController, ILang locale)
        {
            _viewController = viewController;
            _locale = locale;
            _logOutController = new LogOutController(Connection.ConnectionController.GetInstance(), RepositoryController.GetInstance());
            _logOutController.OnRecieveModel += OnMessage;
        }

        private void OnMessage(IModel response)
        {
            HideSpinner();
            switch (response.ControllerStatus)
            {
                case EControllerStatus.Ok:
                    GoToAuth();
                    break;
                case EControllerStatus.Processing:
                    ShowSpinner();
                    break;
                case EControllerStatus.None:
                case EControllerStatus.Error:
                case EControllerStatus.NoConnection:
                default:
                    ShowError();
                    break;
            }
        }

        private void ShowError()
        {
            var alert = UIAlertController.Create(_locale.Error, _locale.UnknownError, UIAlertControllerStyle.Alert);            
            alert.AddAction(UIAlertAction.Create(_locale.OK, UIAlertActionStyle.Destructive, null));
            _viewController.PresentViewController(alert, true, null);
        }

        private void GoToAuth()
        {
            _viewController.PresentViewController(UIStoryboard.FromName("Main", null).InstantiateViewController("AuthViewController"), true, null);            
        }

        private void HideSpinner()
        {
            if (_spinner != null)
            {
                _spinner.StopAnimating();
            }            
        }

        private void ShowSpinner()
        {
            if (_spinner == null)
            {
                InitSpinner();
            }
            _spinner.StartAnimating();
        }

        public void GoTo(EItemsOptions option)
        {
            switch (option)
            {
                case EItemsOptions.EditProfileCell:
                    var viewControllerEditProfile = UIStoryboard.FromName("Main", null).InstantiateViewController("ProfileEdit");
                    _viewController.NavigationController?.PushViewController(viewControllerEditProfile, true);
                    break;
                case EItemsOptions.EditContactCell:
                    var viewController = UIStoryboard.FromName("Main", null).InstantiateViewController("EditContact");
                    _viewController.NavigationController?.PushViewController(viewController, true);
                    break;
                case EItemsOptions.LogoutCell:
                    LogOut();                    
                    break;
            }
        }

        private void LogOut()
        {
            var alert = UIAlertController.Create(_locale.MoreOptionsLogOut, _locale.LogoutAlert, UIAlertControllerStyle.Alert);

            alert.AddAction(UIAlertAction.Create(_locale.Cancel, UIAlertActionStyle.Cancel, null));
            alert.AddAction(UIAlertAction.Create(_locale.OK, UIAlertActionStyle.Destructive, a => 
            {
                _logOutController.Send(new LogOutModel());
            }));
            
            _viewController.PresentViewController(alert, true, null);
        }

        private void InitSpinner()
        {
            if (_spinner != null)
            {
                return;
            }
            _spinner = new UISpinnerView(UIScreen.MainScreen.Bounds);
            UIApplication.SharedApplication.KeyWindow.InvokeOnMainThread(() =>
            {
                UIApplication.SharedApplication.KeyWindow.AddSubview(_spinner);
                UIApplication.SharedApplication.KeyWindow.BringSubviewToFront(_spinner);
            });
        }
    }
}