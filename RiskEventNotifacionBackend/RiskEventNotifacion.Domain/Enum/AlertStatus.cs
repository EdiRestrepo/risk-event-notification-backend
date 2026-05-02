using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Domain.Enum
{
    public enum AlertStatus
    {
        /// <summary>
        /// Activas
        /// </summary>
        Active,

        /// <summary>
        /// Resueltas
        /// </summary>
        Resolved,

        /// <summary>
        /// Ya pasaron
        /// </summary>
        Expired
    }
}
