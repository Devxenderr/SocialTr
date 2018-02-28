using System;
using System.Collections.Generic;

using SocialTrading.DTO.Response.Post.Interfaces;
using SocialTrading.Service.Interfaces.Notifications;

namespace SocialTrading.Service
{
    public class NotificationCenter : INotificationCenter
    {
        public Action<IPostBodyModel> PostBodyDataIncome { get; set; }
        public Action<IPostHeaderModel> PostHeaderDataIncome { get; set; }
        public Action<IPostSocialModel> PostSocialDataIncome { get; set; }
        public Action<string> PostsIncome { get; set; }
        public Action<HashSet<string>> QcDataIncome { get; set; }
    }
}