using Xamarin.UITest;

namespace MAST_UI_Portable
{
    public abstract class APomBase
    {
        private Platform _platform;

        protected Platform Platform
        {
            get
            {
                return _platform;
            }
            private set
            {
                if (value == Platform.Android)
                {
                    OniOS = false;
                    OnAndroid = true;
                }
                else
                {
                    OnAndroid = false;
                    OniOS = true;
                }
                _platform = value;
            }
        }

        public bool OniOS { get; private set; }
        public bool OnAndroid { get; private set; }

        protected UserData user;
        protected readonly AppManager appManager;

        public APomBase(Platform lPlatform, AppManager manager)
        {
            Platform = lPlatform;                    
            user = new UserData();
            appManager = manager;
        }
    }
}
