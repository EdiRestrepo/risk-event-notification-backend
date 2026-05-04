using Newtonsoft.Json;
using RiskEventNotifacion.Application.DTOs;
using RiskEventNotifacion.Application.Entities;
using RiskEventNotifacion.Application.Interfaces;
using RiskEventNotifacion.Domain.Entities;
using RiskEventNotifacion.Domain.Enum;
using RiskEventNotifacion.Domain.Interfaces;

namespace RiskEventNotifacion.Application.Services
{
    public class AlertsService : IAlertsService
    {
        private readonly INotificationService notificationService;
        private readonly ITraceLogger traceLogger;

        public AlertsService(INotificationService notificationService, ITraceLogger traceLogger )
        {
            this.notificationService = notificationService;
            this.traceLogger = traceLogger;
        }

        public async Task<Boolean> GenerarateAlertAsync(Int16 eventType, Int16 riskLevel, String title, String message, String location, String source, List<String> instructions, List<Int16> channels, Boolean isGeneric, TraceContext traceContext)
        {
            await this.traceLogger.LogAsync(traceContext, "Application", "StartExecute", "OK", "Construyendo alerta");
            Alerts alert = new Alerts();
            Boolean isAlertGenerate = false;
            if (isGeneric)
            {
                if ((EventType)eventType == EventType.Flood)
                {
                    alert = AlertDirector.CreateFloodAlert(
                        new AlertBuilder(),
                        location
                    );
                    isAlertGenerate = true;
                }
                else if ((EventType)eventType == EventType.Landslide)
                {
                    alert = AlertDirector.CreateLandslideAlert(
                        new AlertBuilder(),
                        location
                    );
                    isAlertGenerate = true;
                }
            }

            if (!isAlertGenerate)
            {
                EventType eventTypeInit = (EventType)eventType;
                RiskLevel riskLevelInit = (RiskLevel)riskLevel;
                List<NotificationChannel> channelsInit = new List<NotificationChannel>();

                foreach (Int16 channel in channels)
                {
                    channelsInit.Add((NotificationChannel)channel);
                }
                alert = AlertDirector.CreateAlertDynamic(new AlertBuilder(), eventTypeInit, riskLevelInit, title, message, location, source, instructions, channelsInit);
                isAlertGenerate = true;
            }
            
            if (isAlertGenerate)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    Formatting = Formatting.Indented // Opcional: para que se vea ordenado
                };

                String alertsJson = JsonConvert.SerializeObject(alert, settings);
                NotificationMessage notificationMessage = new NotificationMessage
                {
                    Title = alert.Title,
                    Content = alertsJson,
                };

                //String alertsPlane = JsonConvert.SerializeObject(new {id= alert.Id, message=alert.Message}, settings);
                await this.traceLogger.LogAsync(traceContext, "Application", "FinishExecute", "OK", "Alerta contruida");
                await this.notificationService.SendToMessagePlaneAsync(alert.Message);
                await this.traceLogger.LogAsync(traceContext, "Application", "StarNotification", "OK", "Notificación de alerta enviada");
            }

            Console.WriteLine(alert);
            return isAlertGenerate;
            
        }
    }
}
