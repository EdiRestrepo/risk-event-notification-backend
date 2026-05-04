using RiskEventNotifacion.Application.Entities;
using RiskEventNotifacion.Application.Interfaces;
using RiskEventNotifacion.Presentation.Entities;
using RiskEventNotifacion.Presentation.Interfaces;

namespace RiskEventNotifacion.Presentation.Facades
{
    public class AlertsFacade : IAlertsFacade
    {
        private readonly IAlertsService alertsService;
        private readonly ITraceLogger traceLogger;

        public AlertsFacade(IAlertsService alertsService, ITraceLogger traceLogger)
        {
            this.alertsService = alertsService;
            this.traceLogger = traceLogger;
        }
        public async Task<Boolean> GenerarateAlertAsync(AlertRequest alert, TraceContext traceContext)
        {
            await this.traceLogger.LogAsync(traceContext, "PresentationFacade", "StartExecute", "OK", "Iniciando aplicación");
            return await this.alertsService.GenerarateAlertAsync(alert.EventType, alert.RiskLevel, alert.Title, alert.Message, alert.Location, alert.Source, alert.Instructions, alert.Channels, alert.isGenereric, traceContext);
        }

        public Task<Boolean> GetPreferencesChannelsByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
