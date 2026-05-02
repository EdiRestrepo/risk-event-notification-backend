using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Domain.Enum
{
    public enum NotificationChannel
    {

        /// <summary>
        /// Plataforma web
        /// </summary>
        NotificationWeb,

        /// <summary>
        /// Mensaje de texto
        /// </summary>
        Sms,

        /// <summary>
        /// Correo electronico
        /// </summary>
        Email,

        /// <summary>
        /// Mensaje de whatsapp
        /// </summary>
        WhatsApp
    }
}
