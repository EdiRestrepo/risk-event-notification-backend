using RiskEventNotifacion.Application.Interfaces;
using RiskEventNotifacion.Domain.Entities;

namespace RiskEventNotifacion.Application.Services
{
    public class ChannelsService : IChannelsService
    {
        public async Task<UserSettings> GetPreferencesChannelsByUserId(String userId)
        {
            UserSettings userSettings = new UserSettings
            {
                UserId = userId,
                Channels = new Channels
                {
                    Sms = true,
                    Email = false,
                    Push = true,
                    Whatsapp = true
                }
            };
            return userSettings;
        }

        public async Task<Boolean> UpdatePreferencesChannelsByUserId(String userId, Channels channels)
        {
            //ToDo: Pendiente crear codigo de persistencia
            return true;
        }
    }
}
