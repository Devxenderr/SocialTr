using System;

using SocialTrading.DTO.Response.RA;
using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Service.Repositories
{
    public class RepositoryUserAuth : IRepositoryUserAuth
    {
        private Lazy<UserAuthData> _authData;

        public RepositoryUserAuth()
        {
            _authData = null;
        }

        public UserAuthData AuthData
        {
            get => _authData.Value;
            set => _authData = new Lazy<UserAuthData>(() => value);
        }
    }
}
