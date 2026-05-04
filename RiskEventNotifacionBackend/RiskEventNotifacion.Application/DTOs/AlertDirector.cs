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
        public static Alerts CreateFloodAlert(IAlertBuilder builder, String location)
        {
            return builder
                .SetEventType(EventType.Flood)
                .SetRiskLevel(RiskLevel.High)
                .SetTitle("Alerta de inundación")
                .SetMessage("Se detecta aumento del caudal y riesgo de inundación")
                .SetLocation(location)
                .SetSource("SIATA")
                .SetExpiration(DateTime.UtcNow.AddHours(4))
                .AddInstruction(["Evacuar zonas bajas", "Evitar cruzar corrientes de agua"])
                .AddChannel([NotificationChannel.NotificationWeb, NotificationChannel.Sms])
                .Build();
        }

        /// <summary>
        /// Alerta estandar de un deslizamiento de tierra
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public static Alerts CreateLandslideAlert(IAlertBuilder builder, String location)
        {
            return builder
                .SetEventType(EventType.Landslide)
                .SetRiskLevel(RiskLevel.Critical)
                .SetTitle("Alerta de deslizamiento")
                .SetMessage("Movimiento de tierra detectado")
                .SetLocation(location)
                .SetSource("SIATA")
                .SetExpiration(DateTime.UtcNow.AddHours(2))
                .AddInstruction(["Evacuar inmediatamente"])
                .AddChannel([NotificationChannel.NotificationWeb, NotificationChannel.WhatsApp])
                .Build();
        }

        /// <summary>
        /// Alerta dinamica, con base en los datos suministrados
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="eventType"></param>
        /// <param name="riskLevel"></param>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="location"></param>
        /// <param name="source"></param>
        /// <param name="instructions"></param>
        /// <param name="channels"></param>
        /// <returns></returns>
        public static Alerts CreateAlertDynamic(IAlertBuilder builder, EventType eventType, RiskLevel riskLevel, String title, String message, 
            String location, String source, List<String> instructions, List<NotificationChannel> channels)
        {
            if (eventType != EventType.UnDefined)
            {
                builder.SetEventType(eventType);
            }

            if (riskLevel != RiskLevel.UnDefined)
            {
                builder.SetRiskLevel(riskLevel);
            }

            if (!String.IsNullOrEmpty(title))
            {
                builder.SetTitle(title);
            }

            if (!String.IsNullOrEmpty(message))
            {
                builder.SetMessage(message);
            }

            if (!String.IsNullOrEmpty(location))
            {
                builder.SetLocation(location);
            }

            if (!String.IsNullOrEmpty(source))
            {
                builder.SetSource(source);
            }

            if (instructions != null)
            {
                builder.AddInstruction(instructions);
            }

            if (channels != null)
            {
                builder.AddChannel(channels);
            }

            return builder.Build();
        }
    }
}
