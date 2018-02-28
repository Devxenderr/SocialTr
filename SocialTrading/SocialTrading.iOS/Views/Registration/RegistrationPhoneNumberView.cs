using UIKit;
using Foundation;

using System;
using System.ComponentModel;

using SocialTrading.Theme;
using SocialTrading.iOS.Theme;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.Vipers.Registration.Phone.Interfaces;

namespace SocialTrading.iOS
{
    public partial class RegistrationPhoneNumberView : UIView, IComponent, IViewRegPhone
    {
        public IPresenterRegPhone Presenter { set; get; }


        public RegistrationPhoneNumberView (IntPtr handle) : base (handle)
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

			NSBundle.MainBundle.LoadNib("RegistrationPhoneNumberView", this, null);

			InvokeOnMainThread(() =>
			{
				var frame = _rootView.Frame;
				frame.Height = Frame.Height;
				frame.Width = Frame.Width;
				_rootView.Frame = frame;
				AddSubview(_rootView);
			});
		}



        #region Event handlers

        partial void PhoneNumberDidEnd(UITextField sender)
        {
            Presenter.PhoneNumberInput();
        }

        partial void PhoneCountryDidEnd(UITextField sender)
        {
            Presenter.PhoneCountryInput();
        }

        partial void PhoneCountryValueChanged(UITextField sender)
        {
            var textField = sender as UITextField;

            if (textField.Text.Length.Equals(0))
            {
                textField.Text = "+";
            }
            else if (!textField.Text[0].Equals('+'))
            {
                textField.Text = textField.Text.Insert(0, "+");
            }
        }

        partial void NextButtonTouchUpInside(UIButton sender)
        {
            Presenter.NextClick();
        }

        partial void SkipButtonTouchUpInside(UIButton sender)
        {
            Presenter.SkipClick();
        }

		partial void BackButtonTouchUpInside(UIButton sender)
		{
            Presenter.BackClick();
		}

        #endregion

        #region IViewRegPhone
        
        public void SetPhone(string phone)
        {
            InvokeOnMainThread(() =>
            {
                _phoneNumberTextField.Text = phone;
            });
        }

        public string GetPhone()
        {
            return _phoneNumberTextField.Text;
        }

        public void SetPhoneCountry(string phoneCountry)
        {
            InvokeOnMainThread(() =>
            {
                _phoneCountryTextField.Text = phoneCountry;
            });
        }

        public string GetPhoneCountry()
        {
            return _phoneCountryTextField.Text;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            InvokeOnMainThread(() =>
            {
                _phoneNumberTextField.Text = phoneNumber;
            });
        }

        public string GetPhoneNumber()
        {
            return _phoneNumberTextField.Text;
        }

        public void SetHeaderLabelTheme(ITextViewTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _headerLabel.SetTheme(themeName);
            });
        }

        public void SetPhoneCountryLabelTheme(ITextViewTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _phoneCountryLabel.SetTheme(themeName);
            });
        }

        public void SetPhoneNumberLabelTheme(ITextViewTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _phoneNumberLabel.SetTheme(themeName);
            });
        }

        public void SetNextButtonTheme(IButtonTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _nextButton.SetTheme(themeName);
            });
        }

        public void SetSkipButtonTheme(IButtonTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _skipButton.SetTheme(themeName);
            });
        }

        public void SetViewTheme(IImageViewTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _rootView.SetTheme((IViewTheme) themeName);
            });
        }

        public void SetLogoImageViewTheme(IImageViewTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _logoImage.SetTheme(themeName);
            });
        }

		public void SetBackButtonTheme(IImageButtonTheme themeName)
		{
		    InvokeOnMainThread(() =>
		    {
		        _backImageButton.SetTheme((IImageViewTheme) themeName);
		    });
		}

        public void SetPhoneCountryEditTextTheme(IEditTextTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _phoneCountryTextField.SetTheme(themeName);
            });
        }

        public void SetPhoneNumberEditTextTheme(IEditTextTheme themeName)
        {
            InvokeOnMainThread(() =>
            {
                _phoneNumberTextField.SetTheme(themeName);
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

        public void SetPhoneCountryLocale(string regPhoneCountryHint)
        {
            InvokeOnMainThread(() =>
            {
                _phoneCountryLabel.Text = regPhoneCountryHint;
            });
        }

        public void SetPhoneNumberLocale(string regPhoneNumberHint)
        {
            InvokeOnMainThread(() =>
            {
                _phoneNumberLabel.Text = regPhoneNumberHint;
            });
        }

        public void SetNextButtonLocale(string buttonNext)
        {
            InvokeOnMainThread(() =>
            {
                _nextButton.SetTitle(buttonNext, UIControlState.Normal);
            });
        }

        public void SetSkipButtonLocale(string regPhoneNumberButtonSkip)
        {
            InvokeOnMainThread(() =>
            {
                _skipButton.SetTitle(regPhoneNumberButtonSkip, UIControlState.Normal);
            });
        }

        public void SetTitleLocale(string regPhoneNumberHeader)
        {
            InvokeOnMainThread(() =>
            {
                _headerLabel.Text = regPhoneNumberHeader;
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
            _phoneCountryTextField.ShouldChangeCharacters = (textField, range, replacementString) =>
            {
                var newLength = textField.Text.Length + replacementString.Length - range.Length;
                return newLength <= 5;
            };
            _phoneNumberTextField.ShouldChangeCharacters = (textField, range, replacementString) =>
            {
                var newLength = textField.Text.Length + replacementString.Length - range.Length;
                return newLength <= 16;
            };
            _phoneCountryTextField.Text = "+";

            Presenter.SetLocale();
        }

        private void HideShowKeyboard()
        {
            _phoneCountryTextField.ShouldReturn += (textField) =>
            {
                textField.ResignFirstResponder();
                return true;
            };

            _phoneNumberTextField.ShouldReturn += (textField) =>
            {
                textField.ResignFirstResponder();
                return true;
            };

            UITapGestureRecognizer g_recognizer = new UITapGestureRecognizer(() =>
            {
                _phoneCountryTextField.ResignFirstResponder();
                _phoneNumberTextField.ResignFirstResponder();
            });

            AddGestureRecognizer(g_recognizer);
        }

        #endregion
    }
}