using RiskEventNotifacion.Application.Interfaces;
using RiskEventNotifacion.Domain.Entities;
using RiskEventNotifacion.Presentation.Entities;
using RiskEventNotifacion.Presentation.Interfaces;

namespace RiskEventNotifacion.Presentation.Facades
{
    public class ChannelsFacade : IChannelsFacade
    {
        private readonly IChannelsService channelsService;

        public ChannelsFacade(IChannelsService channelsService)
        {
            this.channelsService = channelsService;
        }

        public async Task<ChannelsPreferencesResult> GetPreferencesChannelsByUserId(String userId)
        {
            var result = await this.channelsService.GetPreferencesChannelsByUserId(userId);

            ChannelsResult channelsResult = new ChannelsResult();
            channelsResult.Push = result.Channels.Push;
            channelsResult.Sms = result.Channels.Sms;
            channelsResult.Email = result.Channels.Email;
            channelsResult.Whatsapp = result.Channels.Whatsapp;

            ChannelsPreferencesResult channelsPreferencesResult = new ChannelsPreferencesResult();
            channelsPreferencesResult.UserId = result.UserId;
            channelsPreferencesResult.Channels = channelsResult;

            return channelsPreferencesResult;
        }

        public async Task<Boolean> UpdatePreferencesChannelsByUserId(String userId, ChannelsResult channelsUpdate)
        {
            Channels channels = new Channels();
            channels.Push = channelsUpdate.Push;
            channels.Sms = channelsUpdate.Sms;
            channels.Email = channelsUpdate.Email;
            channels.Whatsapp = channelsUpdate.Whatsapp;

            return await this.channelsService.UpdatePreferencesChannelsByUserId(userId, channels);
        }
    }
}
