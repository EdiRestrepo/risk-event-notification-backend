using Newtonsoft.Json;
using RiskEventNotifacion.Application.DTOs;
using RiskEventNotifacion.Application.Interfaces;
using RiskEventNotifacion.Domain.Entities;
using RiskEventNotifacion.Domain.Enum;
using RiskEventNotifacion.Domain.Interfaces;

namespace RiskEventNotifacion.Application.Services
{
    public class AlertsService : IAlertsService
    {
        private readonly INotificationService notificationService;
        public AlertsService(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public async Task<Boolean> GenerarateAlertAsync(Int16 eventType, Int16 riskLevel, String title, String message, String location, String source, List<String> instructions, List<Int16> channels, Boolean isGeneric)
        {
            AlertDirector alertDirector = new AlertDirector();
            Alerts alert = new Alerts();
            Boolean isAlertGenerate = false;
            if (isGeneric)
            {
                if ((EventType)eventType == EventType.Flood)
                {
                    alert = alertDirector.CreateFloodAlert(
                        new AlertBuilder(),
                        location
                    );
                    isAlertGenerate = true;
                }
                else if ((EventType)eventType == EventType.Landslide)
                {
                    alert = alertDirector.CreateLandslideAlert(
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
                alert = alertDirector.CreateAlertDynamic(new AlertBuilder(), eventTypeInit, riskLevelInit, title, message, location, source, instructions, channelsInit);
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

                await this.notificationService.SendToAllAsync(notificationMessage);
            }

            Console.WriteLine(alert);
            return isAlertGenerate;
            
        }

        public Task<bool> GetPreferencesChannelsByUserId(string UserId)
        {
            throw new NotImplementedException();
        }

        //public Task<Boolean> GetPreferencesChannelsByUserId(String UserId)
        //{
        //    UserSettings userSettings = new UserSettings
        //    {
        //        UserId = "12345",
        //        Channels = new Channels
        //        {
        //            Sms = true,
        //            Email = false,
        //            Push = true,
        //            Whatsapp = true
        //        }
        //    };

        //    return true;
        //}
    }

    public class UserSettings
    {
        public String UserId { get; set; }
        public Channels Channels { get; set; }
    }

    public class Channels
    {
        public Boolean Sms { get; set; }
        public Boolean Email { get; set; }
        public Boolean Push { get; set; }
        public Boolean Whatsapp { get; set; }
    }

}
