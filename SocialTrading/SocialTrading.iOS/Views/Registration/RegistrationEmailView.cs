using UIKit;
using Foundation;

using System;
using System.ComponentModel;

using SocialTrading.Theme;
using SocialTrading.iOS.Theme;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Vipers.Registration.Email.Interfaces;

namespace SocialTrading.iOS
{
    [DesignTimeVisible(true)]
    public partial class RegistrationEmailView : UIView, IComponent, IViewRegEmail
    {
        public IPresenterRegEmail Presenter { get; set; }

        public RegistrationEmailView (IntPtr handle) : base (handle)
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

			NSBundle.MainBundle.LoadNib("RegistrationEmailView", this, null);

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

        partial void TouchUpInsideButtonNext(UIButton sender)
        {
            Presenter.NextClick();
        }

        partial void DidEndEmailEditText (UITextField sender)
        {
            Presenter.EmailInput();
        }

		partial void BackButtonTouchUpInside(UIButton sender)
		{
			Presenter.BackClick();
		}
        #endregion

        #region IViewRegEmail

        public void SetEmail(string email)
        {
			InvokeOnMainThread(() =>
			{
                _emailEditText.Text = email;
            });
        }

        public string GetEmail()
        {
            return _emailEditText.Text;
        }

        public void ShowConnectedEmails()
        {
        }

        public void SetHeaderLabelTheme(ITextViewTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _emailHeaderLabel.SetTheme(themeName);
            });
        }

        public void SetEmailLabelTheme(ITextViewTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _emailLabel.SetTheme(themeName);
            });
        }

        public void SetNextButtonTheme(IButtonTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _nextButton.SetTheme(themeName);
            });
        }
        
        public void SetViewTheme(IImageViewTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _rootView.SetTheme((IViewTheme)themeName);
            });
        }

        public void SetLogoImageViewTheme(IImageViewTheme backgroundImage)
        {
            InvokeOnMainThread(() =>
            {
                _logoImage.SetTheme(backgroundImage);
            });
        }

        public void SetEmailEditTextTheme(IEditTextTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _emailEditText.SetTheme(themeName);
            });
        }

		public void SetBackButtonTheme(IImageButtonTheme themeName)
		{
		    InvokeOnMainThread(() =>
		    {
		        _backImageButton.SetTheme((IImageViewTheme)themeName);
		    });
		}

		public void SetFeatureImageTheme(IImageViewTheme themeName)
		{
		    InvokeOnMainThread(() =>
		    {
		        _featureImage.SetTheme(themeName);
		    });
		}

		public void SetFeatureTextTheme(ITextViewTheme themeName)
		{
		    InvokeOnMainThread(() =>
		    {
		        _featureText.SetTheme(themeName);
		    });
		}


        public void SetEmailLocale(string regEmailTextView)
        {
            InvokeOnMainThread(() =>
            {
                _emailLabel.Text = regEmailTextView;
            });
        }

        public void SetNextButtonLocale(string buttonNext)
        {
            InvokeOnMainThread(() =>
            {
                _nextButton.SetTitle(buttonNext, UIControlState.Normal);
            });
        }

        public void SetTitleLocale(string regEmailTextView)
        {
            InvokeOnMainThread(() =>
            {
                _emailHeaderLabel.Text = regEmailTextView;
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

        private void FillView()
        {
            _emailEditText.ShouldChangeCharacters = (textField, range, replacementString) =>
            {
                var newLength = textField.Text.Length + replacementString.Length - range.Length;
                return newLength <= 256;
            };

            Presenter.SetLocale();
        }

        private void HideShowKeyboard()
        {
            _emailEditText.ShouldReturn += (textField) =>
            {
                textField.ResignFirstResponder();
                return true;
            };

            UITapGestureRecognizer g_recognizer = new UITapGestureRecognizer(() =>
            {
                _emailEditText.ResignFirstResponder();
            });

            AddGestureRecognizer(g_recognizer);
        }

        #endregion
    }


}
