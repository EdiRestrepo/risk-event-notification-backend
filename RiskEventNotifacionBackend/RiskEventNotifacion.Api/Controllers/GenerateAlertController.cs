using Microsoft.AspNetCore.Mvc;
using RiskEventNotifacion.Presentation.Entities;
using RiskEventNotifacion.Presentation.Interfaces;

namespace RiskEventNotifacion.Api.Controllers
{
    [ApiController]
    [Route("api/alertas")]
    public class GenerateAlertController : ControllerBase
    {
        private readonly IAlertsFacade alertsFacade;

        public GenerateAlertController(IAlertsFacade alertsFacade)
        {
            this.alertsFacade = alertsFacade;
        }

        [HttpPost("generar")]
        public async Task<IActionResult> Login(AlertRequest request)
        {
            Boolean result = await this.alertsFacade.GenerarateAlertAsync(request);
            if (result == true)
            {
                //return Ok(new { message = "Login exitoso", token = "un-jwt-token-aqui" });
                return Ok("Alerta Generada Correctametne");
            }
            //return Unauthorized(new { message = "No autorizado", token = "un-jwt-token-aqui" });
            return Unauthorized("No se pudo generar la alerta");
        }
    }
}
