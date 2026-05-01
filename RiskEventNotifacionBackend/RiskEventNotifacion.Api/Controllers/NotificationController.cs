using Microsoft.AspNetCore.Mvc;
using RiskEventNotifacion.Application.Interfaces;
using RiskEventNotifacion.Domain.Entities;
using RiskEventNotifacion.Presentation.Entities;

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
            ResultObject resultObject = new ResultObject
            {
                Success = false,
                Message = String.Empty,
                Token = Guid.NewGuid()
            };

            await this.producer.ProduceAsync(message);
            resultObject.Success = true;
            resultObject.Message = "Notificación enviada a Kafka";
            return Ok(resultObject);
        }
    }
}
