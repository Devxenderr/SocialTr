using System;

namespace SocialTrading.DTO.Response.Post.Interfaces
{
    public interface IPostHeaderModel
    {
        string Quote { get; set; }
        string Market { get; }
        string Recommend { get; set; }
        string Price { get; set; }
        string Access { get; set; }
        string Forecast { get; set; }
        DateTime ForecastDateTime { get; set; }

        string CreatedAt { get; set; }
        DateTime CreatedAtDateTime { get; set; }
        string UpdatedAt { get; set; }
        bool IsQuoteFavorite { get; set; }

        string AuthorName { get; }
        string AuthorAvatar { get; set; }

        string Id { get; }
        string UserId { get; }

        string CachedAvatar { get; set; }

        bool IsMyPost { get; set; }
    }
}
