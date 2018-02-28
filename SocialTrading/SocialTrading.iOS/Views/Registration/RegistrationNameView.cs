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
using SocialTrading.Vipers.Registration.Name.Interfaces;

namespace SocialTrading.iOS
{
    [DesignTimeVisible(true)]
    public partial class RegistrationNameView : UIView, IComponent, IViewRegName
    {
        public IPresenterRegName Presenter { get; set; }

        public RegistrationNameView(IntPtr handle) : base(handle)
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

            NSBundle.MainBundle.LoadNib("RegistrationNameView", this, null);

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

        partial void DidEndFirstNameEditText(UITextField sender)
        {
            Presenter.NameInput();
        }

        partial void DidEndLastNameEditText(UITextField sender)
        {
            Presenter.LastNameInput();
        }

		partial void BackButtonTouchUpInside(UIButton sender)
		{
            Presenter.BackClick();
		}

		#endregion


		#region IViewRegName
        
        public void SetFirstName(string firstName)
        {
            InvokeOnMainThread(() =>
            {
                _firstNameEditText.Text = firstName;
            });
        }

        public void SetLastName(string lastName)
        {
            InvokeOnMainThread(() =>
            {
                _lastNameEditText.Text = lastName;
            });
        }

        public string GetFirstName()
        {
            return _firstNameEditText.Text;
        }

        public string GetLastName()
        {
            return _lastNameEditText.Text;
        }

        public void SetHeaderLabelTheme(ITextViewTheme themeName)
        {
            _nameHeader.SetTheme(themeName);
        }

        public void SetNameLabelTheme(ITextViewTheme themeName)
        {
			_nameLabel.SetTheme(themeName);
        }

        public void SetLastNameLabelTheme(ITextViewTheme themeName)
        {
           _lastNameLabel.SetTheme(themeName);
        }

        public void SetNextButtonTheme(IButtonTheme themeName)
        {
            _nextButton.SetTheme(themeName);
        }

        public void SetViewTheme(IImageViewTheme themeName)
        {
            _rootView.SetTheme((IViewTheme)themeName);
        }

        public void SetLogoImageViewTheme(IImageViewTheme themeName)
        {
            _logoImage.SetTheme(themeName);
        }

        public void SetNameEditTextTheme(IEditTextTheme themeName)
        {
            _firstNameEditText.SetTheme(themeName);
        }

        public void SetLastNameEditTextTheme(IEditTextTheme themeName)
        {
            _lastNameEditText.SetTheme(themeName);
        }

        public void SetBackButtonTheme(IImageButtonTheme themeName)
		{
            _backImageButton.SetTheme((IImageViewTheme)themeName);
        }

		public void SetFeatureImageTheme(IImageViewTheme themeName)
		{
			_featureImage.SetTheme(themeName);
		}

		public void SetFeatureTextTheme(ITextViewTheme themeName)
		{
			_featureText.SetTheme(themeName);
		}

        public void SetNameLocale(string regNameHint)
        {
            _nameLabel.Text = regNameHint;
        }

        public void SetLastNameLocale(string regLastNameHint)
        {
            _lastNameLabel.Text = regLastNameHint;
        }

        public void SetNextButtonLocale(string buttonNext)
        {
            _nextButton.SetTitle(buttonNext, UIControlState.Normal);
            _nextButton.Layer.CornerRadius = 5;
        }

        public void SetTitleLocale(string regNameTextView)
        {
            _nameHeader.Text = regNameTextView;
        }

		public void SetFeatureTextLocale(string featureText)
		{
			_featureText.Text = featureText;
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
            _firstNameEditText.ShouldChangeCharacters = (textField, range, replacementString) =>
            {
                var newLength = textField.Text.Length + replacementString.Length - range.Length;
                return newLength <= 200;
            };

            _lastNameEditText.ShouldChangeCharacters = (textField, range, replacementString) =>
            {
                var newLength = textField.Text.Length + replacementString.Length - range.Length;
                return newLength <= 200;
            };

            Presenter.SetLocale();
        }

        private void HideShowKeyboard()
        {
            _firstNameEditText.ShouldReturn += (textField) =>
            {
                textField.ResignFirstResponder();
                return true;
            };

            _lastNameEditText.ShouldReturn += (textField) =>
            {
                textField.ResignFirstResponder();
                return true;
            };

            UITapGestureRecognizer g_recognizer = new UITapGestureRecognizer(() =>
            {
                _firstNameEditText.ResignFirstResponder();
                _lastNameEditText.ResignFirstResponder();
            });

            AddGestureRecognizer(g_recognizer);
        }

        #endregion

    }
}