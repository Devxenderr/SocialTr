using System;
using SocialTrading.DTO.Response.Post.ConstituentParts;
using SocialTrading.DTO.Response.Post.Interfaces;
using SocialTrading.DTO.Response.UserSettings;
using SocialTrading.Vipers.Post.Interfaces.Header;

namespace SocialTrading.Vipers.Post.Implementation.Header
{
    public class HeaderUserModelCreator : IHeaderUserModelCreator
    {
        public readonly IPostHeaderModel _userInfo;

        public HeaderUserModelCreator(IPostHeaderModel userInfo)
        {
            _userInfo = userInfo ?? throw new ArgumentNullException();
        }

        public PostHeaderUserModel GetModel()
        {
            return new PostHeaderUserModel(_userInfo.AuthorFirstName, _userInfo.AuthorLastName, _userInfo.AuthorAvatar, true);
        }

        //private bool IsNickname()
        //{
        //    return !string.IsNullOrEmpty(_userInfo.Nickname);
        //}
    }
}
