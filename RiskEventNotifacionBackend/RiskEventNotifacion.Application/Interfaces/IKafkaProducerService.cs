using RiskEventNotifacion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Application.Interfaces
{
    public interface IKafkaProducerService
    {
        Task ProduceAsync(NotificationMessage message);
    }
}
