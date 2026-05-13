using RiskEventNotifacion.Application.Interfaces;
using RiskEventNotifacion.Presentation.Entities;
using RiskEventNotifacion.Presentation.Interfaces;

namespace RiskEventNotifacion.Presentation.Facades
{
    public class AlertsFacade : IAlertsFacade
    {
        private readonly IAlertsService alertsService;

        public AlertsFacade(IAlertsService alertsService)
        {
            this.alertsService = alertsService;
        }
        public async Task<Boolean> GenerarateAlertAsync(AlertRequest alert)
        {
            return await this.alertsService.GenerarateAlertAsync(alert.EventType, alert.RiskLevel, alert.Title, alert.Message, alert.Location, alert.Source, alert.Instructions, alert.Channels, alert.isGenereric);
        }
    }
}
