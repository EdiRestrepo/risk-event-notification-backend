using RiskEventNotifacion.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Infraestructure.Interfaces
{
    public interface IExternalNotificationLogsRepository
    {
        Task<Boolean> SaveLogsAsync(NotificationExternalLogType origin, String originConfiguration, String message);
    }
}
