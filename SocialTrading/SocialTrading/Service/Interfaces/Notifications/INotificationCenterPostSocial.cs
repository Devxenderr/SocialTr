using System;

using SocialTrading.DTO.Response.Post.Interfaces;

namespace SocialTrading.Service.Interfaces.Notifications
{
    public interface INotificationCenterPostSocial
    {
        Action<IPostSocialModel> PostSocialDataIncome { get; set; }
    }
}
