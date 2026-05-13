using RiskEventNotifacion.Presentation.DTOs;
using RiskEventNotifacion.Presentation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Presentation.Interfaces
{
    public interface ISiataAlertAdapter
    {
        AlertRequest Adapter(SiataAlertDto siataAlertDto);
    }
}
