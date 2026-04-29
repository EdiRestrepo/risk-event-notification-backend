using RiskEventNotifacion.Application.Interfaces;
using RiskEventNotifacion.Domain.Entities;
using RiskEventNotifacion.Infraestructure.Interfaces;

namespace RiskEventNotifacion.Application.Services
{
    public class AlertsService : IAlertsService
    {
        public AlertsService()
        {
        }

        public Task<Boolean> GenerarateAlertAsync(Int16 eventType, Int16 riskLevel, String title, String message, String location, String source, List<String> instructions, List<Int16> channels)
        {
            throw new NotImplementedException();
        }
    }
}
