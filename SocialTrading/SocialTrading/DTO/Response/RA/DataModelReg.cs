using Newtonsoft.Json;

using System.Collections.Generic;

using SocialTrading.Connection.Interfaces;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Registration.Password;
using SocialTrading.Vipers.Registration.Password.Interfaces;

namespace SocialTrading.DTO.Response.RA
{
    public class DataModelReg : ARoRResponse, IModel, IRegResponseStatus
    {
        public string Id { get;  }
		public string Provider { get; }
        public string Uid { get;  }
		public string LastedAt { get; }
		public string FirstName { get; }
		public string LastName { get; }
		public string Nickname { get; }
		public string Image { get; }
		public string Email { get; }
        public string CreatedAt { get; }
        public string UpdatedAt { get; }

        public ERegResponseStatus Status { get; set; }

        [JsonConstructor]
		public DataModelReg(string id, string email, string first_name, string last_name, string nickname, string provider, string uid,
                           string image, string lasted_at, string created_at, string updated_at, string[] errors, string status = null) : base(errors ?? new string[0])
        {
            Id = id                 ?? string.Empty;
            Provider = provider     ?? string.Empty;
            Uid = uid               ?? string.Empty;
            LastedAt = lasted_at    ?? string.Empty;
            FirstName = first_name  ?? string.Empty;
            LastName = last_name    ?? string.Empty;
            Nickname = nickname     ?? string.Empty;
            Image = image           ?? string.Empty;
            Email = email           ?? string.Empty;
            CreatedAt = created_at  ?? string.Empty;
            UpdatedAt = updated_at  ?? string.Empty;
        }

        public override bool Equals(object obj)
        {
            bool result = false;

            if (!(obj is DataModelReg model))
            {
                return false;
            }

            if (model.Id.Equals(Id) &&
                model.Email.Equals(Email) &&
                model.FirstName.Equals(FirstName) &&
                model.LastName.Equals(LastName) &&
                model.Provider.Equals(Provider) &&
                model.Uid.Equals(Uid) &&
                model.LastedAt.Equals(LastedAt) &&
                model.CreatedAt.Equals(CreatedAt) &&
                model.UpdatedAt.Equals(UpdatedAt))
            {
                result = true;
            }

            return result;
        }

        public override int GetHashCode()
        {
            var hashCode = -513195469;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Provider);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Uid);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastedAt);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nickname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Image);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CreatedAt);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UpdatedAt);
            return hashCode;
        }

        public EControllerStatus ControllerStatus { get; set; }
    }
}
