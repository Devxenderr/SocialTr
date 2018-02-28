using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;

using SocialTrading.Theme;
using SocialTrading.Droid.Theme;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.Vipers.Registration.Phone.Interfaces;

namespace SocialTrading.Droid.Views
{
    public class RegPhoneView : RelativeLayout, IViewRegPhone
    {
        public IPresenterRegPhone Presenter { get; set; }

        private Holder _holder;
        private bool _phoneCountryChanged;
        private bool _phoneNumberChanged;


        #region For RelativeLayout

        public RegPhoneView(Context context) : base(context)
        {
            Init(context);
        }

        public RegPhoneView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context);
        }

        public RegPhoneView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init(context);
        }

        public RegPhoneView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Init(context);
        }

        private void Init(Context context)
        {
            LayoutInflater inflater = ((Activity)context).LayoutInflater;
            inflater.Inflate(Resource.Layout.RegPhoneView, this, true);

            _holder = new Holder(this);
            SetButtonsActions();
        }

        private void SetButtonsActions()
        {
            if (!_holder.NextButton.HasOnClickListeners)
            {
                _holder.NextButton.Click += (s, e) =>
                {
                    Presenter.NextClick();
                };
            }

            if (!_holder.SkipButton.HasOnClickListeners)
            {
                _holder.SkipButton.Click += (s, e) =>
                {
                    Presenter.SkipClick();
                };
            }

            if (!_holder.PhoneCountryEditText.HasOnClickListeners)
            {
                _holder.PhoneCountryEditText.TextChanged += (s, e) =>
                {
                    var textField = s as EditText;

                    if (textField.Text.Length.Equals(0))
                    {
                        textField.Text = "+";
                    }
                    else if (!textField.Text[0].Equals('+'))
                    {
                        textField.Text = textField.Text.Insert(0, "+");
                    }
                    textField.SetSelection(textField.Text.Length);

                    _phoneCountryChanged = true;
                };
                _holder.PhoneCountryEditText.FocusChange += (s, e) =>
                {
                    if (_phoneCountryChanged)
                    {
                        _phoneCountryChanged = false;
                        Presenter.PhoneCountryInput();
                    }
                };
            }

            if (!_holder.PhoneNumberEditText.HasOnClickListeners)
            {
                _holder.PhoneNumberEditText.AfterTextChanged += (s, e) =>
                {
                    _phoneNumberChanged = true;
                };
                _holder.PhoneNumberEditText.FocusChange += (s, e) =>
                {
                    if (_phoneNumberChanged)
                    {
                        _phoneNumberChanged = false;
                        Presenter.PhoneNumberInput();
                    }
                };
            }

            if (!_holder.BackImageButton.HasOnClickListeners)
            {
                _holder.BackImageButton.Click += (s, e) =>
                {
                    Presenter.BackClick();
                };
            }
        }
        #endregion

        #region IViewRegPhone
        
        public void SetPhoneCountry(string phoneCountry)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PhoneCountryEditText.Text = phoneCountry;
            });
        }

        public string GetPhoneCountry()
        {
            return _holder.PhoneCountryEditText.Text;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PhoneNumberEditText.Text = phoneNumber;
            });
        }

        public string GetPhoneNumber()
        {
            return _holder.PhoneNumberEditText.Text;
        }

        public void SetHeaderLabelTheme(ITextViewTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.TitleTextView.SetTheme(themeName);
            });
        }

        public void SetPhoneCountryLabelTheme(ITextViewTheme themeName)
        {
        }

        public void SetPhoneNumberLabelTheme(ITextViewTheme themeName)
        {
        }

        public void SetNextButtonTheme(IButtonTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.NextButton.SetTheme(themeName);
            });
        }

        public void SetSkipButtonTheme(IButtonTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.SkipButton.SetTheme(themeName);
            });
        }
        
        public void SetBackButtonTheme(IImageButtonTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.BackImageButton.SetTheme(themeName);
            });
        }

        public void SetViewTheme(IImageViewTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.BackgroundImageView.SetTheme(themeName);
            });
        }

        public void SetLogoImageViewTheme(IImageViewTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.LogoImageView.SetTheme(themeName);
            });
        }

        public void SetPhoneCountryEditTextTheme(IEditTextTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PhoneCountryEditText.SetTheme(themeName);
            });
        }

        public void SetPhoneNumberEditTextTheme(IEditTextTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PhoneNumberEditText.SetTheme(themeName);
            });
        }

        public void SetFeatureImageTheme(IImageViewTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.FeatureImageView.SetTheme(themeName);
            });
        }

        public void SetFeatureTextTheme(ITextViewTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.FeatureTextView.SetTheme(themeName);
            });
        }

        public void SetFeatureTextLocale(string featureText)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.FeatureTextView.Text = featureText;
            });
        }

        public void SetPhoneCountryLocale(string regPhoneCountryHint)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PhoneCountryEditText.Hint = regPhoneCountryHint;
            });
        }

        public void SetPhoneNumberLocale(string regPhoneNumberHint)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PhoneNumberEditText.Hint = regPhoneNumberHint;
            });
        }

        public void SetNextButtonLocale(string buttonNext)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.NextButton.Text = buttonNext;
            });
        }

        public void SetSkipButtonLocale(string regPhoneNumberButtonSkip)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.SkipButton.Text = regPhoneNumberButtonSkip;
            });
        }

        public void SetTitleLocale(string regPhoneNumberHeader)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.TitleTextView.Text = regPhoneNumberHeader;
            });
        }


        public void SetConfig()
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                Presenter.SetLocale();
                ThemesHelper.PerformTheme(Context, Themes.GetRegTheme());
            });
        }
        
        #endregion

        private class Holder
        {
            public Holder(ViewGroup viewGroup)
            {
                PhoneCountryEditText = viewGroup.FindViewById<EditText>(Resource.Id.reg_phoneCountry_editText);
                PhoneNumberEditText = viewGroup.FindViewById<EditText>(Resource.Id.reg_phoneNumber_editText);
                NextButton = viewGroup.FindViewById<Button>(Resource.Id.reg_follow_email_button);
                SkipButton = viewGroup.FindViewById<Button>(Resource.Id.reg_skip_phone_button);
                
                TitleTextView = viewGroup.FindViewById<TextView>(Resource.Id.reg_enterPhone_textView);
                BackImageButton = viewGroup.FindViewById<ImageButton>(Resource.Id.regPhone_back_imageButton);
                LogoImageView = viewGroup.FindViewById<ImageView>(Resource.Id.regPhone_logo_imageView);

                MainRelativeLayout = viewGroup.FindViewById<RelativeLayout>(Resource.Id.regPhone_background_relativeLayout);
                BackgroundImageView = viewGroup.FindViewById<ImageView>(Resource.Id.regPhone_background_imageView);

                FeatureImageView = viewGroup.FindViewById<ImageView>(Resource.Id.regPhone_featureImage_imageView);
                FeatureTextView = viewGroup.FindViewById<TextView>(Resource.Id.regPhone_featureText_textView);
            }

            public EditText PhoneCountryEditText { get; }
            public EditText PhoneNumberEditText { get; }
            public Button NextButton { get; }
            public Button SkipButton { get; }

            public TextView TitleTextView { get; }
            public ImageButton BackImageButton { get; }
            public ImageView LogoImageView { get; }

            public RelativeLayout MainRelativeLayout { get; }

            public ImageView FeatureImageView { get; }
            public TextView FeatureTextView { get; }
            public ImageView BackgroundImageView { get; }
        }
    }
}