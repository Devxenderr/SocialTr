using UIKit;
using Foundation;

using System;
using System.ComponentModel;

using SocialTrading.iOS.Tools;
using SocialTrading.iOS.Theme;
using SocialTrading.Vipers.ForgotPass.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

namespace SocialTrading.iOS
{
    [DesignTimeVisible(true)]
    public partial class ForgotPassView : UIView, IComponent, IViewForgotPass
    {
        public IPresenterForgotPass Presenter { private get; set; }
        private UISpinnerView _spinner = null;

        public ForgotPassView (IntPtr handle) : base (handle)
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

			NSBundle.MainBundle.LoadNib("ForgotPassView", this, null);

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

        partial void BackButtonTouchUpInside(UIButton sender)
        {
            Presenter.BackButtonClick();
        }

        partial void TouchUpInsideButtonPassRetrieval(UIButton sender)
        {
            InitSpinner();
            Presenter.PassRecoveryClick(_emailEditText.Text.Trim().ToLower());           
        }

        #region IViewForgotPass


        public void SetConfig()
        {
            InvokeOnMainThread(() =>
            {
                FillView();
                HideShowKeyboard();
            });
        }

        private void InitSpinner()
        {
            if(_spinner != null)
            {
                return;
            }
            _spinner = new UISpinnerView(_rootView.Frame);

            _rootView.AddSubview(_spinner);
        }

        private void HideShowKeyboard()
        {
            _emailEditText.ShouldReturn += (textField) =>
            {
                textField.ResignFirstResponder();
                return true;
            };

            var tapGestureRecognizer = new UITapGestureRecognizer(() =>
            {
                _emailEditText.ResignFirstResponder();
            });

            AddGestureRecognizer(tapGestureRecognizer);
        }

        private void FillView()
        {
            _emailEditText.ShouldChangeCharacters = (textField, range, replacementString) =>
            {
                var newLength = textField.Text.Length + replacementString.Length - range.Length;
                return newLength <= 256;
            };

            Presenter.SetLocale();
        }

        public void ShowAlertEmailRedirect(string msg, string btnOk)
        {
            InvokeOnMainThread(() =>
            {
                var alert = new UIAlertView
                {
                    Message = msg
                };

                alert.AddButton(btnOk);
                alert.Show();
                alert.Clicked += (s, e) => { Presenter.AlertButtonClick(); };
            });

        }

        public void ShowSpinner()
        {
            _spinner.StartAnimating();
            _emailEditText.Enabled = false;
        }

        public void HideSpinner()
        {
            _spinner.StopAnimating();
            _emailEditText.Enabled = true;
        }

        public void SetLogoImageViewTheme(IImageViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _logoImage.SetTheme(theme);
            });
        }
       
        public void SetRecoveryButtonTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _passRecoveryButton.SetTheme(theme);
            });
        }

        public void SetViewTheme(IImageViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _rootView.SetTheme((IViewTheme)theme);
            });
        }

        public void SetHeaderLabelTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _forgotPassHeaderLabel.SetTheme(theme);
            });
        }

        public void SetBackButtonTheme(IImageButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _backButton.SetTheme((IImageViewTheme)theme);
            });
        }

        public void SetEmailLabelTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _emailLabel.SetTheme(theme);
            });
        }

        public void SetEmailEditTextTheme(IEditTextTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _emailEditText.SetTheme(theme);
            });
        }

        public void SetButtonLocale(string forgotPassButton)
        {
            _passRecoveryButton.SetTitle(forgotPassButton, UIControlState.Normal);
        }

        public void SetHeaderLabelLocale(string passwordRecovery)
        {
            _forgotPassHeaderLabel.Text = passwordRecovery;
        }

        public void SetHintLocale(string emailHint)
        {
            _emailLabel.Text = emailHint;
        }

        #endregion
    }
}