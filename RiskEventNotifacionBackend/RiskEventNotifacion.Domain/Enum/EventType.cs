using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Domain.Enum
{
    public enum EventType
    {
        /// <summary>
        /// Inundaciones
        /// </summary>
        Flood,

        /// <summary>
        /// Deslizamientos de tierra
        /// </summary>
        Landslide,

        /// <summary>
        /// Lluvias fuertes
        /// </summary>
        HeavyRain,

        /// <summary>
        /// Desbordamientos de rios
        /// </summary>
        RiverOverflow
    }
}
