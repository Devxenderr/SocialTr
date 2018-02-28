using System;
using System.Collections.Generic;

using SocialTrading.Locale.Modules;
using SocialTrading.DTO.Response.Post;
using SocialTrading.DTO.Response.Post.Interfaces;

namespace SocialTrading.Service.Interfaces.Repository
{
    public interface IRepositoryPost
    {
        event Action<List<string>> OnAllPostsIncome;

        IPost LangPost { get; }
        bool IsRepositoryPostCleaned { get; }

        int MinimizedPostContentLength { get; set; }
        int MaxMinimizedPostContentLength { get; set; }
        DataModelPostLike PostLike { get; set; }

        string GetLatestPostCreationDate();
        DataModelOnePost GetOnePostById(string id);

        List<string> GetPostIds();
        DataModelPost GetPostById(string id);
        IPostBodyModel GetPostBodyModelById(string id);
        IPostHeaderModel GetPostHeaderModelById(string id);
        IPostSocialModel GetPostSocialModelById(string id);

        void SetPosts(Dictionary<string, DataModelPost> dataModelPost);
        void AddPosts(Dictionary<string, DataModelPost> dataModelPost);

        void ConfigRepositoryPost();
        void DisposeRepositoryPost();

        void UpdatePost(DataModelPost model);
    }
}
