using System.Collections.Generic;

using Newtonsoft.Json;

using SocialTrading.DTO.Interfaces;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Vipers.ProfileCell.Interfaces;

namespace SocialTrading.DTO.Response.UserSettings
{
    public class DataModelUserInfo : ARoRResponse, IModel, IOptionsProfileResponseStatus, IEditContactEntity, IEditProfileEntity
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhoneSecond { get; set; }
        public string Skype { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string UserStatus { get; set; }
        public bool IsNickName { get; set; }

        [JsonConstructor]
        public DataModelUserInfo(string id, string first_name, string last_name, string nickname, string image, string email, string phone,
                                 string phone_2, string skype, string country, string city, string status, bool isNickName, string[] errors) : base(errors ?? new string[0])
        {
            Id = id;
            FirstName = first_name;
            LastName = last_name;
            Nickname = nickname;
            Image = image;
            Email = email;
            Phone = phone;
            PhoneSecond = phone_2;
            Skype = skype;
            Country = country;
            City = city;
            UserStatus = status;
            IsNickName = isNickName;
        }

        public EUserSettingsResponseState Status { get; set; }

        public override bool Equals(object obj)
        {
            var userInfo = obj as DataModelUserInfo;

            return Id == userInfo?.Id &&
                   FirstName == userInfo?.FirstName &&
                   LastName == userInfo?.LastName &&
                   Nickname == userInfo?.Nickname &&
                   Image == userInfo?.Image &&
                   Email == userInfo?.Email &&
                   Phone == userInfo?.Phone &&
                   PhoneSecond == userInfo?.PhoneSecond &&
                   Skype == userInfo?.Skype &&
                   City == userInfo?.City &&
                   Country == userInfo?.Country &&
                   UserStatus == userInfo?.UserStatus &&
                   IsNickName == userInfo?.IsNickName;
        }

        public override int GetHashCode()
        {
            var hashCode = -1299811330;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nickname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Image);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Phone);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PhoneSecond);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Skype);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Country);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserStatus);
            hashCode = hashCode * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(IsNickName);
            return hashCode;
        }

        public EControllerStatus ControllerStatus { get; set; }
    }
}