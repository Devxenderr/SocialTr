using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Views.InputMethods;
using SocialTrading.Locale;
using SocialTrading.Droid.Theme;
using SocialTrading.Vipers.ForgotPass.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;

namespace SocialTrading.Droid.Views
{
    public class ForgotPassView : RelativeLayout, IViewForgotPass
    {
        public IPresenterForgotPass Presenter { private get; set; }

        private Holder _holder;
        private bool _emailChanged;
        private LayoutInflater _inflater;
        private const string SpinnerConst = "SpinnerTag";

        #region For RelativeLayout

        public ForgotPassView(Context context) : base(context)
        {
            Init(context);
        }

        public ForgotPassView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context);
        }

        public ForgotPassView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init(context);
        }

        public ForgotPassView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Init(context);
        }

        private void Init(Context context)
        {
            _inflater = ((Activity)context).LayoutInflater;
            _inflater.Inflate(Resource.Layout.ForgotPassView, this, true);
            
            _holder = new Holder(this);
            SetButtonsActions();
        }

        private void SetButtonsActions()
        {
            if (!_holder.RecoveryButton.HasOnClickListeners)
            {
                _holder.RecoveryButton.Click += (s, e) =>
                {
                    Presenter.PassRecoveryClick(_holder.EmailEditText.Text.Trim().ToLower());
                };
            }
            if (!_holder.BackImageButton.HasOnClickListeners)
            {
                _holder.BackImageButton.Click += (s, e) =>
                {
                    Presenter.BackButtonClick();
                };
            }

            if (!_holder.EmailEditText.HasOnClickListeners)
            {
                _holder.EmailEditText.AfterTextChanged += (s, e) =>
                {
                    _emailChanged = true;
                };
                _holder.EmailEditText.FocusChange += (s, e) =>
                {
                    if (_emailChanged)
                    {
                        _emailChanged = false;
                        Presenter.EmailInput(_holder.EmailEditText.Text.Trim().ToLower());
                    }
                };
            }
        }

        #endregion

        #region IView implementation

        public void ShowAlertEmailRedirect(string msg, string btnOk)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(Context);
                alert.SetMessage(msg);
                alert.SetPositiveButton(btnOk, (senderAlert, args) => { Presenter.AlertButtonClick();});
                Dialog dialog = alert.Create();
                dialog.Show();
            });
        }

        public void ShowSpinner()
        {
            _inflater.Inflate(Resource.Layout.Spinner, this, true);
            FindViewById(Resource.Id.LayoutForDelete).Tag = SpinnerConst;
            var spinnerView = FindViewById<View>(Resource.Id.SpinnerView);

            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.EmailEditText.Enabled = false;
            });

            spinnerView.SetOnTouchListener(new CliclToBlockBottomsElement());     
        }

        private class CliclToBlockBottomsElement : Java.Lang.Object, View.IOnTouchListener
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
                _holder.EmailEditText.Enabled = true;

                if (spinner != null)
                {
                    RemoveView(spinner);
                }
            });
        }

        public void SetConfig()
        {
            Presenter.SetLocale();

            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.EmailEditText.Hint = Localization.Lang.EmailHint;
                _holder.RecoveryButton.Text = Localization.Lang.ButtonNext;
            });
        }


        public void SetLogoImageViewTheme(IImageViewTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.LogoImageView.SetTheme(theme);
            });
        }

        public void SetEmailEditTextTheme(IEditTextTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.EmailEditText.SetTheme(theme);
            });
        }

        public void SetRecoveryButtonTheme(IButtonTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.RecoveryButton.SetTheme(theme);
            });
        }

        public void SetViewTheme(IImageViewTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.ImageBackground.SetTheme(theme);
            });
        }

        public void SetHeaderLabelTheme(ITextViewTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.HeaderTextView.SetTheme(theme);
            });
        }

        public void SetBackButtonTheme(IImageButtonTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.BackImageButton.SetTheme(theme);
            });
            
        }

        public void SetEmailLabelTheme(ITextViewTheme themeName)
        {
        }

        public void SetButtonLocale(string forgotPassButton)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.RecoveryButton.Text = forgotPassButton;
            });
        }

        public void SetHeaderLabelLocale(string passwordRecovery)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.HeaderTextView.Text = passwordRecovery;
            });
        }

        public void SetHintLocale(string emailHint)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.EmailEditText.Hint = emailHint;
            });
        }

        #endregion


        private class Holder
        {
            public Holder(ViewGroup viewGroup)
            {
                EmailEditText = viewGroup.FindViewById<EditText>(Resource.Id.pass_email_editText);
                RecoveryButton = viewGroup.FindViewById<Button>(Resource.Id.pass_retrive_button);
                ImageBackground = viewGroup.FindViewById<ImageView>(Resource.Id.forgotPass_background_imageView);
                LogoImageView = viewGroup.FindViewById<ImageView>(Resource.Id.pass_logo_imageView);
                HeaderTextView = viewGroup.FindViewById<TextView>(Resource.Id.pass_header_textView);
                BackImageButton = viewGroup.FindViewById<ImageButton>(Resource.Id.pass_back_imageButton);
            }
            
            public ImageView ImageBackground { get; }
            public EditText EmailEditText { get; }
            public Button RecoveryButton { get; }
            public ImageView LogoImageView { get; }
            public TextView HeaderTextView { get; }
            public ImageButton BackImageButton { get; }
        }
    }
}