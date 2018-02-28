using System;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;

using SocialTrading.DTO.Interfaces;
using SocialTrading.Connection.Markers;
using SocialTrading.Connection.Enumerations;

namespace SocialTrading.DTO.Request.EditContact
{
    public class UserInfoDTO : IModelSend
    {
        public ERestCommands Method { get; set; }
        public string ApiPath { get; set; }

        public Type TypeMarker => typeof(RestRorMarker);

        private readonly IUserInfo _entity;


        public UserInfoDTO(IUserInfo entity)
        {
            _entity = entity ?? throw new ArgumentNullException(nameof(entity));

            Method = ERestCommands.PUT;
            ApiPath = "/api/v3/update_personal_info";
        }


        public JObject PerformQuery()
        {
            JObject json = null;

            if (_entity is IEditContactEntity contactEntity)
            {
                var hash = new JObject();
                if (contactEntity.Skype != null)
                {
                    hash.Add("skype", contactEntity.Skype);
                }
                if (contactEntity.Country != null)
                {
                    hash.Add("country", contactEntity.Country);
                }
                if (contactEntity.City != null)
                {
                    hash.Add("city", contactEntity.City);
                }
                if (contactEntity.Phone != null)
                {
                    hash.Add("phone", contactEntity.Phone);
                }

                json = new JObject
                {
                    ["user"] = hash
                };
            }
            else if (_entity is IEditProfileEntity profileEntity)
            {
                json = new JObject
                {
                    ["user"] = new JObject
                    {
                        ["first_name"] = profileEntity.FirstName,
                        ["last_name"] = profileEntity.LastName,
                        ["status"] = profileEntity.UserStatus
                    }
                };
            }

            return json;
        }


        public override bool Equals(object obj)
        {
            var dTO = obj as UserInfoDTO;
            return dTO != null &&
                   Method == dTO.Method &&
                   ApiPath == dTO.ApiPath &&
                   EqualityComparer<Type>.Default.Equals(TypeMarker, dTO.TypeMarker) &&
                   EqualityComparer<IUserInfo>.Default.Equals(_entity, dTO._entity);
        }

        public override int GetHashCode()
        {
            var hashCode = 1423654244;
            hashCode = hashCode * -1521134295 + Method.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ApiPath);
            hashCode = hashCode * -1521134295 + EqualityComparer<Type>.Default.GetHashCode(TypeMarker);
            hashCode = hashCode * -1521134295 + EqualityComparer<IUserInfo>.Default.GetHashCode(_entity);
            return hashCode;
        }
    }
}