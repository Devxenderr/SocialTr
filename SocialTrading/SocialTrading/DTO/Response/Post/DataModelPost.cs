using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.DTO.Response.Post.Interfaces;

namespace SocialTrading.DTO.Response.Post
{
    public class DataModelPost : IModel, IPostBodyModel, IPostSocialModel, IPostHeaderModel, IPostChartModel, IComparable
    {
        public string Id { get; }
        public string UserId { get; }

        // Body
        public string Image { get; }
        public string Content { get; }
        public string CachedImage { get; set; }

        //Social
        public bool IsLiked { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }

        //Header
        public string Quote { get; set; }
        public string Market { get; }
        public string Recommend { get; set; }
        public string Price { get; set; }
        public string Access { get; set; }
        public string Forecast { get; set; }
        public DateTime ForecastDateTime { get; set; }

        public string CreatedAt { get;  set; }
        public DateTime CreatedAtDateTime { get;  set; }
        public string UpdatedAt { get;  set; }
        public bool IsQuoteFavorite { get; set; }

        public string AuthorName { get; }
        public string AuthorAvatar { get; set; }
        public string CachedAvatar { get; set; }

        //Service
        public bool IsMyPost { get; set; }

        [JsonConstructor]
        public DataModelPost(string id, string user_id, string quote, string market, string recommend, float? price, string access, 
            string image, string content, string forecast, string created_at, string updated_at, string author_name, string author_avatar,
            int likes_count, int comments_count, bool liked)
        {
            Id = id ?? string.Empty;
            Image = image ?? string.Empty;
            Quote = quote ?? string.Empty;
            Market = market ?? string.Empty;
            Access = access ?? string.Empty;
            UserId = user_id ?? string.Empty;
            Content = content ?? string.Empty;
            Forecast = forecast ?? string.Empty;
            Recommend = recommend ?? string.Empty;
            CreatedAt = created_at ?? string.Empty;
            UpdatedAt = updated_at ?? string.Empty;
            Price = price.HasValue ? price.Value.ToString() : "0.0";
            IsLiked = liked;
            LikeCount = likes_count;
            CommentCount = comments_count;
            AuthorName = author_name ?? string.Empty;
            AuthorAvatar = author_avatar ?? string.Empty;
        }

        public override bool Equals(object obj)
        {
            var post = obj as DataModelPost;

            return post != null &&
                   Id == post.Id &&
                   UserId == post.UserId &&
                   Image == post.Image &&
                   Content == post.Content &&
                   IsLiked == post.IsLiked &&
                   LikeCount == post.LikeCount &&
                   CommentCount == post.CommentCount &&
                   Quote == post.Quote &&
                   Market == post.Market &&
                   Recommend == post.Recommend &&
                   Price == post.Price &&
                   Access == post.Access &&
                   Forecast == post.Forecast &&
                   CreatedAt == post.CreatedAt &&
                   IsQuoteFavorite == post.IsQuoteFavorite;
        }

        public override int GetHashCode()
        {
            var hashCode = 175731186;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Image);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Content);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Quote);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Market);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Recommend);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Price);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Access);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Forecast);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CreatedAt);
            hashCode = hashCode * -1521134295 + IsQuoteFavorite.GetHashCode();
            hashCode = hashCode * -1521134295 + CommentCount.GetHashCode();
            hashCode = hashCode * -1521134295 + LikeCount.GetHashCode();
            hashCode = hashCode * -1521134295 + IsLiked.GetHashCode();
            return hashCode;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is DataModelPost model))
            {
                throw new ArgumentException();
            }

            var result = 0;

            if (model.CreatedAtDateTime > CreatedAtDateTime)
            {
                result = 1;
            }
            else if (model.CreatedAtDateTime < CreatedAtDateTime)
            {
                result = -1;
            }

            return result;
        }

        public EControllerStatus ControllerStatus { get; set; }
    }
}
