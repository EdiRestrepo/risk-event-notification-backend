using RiskEventNotifacion.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RiskEventNotifacion.Domain.Entities
{
    public class UserNotificationMessage : IUserNotificationMessage
    {
        private Alerts alerts;
        private readonly INotificationService notificationService;
        public UserNotificationMessage(Alerts alertsNew, INotificationService notificationService)
        {
            this.alerts = alertsNew;
            this.notificationService = notificationService;
        }
        public void SendNotificationMessage()
        {
            _ = this.SendNotificationMessageWebAsync();
            Debug.WriteLine("Alerta enviada por plataforma Web: " + this.alerts.Message);
        }

        private async Task SendNotificationMessageWebAsync()
        {
            await this.notificationService.SendToMessagePlaneAsync(this.alerts.Message);
        }
    }
}
