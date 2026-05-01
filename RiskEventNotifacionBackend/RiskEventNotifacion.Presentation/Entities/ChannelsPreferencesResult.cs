using RiskEventNotifacion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Presentation.Entities
{
    public class ChannelsPreferencesResult
    {
        public String UserId { get; set; }
        public ChannelsResult Channels { get; set; }
    }
}
