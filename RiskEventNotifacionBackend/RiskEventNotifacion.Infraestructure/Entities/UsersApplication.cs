using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Infraestructure.Entities
{
    public class UsersApplication
    {
        public String Id { get; set; }
        public String User { get; set; }

        public String Name { get; set; }
        public String Password { get; set; }

        public Boolean IsActive { get; set; }
    }
}
