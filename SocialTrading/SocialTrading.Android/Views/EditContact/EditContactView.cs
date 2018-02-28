using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Runtime;
using Android.Text.Style;

using Java.Lang;

using SocialTrading.Droid.Theme;
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Vipers.EditContact.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using Android.Views.InputMethods;

namespace SocialTrading.Droid.Views.EditContact
{
    [Register("socialTrading.droid.views.editContact.EditContactView")]
    public class EditContactView : RelativeLayout, IViewEditContact
    {
        private Holder _holder;
        private LayoutInflater _inflater;

        private bool _phoneChanged;
        private bool _cityChanged;
        private bool _skypeChanged;

        private const string SpinnerConst = "SpinnerTag";

        public IPresenterForViewEditContact Presenter { private get; set; }
        

        #region For RelatineLayout

        public EditContactView(Context context) : base(context)
        {
            Init(context);
        }

        public EditContactView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context);
        }

        public EditContactView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs,
            defStyleAttr)
        {
            Init(context);
        }

        public EditContactView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context,
            attrs, defStyleAttr, defStyleRes)
        {
            Init(context);
        }
        
        private void Init(Context context)
        {
            _inflater = ((Activity) context).LayoutInflater;
            _inflater.Inflate(Resource.Layout.EditContactView, this, true);
            _holder = new Holder(this);
            SetButtonsActions();
        }

        private void SetButtonsActions()
        {
            if (!_holder.SaveButton.HasOnClickListeners)
            {
                _holder.SaveButton.Click += (s, e) =>
                {
                    Presenter.SaveClick(_holder.EmailEditText.Text, _holder.SkypeEditText.Text, _holder.CountryEditText.Text, _holder.CityEditText.Text, _holder.PhoneEditText.Text);
                };
            }

            if (!_holder.CancelButton.HasOnClickListeners)
            {
                _holder.CancelButton.Click += (s, e) =>
                {
                    Presenter.CancelClick();
                };
            }

            if (!_holder.CountryEditText.HasOnClickListeners)
            {
                _holder.CountryEditText.FocusChange += (s, e) =>
                {
                    if (_holder.CountryEditText.HasFocus)
                    {
                        Presenter.CountryClick();
                    }
                };
            }

            _holder.SkypeEditText.EditorAction += (s, e) =>
            {
                if (e.ActionId == ImeAction.Next)
                {
                    _holder.CityEditText.RequestFocus();
                    _holder.CityEditText.SetSelection(_holder.CityEditText.Text.Length);
                }
            };

            _holder.SkypeEditText.AfterTextChanged += (s, e) =>
            {
                _skypeChanged = true;
            };

            _holder.SkypeEditText.FocusChange += (s, e) =>
            {
                if (_skypeChanged)
                {
                    _skypeChanged = false;
                    Presenter.SkypeTextChanged(_holder.SkypeEditText.Text);
                }
            };

            _holder.CityEditText.AfterTextChanged += (s, e) =>
            {
                _cityChanged = true;
            };

            _holder.CityEditText.FocusChange += (s, e) =>
            {
                if (_cityChanged)
                {
                    _cityChanged = false;
                    Presenter.CityTextChanged(_holder.CityEditText.Text);
                }
            };

            _holder.PhoneEditText.AfterTextChanged += (s, e) =>
            {
                _phoneChanged = true;
            };

            _holder.PhoneEditText.FocusChange += (s, e) =>
            {
                if (_phoneChanged)
                {
                    _phoneChanged = false;
                    Presenter.PhoneTextChanged(_holder.PhoneEditText.Text);
                }
            };
        }
        #endregion


        #region IViewEditContact

        public void SetCountry(string text)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.CountryEditText.Text = text;
            });
        }

        public void SetEmail(string text)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.EmailEditText.Text = text;
            });
        }

        public void SetSkype(string text)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.SkypeEditText.Text = text;
            });
        }

        public void SetPhone(string text)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PhoneEditText.Text = text;
            });
        }

        public void SetCity(string text)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.CityEditText.Text = text;
            });
        }


        public void SetCancelButtonLocale(string text)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.CancelButton.Text = text;
            });
        }

        public void SetCityLabelLocale(string text)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.CityTextView.Text = text;
            });
        }

        public void SetSkypeLabelLocale(string text)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.SkypeTextView.Text = text;
            });
        }

        public void SetSaveButtonLocale(string text)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.SaveButton.Text = text;
            });
        }

        public void SetPhoneLabelLocale(string text)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PhoneTextView.Text = text;
            });
        }

        public void SetEmailLabelLocale(string text)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.EmailTextView.Text = text;
            });
        }

        public void SetCountryLabelLocale(string text)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.CountryTextView.Text = text;
            });
        }


        public void SetCancelButtonTheme(IButtonTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.CancelButton.SetTheme(theme);
            });
        }

        public void SetCityEditTextTheme(IEditTextTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.CityEditText.SetTheme(theme);
            });
        }
        
        public void SetCityTextViewTheme(ITextViewTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.CityTextView.SetTheme(theme);
            });
        }
        
        public void SetCountryEditTextTheme(IEditTextTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.CountryEditText.SetTheme(theme);
            });
        }
        
        public void SetCountryTextViewTheme(ITextViewTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.CountryTextView.SetTheme(theme);
            });
        }
        
        public void SetEmailEditTextTheme(IEditTextTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.EmailEditText.SetTheme(theme);
            });
        }
        
        public void SetEmailTextViewTheme(ITextViewTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.EmailTextView.SetTheme(theme);
            });
        }
        
        public void SetPhoneEditTextTheme(IEditTextTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PhoneEditText.SetTheme(theme);
            });
        }
        
        public void SetPhoneTextViewTheme(ITextViewTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PhoneTextView.SetTheme(theme);
            });
        }
        
        public void SetSaveButtonTheme(IButtonTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.SaveButton.SetTheme(theme);
            });
        }
        
        public void SetSkypeEditTextTheme(IEditTextTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.SkypeEditText.SetTheme(theme);
            });
        }
        
        public void SetSkypeTextViewTheme(ITextViewTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.SkypeTextView.SetTheme(theme);
            });
        }

        public void SetViewTheme(IViewTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                this.SetTheme(theme);
            });
        }

        public void ShowSuccessAlert(string message, string buttonTitle)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                var alert = new AlertDialog.Builder(Context);

                alert.SetMessage(message)
                    .SetPositiveButton(buttonTitle, (senderAlert, args) => { Presenter.AlertOkClick();});

                Dialog dialog = alert.Create();
                dialog.Show();
            });
        }

        public void ShowFailAlert(string message, string buttonTitle)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                var alert = new AlertDialog.Builder(Context);

                alert.SetMessage(message)
                    .SetPositiveButton(buttonTitle, (senderAlert, args) => { });

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
                _holder.EmailEditText.Enabled = false;
                _holder.SkypeEditText.Enabled = false;
                _holder.CityEditText.Enabled = false;
            });
            spinnerView.Touch += (sender, args) => { };
        }

        public void HideSpinner()
        {
            var spinner = FindViewWithTag(SpinnerConst) as ViewGroup;

            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.EmailEditText.Enabled = true;
                _holder.SkypeEditText.Enabled = true;
                _holder.CityEditText.Enabled = true;

                if (spinner != null)
                {
                    RemoveView(spinner);
                }
            });
        }

        #endregion


        private class Holder
        {
            public Holder(View viewGroup)
            {
                EmailTextView = viewGroup.FindViewById<TextView>(Resource.Id.editContact_email_textView);
                SkypeTextView = viewGroup.FindViewById<TextView>(Resource.Id.editContact_skype_textView);
                CountryTextView = viewGroup.FindViewById<TextView>(Resource.Id.editContact_country_textView);
                CityTextView = viewGroup.FindViewById<TextView>(Resource.Id.editContact_city_textView);
                PhoneTextView = viewGroup.FindViewById<TextView>(Resource.Id.editContact_phone_textView);

                EmailEditText = viewGroup.FindViewById<EditText>(Resource.Id.editContact_email_editText);
                SkypeEditText = viewGroup.FindViewById<EditText>(Resource.Id.editContact_skype_editText);
                CountryEditText = viewGroup.FindViewById<EditText>(Resource.Id.editContact_country_editText);
                CityEditText = viewGroup.FindViewById<EditText>(Resource.Id.editContact_city_editText);
                PhoneEditText = viewGroup.FindViewById<EditText>(Resource.Id.editContact_phone_editText);

                SaveButton = viewGroup.FindViewById<Button>(Resource.Id.editContact_save_button);
                CancelButton = viewGroup.FindViewById<Button>(Resource.Id.editContact_cancel_button);
            }
            
            public TextView EmailTextView { get; }
            public TextView SkypeTextView { get; }
            public TextView CountryTextView { get; }
            public TextView CityTextView { get; }
            public TextView PhoneTextView { get; }

            public EditText EmailEditText { get; }
            public EditText SkypeEditText { get; }
            public EditText CountryEditText { get; }
            public EditText CityEditText { get; }
            public EditText PhoneEditText { get; }

            public Button SaveButton { get; }
            public Button CancelButton { get; }
        }
    }
}