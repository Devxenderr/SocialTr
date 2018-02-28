using System;
using System.Linq;
using System.Collections.Generic;

using SocialTrading.Tools;
using SocialTrading.Locale;
using SocialTrading.Vipers.Entity;
using SocialTrading.Locale.Modules;
using SocialTrading.DTO.Request.RA;
using SocialTrading.DTO.Response.RA;
using SocialTrading.Tools.Exceptions;
using SocialTrading.DTO.Response.Post;
using SocialTrading.Connection.Models;
using SocialTrading.Service.Interfaces.Timer;
using SocialTrading.DTO.Response.Post.Interfaces;
using SocialTrading.Service.Interfaces.Repository;

namespace SocialTrading.Service.Repositories
{
    public class Repository : IRepositoryRA, IRepositoryCreatePost, IRepositoryPost, IRepositoryRestHeader, IRepositoryUser, IRepositoryToolbar, IRepositoryMoreOptions

    {
        private readonly Lazy<ILang> _lang;
        private readonly IRepositoryUserAuth _repositoryUserAuth;
        private readonly IRepositoryUserSettings _repositoryUserSettings;

        public Repository(IRepositoryUserAuth repositoryUserAuth, IRepositoryUserSettings repositoryUserSettings)
        {
            _lang = new Lazy<ILang>(() => Localization.Lang); 

            ConfigRepositoryRA();
            ConfigRepositoryCreatePost();
            ConfigRepositoryPost();
            ConfigRepositoryRestHeader();

            _repositoryUserAuth = repositoryUserAuth ?? throw new RepoUserAuthNullReferenceException();
            _repositoryUserSettings = repositoryUserSettings ?? throw new RepoEditContactNullReferenceException();
        }

        public void Init()
        {
            ConfigRepositoryRA();
            ConfigRepositoryCreatePost();
            ConfigRepositoryPost();
            ConfigRepositoryRestHeader();
        }

        #region IRepositoryUser

        public string Id => _headerModel?.Value.Client;

        public string UserId => _modelAuth?.Value.Id;

        #endregion

        #region IRepositoryRA

        private Lazy<UserReg> _user;
        private Lazy<DataModelReg> _modelReg;
        private Lazy<DataModelAuth> _modelAuth;
        //private Lazy<DataModelRegErrors> _modelRegErrors;

        public bool IsRepositoryRACleaned { get; private set; }
        public IRegAuth LangRA => _lang.Value;

        public UserReg User
        {
            get => _user?.Value;
            set { _user = new Lazy<UserReg>(() => value); }
        }

        public DataModelAuth ModelAuth
        {
            get => _modelAuth.Value;
            set
            {
                _modelAuth = new Lazy<DataModelAuth>(() => value);
                _repositoryUserAuth.AuthData = new UserAuthData(value);
                _repositoryUserSettings.UserId = value.Id;
                _repositoryUserSettings.EditContactUserInfo = new EditContactEntity
                {
                    Email = value.Email
                };
                _repositoryUserSettings.EditProfileUserInfo = new EditProfileEntity(value.FirstName, value.LastName, null);
            }
        }

        public DataModelReg ModelReg
        {
            get => _modelReg?.Value;
            set { _modelReg = new Lazy<DataModelReg>(() => value); }
        }

      
        public void ConfigRepositoryRA()
        {
            _user = null;
            _modelReg = null;
            _modelAuth = null;
            IsRepositoryRACleaned = false;
        }

        public void DisposeRepositoryRA()
        {
            _user = null;
            _modelReg = null;
            _modelAuth = null;
            IsRepositoryRACleaned = true;
        }

        #endregion

        #region IRepositoryCreatePost

        private Lazy<string> _selectedTool;
        private Lazy<string> _attachmentImage;
        private Lazy<CreatePostStrings> _createPostStrings;

        public bool IsRepositoryCreatePostCleaned { get; private set; }
        public ICreatePost LangCreatePost => _lang.Value;

        public CreatePostStrings CreatePostStrings
        {
            get => _createPostStrings?.Value;
            set => _createPostStrings = new Lazy<CreatePostStrings>(() => value);
        }

        public string SelectedTool
        {
            get => _selectedTool?.Value;
            set => _selectedTool = new Lazy<string>(() => value);
        }

        public string AttachmentImage
        {
            get => _attachmentImage?.Value;
            set => _attachmentImage = new Lazy<string>(() => value);
        }

        public void ConfigRepositoryCreatePost()
        {
            _selectedTool = null;
            _attachmentImage = null;
            _createPostStrings = null;
            IsRepositoryCreatePostCleaned = false;
        }

        public void DisposeRepositoryCreatePost()
        {
            _selectedTool = null;
            _attachmentImage = null;
            _createPostStrings = null;
            IsRepositoryCreatePostCleaned = true;
        }

        #endregion

        #region IRepositoryPost

        private Lazy<DataModelPostLike> _postLikeData;
        private Dictionary<string, DataModelPost> _posts;
        private IDateTimeConverter _converter;

        public event Action<List<string>> OnAllPostsIncome;

        public void UpdatePost(DataModelPost model)
        {
            if (_posts == null || !_posts.ContainsKey(model.Id))
            {
                return;
            }

            _posts[model.Id] = model;
        }

        public bool IsRepositoryPostCleaned { get; private set; }

        public IPost LangPost => _lang.Value;

        public int MinimizedPostContentLength { get; set; }
        public int MaxMinimizedPostContentLength { get; set; }

        public DataModelPostLike PostLike
        {
            get => _postLikeData?.Value;
            set => _postLikeData = new Lazy<DataModelPostLike>(() => value);
        }

        public void SetPosts(Dictionary<string, DataModelPost> dataModelPost)
        {
            _posts = dataModelPost;
            OnPostsIncome();
        }

        public void AddPosts(Dictionary<string, DataModelPost> dataModelPost)
        {
            foreach (var item in dataModelPost)
            {
                if (!_posts.ContainsKey(item.Key))
                {
                    _posts.Add(item.Key, item.Value);
                    //var list = _posts.Values.ToList();
                    //list.Sort();
                    //_posts = list.ToDictionary(key => key.Id, value => value);
                }
            }

            OnPostsIncome();
        }

        private void OnPostsIncome()
        {
            CheckIfPostIsMy(_posts);

            //TODO add logic for CRUD
            OnAllPostsIncome?.Invoke(_posts.Keys.ToList());
        }

        private void CheckIfPostIsMy(Dictionary<string, DataModelPost> posts)
        {
            var listPosts = posts.Values.ToList();
            for (int i = 0; i < listPosts.Count; i++)
            {
                listPosts[i].IsMyPost = listPosts[i].UserId == UserId;
            }
        }

        public List<string> GetPostIds() => _posts?.Keys.ToList();

        public IPostBodyModel GetPostBodyModelById(string id) => GetPostById(id);
        public IPostHeaderModel GetPostHeaderModelById(string id) => GetPostById(id);
        public IPostSocialModel GetPostSocialModelById(string id) => GetPostById(id);

        public DataModelPost GetPostById(string id)
        {          
            lock (this)
            {
                if (_posts == null || !_posts.ContainsKey(id))
                {
                    return null;
                }

                var post = _posts?[id];

                //TODO remove to another place **********************************************
                post.CreatedAtDateTime = _converter.Convert(post.CreatedAt);
                post.ForecastDateTime = _converter.Convert(post.Forecast);
                //TODO remove to another place **********************************************

                return post;
            }
        }

        public DataModelOnePost GetOnePostById(string id)
        {
            var onePost = new DataModelOnePost
            {
                ModelPost = GetPostById(id)
            };
            return onePost;
        }

        public string GetLatestPostCreationDate()
        {
            var list = _posts.Values.Select(f => f.CreatedAtDateTime).ToList();
            var result = _posts.Values.First(f => f.CreatedAtDateTime.Equals(list.Min())).CreatedAt;
            return result;
        }

        public void ConfigRepositoryPost()
        {
            _converter = new DateTimeConverter();

            _posts = null;
            _postLikeData = null;
            MinimizedPostContentLength = 200;
            MaxMinimizedPostContentLength = 250;
            IsRepositoryCreatePostCleaned = false;
        }

        public void DisposeRepositoryPost()
        {
            _posts = null;
            _postLikeData = null;
            MinimizedPostContentLength = 0;
            IsRepositoryCreatePostCleaned = true;
        }

        #endregion

        #region IRepositoryRestHeader

        private Lazy<RestHeaderModel> _headerModel;
        
        public RestHeaderModel HeaderModel
        {
            get => _headerModel?.Value;
            set => _headerModel = new Lazy<RestHeaderModel>(() => value);
        }

        private void ConfigRepositoryRestHeader()
        {
            HeaderModel = new RestHeaderModel(
                accessTokenTitle: DAL.RestHeaderValues.AccessTokenTitle, 
                clientTitle:      DAL.RestHeaderValues.ClientTitle, 
                uidTitle:         DAL.RestHeaderValues.UidTitle,
                acceptLangTitle:  DAL.RestHeaderValues.AcceptLangTitle,
                contentType:      DAL.RestHeaderValues.ContentType,
                acceptLang:       DAL.RestHeaderValues.AcceptLang);
        }
        
        #endregion

        public IToolbar LangToolbar => _lang.Value;

        public IProfileCellLocale LangMoreOptions => _lang.Value;

    }
}