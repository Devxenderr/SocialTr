using System;
using System.Collections.Generic;

using SocialTrading.Tools.Interfaces;
using SocialTrading.Tools.Enumerations;

namespace SocialTrading.Service
{
    public class DataForMoreOptions : List<Tuple<Type, EItemsOptions>>
    {
        public DataForMoreOptions()
        {
            Add(Tuple.Create(typeof(IProfileCell), EItemsOptions.ProfileCell));     // Profile info cell

            Add(Tuple.Create(typeof(IOptionCell), EItemsOptions.EditProfileCell));  // Profile edit cell
            Add(Tuple.Create(typeof(IOptionCell), EItemsOptions.EditContactCell));  // Contact edit cell

            Add(Tuple.Create(typeof(IOptionCell), EItemsOptions.LogoutCell));       // Logout cell
        }
    }
}