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
using SocialTrading.ThemesStyles.Interfaces.View;
using SocialTrading.Vipers.Registration.Name.Interfaces;

namespace SocialTrading.Droid.Views
{
    public class RegNameView : RelativeLayout, IViewRegName
    {
        public IPresenterRegName Presenter { private get; set; }

        private Holder _holder;

        private bool _nameChanged;
        private bool _lastNameChanged;


        #region For RelativeLayout

        public RegNameView(Context context) : base(context)
        {
            Init(context);
        }

        public RegNameView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context);
        }

        public RegNameView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init(context);
        }

        public RegNameView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Init(context);
        }

        private void Init(Context context)
        {
            LayoutInflater inflater = ((Activity)context).LayoutInflater;
            inflater.Inflate(Resource.Layout.RegNameView, this, true);

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

            if (!_holder.NameEditText.HasOnClickListeners)
            {
                _holder.NameEditText.AfterTextChanged += (s, e) =>
                {
                    _nameChanged = true;
                };
                _holder.NameEditText.FocusChange += (s, e) =>
                {
                    if (_nameChanged)
                    {
                        _nameChanged = false;
                        Presenter.NameInput();
                    }
                };
            }

            if (!_holder.LastNameEditText.HasOnClickListeners)
            {
                _holder.LastNameEditText.AfterTextChanged += (s, e) =>
                {
                    _lastNameChanged = true;
                };
                _holder.LastNameEditText.FocusChange += (s, e) =>
                {
                    if (_lastNameChanged)
                    {
                        _lastNameChanged = false;
                        Presenter.LastNameInput();
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

        #region IViewRegName
        
        public void SetFirstName(string firstName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.NameEditText.Text = firstName;
            });
        }

        public void SetLastName(string lastName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.LastNameEditText.Text = lastName;
            });
        }

        public string GetFirstName()
        {
            string name = string.Empty;
            (Context as Activity)?.RunOnUiThread(() =>
            {
                name = _holder.NameEditText.Text;
            });
            return name;
        }

        public string GetLastName()
        {
            string lastname = string.Empty;
            (Context as Activity)?.RunOnUiThread(() =>
            {
                lastname = _holder.LastNameEditText.Text;
            });
            return lastname;
        }

        public void SetHeaderLabelTheme(ITextViewTheme themeName)
        {
            _holder.TitleTextView.SetTheme(themeName);
        }

        public void SetNameLabelTheme(ITextViewTheme themeName)
        {
        }

        public void SetLastNameLabelTheme(ITextViewTheme themeName)
        {
        }

        public void SetBackButtonTheme(IImageButtonTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.BackImageButton.SetTheme((IImageViewTheme) themeName);
            });
        }

        public void SetNextButtonTheme(IButtonTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.NextButton.SetTheme(themeName);
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

        public void SetNameEditTextTheme(IEditTextTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.NameEditText.SetTheme(themeName);
            });
        }

        public void SetLastNameEditTextTheme(IEditTextTheme themeName)
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                _holder.LastNameEditText.SetTheme(themeName);
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
            _holder.FeatureTextView.Text = featureText;
        }
        
        public void SetNameLocale(string regNameHint)
        {
            _holder.NameEditText.Hint = regNameHint;
        }

        public void SetLastNameLocale(string regLastNameHint)
        {
            _holder.LastNameEditText.Hint = regLastNameHint;
        }

        public void SetNextButtonLocale(string buttonNext)
        {
            _holder.NextButton.Text = buttonNext;
        }

        public void SetTitleLocale(string regNameTextView)
        {
            _holder.TitleTextView.Text = regNameTextView;
        }


        public void SetConfig()
        {
            (Context as Activity)?.RunOnUiThread(() =>
            {
                Presenter.SetLocale();
            });
        }
        
        #endregion

        private class Holder
        {
            public Holder(ViewGroup viewGroup)
            {
                NameEditText = viewGroup.FindViewById<EditText>(Resource.Id.reg_name_editText);
                LastNameEditText = viewGroup.FindViewById<EditText>(Resource.Id.reg_lastname_editText);
                NextButton = viewGroup.FindViewById<Button>(Resource.Id.reg_follow_phone_button);

                BackImageButton = viewGroup.FindViewById<ImageButton>(Resource.Id.regName_back_imageButton);
                LogoImageView = viewGroup.FindViewById<ImageView>(Resource.Id.regName_logo_imageView);

                TitleTextView = viewGroup.FindViewById<TextView>(Resource.Id.reg_enterName_textView);

                MainRelativeLayout = viewGroup.FindViewById<RelativeLayout>(Resource.Id.regName_background_relativeLayout);
                BackgroundImageView = viewGroup.FindViewById<ImageView>(Resource.Id.regName_background_imageView); 

                FeatureImageView = viewGroup.FindViewById<ImageView>(Resource.Id.regName_featureImage_imageView);
                FeatureTextView = viewGroup.FindViewById<TextView>(Resource.Id.regName_featureText_textView);
            }

            public EditText NameEditText { get; }
            public EditText LastNameEditText { get; }
            public Button NextButton { get; }

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