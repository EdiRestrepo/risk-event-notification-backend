using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Domain.Entities
{
    public class User
    {
        public string UserName { get; set; }
        public string Password{ get; set; }
        public bool IsActive { get; private set; }

        public bool CanLogin()
        {
            return IsActive;
        }
    }
}
