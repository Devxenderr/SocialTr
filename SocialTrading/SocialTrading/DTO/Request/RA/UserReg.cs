using System;

using Newtonsoft.Json.Linq;

using SocialTrading.Connection.Markers;
using SocialTrading.Connection.Enumerations;

namespace SocialTrading.DTO.Request.RA
{
    public class UserReg : IModelSend
    {
        public string Name { get; set; }
        public string LastName { get; set; }
		public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneCountry { get; set; }
        public string PhoneNumber { get; set; }

        public string ApiPath { get; set; }
        public ERestCommands Method { get; set; }
        public EResponseModule ResponseModule { get; set; }

        public Type TypeMarker { get; private set; } = typeof(RestRorMarker);

        public UserReg()
        {
            Name = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
            PhoneCountry = string.Empty;
            PhoneNumber = string.Empty;

            ApiPath = "/auth";
            Method = ERestCommands.POST;
            ResponseModule = EResponseModule.Reg;
        }

        public UserReg(string name, string lastName, string email, string pass, string phoneCountry = "", string phoneNumber = "")
        {
            Name = name ?? string.Empty;
            LastName = lastName ?? string.Empty;
            Email = email?.Trim().ToLower() ?? string.Empty;
            Password = pass ?? string.Empty;
            PhoneCountry = phoneCountry ?? string.Empty;
            PhoneNumber = phoneNumber ?? string.Empty;

            ApiPath = "/auth";
            Method = ERestCommands.POST;
            ResponseModule = EResponseModule.Reg;
        }

		public JObject PerformQuery()
        {
            var json = new JObject
            {
                ["email"] = Email,
                ["password"] = Password,
                ["password_confirmation"] = Password,
                ["first_name"] = Name,
                ["last_name"] = LastName,
                ["country"] = PhoneCountry,
                ["phone"] = PhoneNumber
            };
            return json;
        }
    }
}
