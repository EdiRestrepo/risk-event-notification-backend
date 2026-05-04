using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Domain.Enum
{
    public enum NotificationExternalLogType
    {
        /// <summary>
        /// Sin ningùn origin expecifico
        /// </summary>
        None,

        /// <summary>
        /// Notificacones recibidas por el productor de servidor kafka 
        /// </summary>
        KafkaProducer,

        /// <summary>
        /// Notificacones recibidas por el consumidor de servidor kafka 
        /// </summary>
        KafkaConsumer
    }
}
