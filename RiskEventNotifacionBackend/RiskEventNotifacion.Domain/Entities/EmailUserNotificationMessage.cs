using RiskEventNotifacion.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Transactions;

namespace RiskEventNotifacion.Domain.Entities
{
    public class EmailUserNotificationMessage : DecoratorUserNotificationMessage
    {
        private Alerts alerts;
        public EmailUserNotificationMessage(IUserNotificationMessage decoratorNotificationMessage, Alerts alertsNew) 
            : base(decoratorNotificationMessage)
        {
            this.alerts = alertsNew;
        }

        public override void SendNotificationMessage()
        {
            this.SendNotificationMessageByEmail();
            base.SendNotificationMessage();
        }

        private void SendNotificationMessageByEmail()
        {
            Debug.WriteLine("Alerta enviada por Email: " + this.alerts.Message);
        }
    }
}
