using RiskEventNotifacion.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Application.Interfaces
{
    public interface ITraceLogger
    {
        Task LogAsync(TraceContext context, String layer, String step, String status, String message);
    }
}
