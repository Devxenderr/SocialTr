using System;
using System.Collections.Generic;

namespace SocialTrading.Service.Interfaces.Notifications
{
    public interface INotificationCenterQc
    {
        Action<HashSet<string>> QcDataIncome { get; set; }
    }
}