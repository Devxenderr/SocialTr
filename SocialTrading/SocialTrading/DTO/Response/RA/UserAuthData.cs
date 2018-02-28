using System;
using System.Collections.Generic;

using SocialTrading.Tools.Exceptions;

namespace SocialTrading.DTO.Response.RA
{
    public class UserAuthData
    {
        public string Name { get; set; }
        public string Image { get; private set; }


        public UserAuthData(DataModelAuth model)
        {
            if (model == null)
            {
                throw new DataModelAuthNullReferenceException();
            }

            Name = model.IsNickname ? model.Nickname : model.FirstName + " " + model.LastName;
            Image = model.Image;
        }


        public override bool Equals(object obj)
        {
            var data = obj as UserAuthData;
            return data != null &&
                   Name == data.Name &&
                   Image == data.Image;
        }

        public override int GetHashCode()
        {
            var hashCode = 2033062288;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Image);
            return hashCode;
        }

        public static implicit operator UserAuthData(Lazy<UserAuthData> lazy)
        {
            if (lazy == null)
            {
                throw new LazyUserAuthDataInvalidCastException();
            }

            return lazy.Value;
        }
    }
}
