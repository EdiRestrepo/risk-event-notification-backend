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
            ResultObject resultObject = new ResultObject
            {
                Success = false,
                Message = String.Empty,
                Token = Guid.NewGuid()
            };
            Boolean result = await this.alertsFacade.GenerarateAlertAsync(request);
            if (result == true)
            {
                resultObject.Success = true;
                resultObject.Message = "Alerta Generada Correctametne";
                return Ok(resultObject);
            }
            resultObject.Message = "No se pudo generar la alerta";
            return BadRequest(resultObject);
        }
    }
}
