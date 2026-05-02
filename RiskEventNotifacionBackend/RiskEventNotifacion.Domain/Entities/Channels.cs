using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Domain.Entities
{
    public class Channels
    {
        public Boolean Sms { get; set; }
        public Boolean Email { get; set; }
        public Boolean Push { get; set; }
        public Boolean Whatsapp { get; set; }
    }
}
