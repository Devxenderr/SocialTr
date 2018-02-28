using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;

using Xamarin.Facebook;

using SocialTrading.Theme;
using SocialTrading.Droid.Theme;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.Vipers.Authorization.Interfaces;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.ThemesStyles.Interfaces.ImageView;

namespace SocialTrading.Droid.Views
{
    public class AuthView : RelativeLayout, IViewAuth
    {
        public IPresenterAuth Presenter { private get; set; }
        private Holder _holder;
        private LayoutInflater _inflater;
        private bool _emailChanged;
        private bool _passChanged;

        private const string SpinnerConst = "SpinnerTag";
        private string _token;

        #region For RelatineLayout

        public AuthView(Context context) : base(context)
        {
            Init(context);
        }

        public AuthView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context);
        }

        public AuthView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init(context);
        }

        public AuthView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Init(context);
        }
        
        private void Init(Context context)
        {
            _inflater = ((Activity)context).LayoutInflater;
            _inflater.Inflate(Resource.Layout.AuthView, this, true);

            _holder = new Holder(this);
            SetButtonsActions();
        }

        private void SetButtonsActions()
        {
            if (!_holder.AuthButton.HasOnClickListeners)
            {
                _holder.AuthButton.Click += (s, e) =>
                {
                    Presenter.LoginClick(_holder.EmailEditText.Text.Trim().ToLower(), _holder.PassEditText.Text);
                };
            }

            if (!_holder.RegButton.HasOnClickListeners)
            {
                _holder.RegButton.Click += (s, e) =>
                {
                    Presenter.RegistrationClick();
                };
            }

            if (!_holder.ForgotPassTextView.HasOnClickListeners)
            {
                _holder.ForgotPassTextView.Click += (s, e) =>
                {
                    Presenter.ForgotPasswordClick();
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

            if (!_holder.PassEditText.HasOnClickListeners)
            {
                _holder.PassEditText.AfterTextChanged += (s, e) =>
                {
                    _passChanged = true;
                };
                _holder.PassEditText.FocusChange += (s, e) =>
                {
                    if (_passChanged)
                    {
                        _passChanged = false;
                        Presenter.PasswordInput(_holder.PassEditText.Text);
                    }
                };
            }

            if (!_holder.NewFacebookImageButton.HasOnClickListeners)
            {
                _holder.NewFacebookImageButton.Click += (s, e) =>
                {
                    FacebookLoginClick();
                };
            }

            //if (!_holder.GoogleImageButton.HasOnClickListeners)
            //{
            //    _holder.GoogleImageButton.Click += (s, e) =>
            //    {
            //        GoogleLoginClick();
            //    };
            //}
            //if (!_holder.VkontakteImageButton.HasOnClickListeners)
            //{
            //    _holder.VkontakteImageButton.Click += (s, e) =>
            //    {
            //        VkLoginClick();
            //    };
            //}
            //if (!_holder.OdnoclassnikiImageButton.HasOnClickListeners)
            //{
            //    _holder.OdnoclassnikiImageButton.Click += (s, e) =>
            //    {
            //        OkLoginClick();
            //    };
            //}
        }

        #endregion

        #region IViewAuth

        public void ShowAlert(string title,string okLocale, string message)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(Context);
                alert.SetTitle(title);
                alert.SetMessage(message);
                alert.SetPositiveButton(okLocale, (senderAlert, args) => { });
                Dialog dialog = alert.Create();
                dialog.Show();
            });
        }

        public void ShowSpinner()
        {
            _inflater.Inflate(Resource.Layout.Spinner, this, true);
            FindViewById(Resource.Id.LayoutForDelete).Tag = SpinnerConst;
            var spinnerViewAuth = FindViewById<View>(Resource.Id.SpinnerView);

            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.EmailEditText.Enabled = false;
                _holder.PassEditText.Enabled = false;
            });
            spinnerViewAuth.SetOnTouchListener(new ClickToBlockBottomsElement());
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
                _holder.EmailEditText.Enabled = true;
                _holder.PassEditText.Enabled = true;
                
                if (spinner != null)
                {
                    RemoveView(spinner);
                }
            });
           
        }

        public void SetHeaderLabelTheme(ITextViewTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.SloganTextView.SetTheme(theme);
            });
        }

        public void SetEmailLabelTheme(ITextViewTheme theme)
        {
        }

        public void SetPasswordLabelTheme(ITextViewTheme theme)
        {
        }

        public void SetNoAccountLabelTheme(ITextViewTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.NoAccountTextView.SetTheme(theme);
            });
        }

        public void SetSocialNetworkLabelTheme(ITextViewTheme theme)
        {
        }

        public void SetLogInButtonTheme(IButtonTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.AuthButton.SetTheme(theme);
            });
        }

        public void SetFacebookButtonTheme(IButtonTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.NewFacebookImageButton.SetTheme(theme);
            });
        }

        public void SetRegistrationButtonTheme(IButtonTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.RegButton.SetTheme(theme);
            });
        }

        public void SetForgetPassTheme(IButtonTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.ForgotPassTextView.SetTheme((ITextViewTheme)theme);
            });
        }

        public void SetViewTheme(IImageViewTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.Background_imageView.SetTheme(theme);
            });
        }

        public void SetFbAuthTheme(string backgroundImage, string tintColor)
        {
            // TODO: Create theme
        }

        public void SetGoogleAuthTheme(string backgroundImage, string tintColor)
        {
            // TODO: Create theme
        }

        public void SetOkAuthTheme(string backgroundImage, string tintColor)
        {
            // TODO: Create theme
        }

        public void SetVkAuthTheme(string backgroundImage, string tintColor)
        {
            // TODO: Create theme
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

        public void SetPasswordEditTextTheme(IEditTextTheme theme)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.PassEditText.SetTheme(theme);
            });
        }

        public void SetEmailLocale(string emailHint)
        {
            _holder.EmailEditText.Hint = emailHint;
        }

        public void SetPassLocale(string passwordHint)
        {
            _holder.PassEditText.Hint = passwordHint;
        }

        public void SetRegButtonLocale(string regButton)
        {
            _holder.RegButton.Text = regButton;
        }

        public void SetAuthButtonLocale(string logInButton)
        {
            _holder.AuthButton.Text = logInButton;
        }

        public void SetFacebookButtonLocale(string enterFacebook)
        {
            _holder.NewFacebookImageButton.Text = enterFacebook;
        }

        public void SetForgotPassLocale(string forgetPasswordLink)
        {
            _holder.ForgotPassTextView.Text = forgetPasswordLink;
        }

        public void SetSloganLocale(string authSlogan)
        {
            _holder.SloganTextView.Text = authSlogan;
        }

        public void SetNoAccountLocale(string authNoAccount)
        {
            _holder.NoAccountTextView.Text = authNoAccount;
        }

        public void SetSocialEnterLocale(string authSocialEnter)
        {
            //_holder.SocialEnterTextView.Text = authSocialEnter;
        }

        public void FacebookLoginClick()
        {
            Presenter.FacebookLoginClick();
        }

        public void GoogleLoginClick()
        {
            Presenter.GoogleLoginClick();
        }

        public void VkLoginClick()
        {
            Presenter.VkLoginClick();
        }

        public void OkLoginClick()
        {
            Presenter.OkLoginClick();
        }

        public void SetConfig()
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                Presenter.SetLocale();
                ThemesHelper.PerformTheme(Context, Themes.GetAuthTheme());
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
                _holder.AuthButton.Enabled = availability;
                _holder.NewFacebookImageButton.Enabled = availability;
                _holder.RegButton.Enabled = availability;
                _holder.ForgotPassTextView.Enabled = availability;
                //  _holder.VkontakteImageButton.Enabled = availability;
                //    _holder.OdnoclassnikiImageButton.Enabled = availability;
                //    _holder.GoogleImageButton.Enabled = availability;
                //   _holder.FacebookImageButton.Enabled = availability;
                _holder.NewFacebookImageButton.Enabled = availability;
                _holder.EmailEditText.Enabled = availability;
                _holder.PassEditText.Enabled = availability;
            });
        }

        #endregion

        //#region Facebook

        //public void OnFBError(FacebookException ex)
        //{
        //    ShowAlert(Presenter.GetErrorLocale(), Presenter.GetFacebookAuthErrorLocale());
        //}

        //public void OnFBSuccess(Java.Lang.Object result)
        //{
        //    _token = AccessToken.CurrentAccessToken.Token;
        //}

        //public void OnFBCancel()
        //{

        //} TODO: delete this???

        //#endregion

        private class Holder
        {
            public Holder(ViewGroup viewGroup)
            {
                EmailEditText = viewGroup.FindViewById<EditText>(Resource.Id.auth_email_editText);
                PassEditText = viewGroup.FindViewById<EditText>(Resource.Id.auth_pass_editText);

                RegButton = viewGroup.FindViewById<Button>(Resource.Id.auth_reg_button);
                AuthButton = viewGroup.FindViewById<Button>(Resource.Id.auth_auth_button);
                ForgotPassTextView = viewGroup.FindViewById<TextView>(Resource.Id.auth_forgot_textView);

                SloganTextView = viewGroup.FindViewById<TextView>(Resource.Id.auth_slogan_textViewView);
               // SocialEnterTextView = viewGroup.FindViewById<TextView>(Resource.Id.auth_socialEnter_textView);
                NoAccountTextView = viewGroup.FindViewById<TextView>(Resource.Id.auth_noAccount_textView);

                MainRelativeLayout = viewGroup.FindViewById<RelativeLayout>(Resource.Id.backgroundRA_relativeLayout);
                Background_imageView = viewGroup.FindViewById<ImageView>(Resource.Id.auth_background_imageView);

                //VkontakteImageButton = viewGroup.FindViewById<ImageButton>(Resource.Id.auth_vk_imageButton);
                //GoogleImageButton = viewGroup.FindViewById<ImageButton>(Resource.Id.auth_google_imageButton);
                //FacebookImageButton = viewGroup.FindViewById<ImageButton>(Resource.Id.auth_facebook_imageButton);
                //OdnoclassnikiImageButton = viewGroup.FindViewById<ImageButton>(Resource.Id.auth_odnokl_imageButton);
                NewFacebookImageButton = viewGroup.FindViewById<Button>(Resource.Id.newauth_facebook_imageButton);
                LogoImageView = viewGroup.FindViewById<ImageView>(Resource.Id.auth_logo_imageView);
            }

            public EditText EmailEditText { get; } 
            public EditText PassEditText { get; }

            public Button RegButton { get; }
            public Button AuthButton { get; }
            public TextView ForgotPassTextView { get; }

            public TextView SloganTextView { get; }
          //  public TextView SocialEnterTextView { get; }
            public TextView NoAccountTextView { get; }
            
            public RelativeLayout MainRelativeLayout { get; }

       //     public ImageButton FacebookImageButton { get; }
       //     public ImageButton GoogleImageButton { get; }
       //     public ImageButton OdnoclassnikiImageButton { get; }
       //     public ImageButton VkontakteImageButton { get; }

            public Button NewFacebookImageButton { get; }

            public ImageView LogoImageView { get; }
            public ImageView Background_imageView { get; }
        }
    }
}