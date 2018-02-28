using System;
using System.Linq;
using System.Collections.Generic;

namespace SocialTrading.DTO.Response
{
    public abstract class ARoRResponse
    {
        public List<string> Errors { get; }

        protected ARoRResponse(string[] errors)
        {
            if (errors == null)
            {
                throw new ArgumentException("errors cannot be a null!");
            }

            if (errors.Any(t => t == null))
            {
                throw new ArgumentException("String in Errors cannot be a null!");
            }

            Errors = errors.ToList();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ARoRResponse model))
            {
                return false;
            }

            if (Errors.Count != model.Errors.Count)
            {
                return false;
            }

            for (int i = 0; i < model.Errors.Count; i++)
            {
                if (Errors[i] != model.Errors[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {                       
            var hashCode = -549579115;
            hashCode = hashCode * -1265784589 + EqualityComparer<List<string>>.Default.GetHashCode(Errors);
            return hashCode;
        }
    }
}
