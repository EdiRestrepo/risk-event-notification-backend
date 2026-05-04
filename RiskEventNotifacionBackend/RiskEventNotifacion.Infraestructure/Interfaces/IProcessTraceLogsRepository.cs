using RiskEventNotifacion.Domain.Enum;
using RiskEventNotifacion.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Infraestructure.Interfaces
{
    public interface IProcessTraceLogsRepository
    {
        Task<Boolean> SaveTraceAsync(ProcessTraceLog trace);
    }
}
