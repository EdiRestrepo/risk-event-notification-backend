using Microsoft.AspNetCore.Mvc;
using RiskEventNotifacion.Application.Interfaces;
using RiskEventNotifacion.Domain.Entities;

namespace RiskEventNotifacion.Api.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    public class NotificationController : ControllerBase
    {
        private readonly IKafkaProducerService producer;

        public NotificationController(IKafkaProducerService producer)
        {
            this.producer = producer;
        }

        [HttpPost]
        public async Task<IActionResult> Send(NotificationMessage message)
        {
            await this.producer.ProduceAsync(message);

            return Ok(new
            {
                message = "Notificación enviada a Kafka"
            });
        }
    }
}
