using RiskEventNotifacion.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Presentation.Entities
{
    public class AlertRequest
    {
        public Int16 EventType { get; set; }

        public Int16 RiskLevel { get; set; }

        public String Title { get; set; }

        public String Message { get; set; }

        public String Location { get; set; }

        public String Source { get; set; }

        public List<String> Instructions { get; set; } = [];

        public List<Int16> Channels { get; set; } = [];

        public Boolean isGenereric { get; set; } = false;

    }
}
