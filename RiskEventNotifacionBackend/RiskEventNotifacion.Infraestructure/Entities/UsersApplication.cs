using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Infraestructure.Entities
{
    public class UsersApplication
    {
        internal string User { get; set; }
        internal string Password { get; set; }
        internal bool IsActive { get; set; }
    }
}
