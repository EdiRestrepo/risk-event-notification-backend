using Confluent.Kafka;
using Microsoft.AspNetCore.SignalR;
using RiskEventNotifacion.Domain.Entities;
using RiskEventNotifacion.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> hubContext;

        public NotificationService(IHubContext<NotificationHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public async Task SendToAllAsync(NotificationMessage message)
        {
            await this.hubContext.Clients.All.SendAsync(
                "ReceiveNotification",
                message);
        }

        public async Task SendToUserAsync(String userId, NotificationMessage message)
        {
            await this.hubContext.Clients.User(userId).SendAsync("ReceiveNotification", message);
        }

        public async Task SendToMessagePlaneAsync(String messagePlane)
        {
            await this.hubContext.Clients.All.SendAsync(
                "ReceiveNotification",
                messagePlane);
        }
    }
}
