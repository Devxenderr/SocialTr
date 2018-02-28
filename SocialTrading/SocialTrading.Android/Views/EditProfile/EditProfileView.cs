using System;

using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Graphics;
using Android.Runtime;

using SocialTrading.Droid.Theme;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.Vipers.MoreOptions.EditProfile.Models;
using SocialTrading.Vipers.MoreOptions.EditProfile.Interfaces;

namespace SocialTrading.Droid.Views.EditProfile
{
    [Register("socialTrading.droid.views.editProfile.EditProfileView")]
    public class EditProfileView : RelativeLayout, IViewEditProfile
    {
        private Holder _holder;
        private bool _iSNameChahged;
        private bool _iSLastNameChahged;
        private bool _iSStatusChahged;

        private LayoutInflater _inflater;
        private const string SpinnerConst = "SpinnerTag";

        #region RelativeLayout
        public EditProfileView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public EditProfileView(Context context) : base(context)
        {
            Init(context);
        }

        public EditProfileView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context);
        }

        public EditProfileView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init(context);
        }

        public EditProfileView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Init(context);
        }

        private void Init(Context context)
        {
            _inflater = ((Activity)context).LayoutInflater;
            _inflater.Inflate(Resource.Layout.EditProfileView, this, true);
            
            _holder = new Holder(this);
            SetButtonsActions();
        }

        private void SetButtonsActions()
        {
            if (!_holder.SaveButton.HasOnClickListeners)
            {
                _holder.SaveButton.Click += (s, e) =>
                {
                    SaveButtonClick?.Invoke(_holder.NameEditText.Text, _holder.LastnameEditText.Text, _holder.StatusEditText.Text);
                };
            }

            if (!_holder.CancelButton.HasOnClickListeners)
            {
                _holder.CancelButton.Click += (s, e) =>
                {
                    CancelButtonClick?.Invoke();
                };
            }

            _holder.NameEditText.TextChanged += (sender, args) =>
            {
                _iSNameChahged = true;
            };
            _holder.NameEditText.FocusChange += (sender, args) =>
            {
                if (_iSNameChahged && !args.HasFocus)
                {
                    NameWasChanged?.Invoke(_holder.NameEditText.Text);
                }
            };

            _holder.LastnameEditText.TextChanged += (sender, args) =>
            {
                _iSLastNameChahged = true;
            };
            _holder.LastnameEditText.FocusChange += (sender, args) =>
            {
                if (_iSLastNameChahged && !args.HasFocus)
                {
                    LastNameWasChanged?.Invoke(_holder.LastnameEditText.Text);
                }
            };

            _holder.StatusEditText.TextChanged += (sender, args) =>
            {
                _iSStatusChahged = true;
            };
            _holder.StatusEditText.FocusChange += (sender, args) =>
            {
                if (_iSStatusChahged && !args.HasFocus)
                {
                    StatusWasChanged?.Invoke(_holder.StatusEditText.Text);
                }
            };
        }
        #endregion

        #region IViewProfileSettings
        public void SetLabelsTheme(ITextViewTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.NameTextView.SetTheme(theme);
                _holder.LastnameTextView.SetTheme(theme);
                _holder.StatusTextView.SetTheme(theme);
            });
        }

        public void SetNameEditTextTheme(IEditTextTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.NameEditText.SetTheme(theme);
            });
        }

        public void SetLastnameEditTextTheme(IEditTextTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.LastnameEditText.SetTheme(theme);
            });
        }

        public void SetStatusEditTextTheme(IEditTextTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.StatusEditText.SetTheme(theme);
            });
        }

        public void SetSaveButtonTheme(IButtonTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.SaveButton.SetTheme(theme);
            });
        }

        public void SetCancelButtonTheme(IButtonTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.CancelButton.SetTheme(theme);
            });
        }

        public void SetName(string text)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.NameEditText.Text = text;
            });
        }

        public void SetNameLabel(string localeString)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.NameTextView.Text = localeString;
            });
        }

        public void SetLastname(string text)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.LastnameEditText.Text = text;
            });
        }

        public void SetLastnameLabel(string localeString)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.LastnameTextView.Text = localeString;
            });
        }

        public void SetStatus(string text)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.StatusEditText.Text = text;
            });
        }

        public void SetStatusLabel(string localeString)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.StatusTextView.Text = localeString;
            });
        }

        public void SetSaveButtonTitle(string title)
        {
            _holder.SaveButton.Text = title;
        }

        public void SetCancelButtonTitle(string title)
        {
            _holder.CancelButton.Text = title;
        }

        public void ShowAlert(string message, string btnOkTitle, EEditProfileAlertType alertType)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(Context);
                alert.SetMessage(message);
                alert.SetPositiveButton(btnOkTitle, (senderAlert, args) => { AlertButtonClick?.Invoke(alertType); });
                Dialog dialog = alert.Create();
                dialog.Show();
            });
        }

        public void ShowSpinner()
        {
            _inflater.Inflate(Resource.Layout.Spinner, this, true);
            var layoutForDelete = FindViewById(Resource.Id.LayoutForDelete);
            layoutForDelete.Tag = SpinnerConst;

            try
            {
                float px = TypedValue.ApplyDimension(ComplexUnitType.Dip, 7, Resources.DisplayMetrics);
                layoutForDelete.Elevation = px;
            }
            catch { }

            var spinnerView = FindViewById<View>(Resource.Id.SpinnerView);

            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.NameEditText.Enabled = false;
                _holder.LastnameEditText.Enabled = false;
                _holder.StatusEditText.Enabled = false;
            });
            spinnerView.Touch += (sender, args) => { };
        }

        public void HideSpinner()
        {
            var spinner = FindViewWithTag(SpinnerConst) as ViewGroup;

            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.NameEditText.Enabled = true;
                _holder.LastnameEditText.Enabled = true;
                _holder.StatusEditText.Enabled = true;

                if (spinner != null)
                {
                    RemoveView(spinner);
                }
            });
        }

        public event Action<string, string, string> SaveButtonClick;
        public event Action<string> NameWasChanged;
        public event Action<string> LastNameWasChanged;
        public event Action<string> StatusWasChanged;
        public event Action CancelButtonClick;
        public event Action<EEditProfileAlertType> AlertButtonClick;
        #endregion

        private class Holder
        {
            public Holder(View viewGroup)
            {
                NameTextView = viewGroup.FindViewById<TextView>(Resource.Id.editProfile_name_textView);
                LastnameTextView = viewGroup.FindViewById<TextView>(Resource.Id.editProfile_lastname_textView);
                StatusTextView = viewGroup.FindViewById<TextView>(Resource.Id.editProfile_status_textView);

                NameEditText = viewGroup.FindViewById<EditText>(Resource.Id.editProfile_name_editText);
                LastnameEditText = viewGroup.FindViewById<EditText>(Resource.Id.editProfile_lastname_editText);
                StatusEditText = viewGroup.FindViewById<EditText>(Resource.Id.editProfile_status_editText);

                SaveButton = viewGroup.FindViewById<Button>(Resource.Id.editProfile_save_button);
                CancelButton = viewGroup.FindViewById<Button>(Resource.Id.editProfile_cancel_button);
            }

            public TextView NameTextView { get; }
            public TextView LastnameTextView { get; }
            public TextView StatusTextView { get; }

            public EditText NameEditText { get; }
            public EditText LastnameEditText { get; }
            public EditText StatusEditText { get; }

            public Button SaveButton { get; }
            public Button CancelButton { get; }
        }
    }
}