using System.Collections.Generic;

using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.Accounts;

using SocialTrading.Theme;
using SocialTrading.Droid.Theme;
using SocialTrading.ThemesStyles.Interfaces.Button;
using SocialTrading.ThemesStyles.Interfaces.EditText;
using SocialTrading.ThemesStyles.Interfaces.ImageButton;
using SocialTrading.ThemesStyles.Interfaces.ImageView;
using SocialTrading.ThemesStyles.Interfaces.TextView;
using SocialTrading.Vipers.Registration.Email.Interfaces;

namespace SocialTrading.Droid.Views
{
    public class RegEmailView : RelativeLayout, IViewRegEmail
    {
        public IPresenterRegEmail Presenter { private get; set; }

        private Holder _holder;
        

        #region For RelativeLayout

        public RegEmailView(Context context) : base(context)
        {
            Init(context);
        }

        public RegEmailView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context);
        }

        public RegEmailView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init(context);
        }

        public RegEmailView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Init(context);
        }

        private void Init(Context context)
        {
            LayoutInflater inflater = ((Activity)context).LayoutInflater;
            inflater.Inflate(Resource.Layout.RegEmailView, this, true);

            _holder = new Holder(this);
            SetButtonsActions();
        }

        public void ShowConnectedEmails()
        {
            if (_holder.EmailEditText.Text != string.Empty)
            {
                return;
            }

            List<string> emails = FindAllEmails();

            if (emails == null || emails.Count == 0)
            {
                return;
            }

            ShowEmailsAlert(emails);
        }

        private void ShowEmailsAlert(List<string> emails)
        {
            LayoutInflater inflater = ((Activity)Context).LayoutInflater;
            View view = inflater.Inflate(Resource.Layout.CustomAlert, null);

            ViewGroup viewGroup = view.FindViewById<ViewGroup>(Resource.Id.ll_alert);
            viewGroup.SetPadding(40, 20, 10, 20);

            RadioGroup group = new RadioGroup(Context);

            for (int i = 0; i < emails.Count; i++)
            {
                RadioButton radio = new RadioButton(Context)
                {
                    Text = emails[i],
                    TextSize = 16,
                    Id = i
                };

                if (i == 0)
                {
                    radio.Checked = true;
                }

                group.AddView(radio);
            }
            viewGroup.AddView(group);

            AlertDialog.Builder builder = new AlertDialog.Builder(Context);
            builder.SetTitle(Presenter.GetShowEmailsAlertTitleLocale())
                .SetView(view)
                .SetCancelable(false)
                .SetNegativeButton(Presenter.GetCancelLocale(), (o, e) => { })
                .SetPositiveButton(Presenter.GetOkLocale(), (o, e) => { _holder.EmailEditText.Text = emails[group.CheckedRadioButtonId]; })
                .Show();
        }

        private List<string> FindAllEmails()
        {
            List<string> emails = new List<string>();
            Java.Util.Regex.Pattern emailPattern = Patterns.EmailAddress;
            Account[] accounts = AccountManager.Get(Context).GetAccounts();
            for (int i = 0; i < accounts.Length; i++)
            {
                if (emailPattern.Matcher(accounts[i].Name).Matches())
                {
                    if (!emails.Contains(accounts[i].Name))
                    {
                        emails.Add(accounts[i].Name);
                    }
                }
            }
            return emails;
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

            if (!_holder.BackImageButton.HasOnClickListeners)
            {
                _holder.BackImageButton.Click += (s, e) =>
                {
                    Presenter.BackClick();
                };
            }
        }
        
        #endregion

        #region IViewRegEmail

        public void SetEmail(string email)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.EmailEditText.Text = email;
            });
        }

        public void SetFeatureTextLocale(string featureText)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.FeatureTextView.Text = featureText;
            });
        }

        public string GetEmail()
        {
            return _holder.EmailEditText.Text;
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

        public void SetHeaderLabelTheme(ITextViewTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.TitleTextView.SetTheme(themeName);
            });
        }

        public void SetEmailLabelTheme(ITextViewTheme themeName)
        {
        }

        public void SetNextButtonTheme(IButtonTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.NextButton.SetTheme(themeName);
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
                _holder.Background_imageView.SetTheme(themeName);
            });
        }

        public void SetLogoImageViewTheme(IImageViewTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.LogoImageView.SetTheme(themeName);
            });
        }

        public void SetEmailEditTextTheme(IEditTextTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.EmailEditText.SetTheme(themeName);
            });
        }


        public void SetEmailLocale(string regEmailTextView)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.EmailEditText.Hint = regEmailTextView;
            });
        }

        public void SetNextButtonLocale(string buttonNext)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.NextButton.Text = buttonNext;
            });
        }

        public void SetTitleLocale(string regEmailTextView)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.TitleTextView.Text = regEmailTextView;
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
                EmailEditText = viewGroup.FindViewById<EditText>(Resource.Id.reg_email_editText);
                NextButton = viewGroup.FindViewById<Button>(Resource.Id.reg_follow_pass_button);

                BackImageButton = viewGroup.FindViewById<ImageButton>(Resource.Id.regEmail_back_imageButton);
                LogoImageView = viewGroup.FindViewById<ImageView>(Resource.Id.regEmail_logo_imageView);

                TitleTextView = viewGroup.FindViewById<TextView>(Resource.Id.reg_enterEmail_textView);

                MainRelativeLayout = viewGroup.FindViewById<RelativeLayout>(Resource.Id.regEmail_background_relativeLayout);
                Background_imageView = viewGroup.FindViewById<ImageView>(Resource.Id.regEmail_background_imageView);

                FeatureImageView = viewGroup.FindViewById<ImageView>(Resource.Id.regEmail_featureImage_imageView);
                FeatureTextView = viewGroup.FindViewById<TextView>(Resource.Id.regEmail_featureText_textView);
            }

            public EditText EmailEditText { get; }
            public Button NextButton { get; }

            public ImageButton BackImageButton { get; }
            public ImageView LogoImageView { get; }

            public TextView TitleTextView { get; }

            public RelativeLayout MainRelativeLayout { get; }

            public ImageView FeatureImageView { get; }
            public TextView FeatureTextView { get; }
            public ImageView Background_imageView { get; }
        }
    }
}