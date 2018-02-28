using System;

using SocialTrading.DTO.Response.Post.Interfaces;

namespace SocialTrading.Service.Interfaces.Notifications
{
    public interface INotificationCenterPostHeader : INotificationCenterQc
    {
        Action<IPostHeaderModel> PostHeaderDataIncome { get; set; }
    }
}
