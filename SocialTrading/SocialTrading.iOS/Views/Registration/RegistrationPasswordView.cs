using UIKit;
using Foundation;

using System;
using System.ComponentModel;

using SocialTrading.Theme;
using SocialTrading.iOS.Tools;
using SocialTrading.iOS.Theme;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Vipers.Registration.Password.Interfaces;

namespace SocialTrading.iOS
{
    [DesignTimeVisible(true)]
    public partial class RegistrationPasswordView : UIView, IComponent, IViewRegPass
    {
		public IPresenterRegPass Presenter { get; set; }
        private UISpinnerView _spinner = null;

        public RegistrationPasswordView(IntPtr handle) : base(handle)
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

            NSBundle.MainBundle.LoadNib("RegistrationPasswordView", this, null);

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

        #region Event Handlers
        partial void TouchUpInsideButtonReg(UIButton sender)
        {
            InitSpinner();
            Presenter.RegisterClick();
        }

        partial void TouchUpInsideButtonUserAgreement(UIButton sender)
        {
            Presenter.UserAgreementClick();
        }

        partial void DidEndEditTextPass(UITextField sender)
        {
            Presenter.PasswordInput();
        }

        partial void ChangedEditTextConfirmPass(UITextField sender)
        {
            if (sender.Text.Length >= _passEditText.Text.Length)
            {
                Presenter.PasswordConfirmInput();
            }
		}

		partial void ChangedEditTextPass(UITextField sender)
		{
            if (sender.Text.Length <= _confirmPassEditText.Text.Length)
			{
                Presenter.PasswordConfirmInput();
			}
		}

		partial void BackButtonTouchUpInside(UIButton sender)
		{
			Presenter.BackClick();
		}
        #endregion

        #region IViewRegPass
        
        public void ShowRegSuccess(string title, string message)
        {
            ShowAlert(title, message, delegate { Presenter.AlertOkClick(); });
        }

        public void ShowRegFail(string title, string message)
        {
            ShowAlert(title, message, delegate { });
        }

        public void SetPassword(string pass)
        {
            InvokeOnMainThread(() =>
            {
                _passEditText.Text = pass;
            });
        }

        public void SetConfirmPass(string confirmPass)
        {
            InvokeOnMainThread(() =>
            {
                _confirmPassEditText.Text = confirmPass;
            });
        }

        public string GetPassword()
        {
            return _passEditText.Text;
        }

        public string GetConfirmPassword()
        {
            return _confirmPassEditText.Text;
        }


        public void SetHeaderLabelTheme(ITextViewTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _passwordHeader.SetTheme(themeName);
            });
        }

        public void SetPasswordLabelTheme(ITextViewTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _passwordLabel.SetTheme(themeName);
            });
        }

        public void SetConfirmPasswordLabelTheme(ITextViewTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _passwordConfirmLabel.SetTheme(themeName);
            });
        }

        public void SetRegButtonTheme(IButtonTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _registerButton.SetTheme(themeName);
            });
        }

        public void SetViewTheme(IImageViewTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _rootView.SetTheme((IViewTheme)themeName);
            });
        }

        public void SetLogoImageViewTheme(IImageViewTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _logoImage.SetTheme(themeName);
            });
        }

		public void SetUserAgreementTheme(IButtonTheme mainThemeName, string mainText, IButtonTheme attrThemeName, string attrText, int position)
		{
		    InvokeOnMainThread(() =>
		    {
		        _userAgreementLink.SetTheme(mainThemeName, mainText, attrThemeName, attrText, position);
		    });
		}

        public void SetPasswordEditTextTheme(IEditTextTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _passEditText.SetTheme(themeName);
            });
        }

        public void SetConfirmPasswordEditTextTheme(IEditTextTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _confirmPassEditText.SetTheme(themeName);
            });
        }

		public void SetBackButtonTheme(IImageButtonTheme themeName)
		{
		    InvokeOnMainThread(() =>
		    {
		        _backImageButton.SetTheme((IImageViewTheme)themeName);
		    });
		}

		public void SetFeatureImageTheme(IImageViewTheme image)
		{
		    InvokeOnMainThread(() =>
		    {
		        _featureImage.SetTheme(image);
		    });
		}

		public void SetFeatureTextTheme(ITextViewTheme themeName)
		{
		    InvokeOnMainThread(() =>
		    {
		        _featureText.SetTheme(themeName);
		    });
		}


        public void SetPasswordLocale(string passwordHint)
        {
            InvokeOnMainThread(() =>
            {
                _passwordLabel.Text = passwordHint;
            });
        }

        public void SetConfirmPasswordLocale(string regPassConfirmHint)
        {
            InvokeOnMainThread(() =>
            {
                _passwordConfirmLabel.Text = regPassConfirmHint;
            });
        }

        public void SetRegButtonLocale(string regButton)
        {
            InvokeOnMainThread(() =>
            {
                _registerButton.SetTitle(regButton, UIControlState.Normal);
            });
        }

        public void SetUserAgreementLocale(string regUserAgreementLink)
        {
            InvokeOnMainThread(() =>
            {
                _userAgreementLink.SetTitle(regUserAgreementLink, UIControlState.Normal);   // TO REMOVE???
            });
        }

        public void SetTitleLocale(string regPassTextView)
        {
            InvokeOnMainThread(() =>
            {
                _passwordHeader.Text = regPassTextView;
            });
        }

		public void SetFeatureTextLocale(string featureText)
		{
		    InvokeOnMainThread(() =>
		    {
		        _featureText.Text = featureText;
		    });
		}


        public void SetConfig()
        {
            InvokeOnMainThread(() =>
            {
                ThemeHelper.PerformTheme(Themes.GetRegTheme());
                FillView();
                HideShowKeyboard();
            });
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

        private void FillView()
        {
            _passEditText.ShouldChangeCharacters = (textField, range, replacementString) =>
            {
                var newLength = textField.Text.Length + replacementString.Length - range.Length;
                return newLength <= 128;
            };

            _confirmPassEditText.ShouldChangeCharacters = (textField, range, replacementString) =>
            {
                var newLength = textField.Text.Length + replacementString.Length - range.Length;
                return newLength <= 128;
            };

            Presenter.SetLocale();
        }

        private void HideShowKeyboard()
        {
            _passEditText.ShouldReturn += (textField) =>
            {
                textField.ResignFirstResponder();
                return true;
            };

            _confirmPassEditText.ShouldReturn += (textField) =>
            {
                textField.ResignFirstResponder();
                return true;
            };

            UITapGestureRecognizer tapGestureRecognizer = new UITapGestureRecognizer(() =>
            {
                _passEditText.ResignFirstResponder();
                _confirmPassEditText.ResignFirstResponder();
            });

            AddGestureRecognizer(tapGestureRecognizer);
        }

        #endregion

        private void ShowAlert(string title, string message, Action Act)
        {
            InvokeOnMainThread(() =>
            {
                UIAlertView alert = new UIAlertView()
                {
                    Title = title,
                    Message = message
                };
                alert.AddButton(Presenter.GetOkLocale());
                alert.Show();
                alert.Clicked += (s, e) => Act();
            });

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
                _confirmPassEditText.Enabled = availability;
                _passEditText.Enabled = availability;
                _registerButton.Enabled = availability;
                _userAgreementLink.Enabled = availability;
            });
        }

        public void ShowSpinner()
        {
            _spinner.StartAnimating();
            _confirmPassEditText.Enabled = false;
            _passEditText.Enabled = false;
        }

        public void HideSpinner()
        {
            _spinner.StopAnimating();
            _confirmPassEditText.Enabled = true;
            _passEditText.Enabled = true;
        }
    }
}