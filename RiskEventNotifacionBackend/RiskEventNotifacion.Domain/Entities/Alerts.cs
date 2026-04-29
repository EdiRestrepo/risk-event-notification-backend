using RiskEventNotifacion.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Domain.Entities
{
    public class Alerts
    {
        /// <summary>
        /// Identificador ùnico de alerta
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Tipo de alerta
        /// </summary>
        public EventType EventType { get; set; }
        
        /// <summary>
        /// Riesgo de alerta
        /// </summary>
        public RiskLevel RiskLevel { get; set; }
        
        /// <summary>
        /// Titulo de la alerta
        /// </summary>
        public String Title { get; set; }
        
        /// <summary>
        /// Mensaje de la alerta
        /// </summary>
        public String Message { get; set; }
        
        /// <summary>
        /// Ubicaciòn
        /// </summary>
        public String Location { get; set; }
        
        /// <summary>
        /// Origen de la alerta
        /// </summary>
        public String Source { get; set; }
        
        /// <summary>
        /// Fecha de inicio 
        /// </summary>
        public DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// Fecha de finalizaciòn
        /// </summary>
        public DateTime ExpiresAt { get; set; }
        
        /// <summary>
        /// Estado de la alerta
        /// </summary>
        public AlertStatus Status { get; set; }

        /// <summary>
        /// Instrucciones y recomendaciones
        /// </summary>
        public List<String> Instructions { get; set; } = [];

        /// <summary>
        /// Lista de canales para la notificación
        /// </summary>
        public List<NotificationChannel> Channels { get; set; } = [];
    }
}
