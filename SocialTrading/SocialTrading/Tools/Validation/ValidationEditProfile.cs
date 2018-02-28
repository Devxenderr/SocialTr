using SocialTrading.Tools.Validation.Interfaces;

namespace SocialTrading.Tools.Validation
{
    public class ValidationEditProfile : IValidationEditProfile
    {
        public bool CheckName(string name)
        {
            if (name?.Length <= 200)
            {
                return Validation.CheckValue("\\A([^~!@#'`\"\\\\\\/.()?,|*&%_+$;:\\[\\]{}><=\\^\\s\\-]([^~!@#`\"\\\\\\/.()?,|*&%_+$;:\\[\\]{}><=\\^]*[^~!@#'`\"\\\\\\/.()?,|*&%_+$;:\\[\\]{}><=\\^\\s\\-])?)" +
                                             "{1,200}\\z", name);
            }
            return false;
        }

        public bool CheckStatus(string status)
        {
            if (status?.Length <= 50)
            {
                return Validation.CheckValue("\\A[\\p{L}\\p{Z}\\p{N}\\p{P}\\p{S}]" +
                                             "{0,50}\\z", status);
            }
            return false;
        }
    }
}