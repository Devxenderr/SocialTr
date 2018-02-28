using System;
using System.Collections.Generic;

using SocialTrading.Tools.Enumerations;

namespace SocialTrading.Tools
{
    public class DictionaryForOptions : Dictionary<EItemsOptions, Tuple<string, string>>
    {
        public DictionaryForOptions()
        {
            Add(EItemsOptions.EditProfileCell, new Tuple<string, string>("profileSettingsMoreOptions36", Locale.Localization.Lang.MoreOptionsProfileSettings));
            Add(EItemsOptions.EditContactCell, new Tuple<string, string>("contactsMoreOptions36", Locale.Localization.Lang.MoreOptionsContacts));
            Add(EItemsOptions.LogoutCell,      new Tuple<string, string>("logoutMoreOptions36", Locale.Localization.Lang.MoreOptionsLogOut));
        }
    }
}
