using System;
using System.ComponentModel;

using UIKit;
using Foundation;
using SocialTrading.Theme;
using SocialTrading.Locale;
using SocialTrading.iOS.Theme;
using SocialTrading.iOS.Tools;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.Vipers.Authorization.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;

namespace SocialTrading.iOS
{
    [DesignTimeVisible(true)]
    public partial class AuthView : UIView, IComponent, IViewAuth
    {
        public IPresenterAuth Presenter { get; set; }
        private UISpinnerView _spinner = null;

        //private FacebookAuth _facebookAuth;


        public AuthView(IntPtr handle) : base(handle)
        {
        }

        #region IComponent realization
        public ISite Site { get; set; }
        public event EventHandler Disposed;
        #endregion


        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            if (Site != null)
            {
                return;
            }

            NSBundle.MainBundle.LoadNib("AuthView", this, null);

            InvokeOnMainThread(() =>
            {
                var frame = _rootView.Frame;
                frame.Height = Frame.Height;
                frame.Width = Frame.Width;
                _rootView.Frame = frame;
                AddSubview(_rootView);
            });
        }

        public void ViewDidDisappear()
        {
            ReleaseDesignerOutlets();
        }

        #region Event handlers

        partial void EmailDidEndEditText(UITextField sender)
        {
            Presenter.EmailInput(sender.Text.Trim().ToLower());
        }

        partial void PassDidEndEditText(UITextField sender)
        {
            Presenter.PasswordInput(sender.Text);
        }

        partial void TouchUpInsideButtonForgot(UIButton sender)
        {
            Presenter.ForgotPasswordClick();
        }

        partial void TouchUpInsideButtonAuth(UIButton sender)
        {
            Presenter.LoginClick(_emailEditText.Text.Trim().ToLower(), _passEditText.Text);
        }

        partial void TouchUpInsideButtonReg(UIButton sender)
        {
            Presenter.RegistrationClick();
        }

        partial void TouchUpInsideButtonFacebook(UIButton sender)
        {
            FacebookLoginClick();
        }

        #endregion

        #region IViewAuth

        private void HideShowKeyboard()
        {
            _passEditText.ShouldReturn += (textField) =>
            {
                textField.ResignFirstResponder();
                return true;
            };

            _emailEditText.ShouldReturn += (textField) =>
            {
                textField.ResignFirstResponder();
                return true;
            };

            UITapGestureRecognizer tapGestureRecognizer = new UITapGestureRecognizer(() =>
            {
                _passEditText.ResignFirstResponder();
                _emailEditText.ResignFirstResponder();
            });

            AddGestureRecognizer(tapGestureRecognizer);
        }

        private void InitSpinner()
        {
            if (_spinner != null)
            {
                return;
            }
            _spinner = new UISpinnerView(_rootView.Frame);

            _rootView.AddSubview(_spinner);
        }

        public void SetHeaderLabelTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _headerLabel.SetTheme(theme);                
            });
        }

        public void SetEmailLabelTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _emailLabel.SetTheme(theme);               
            });
        }

        public void SetPasswordLabelTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _passwordLabel.SetTheme(theme);
            });
        }

        public void SetNoAccountLabelTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _noAccountLabel.SetTheme(theme);
            });
		}

        public void SetSocialNetworkLabelTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                //_socialNetworksLabel.SetTheme(themeName);
            });
        }

        public void SetLogInButtonTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _logInButton.SetTheme(theme);
            });
        }

        public void SetRegistrationButtonTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _registrationButton.SetTheme(theme);
            });
		}

        public void SetForgetPassTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _forgetPassButton.SetTheme(theme);
            });
        }

        public void SetViewTheme(IImageViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _rootView.SetTheme((IViewTheme)theme);
            });
        }

        public void SetFacebookButtonTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _fbAuthButton.SetTheme(theme);
            });
        }

        public void SetFbAuthTheme(string backgroundImage, string tintColor)
        {
            // TODO: Create theme
        }

        public void SetGoogleAuthTheme(string backgroundImage, string tintColor)
        {
            // TODO: Create theme
        }

        public void SetOkAuthTheme(string backgroundImage, string tintColor)
        {
            // TODO: Create theme
        }

        public void SetVkAuthTheme(string backgroundImage, string tintColor)
        {
            // TODO: Create theme
        }

        public void SetLogoImageViewTheme(IImageViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _logoImage.SetTheme(theme);
            });
        }

		public void SetEmailEditTextTheme(IEditTextTheme theme)
		{
            InvokeOnMainThread(() =>
            {
                _emailEditText.SetTheme(theme);
            });
		}

		public void SetPasswordEditTextTheme(IEditTextTheme theme)
		{
		    InvokeOnMainThread(() =>
		    {
		        _passEditText.SetTheme(theme);
		    });
        }

        public void SetFacebookButtonLocale(string enterFacebook)
        {
            _fbAuthButton.SetTitle(enterFacebook, UIControlState.Normal);
        }

        public void SetEmailLocale(string emailHint)
        {
            _emailLabel.Text = emailHint;
        }

        public void SetPassLocale(string passwordHint)
        {
            _passwordLabel.Text = passwordHint;
        }

        public void SetRegButtonLocale(string regButton)
        {
            _registrationButton.SetTitle(regButton, UIControlState.Normal);
        }

        public void SetAuthButtonLocale(string logInButton)
        {
            _logInButton.SetTitle(logInButton, UIControlState.Normal);
        }

        public void SetForgotPassLocale(string forgetPasswordLink)
        {
            _forgetPassButton.SetTitle(forgetPasswordLink, UIControlState.Normal);
        }

        public void SetSloganLocale(string authSlogan)
        {
            _headerLabel.Text = authSlogan;
        }

        public void SetNoAccountLocale(string authNoAccount)
        {
            _noAccountLabel.Text = authNoAccount;
        }

        public void SetSocialEnterLocale(string authSocialEnter)
        {
           // _socialNetworksLabel.Text = authSocialEnter;
        }

        public void ShowAlert(string title, string okLocale, string message)
        {
            InvokeOnMainThread(() =>
            {
                var alert = new UIAlertView
                {
                    Title = title,
                    Message = message
                };

                alert.AddButton(okLocale);
                alert.Show();
            });
        }


        public void SetConfig()
        {
            ThemeHelper.PerformTheme(Themes.GetAuthTheme());

            InvokeOnMainThread(() =>
            {
                FillView();
                HideShowKeyboard();
            });
        }

        private void FillView()
        {
            _emailEditText.ShouldChangeCharacters = (textField, range, replacementString) =>
            {
                var newLength = textField.Text.Length + replacementString.Length - range.Length;
                return newLength <= 256;
            };

            _passEditText.ShouldChangeCharacters = (textField, range, replacementString) =>
            {
                var newLength = textField.Text.Length + replacementString.Length - range.Length;
                return newLength <= 128;
            };

            Presenter.SetLocale();
        }

        public void SetInteractionUnavailable()
        {
            SetInteraction(false);
        }

        public void SetInteractionAvailable()
        {
            SetInteraction(true);
        }

        private void SetInteraction(bool availability)
        {
            InvokeOnMainThread(() =>
            {
                _emailEditText.Enabled = availability;
                _passEditText.Enabled = availability;
                _forgetPassButton.Enabled = availability;
                _fbAuthButton.Enabled = availability;
                //_googleAuthButton.Enabled = availability;
                //_vkAuthButton.Enabled = availability;
                //_okAuthButton.Enabled = availability;
                _logInButton.Enabled = availability;
                _registrationButton.Enabled = availability;
            });
        }

        public void FacebookLoginClick()
        {
            Presenter.FacebookLoginClick();
        }

        public void GoogleLoginClick()
        {
            Presenter.GoogleLoginClick();
        }

        public void VkLoginClick()
        {
            Presenter.VkLoginClick();
        }

        public void OkLoginClick()
        {
            Presenter.OkLoginClick();
        }

        public void ShowSpinner()
        {
            if (_spinner == null)
            {
                InitSpinner();
            }
            _spinner.StartAnimating();
            _emailEditText.Enabled = false;
            _passEditText.Enabled = false;
        }

        public void HideSpinner()
        {
            _spinner.StopAnimating();
            _emailEditText.Enabled = true;
            _passEditText.Enabled = true;
        }

        #endregion
    }
}