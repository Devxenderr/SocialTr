using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using SocialTrading.Connection.Interfaces;
using SocialTrading.Vipers.ForgotPass;
using SocialTrading.Vipers.ForgotPass.Interfaces;
using SocialTrading.Tools.Enumerations;

namespace SocialTrading.DTO.Response.RA
{
    public class DataRecoveryPasswordResponse : ARoRResponse, IModel, IForgotPassResponseStatus
    {
        public bool Success { get; }
        public string Message { get; }

        public EForgotPassStatus Status { get; set; }

        public EControllerStatus ControllerStatus { get; set; }

        [JsonConstructor]
        public DataRecoveryPasswordResponse(bool? success, string message, string[] errors) : base(errors ?? new string[0])
        {
            if (success == null)
            {
                throw new ArgumentException("success cannot be a null!");
            }

            if (message == null && errors == null)
            {
                throw new ArgumentException("message and errors cannot be a null!");
            }

            if (success.Value && message == null)
            {
                throw new ArgumentException("message cannot be a null!");
            }

            if (!success.Value && errors == null)
            {
                throw new ArgumentException("errors cannot be a null!");
            }
            
            Success = success.Value;
            Message = message ?? string.Empty;
        }

     

        public override bool Equals(object obj)
        {
            if (!(obj is DataRecoveryPasswordResponse model))
            {
                return false;
            }

            return base.Equals(obj) && model.Message.Equals(Message) && model.Success.Equals(Success);
        }

        public override int GetHashCode()
        {                  
            var hashCode = -546564478;
            hashCode = hashCode * -1055795497 + EqualityComparer<bool>.Default.GetHashCode(Success);
            hashCode = hashCode * -1055795497 + EqualityComparer<string>.Default.GetHashCode(Message);
            return hashCode;
        }
    }
}
