using SocialTrading.DTO.Response.UserSettings;

namespace SocialTrading.Vipers.ProfileCell.Interfaces
{
    public interface IOptionsProfileResponseStatus
    {
        EUserSettingsResponseState Status { get; }
    }
}
