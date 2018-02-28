using System;

using SocialTrading.DTO.Interfaces;
using SocialTrading.DTO.Response.UserSettings;
using SocialTrading.Vipers.MoreOptions.EditProfile.Models;

namespace SocialTrading.Vipers.MoreOptions.EditProfile.Interfaces
{
    public interface IInteractorEditProfile : IDisposable
    {
        void SaveButtonClick(IEditProfileEntity userData);

        bool NameWasInput(string name);
        bool LastnameWasInput(string lastname);
        bool StatusWasInput(string status);

        void SendRequestForUserData();

        event Action<IEditProfileEntity> ReceiveUserData;
        event Action<EUserSettingsResponseState> CheckEditProfileResponse;
        event Action<EEditProfileFields, bool> ValidationFieldResponse;
    }
}