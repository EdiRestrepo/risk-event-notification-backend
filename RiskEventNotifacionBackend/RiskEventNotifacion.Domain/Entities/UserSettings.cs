using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace RiskEventNotifacion.Domain.Entities
{
    public class UserSettings
    {
        public String UserId { get; set; }
        public Channels Channels { get; set; }
    }
}
