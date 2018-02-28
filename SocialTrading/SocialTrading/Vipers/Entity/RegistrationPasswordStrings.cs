﻿namespace SocialTrading.Vipers.Entity
{
    public class RegistrationPasswordStrings
    {
        public string Password { get; set; }
        public string ConfirmPass { get; set; }

        public RegistrationPasswordStrings(string pass, string confirmPass)
        {
            Password = pass;
            ConfirmPass = confirmPass;
        }
    }
}