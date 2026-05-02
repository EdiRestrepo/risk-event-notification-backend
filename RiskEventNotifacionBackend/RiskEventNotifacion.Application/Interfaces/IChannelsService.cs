using RiskEventNotifacion.Domain.Entities;

namespace RiskEventNotifacion.Application.Interfaces
{
    public interface IChannelsService
    {
        Task<UserSettings> GetPreferencesChannelsByUserId(String userId);

        Task<Boolean> UpdatePreferencesChannelsByUserId(String userId, Channels channels);
    }
}
