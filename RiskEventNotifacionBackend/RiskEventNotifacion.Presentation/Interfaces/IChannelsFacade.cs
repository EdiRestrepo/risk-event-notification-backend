using RiskEventNotifacion.Presentation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Presentation.Interfaces
{
    public interface IChannelsFacade
    {
        Task<ChannelsPreferencesResult> GetPreferencesChannelsByUserId(String userId);

        Task<Boolean> UpdatePreferencesChannelsByUserId(String userId, ChannelsResult channelsUpdate);
    }
}
