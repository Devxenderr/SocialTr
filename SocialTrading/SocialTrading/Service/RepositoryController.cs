using SocialTrading.Service.Repositories;
using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Service
{
    public class RepositoryController : IRepositoryController
    {
        private static RepositoryController _repositoryController;
        public static RepositoryController GetInstance()
        {
            return _repositoryController ?? (_repositoryController = new RepositoryController());
        }

        private Repository _repository;

        public IRepositoryRA RepositoryRA => _repository;
        public IRepositoryCreatePost RepositoryCreatePost => _repository;
        public IRepositoryPost RepositoryPost => _repository;
        public IRepositoryRestHeader RepositoryRestHeader => _repository;
        public IRepositoryMoreOptions RepositoryMoreOptions => _repository;
        public IRepositoryUser RepositoryUser => _repository;
        public IRepositoryToolbar RepositoryToolbar => _repository;

        public IRepositoryQc RepoQc { get; private set; }
        public IRepositoryThemes RepositoryThemes { get; private set; }
        public IRepositoryUserAuth RepositoryUserAuth { get; private set; }
        public IRepositoryUserSettings RepositoryUserSettings { get; private set; }
        public IRepositoryUpdatePost RepositoryUpdatePost { get; private set; }
        public IRepositoryCountries RepositoryCountries { get; private set; }


        private RepositoryController()
        {
            Init();
        }

        public void Init()
        {
            var repoQc = RepositoryQc.GetInstance();
            repoQc.Clear();
            RepoQc = repoQc;
            RepositoryThemes = new RepositoryThemes();
            RepositoryUserAuth = new RepositoryUserAuth();
            RepositoryUserSettings = new RepositoryUserSettings();
            RepositoryUpdatePost = new RepositoryUpdatePost();
            RepositoryCountries = new RepositoryCountries(Locale.Localization.Lang.EditContactCountries);

            _repository = new Repository(RepositoryUserAuth, RepositoryUserSettings);
        }
    }
}
