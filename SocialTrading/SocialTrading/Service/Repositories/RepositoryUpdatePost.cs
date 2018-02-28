using System;

using SocialTrading.Locale;
using SocialTrading.Locale.Modules;
using SocialTrading.Vipers.Entity;
using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Service.Repositories
{
    public class RepositoryUpdatePost : IRepositoryUpdatePost
    {
        private Lazy<UpdatePostModel> _updatePostModel;

        public ICreatePost LangPost => Localization.Lang;

        public RepositoryUpdatePost()
        {
            _updatePostModel = new Lazy<UpdatePostModel>(() => null);
        }

        public UpdatePostModel UpdatePostModel
        {
            get => _updatePostModel.Value;
            set => _updatePostModel = new Lazy<UpdatePostModel>(() => value);
        }
    }
}
