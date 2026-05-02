using MySqlX.XDevAPI.Common;
using RiskEventNotifacion.Application.Interfaces;
using RiskEventNotifacion.Domain.Entities;
using RiskEventNotifacion.Infraestructure.Entities;
using RiskEventNotifacion.Infraestructure.Interfaces;

namespace RiskEventNotifacion.Application.Services
{
    public class ChannelsService : IChannelsService
    {
        private readonly IUserChannelsRepository userChannelsRepository;

        public ChannelsService(IUserChannelsRepository userChannelsRepository)
        {
            this.userChannelsRepository = userChannelsRepository;
        }

        public async Task<UserSettings> GetPreferencesChannelsByUserId(String userId)
        {
            UserSettings userSettings = new UserSettings();

            var result = await this.userChannelsRepository.GetChannelsByUserId(userId);

            if (result != null)
            {
                userSettings.UserId = result.IdUsuario;
                userSettings.Channels = new Channels
                {
                    Sms = result.Sms,
                    Email = result.Email,
                    Push = result.Push,
                    Whatsapp = result.WhatsApp
                };
            }
            return userSettings;
        }

        public async Task<Boolean> UpdatePreferencesChannelsByUserId(String userId, Channels channels)
        {
            UserChannelsEntities userChannelsEntities = await this.userChannelsRepository.GetChannelsByUserId(userId);

            UserChannelsEntities userChannelsEntitiesRequest = new UserChannelsEntities 
            {
                IdUsuario = userId,
                Push = channels.Push,
                WhatsApp = channels.Whatsapp,
                Email = channels.Email,
                Sms = channels.Sms
            };
            Int16 result = 0;

            if (userChannelsEntities == null)
            {
                result = await this.userChannelsRepository.CreateUserChannels(userChannelsEntitiesRequest);
            }
            else
            {
                result = await this.userChannelsRepository.UpdateUserChannels(userChannelsEntitiesRequest);
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }
    }
}
