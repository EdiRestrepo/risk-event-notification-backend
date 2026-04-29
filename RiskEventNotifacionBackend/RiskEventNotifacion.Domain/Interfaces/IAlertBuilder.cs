using RiskEventNotifacion.Domain.Entities;
using RiskEventNotifacion.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Domain.Interfaces
{
    public interface IAlertBuilder
    {
        IAlertBuilder SetEventType(EventType eventType);
        IAlertBuilder SetRiskLevel(RiskLevel riskLevel);
        IAlertBuilder SetTitle(String title);
        IAlertBuilder SetMessage(String message);
        IAlertBuilder SetLocation(String location);
        IAlertBuilder SetSource(String source);
        IAlertBuilder SetExpiration(DateTime expiration);
        IAlertBuilder AddInstruction(String instruction);
        IAlertBuilder AddChannel(NotificationChannel channel);
        Alerts Build();
    }
}
