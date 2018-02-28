using System;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Webkit;

using SocialTrading.Locale;

namespace SocialTrading.Droid.Fragments.RegistrationFragments
{
    public class UserAgreementFragment : Fragment
    {
        private View _view;
        private Button _btnAccept;
        private Button _btnDecline;


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _view = inflater.Inflate(Resource.Layout.UserAgreement, null, false);

            _btnAccept = _view.FindViewById<Button>(Resource.Id.btnAccept);
            _btnDecline = _view.FindViewById<Button>(Resource.Id.btnDecline);

            _btnAccept.Text = Localization.Lang.AcceptButton;
            _btnDecline.Text = Localization.Lang.DeclineButton;

            //WebView
            var localWebView = _view.FindViewById<WebView>(Resource.Id.LocalWebView);
            localWebView.VerticalScrollBarEnabled = true;
            localWebView.LoadUrl(GetString(Resource.String.URLLocalUserAgreement));

            return _view;
        }


        public override void OnResume()
        {
            base.OnResume();

            _btnAccept.Click += BtnAcceptClick;
            _btnDecline.Click += BtnDeclineClick;
        }

        public override void OnPause()
        {
            base.OnPause();

            _btnAccept.Click -= BtnAcceptClick;
            _btnDecline.Click -= BtnDeclineClick;
        }


        private void BtnDeclineClick(object sender, EventArgs e)
        {
            FollowPasswordFragment();
        }

        private void BtnAcceptClick(object sender, EventArgs e)
        {
            FollowPasswordFragment();
        }


        private void FollowPasswordFragment()
        {
            FragmentManager.PopBackStack();
        }
    }
}