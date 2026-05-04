using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Application.Entities
{
    public class TraceContext
    {
        public string CorrelationId { get; set; } = "";
        public string ProcessName { get; set; } = "";
    }
}
