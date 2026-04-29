using RiskEventNotifacion.Domain.Enum;
using RiskEventNotifacion.Domain.Interfaces;

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

        public IAlertBuilder SetTitle(string title)
        {
            this.alert.Title = title;
            return this;
        }

        public IAlertBuilder SetMessage(string message)
        {
            this.alert.Message = message;
            return this;
        }

        public IAlertBuilder SetLocation(string location)
        {
            this.alert.Location = location;
            return this;
        }

        public IAlertBuilder SetSource(string source)
        {
            this.alert.Source = source;
            return this;
        }

        public IAlertBuilder SetExpiration(DateTime expiration)
        {
            this.alert.ExpiresAt = expiration;
            return this;
        }

        public IAlertBuilder AddInstruction(string instruction)
        {
            this.alert.Instructions.Add(instruction);
            return this;
        }

        public IAlertBuilder AddChannel(NotificationChannel channel)
        {
            this.alert.Channels.Add(channel);
            return this;
        }

        public Alerts Build()
        {
            return this.alert;
        }
    }
}
