using RiskEventNotifacion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Domain.Interfaces
{
    public interface INotificationService
    {
        Task SendToAllAsync(NotificationMessage message);
        Task SendToUserAsync(String userId, NotificationMessage message);

        Task SendToMessagePlaneAsync(String messagePlane);
    }
}
