using Newtonsoft.Json;

using System.Collections.Generic;


using SocialTrading.Connection.Interfaces;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Authorization;
using SocialTrading.Vipers.Authorization.Interfaces;

namespace SocialTrading.DTO.Response.RA
{
    public class DataModelAuth : ARoRResponse, IModel, IAuthResponseStatus
    {
        public string Id { get; }
        public string Provider { get; }
        public string Uid { get; }
        public string Email { get; }
        public string LastedAt { get; }
        public string CreatedAt { get; }
        public string Image { get; }
        public string BackgroundImage { get; }
        public string UpdatedAt { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Nickname { get; }
        public string Language { get; }
        public bool IsNickname { get; }
        public long CreatedAtLong { get; }
        public long UpdatedAtLong { get; }
        public long LastedAtLong { get; }

        public EAuthResponseStatus Status { get; set; }

        [JsonConstructor]
        public DataModelAuth(string id, string provider, string uid, string email, string lasted_at, string created_at,
            string image, string background_image, string updated_at, string first_name, string last_name, string nickname, 
            string language, bool is_nickname, long created_at_long, long updated_at_long, long lasted_at_long, string[] errors) : base(errors ?? new string[0])
        {
            Id = id                            ?? string.Empty;
            Provider = provider                ?? string.Empty;
            Uid = uid                          ?? string.Empty;
            Email = email                      ?? string.Empty;
            LastedAt = lasted_at               ?? string.Empty;
            CreatedAt = created_at             ?? string.Empty;
            Image = image                      ?? string.Empty;
            BackgroundImage = background_image ?? string.Empty;
            UpdatedAt = updated_at             ?? string.Empty;
            FirstName = first_name             ?? string.Empty;
            LastName = last_name               ?? string.Empty;
            Nickname = nickname                ?? string.Empty;
            Language = language                ?? string.Empty;
            IsNickname = is_nickname;
            CreatedAtLong = created_at_long;
            UpdatedAtLong = updated_at_long;
            LastedAtLong = lasted_at_long;
        }

        public override bool Equals(object obj)
        {
            var auth = obj as DataModelAuth;
            return auth != null &&
                   Id == auth.Id &&
                   Provider == auth.Provider &&
                   Uid == auth.Uid &&
                   Email == auth.Email &&
                   LastedAt == auth.LastedAt &&
                   CreatedAt == auth.CreatedAt &&
                   Image == auth.Image &&
                   BackgroundImage == auth.BackgroundImage &&
                   UpdatedAt == auth.UpdatedAt &&
                   FirstName == auth.FirstName &&
                   LastName == auth.LastName &&
                   Nickname == auth.Nickname &&
                   Language == auth.Language &&
                   IsNickname == auth.IsNickname &&
                   CreatedAtLong == auth.CreatedAtLong &&
                   UpdatedAtLong == auth.UpdatedAtLong &&
                   LastedAtLong == auth.LastedAtLong;
        }

        public override int GetHashCode()
        {
            var hashCode = 1961667795;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Provider);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Uid);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastedAt);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CreatedAt);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Image);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BackgroundImage);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UpdatedAt);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nickname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Language);
            hashCode = hashCode * -1521134295 + IsNickname.GetHashCode();
            hashCode = hashCode * -1521134295 + CreatedAtLong.GetHashCode();
            hashCode = hashCode * -1521134295 + UpdatedAtLong.GetHashCode();
            hashCode = hashCode * -1521134295 + LastedAtLong.GetHashCode();
            return hashCode;
        }

        public EControllerStatus ControllerStatus { get; set; }
    }
}
