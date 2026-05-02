using RiskEventNotifacion.Domain.Enum;
using RiskEventNotifacion.Domain.Interfaces;
using System.Threading.Channels;

namespace RiskEventNotifacion.Domain.Entities
{
    public class AlertBuilder : IAlertBuilder
    {
        private readonly Alerts alert;

        public AlertBuilder()
        {
            this.alert = new Alerts
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                Status = AlertStatus.Active
            };
        }

        public IAlertBuilder SetEventType(EventType eventType)
        {
            this.alert.EventType = eventType;
            return this;
        }

        public IAlertBuilder SetRiskLevel(RiskLevel riskLevel)
        {
            this.alert.RiskLevel = riskLevel;
            return this;
        }

        public IAlertBuilder SetTitle(String title)
        {
            this.alert.Title = title;
            return this;
        }

        public IAlertBuilder SetMessage(String message)
        {
            this.alert.Message = message;
            return this;
        }

        public IAlertBuilder SetLocation(String location)
        {
            this.alert.Location = location;
            return this;
        }

        public IAlertBuilder SetSource(String source)
        {
            this.alert.Source = source;
            return this;
        }

        public IAlertBuilder SetExpiration(DateTime expiration)
        {
            this.alert.ExpiresAt = expiration;
            return this;
        }

        public IAlertBuilder AddInstruction(List<String> instruction)
        {
            foreach (String itemInstruction in instruction)
            {
                this.alert.Instructions.Add(itemInstruction);
            }
            return this;
        }

        public IAlertBuilder AddChannel(List<NotificationChannel> channel)
        {
            foreach (NotificationChannel itemChanel in channel)
            {
                this.alert.Channels.Add(itemChanel);
            }
            return this;
        }

        public Alerts Build()
        {
            return this.alert;
        }
    }
}
