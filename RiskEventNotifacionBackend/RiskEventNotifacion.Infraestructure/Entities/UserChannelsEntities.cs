using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Infraestructure.Entities
{
    public class UserChannelsEntities
    {
        public String IdUsuario { get; set; }
        public Boolean Sms { get; set; }
        public Boolean Email { get; set; }
        public Boolean Push { get; set; }
        public Boolean WhatsApp { get; set; }
    }
}
