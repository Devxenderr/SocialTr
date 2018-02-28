using Xamarin.UITest;

namespace MAST_UI_Portable
{
  
    public sealed class AppManager
    {
        private static object locker = new object();
        private static AppManager _appManager;
        private static Platform? _platformStatic;

        private Platform _platform;
        private AuthorizationScreen _authScreen;
        private RegistrationScreen _registrScreen;
        private CreatePostScreen _createPostScreen;
        private AutorizationHelper _authHelper;
        private RegistrationHelper _registrHelper;
        private CreatePostHelper _createPostHelper;
        private ToolbarScreen _toolbarScreen;
        private BaseHelper _baseHelper;
        private SmokeHelper _smokeHelper;
        private NavigationHelper _navigationHelper;
        private EditContactDataHelper _editContactDataHelper;
        private TabNewsScreen _tabNewsScreen;
        private AlertScreens _alertScreens;
        private SettingsScreen _settingsScreen;
        private ToolsCreatePostScreen _toolsCreatePostScreen;
        private PostScreen _postScreen;
        private MoreOptionsScreens _moreOptionScreens;
        private EditProfileScreen _editProfileScreen;
        private EditContactScreen _editContactScreen;

        public static AppManager GetInstance(Platform platform)
        {
            lock (locker)
            {
                if (_appManager == null || (_platformStatic != platform && _platformStatic != null))
                {
                    _platformStatic = platform;
                    _appManager = new AppManager(platform);
                }
               
            }
            return _appManager;
        }

        public static AppManager GetInstance()
        {
            if (_platformStatic == null)
            {
                return null;
            }

            return _appManager;
        }

        public IApp App { get; private set; }

        //public Platform Platform; // tyt


        public AuthorizationScreen AuthScreen
        {
            get
            {
                if (_authScreen == null)
                {
                    _authScreen = new AuthorizationScreen(_platform, _appManager);
                }
                return _authScreen;
            }
        }
        public RegistrationScreen RegistrScreen
        {
            get
            {
                if (_registrScreen == null)
                {
                    _registrScreen = new RegistrationScreen(_platform, _appManager);
                }
                return _registrScreen;
            }
        }
        public CreatePostScreen CreatePostScreen
        {
            get
            {
                if (_createPostScreen == null)
                {
                    _createPostScreen = new CreatePostScreen(_platform, _appManager);
                }
                return _createPostScreen;
            }
        }
        public AutorizationHelper AuthHelper
        {
            get
            {
                if (_authHelper == null)
                {
                    _authHelper = new AutorizationHelper(_platform, _appManager);
                }
                return _authHelper;
            }
        }
        public RegistrationHelper RegistrHelper
        {
            get
            {
                if (_registrHelper == null)
                {
                    _registrHelper = new RegistrationHelper(_platform, _appManager);
                }
                return _registrHelper;
            }
        }
        public CreatePostHelper CreatePostHelper
        {
            get
            {
                if (_createPostHelper == null)
                {
                    _createPostHelper = new CreatePostHelper(_platform, _appManager);
                }
                return _createPostHelper;
            }
        }
        public ToolbarScreen TolbarScreen
        {
            get
            {
                if (_toolbarScreen == null)
                {
                    _toolbarScreen = new ToolbarScreen(_platform, _appManager);
                }
                return _toolbarScreen;
            }
        }
        public BaseHelper BaseHelper
        {
            get
            {
                if (_baseHelper == null)
                {
                    _baseHelper = new BaseHelper(_platform, _appManager);
                }
                return _baseHelper;
            }
        }
        public SmokeHelper SmokeHelper
        {
            get
            {
                if (_smokeHelper == null)
                {
                    _smokeHelper = new SmokeHelper(_platform, _appManager);
                }
                return _smokeHelper;
            }
        }
        public NavigationHelper NavigationHelper
        {
            get
            {
                if (_navigationHelper == null)
                {
                    _navigationHelper = new NavigationHelper(_platform, _appManager);
                }
                return _navigationHelper;
            }
        }

        public EditContactDataHelper EditContactDataHelper
        {
            get
            {
                if (_editContactDataHelper == null)
                {
                    _editContactDataHelper = new EditContactDataHelper(_platform, _appManager);
                }
                return _editContactDataHelper;
            }
        }

        public TabNewsScreen TabNewsScreen
        {
            get
            {
                if (_tabNewsScreen == null)
                {
                    _tabNewsScreen = new TabNewsScreen(_platform, _appManager);
                }
                return _tabNewsScreen;
            }
        }
        public AlertScreens AlertScreens
        {
            get
            {
                if (_alertScreens == null)
                {
                    _alertScreens = new AlertScreens(_platform, _appManager);
                }
                return _alertScreens;
            }
        }
        public SettingsScreen SettingsScreen
        {
            get
            {
                if (_settingsScreen == null)
                {
                    _settingsScreen = new SettingsScreen(_platform, _appManager);
                }
                return _settingsScreen;
            }
        }
        public ToolsCreatePostScreen ToolsCreatePostScreen
        {
            get
            {
                if (_toolsCreatePostScreen == null)
                {
                    _toolsCreatePostScreen = new ToolsCreatePostScreen(_platform, _appManager);
                }
                return _toolsCreatePostScreen;
            }
        }
        public PostScreen PostScreen
        {
            get
            {
                if (_postScreen == null)
                {
                    _postScreen = new PostScreen(_platform, _appManager);
                }
                return _postScreen;
            }
        }
        public MoreOptionsScreens MoreOptionsScreens
        {
            get
            {
                if (_moreOptionScreens == null)
                {
                    _moreOptionScreens = new MoreOptionsScreens(_platform, _appManager);
                }
                return _moreOptionScreens;
            }
        }

        public EditProfileScreen EditProfileScreen
        {
            get
            {
                if (_editProfileScreen == null)
                {
                    _editProfileScreen = new EditProfileScreen(_platform, _appManager);
                }
                return _editProfileScreen;
            }
        }

        public EditContactScreen EditContactScreen
        {
            get
            {
                if (_editContactScreen == null)
                {
                    _editContactScreen = new EditContactScreen(_platform, _appManager);
                }
                return _editContactScreen;
            }
        }


        //public RegistrationScreen RegistrScreen { get; private set; }
        //public CreatePostScreen CreatePostScreen { get; private set; }
        //public AutorizationHelper AuthHelper { get; private set; }
        //public RegistrationHelper RegistrHelper { get; private set; }
        //public CreatePostHelper CreatePostHelper { get; private set; }
        //public HederScreen HederScreen { get; private set; }
        //public BaseHelper BaseHelper { get; private set; }
        //public SmokeHelper SmokeHelper { get; private set; }
        //public NavigationHelper NavigationHelper { get; private set; }
        //public TabNewsScreen TabNewsScreen { get; private set; }
        //public AlertScreens AlertScreens { get; private set; }
        //public SettingsScreen SettingsScreen { get; private set; }
        //public ToolsCreatePostScreen ToolsCreatePostScreen { get; private set; }
        //public PostScreen PostScreen { get; private set; }


        //public UserData Auth;




        private AppManager(Platform platform)
        {
            _platform = platform;

            //NavigationHelper = new NavigationHelper(platform);
            
            //RegistrScreen = new RegistrationScreen(platform);
            //CreatePostScreen = new CreatePostScreen(platform);
            //AuthHelper = new AutorizationHelper(platform);
            //RegistrHelper = new RegistrationHelper(platform);
            //CreatePostHelper = new CreatePostHelper(platform);
            //HederScreen = new HederScreen(platform);
            //BaseHelper = new BaseHelper(platform);
            //SmokeHelper = new SmokeHelper(platform);
            //TabNewsScreen = new TabNewsScreen(platform);
            //AlertScreens = new AlertScreens(platform);
            //SettingsScreen = new SettingsScreen(platform);
            //ToolsCreatePostScreen = new ToolsCreatePostScreen(platform);
            //PostScreen = new PostScreen(platform);

        }

        public void Start(Platform platform, string simulatorName = null)
        {
            //NavigationHelper.InitAppManager(_appManager);
            //AuthScreen.InitAppManager(_appManager);
            //RegistrScreen.InitAppManager(_appManager);
            //CreatePostScreen.InitAppManager(_appManager);
            //AuthHelper.InitAppManager(_appManager);
            //RegistrHelper.InitAppManager(_appManager);
            //CreatePostHelper.InitAppManager(_appManager);
            //HederScreen.InitAppManager(_appManager);
            //BaseHelper.InitAppManager(_appManager);
            //SmokeHelper.InitAppManager(_appManager);
            //TabNewsScreen.InitAppManager(_appManager);
            //AlertScreens.InitAppManager(_appManager);
            //SettingsScreen.InitAppManager(_appManager);
            //ToolsCreatePostScreen.InitAppManager(_appManager);

            // Dictionary 
            CreatePostDictionary.Init();
            RegistrDictionary.Init();
            AuthDictionary.Init();

            if (simulatorName == null)
            {
                App = AppInitializer.StartApp(platform);
            }
            else
            {
                App = AppInitializer.StartApp(platform, simulatorName);
            }
            
           // App.Screenshot("App Initialized");
         
        }
        public void Stop()
        {

        }



        
    }


}
