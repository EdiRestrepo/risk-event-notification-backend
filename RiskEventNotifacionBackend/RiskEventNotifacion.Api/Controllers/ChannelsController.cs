using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RiskEventNotifacion.Domain.Entities;
using RiskEventNotifacion.Presentation.Entities;
using RiskEventNotifacion.Presentation.Interfaces;
using static Confluent.Kafka.ConfigPropertyNames;

namespace RiskEventNotifacion.Api.Controllers
{
    [ApiController]
    [Route("api/channels")]
    public class ChannelsController : ControllerBase
    {
        private readonly IChannelsFacade channelsFacade;

        public ChannelsController(IChannelsFacade channelsFacade)
        {
            this.channelsFacade = channelsFacade;
        }

        [HttpGet("preferences/{userId}")]
        public async Task<IActionResult> GetPreferencesChannelsByUserId(String userId)
        {
            ResultObject resultObject = new ResultObject
            {
                Success = false,
                Message = String.Empty,
                Token = Guid.NewGuid()
            };

            var result = await this.channelsFacade.GetPreferencesChannelsByUserId(userId);

            if (result != null)
            {
                resultObject.Success = true;
                resultObject.Data = result;
                return Ok(new { success = resultObject.Success, message = resultObject.Message, token = resultObject.Token, userId = result.UserId, channels = result.Channels });
            }
            resultObject.Message = "No existen registros";
            return Ok(result);
        }

        [HttpPut("savepreferences/{userId}")]
        public async Task<IActionResult> UpdatePreferencesChannelsByUserId(String userId, [FromBody] ChannelsResult channelsUpdate)
        {
            ResultObject resultObject = new ResultObject
            {
                Success = false,
                Message = String.Empty,
                Token = Guid.NewGuid()
            };

            if (channelsUpdate == null)
            {
                resultObject.Message = "Debe diligenciar los canales";
            }

            Boolean result = await this.channelsFacade.UpdatePreferencesChannelsByUserId(userId, channelsUpdate);

            if (result)
            {
                resultObject.Success = true;
                resultObject.Message = "Preferencias actualizadas correctamente";
                return Ok(resultObject);
            }

            return BadRequest(resultObject);
        }
    }
}
