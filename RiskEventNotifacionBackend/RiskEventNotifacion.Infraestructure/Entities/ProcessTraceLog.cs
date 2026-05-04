using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Infraestructure.Entities
{
    public class ProcessTraceLog
    {
        public long Id { get; set; }
        public string CorrelationId { get; set; } = "";
        public string ProcessName { get; set; } = "";
        public string StepName { get; set; } = "";
        public string Status { get; set; } = "";
        public string Message { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}
