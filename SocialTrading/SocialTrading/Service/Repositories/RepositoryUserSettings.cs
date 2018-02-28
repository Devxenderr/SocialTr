using System;

using SocialTrading.DTO.Interfaces;
using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Service.Repositories
{
    public class RepositoryUserSettings : IRepositoryUserSettings
    {
        private Lazy<string> _userId;
        private Lazy<IEditContactEntity> _editContactUserInfo;
        private Lazy<IEditProfileEntity> _editProfileUserInfo;

        public bool IsRepositoryUserSettingsCleaned { get; private set; }


        public string UserId
        {
            get => _userId.Value;
            set { _userId = new Lazy<string>(() => value); }
        }

        public IEditContactEntity EditContactUserInfo
        {
            get => _editContactUserInfo.Value;
            set { _editContactUserInfo = new Lazy<IEditContactEntity>(() => value); }
        }

        public IEditProfileEntity EditProfileUserInfo
        {
            get => _editProfileUserInfo.Value;
            set { _editProfileUserInfo = new Lazy<IEditProfileEntity>(() => value); }
        }


        public void ConfigRepositoryUserSettings()
        {
            _editContactUserInfo = null;
            IsRepositoryUserSettingsCleaned = false;
        }

        public void DisposeRepositoryUserSettings()
        {
            _editContactUserInfo = null;
            IsRepositoryUserSettingsCleaned = true;
        }
    }
}