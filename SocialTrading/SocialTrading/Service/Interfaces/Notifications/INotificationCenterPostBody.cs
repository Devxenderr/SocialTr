using System;

using SocialTrading.DTO.Response.Post.Interfaces;

namespace SocialTrading.Service.Interfaces.Notifications
{
    public interface INotificationCenterPostBody
    {
        Action<IPostBodyModel> PostBodyDataIncome { get; set; }
    }
}
