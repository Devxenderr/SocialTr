using System.Collections.Generic;

using SocialTrading.DTO.Interfaces;

namespace SocialTrading.Vipers.Entity
{
    public class EditContactEntity : IEditContactEntity
    {
        public string Email { get; set; }
        public string Skype { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }


        public EditContactEntity()
        {
        }

        public EditContactEntity(string email, string skype, string country, string city, string phone)
        {
            Email = email;
            Skype = skype;
            Country = country;
            City = city;
            Phone = phone;
        }


        public override bool Equals(object obj)
        {
            var entity = obj as EditContactEntity;
            return entity != null &&
                   Email == entity.Email &&
                   Skype == entity.Skype &&
                   Country == entity.Country &&
                   City == entity.City &&
                   Phone == entity.Phone;
        }

        public override int GetHashCode()
        {
            var hashCode = 1387626102;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Skype);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Country);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Phone);
            return hashCode;
        }
    }
}