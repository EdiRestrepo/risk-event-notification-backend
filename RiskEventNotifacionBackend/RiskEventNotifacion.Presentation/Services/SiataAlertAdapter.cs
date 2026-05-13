using RiskEventNotifacion.Presentation.DTOs;
using RiskEventNotifacion.Presentation.Entities;
using RiskEventNotifacion.Presentation.Interfaces;

namespace RiskEventNotifacion.Presentation.Services
{
    public class SiataAlertAdapter : ISiataAlertAdapter
    {
        public AlertRequest Adapter(SiataAlertDto siataAlertDto)
        {
            return new AlertRequest
            {
                EventType = siataAlertDto.Event_type,
                RiskLevel = siataAlertDto.Risk_type,
                Title = siataAlertDto.AlertName,
                Message = siataAlertDto.Description,
                Location = siataAlertDto.Place,
                Source = siataAlertDto.Origen,
                Instructions = siataAlertDto.Recommendations,
                Channels = siataAlertDto.NotificationChannels,
                isGenereric = siataAlertDto.isBasic
            };
        }
    }
}
