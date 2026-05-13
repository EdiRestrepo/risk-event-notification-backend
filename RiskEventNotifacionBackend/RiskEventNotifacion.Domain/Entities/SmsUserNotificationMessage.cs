using RiskEventNotifacion.Domain.Interfaces;
using System.Diagnostics;

namespace RiskEventNotifacion.Domain.Entities
{
    public class SmsUserNotificationMessage : DecoratorUserNotificationMessage
    {
        private Alerts alerts;
        public SmsUserNotificationMessage(IUserNotificationMessage decoratorNotificationMessage, Alerts alertsNew) 
            : base(decoratorNotificationMessage)
        {
            this.alerts = alertsNew;
        }
        public override void SendNotificationMessage()
        {
            this.SendNotificationMessageBySms();
            base.SendNotificationMessage();
        }

        private void SendNotificationMessageBySms()
        {
            Debug.WriteLine("Alerta enviada por Sms: " + this.alerts.Message);
        }
    }
}
