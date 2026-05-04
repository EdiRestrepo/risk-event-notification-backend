using RiskEventNotifacion.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Application.Interfaces
{
    public interface ITraceProducerService
    {
        Task SendTraceAsync(ProcessTraceMessage trace);
    }
}
