using RiskEventNotifacion.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Domain.Entities
{
    public abstract class DecoratorUserNotificationMessage : IUserNotificationMessage
    {
        protected readonly IUserNotificationMessage userNotificationMessage;
        public DecoratorUserNotificationMessage(IUserNotificationMessage decoratorNotificationMessage)
        {
            this.userNotificationMessage = decoratorNotificationMessage;
        }

        //public virtual void SendNotificationMessage();

        
        public virtual void SendNotificationMessage()
        {
            userNotificationMessage.SendNotificationMessage();
        }
        
    }
}
