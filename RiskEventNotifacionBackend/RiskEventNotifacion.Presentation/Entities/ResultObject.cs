using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Presentation.Entities
{
    public class ResultObject
    {
        public Boolean Success { get; set; }
        public String? Message { get; set; }
        public Guid Token { get; set; }

        public Object? Data { get; set; }
    }
}
