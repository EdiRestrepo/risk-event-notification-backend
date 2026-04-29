using RiskEventNotifacion.Domain.Entities;
using RiskEventNotifacion.Domain.Enum;
using RiskEventNotifacion.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Application.DTOs
{
    public class AlertDirector
    {
        /// <summary>
        /// Alerta estandar de una inundación
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public Alerts CreateFloodAlert(IAlertBuilder builder, String location)
        {
            return builder
                .SetEventType(EventType.Flood)
                .SetRiskLevel(RiskLevel.High)
                .SetTitle("Alerta de inundación")
                .SetMessage("Se detecta aumento del caudal y riesgo de inundación")
                .SetLocation(location)
                .SetSource("SIATA")
                .SetExpiration(DateTime.UtcNow.AddHours(4))
                .AddInstruction("Evacuar zonas bajas")
                .AddInstruction("Evitar cruzar corrientes de agua")
                .AddChannel(NotificationChannel.NotificationWeb)
                .AddChannel(NotificationChannel.Sms)
                .Build();
        }

        /// <summary>
        /// Alerta estandar de un deslizamiento de tierra
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public Alerts CreateLandslideAlert(IAlertBuilder builder, String location)
        {
            return builder
                .SetEventType(EventType.Landslide)
                .SetRiskLevel(RiskLevel.Critical)
                .SetTitle("Alerta de deslizamiento")
                .SetMessage("Movimiento de tierra detectado")
                .SetLocation(location)
                .SetSource("SIATA")
                .SetExpiration(DateTime.UtcNow.AddHours(2))
                .AddInstruction("Evacuar inmediatamente")
                .AddChannel(NotificationChannel.NotificationWeb)
                .AddChannel(NotificationChannel.WhatsApp)
                .Build();
        }
    }
}
