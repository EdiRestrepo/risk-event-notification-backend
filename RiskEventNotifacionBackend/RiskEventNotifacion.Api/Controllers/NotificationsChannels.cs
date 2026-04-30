using Microsoft.AspNetCore.Mvc;
using RiskEventNotifacion.Presentation.Entities;
using RiskEventNotifacion.Presentation.Interfaces;

namespace RiskEventNotifacion.Api.Controllers
{
    [ApiController]
    [Route("api/preferences")]
    public class NotificationsChannels : ControllerBase
    {
        private readonly IAlertsFacade alertsFacade;

        public NotificationsChannels(IAlertsFacade alertsFacade)
        {
            this.alertsFacade = alertsFacade;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetPreferencesChannelsByUserId(String userId)
        {
            //Boolean result = await this.alertsFacade.GenerarateAlertAsync(request);
            //if (result == true)
            //{
            //    //return Ok(new { message = "Login exitoso", token = "un-jwt-token-aqui" });
            //    return Ok("Alerta Generada Correctametne");
            //}
            //return Unauthorized(new { message = "No autorizado", token = "un-jwt-token-aqui" });
            return Unauthorized("No se pudo generar la alerta");
        }
    }
}
