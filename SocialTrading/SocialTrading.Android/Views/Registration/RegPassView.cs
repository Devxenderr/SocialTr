using System;

using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;

using SocialTrading.Theme;
using SocialTrading.Droid.Theme;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.Vipers.Registration.Password.Interfaces;

namespace SocialTrading.Droid.Views
{
    public class RegPassView : RelativeLayout, IViewRegPass
    {
        public IPresenterRegPass Presenter { get; set; }

        private Holder _holder;
        private LayoutInflater _inflater;
        private const string SpinnerConst = "SpinnerTag";

        private bool _passChanged;
        private bool _confirmPassChanged;

        #region For RelativeLayout

        public RegPassView(Context context) : base(context)
        {
            Init(context);
        }

        public RegPassView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context);
        }

        public RegPassView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init(context);
        }

        public RegPassView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Init(context);
        }

        private void Init(Context context)
        {
            _inflater = ((Activity)context).LayoutInflater;
            _inflater.Inflate(Resource.Layout.RegPassView, this, true);

            _holder = new Holder(this);
            SetButtonsActions();
        }

        private void SetButtonsActions()
        {
            if (!_holder.RegButton.HasOnClickListeners)
            {
                _holder.RegButton.Click += (s, e) =>
                {
                    Presenter.RegisterClick();
                };
            }

            if (!_holder.UserAgreementTextView.HasOnClickListeners)
            {
                _holder.UserAgreementTextView.Click += (s, e) =>
                {
                    Presenter.UserAgreementClick();
                };
            }
            if (!_holder.PasswordEditText.HasOnClickListeners)
            {
                _holder.PasswordEditText.AfterTextChanged += (s, e) =>
                {
                    _passChanged = true;
                };
                _holder.PasswordEditText.FocusChange += (s, e) =>
                {
                    if (_passChanged)
                    {
                        _passChanged = false;
                        Presenter.PasswordInput();
                    }
                };
                _holder.PasswordEditText.TextChanged += (s, e) =>
                {
                    if (_confirmPassChanged & _holder.PasswordEditText.Text.Length <= _holder.ConfirmPasswordEditText.Text.Length)
                    {
                        _confirmPassChanged = false;
                        Presenter.PasswordConfirmInput();
                    }
                };
            }

            if (!_holder.ConfirmPasswordEditText.HasOnClickListeners)
            {
                _holder.ConfirmPasswordEditText.AfterTextChanged += (s, e) =>
                {
                    _confirmPassChanged = true;
                };
                _holder.ConfirmPasswordEditText.TextChanged += (s, e) =>
                {
                    if (_confirmPassChanged & _holder.ConfirmPasswordEditText.Text.Length >= _holder.PasswordEditText.Text.Length)
                    {
                        _confirmPassChanged = false;
                        Presenter.PasswordConfirmInput();
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

        #region IViewRegPass
        
        public void ShowRegSuccess(string title, string message)
        { 
            ShowAlert(title, message, Presenter.AlertOkClick);
        }

        public void ShowRegFail(string title, string message)
        {
            ShowAlert(title, message);
        }

        public void ShowSpinner()
        {
            _inflater.Inflate(Resource.Layout.Spinner, this, true);
            FindViewById(Resource.Id.LayoutForDelete).Tag = SpinnerConst;
            var spinnerView = FindViewById<View>(Resource.Id.SpinnerView);

            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PasswordEditText.Enabled = false;
                _holder.ConfirmPasswordEditText.Enabled = false;
            });

            spinnerView.SetOnTouchListener(new ClickToBlockBottomsElement());
        }

        private class ClickToBlockBottomsElement : Java.Lang.Object, View.IOnTouchListener
        {

            public bool OnTouch(View v, MotionEvent e)
            {
                return true;
            }
        }

        public void HideSpinner()
        {
            var spinner = FindViewWithTag(SpinnerConst) as ViewGroup;

            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PasswordEditText.Enabled = true;
                _holder.ConfirmPasswordEditText.Enabled = true;

                if (spinner != null)
                {
                    RemoveView(spinner);
                }
            });
        }

        public void SetPassword(string pass)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PasswordEditText.Text = pass;
            });
        }

        public void SetConfirmPass(string confirmPass)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.ConfirmPasswordEditText.Text = confirmPass;
            });
        }

        public string GetPassword()
        {
            return _holder.PasswordEditText.Text;
        }

        public string GetConfirmPassword()
        {
            return _holder.ConfirmPasswordEditText.Text;
        }


        public void SetHeaderLabelTheme(ITextViewTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.TitleTextView.SetTheme(themeName);
            });
        }

        public void SetPasswordLabelTheme(ITextViewTheme themeName)
        {
        }

        public void SetConfirmPasswordLabelTheme(ITextViewTheme themeName)
        {
        }

        public void SetRegButtonTheme(IButtonTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.RegButton.SetTheme(themeName);
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

        public void SetPasswordEditTextTheme(IEditTextTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PasswordEditText.SetTheme(themeName);
            });
        }

        public void SetConfirmPasswordEditTextTheme(IEditTextTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.ConfirmPasswordEditText.SetTheme(themeName);
            });
        }

        public void SetUserAgreementTheme(IButtonTheme mainThemeName, string mainText, IButtonTheme attrThemeName, string attrText, int position)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.UserAgreementTextView.SetTheme((ITextViewTheme)mainThemeName, mainText, (ITextViewTheme)attrThemeName, attrText, position);
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

        public void SetPasswordLocale(string passwordHint)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PasswordEditText.Hint = passwordHint;
            });
        }

        public void SetConfirmPasswordLocale(string regPassConfirmHint)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.ConfirmPasswordEditText.Hint = regPassConfirmHint;
            });
        }

        public void SetRegButtonLocale(string regButton)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.RegButton.Text = regButton;
            });
        }

        public void SetUserAgreementLocale(string regUserAgreementLink)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.UserAgreementTextView.Text = regUserAgreementLink;
            });
        }

        public void SetTitleLocale(string regPassTextView)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.TitleTextView.Text = regPassTextView;
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

        private void ShowAlert(string title, string message, Action act = null)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(Context);
                alert.SetTitle(title);
                alert.SetMessage(message);
                alert.SetPositiveButton(Presenter.GetOkLocale(), (senderAlert, args) => { act?.Invoke(); });
                AlertDialog dialog = alert.Create();
                dialog.SetCanceledOnTouchOutside(false);
                dialog.Show();
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
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.BackImageButton.Enabled = availability;
                _holder.ConfirmPasswordEditText.Enabled = availability;
                _holder.PasswordEditText.Enabled = availability;
                _holder.RegButton.Enabled = availability;
                _holder.UserAgreementTextView.Enabled = availability;
            });
        }

        private class Holder
        {
            public Holder(ViewGroup viewGroup)
            {
                PasswordEditText = viewGroup.FindViewById<EditText>(Resource.Id.reg_pass_editText);
                ConfirmPasswordEditText = viewGroup.FindViewById<EditText>(Resource.Id.reg_confirm_pass_editText);
                
                UserAgreementTextView = viewGroup.FindViewById<TextView>(Resource.Id.reg_userAgreement_textView);
                RegButton = viewGroup.FindViewById<Button>(Resource.Id.reg_follow_main_button);

                BackImageButton = viewGroup.FindViewById<ImageButton>(Resource.Id.regPass_back_imageButton);
                LogoImageView = viewGroup.FindViewById<ImageView>(Resource.Id.regPass_logo_imageView);

                TitleTextView = viewGroup.FindViewById<TextView>(Resource.Id.reg_enterPass_textView);

                MainRelativeLayout = viewGroup.FindViewById<RelativeLayout>(Resource.Id.regPass_background_relativeLayout);
                BackgroundImageView = viewGroup.FindViewById<ImageView>(Resource.Id.regPass_background_imageView);

                FeatureImageView = viewGroup.FindViewById<ImageView>(Resource.Id.regPass_featureImage_imageView);
                FeatureTextView = viewGroup.FindViewById<TextView>(Resource.Id.regPass_featureText_textView);
            }

            public EditText PasswordEditText { get; }
            public EditText ConfirmPasswordEditText { get; }
            public TextView UserAgreementTextView { get; }
            public Button RegButton { get; }

            public ImageButton BackImageButton { get; }
            public ImageView LogoImageView { get; }

            public TextView TitleTextView { get; }

            public RelativeLayout MainRelativeLayout { get; }

            public ImageView FeatureImageView { get; }
            public TextView FeatureTextView { get; }
            public ImageView BackgroundImageView { get; }
        }
    }
}