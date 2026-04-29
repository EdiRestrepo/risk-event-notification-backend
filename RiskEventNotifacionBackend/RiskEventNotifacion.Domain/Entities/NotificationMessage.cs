using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Domain.Entities
{
    public class NotificationMessage
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = String.Empty;
        public string Content { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
