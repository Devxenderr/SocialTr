using System;
using System.ComponentModel;

using UIKit;
using Foundation;

using SocialTrading.iOS.Theme;
using SocialTrading.iOS.Tools;
using SocialTrading.iOS.Tools.Interfaces;
using SocialTrading.Vipers.EditContact.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.View;

namespace SocialTrading.iOS.Views.EditContact
{
    public partial class EditContactView : UIView, IComponent, IViewEditContact, IGettableViewController
    {
        public EditContactView (IntPtr handle) : base (handle)
        {
        }

        public IPresenterForViewEditContact Presenter { private get;set; }

        private UISpinnerView _spinner = null;

        public Func<UIView, UIViewController> GetViewController { get; set; }

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

            NSBundle.MainBundle.LoadNib("EditContactView", this, null);

            InvokeOnMainThread(() =>
            {
                var frame = _rootView.Frame;
                frame.Height = Frame.Height;
                frame.Width = Frame.Width;
                _rootView.Frame = frame;
                AddSubview(_rootView);
            });

            SetActions();
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

        private void SetActions()
        {
            _countryTextField.ShouldBeginEditing = (sender) => false;
            _emailTextField.ShouldBeginEditing = (sender) => false;
            _emailTextField.Enabled = false;

            var gesture = new UITapGestureRecognizer(() =>
            {
                Presenter.CountryClick();
            });
            _countryTextField.UserInteractionEnabled = true;
            _countryTextField.AddGestureRecognizer(gesture);
            _phoneTextField.KeyboardType = UIKeyboardType.PhonePad;
            HideShowKeyboard();
        }

        private bool ResignResponder(UITextField textField)
        {
            textField.ResignFirstResponder();
            return true;
        }

        private void HideShowKeyboard()
        {
            _cityTextField.ShouldReturn = ResignResponder;
            _countryTextField.ShouldReturn = ResignResponder;
            _emailTextField.ShouldReturn = ResignResponder;
            _phoneTextField.ShouldReturn = ResignResponder;
            _skypeTextField.ShouldReturn = ResignResponder;

            UITapGestureRecognizer tapGestureRecognizer = new UITapGestureRecognizer(() =>
            {
                _cityTextField.ResignFirstResponder();
                _countryTextField.ResignFirstResponder();
                _emailTextField.ResignFirstResponder();
                _phoneTextField.ResignFirstResponder();
                _skypeTextField.ResignFirstResponder();
            });

            AddGestureRecognizer(tapGestureRecognizer);
        }

        partial void CancelTouchUp(UIButton sender)
        {
            Presenter.CancelClick();
        }

        partial void SaveTouchUp(UIButton sender)
        {
            Presenter.SaveClick(_emailTextField.Text, _skypeTextField.Text, _countryTextField.Text, _cityTextField.Text, _phoneTextField.Text);
        }

        partial void CityDidEndEditing(UITextField sender)
        {
            Presenter.CityTextChanged(_cityTextField.Text);
        }

        partial void PhoneDidEndEditing(UITextField sender)
        {
            Presenter.PhoneTextChanged(_phoneTextField.Text);
        }

        partial void SkypeDidEndEditing(UITextField sender)
        {
            Presenter.SkypeTextChanged(_skypeTextField.Text);
        }

        public void SetCancelButtonLocale(string text)
        {
            InvokeOnMainThread(() =>
            {
                _cancelButton.SetTitle(text, UIControlState.Normal);
            });
        }

        public void SetCountryLabelLocale(string text)
        {
            InvokeOnMainThread(() =>
            {
                _countryLabel.Text = text;
            });
        }

        public void SetPhoneLabelLocale(string text)
        {
            InvokeOnMainThread(() =>
            {
                _phoneLabel.Text = text;
            });
        }

        public void SetCityLabelLocale(string text)
        {
            InvokeOnMainThread(() =>
            {
                _cityLabel.Text = text;
            });
        }

        public void SetEmailLabelLocale(string text)
        {
            InvokeOnMainThread(() =>
            {
                _emailLabel.Text = text;
            });
        }

        public void SetSkypeLabelLocale(string text)
        {
            InvokeOnMainThread(() =>
            {
                _skypeLabel.Text = text;
            });
        }

        public void SetSaveButtonLocale(string text)
        {
            InvokeOnMainThread(() =>
            {
                _saveButton.SetTitle(text, UIControlState.Normal);
            });
        }


        public void SetSkype(string text)
        {
            InvokeOnMainThread(() =>
            {
                _skypeTextField.Text = text;
            });
        }

        public void SetPhone(string text)
        {
            InvokeOnMainThread(() =>
            {
                _phoneTextField.Text = text;
            });
        }

        public void SetEmail(string text)
        {
            InvokeOnMainThread(() =>
            {
                _emailTextField.Text = text;
            });
        }

        public void SetCountry(string text)
        {
            InvokeOnMainThread(() =>
            {
                _countryTextField.Text = text;
            });
        }

        public void SetCity(string text)
        {
            InvokeOnMainThread(() =>
            {
                _cityTextField.Text = text;
            });
        }


        public void SetCancelButtonTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _cancelButton.SetTheme(theme);
            });
        }
        
        public void SetCityEditTextTheme(IEditTextTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _cityTextField.SetTheme(theme);
            });
        }
        
        public void SetCityTextViewTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _cityLabel.SetTheme(theme);
            });
        }
        
        public void SetCountryEditTextTheme(IEditTextTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _countryTextField.SetTheme(theme);
            });
        }
        
        public void SetCountryTextViewTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _countryLabel.SetTheme(theme);
            });
        }
        
        public void SetEmailEditTextTheme(IEditTextTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _emailTextField.SetTheme(theme);
                _emailTextField.TextColor = UIColor.Gray;
            });
        }
        
        public void SetEmailTextViewTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _emailLabel.SetTheme(theme);
            });
        }
        
        public void SetPhoneEditTextTheme(IEditTextTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _phoneTextField.SetTheme(theme);
            });
        }

        public void SetPhoneTextViewTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _phoneLabel.SetTheme(theme);
            });
        }
        
        public void SetSaveButtonTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _saveButton.SetTheme(theme);
            });
        }
        
        public void SetSkypeEditTextTheme(IEditTextTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _skypeTextField.SetTheme(theme);
            });
        }
        
        public void SetSkypeTextViewTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _skypeLabel.SetTheme(theme);
            });
        }

        public void SetViewTheme(IViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _rootView.SetTheme(theme);
            });
        }
        
        public void ShowSuccessAlert(string message, string buttonTitle)
        {
            InvokeOnMainThread(() =>
            {
                InvokeOnMainThread(() =>
                {
                    var alertVC = UIAlertController.Create("", message, UIAlertControllerStyle.Alert);
                    alertVC.AddAction(UIAlertAction.Create(buttonTitle, UIAlertActionStyle.Default, action => { Presenter.AlertOkClick(); }));

                    var currVC = GetViewController?.Invoke(this);
                    currVC?.PresentViewController(alertVC, true, null);
                }); 
            });
        }

        public void ShowFailAlert(string message, string buttonTitle)
        {
            InvokeOnMainThread(() =>
            {
                var alertVC = UIAlertController.Create("", message, UIAlertControllerStyle.Alert);
                alertVC.AddAction(UIAlertAction.Create(buttonTitle, UIAlertActionStyle.Default, action => { }));

                var currVC = GetViewController?.Invoke(this);
                currVC?.PresentViewController(alertVC, true, null);
            });
        }

        public void ShowSpinner()
        {
            if (_spinner == null)
            {
                InitSpinner();
            }
            _spinner.StartAnimating();
            _cityTextField.Enabled = false;
            _phoneTextField.Enabled = false;
            _skypeTextField.Enabled = false;
        }

        public void HideSpinner()
        {
            _spinner.StopAnimating();
            _cityTextField.Enabled = true;
            _phoneTextField.Enabled = true;
            _skypeTextField.Enabled = true;
        }
    }
}