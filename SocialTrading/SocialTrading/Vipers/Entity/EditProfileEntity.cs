using System.Collections.Generic;

using SocialTrading.DTO.Interfaces;

namespace SocialTrading.Vipers.Entity
{
    public class EditProfileEntity : IEditProfileEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserStatus { get; set; }

        public EditProfileEntity(string firstName, string lastName, string userStatus)
        {
            FirstName = firstName;
            LastName = lastName;
            UserStatus = userStatus;
        }

        public override bool Equals(object obj)
        {
            var entity = obj as EditProfileEntity;
            return entity != null &&
                   FirstName == entity.FirstName &&
                   LastName == entity.LastName &&
                   UserStatus == entity.UserStatus;
        }

        public override int GetHashCode()
        {
            var hashCode = -1083246120;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserStatus);
            return hashCode;
        }
    }
}