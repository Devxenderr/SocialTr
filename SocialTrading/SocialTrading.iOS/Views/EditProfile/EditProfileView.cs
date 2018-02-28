using System;
using System.ComponentModel;

using UIKit;
using Foundation;

using SocialTrading.iOS.Theme;
using SocialTrading.iOS.Tools;
using SocialTrading.iOS.Tools.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.Vipers.MoreOptions.EditProfile.Models;
using SocialTrading.Vipers.MoreOptions.EditProfile.Interfaces;

namespace SocialTrading.iOS
{
    public partial class EditProfileView : UIView, IComponent, IViewEditProfile, IGettableViewController
    {
        private UISpinnerView _spinner = null;

        public EditProfileView(IntPtr handle) : base(handle)
        {
        }

        public ISite Site { get; set; }

        public Func<UIView, UIViewController> GetViewController { get; set; }

        public event EventHandler Disposed;
        public void ShowAlert(string message, string btnOkTitle, EEditProfileAlertType alertType)
        {
            var alertVC = UIAlertController.Create("", message, UIAlertControllerStyle.Alert);
            alertVC.AddAction(UIAlertAction.Create(btnOkTitle, UIAlertActionStyle.Default, action => { AlertButtonClick?.Invoke(alertType);}) );

            var currVC = GetViewController?.Invoke(this);
            currVC?.PresentViewController(alertVC, true, null);
        }

        public void ShowSpinner()
        {
            if (_spinner == null)
            {
                InitSpinner();
            }
            _spinner.StartAnimating();
            _nameTextField.Enabled = false;
            _lastNameTextField.Enabled = false;
            _statusTextField.Enabled = false;
        }

        public void HideSpinner()
        {
            _spinner.StopAnimating();
            _nameTextField.Enabled = true;
            _lastNameTextField.Enabled = true;
            _statusTextField.Enabled = true;
        }

        public event Action<string> NameWasChanged;
        public event Action<string> LastNameWasChanged;
        public event Action<string> StatusWasChanged;
        public event Action<string, string, string> SaveButtonClick;
        public event Action CancelButtonClick;
        public event Action<EEditProfileAlertType> AlertButtonClick;

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            if (Site != null)
            {
                return;
            }

            NSBundle.MainBundle.LoadNib("EditProfileView", this, null);

            InvokeOnMainThread(() =>
            {
                var frame = _rootView.Frame;
                frame.Height = Frame.Height;
                frame.Width = Frame.Width;
                _rootView.Frame = frame;
                AddSubview(_rootView);
            });

            HideShowKeyboard();
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

        private bool ResignResponder(UITextField textField)
        {
            textField.ResignFirstResponder();
            return true;
        }

        private void HideShowKeyboard()
        {
            _nameTextField.ShouldReturn = ResignResponder;

            _lastNameTextField.ShouldReturn = ResignResponder;

            _statusTextField.ShouldReturn = ResignResponder;

            UITapGestureRecognizer tapGestureRecognizer = new UITapGestureRecognizer(() =>
            {
                _nameTextField.ResignFirstResponder();
                _lastNameTextField.ResignFirstResponder();
                _statusTextField.ResignFirstResponder();
            });

            AddGestureRecognizer(tapGestureRecognizer);
        }

        partial void _nameTextField_DidEnd(UITextField sender)
        {
            NameWasChanged?.Invoke(_nameTextField.Text);
        }        
        partial void _lastNameTextField_DidEnd(UITextField sender)
        {
            LastNameWasChanged?.Invoke(_lastNameTextField.Text);
        }
		partial void _statusTextField_DidEnd(UITextField sender)
		{
            StatusWasChanged?.Invoke(_statusTextField.Text);
		}

        partial void _cancelButton_TouchUpInside(UIButton sender)
		{
            CancelButtonClick?.Invoke();
		}
		
		partial void _saveButton_TouchUpInside(UIButton sender)
		{
            SaveButtonClick?.Invoke(_nameTextField.Text, _lastNameTextField.Text, _statusTextField.Text);
		}

        public void SetCancelButtonTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _cancelButton.SetTheme(theme);
            });
        }

        public void SetLabelsTheme(ITextViewTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _nameLabel.SetTheme(theme);
                _lastNameLabel.SetTheme(theme);
                _statusLabel.SetTheme(theme);
            });
        }

        public void SetLastname(string text)
        {
            InvokeOnMainThread(() =>
            {
                _lastNameTextField.Text = text;
            });
        }

        public void SetLastnameEditTextTheme(IEditTextTheme theme)
        {
            InvokeOnMainThread(() =>
           {
                _lastNameTextField.SetTheme(theme);
           });
        }

        public void SetLastnameLabel(string localeString)
        {
            InvokeOnMainThread(() =>
            {
                _lastNameLabel.Text = localeString;
            });
        }

        public void SetName(string text)
        {
            InvokeOnMainThread(() =>
            {
                _nameTextField.Text = text;
            });
        }

        public void SetNameEditTextTheme(IEditTextTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _nameTextField.SetTheme(theme);
            });
        }

        public void SetNameLabel(string localeString)
        {
            InvokeOnMainThread(() =>
            {
                _nameLabel.Text = localeString;
            });
        }

        public void SetSaveButtonTheme(IButtonTheme theme)
        {
            InvokeOnMainThread(() =>
            {
                _saveButton.SetTheme(theme);
            });
        }

        public void SetStatus(string text)
        {
            InvokeOnMainThread(() =>
           {
               _statusTextField.Text = text;
           });
        }

        public void SetStatusEditTextTheme(IEditTextTheme theme)
        {
            InvokeOnMainThread(() =>
           {
                _statusTextField.SetTheme(theme);
           });
        }

        public void SetStatusLabel(string localeString)
        {
            InvokeOnMainThread(() =>
           {
               _statusLabel.Text = localeString;
           });
        }

        public void SetSaveButtonTitle(string title)
        {
            InvokeOnMainThread(() =>
            {
                _saveButton.SetTitle(title, UIControlState.Normal);
            });
        }

        public void SetCancelButtonTitle(string title)
        {
            InvokeOnMainThread(() =>
            {
                _cancelButton.SetTitle(title, UIControlState.Normal);
            });
        }
    }
}