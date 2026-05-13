using RiskEventNotifacion.Domain.Interfaces;
using System.Diagnostics;

namespace RiskEventNotifacion.Domain.Entities
{
    public class WhatsAppUserNotificationMessage : DecoratorUserNotificationMessage
    {
        private Alerts alerts;
        public WhatsAppUserNotificationMessage(IUserNotificationMessage decoratorNotificationMessage, Alerts alertsNew) 
            : base(decoratorNotificationMessage)
        {
            this.alerts = alertsNew;
        }
        public override void SendNotificationMessage()
        {
            this.SendNotificationMessageByWhatsApp();
            base.SendNotificationMessage();
        }

        private void SendNotificationMessageByWhatsApp()
        {
            Debug.WriteLine("Alerta enviada por WhatsApp: " + this.alerts.Message);
        }
    }
}
