using Microsoft.AspNetCore.Mvc;
using RiskEventNotifacion.Application.Entities;
using RiskEventNotifacion.Application.Interfaces;
using RiskEventNotifacion.Presentation.Entities;
using RiskEventNotifacion.Presentation.Interfaces;

namespace RiskEventNotifacion.Api.Controllers
{
    [ApiController]
    [Route("api/alertas")]
    public class GenerateAlertController : ControllerBase
    {
        private readonly IAlertsFacade alertsFacade;
        private readonly ITraceLogger traceLogger;

        public GenerateAlertController(IAlertsFacade alertsFacade, ITraceLogger traceLogger)
        {
            this.alertsFacade = alertsFacade;
            this.traceLogger = traceLogger;
        }

        [HttpPost("generar")]
        public async Task<IActionResult> GenerateAlert(AlertRequest request)
        {

            TraceContext traceContext = new TraceContext
            {
                CorrelationId = Guid.NewGuid().ToString(),
                ProcessName = "GenerateAlert"
            };

            await this.traceLogger.LogAsync(traceContext, "PresentationApi", "RequestReceived", "OK", "Solicitud recibida");

            ResultObject resultObject = new ResultObject
            {
                Success = false,
                Message = String.Empty,
                Token = Guid.NewGuid()
            };
            Boolean result = await this.alertsFacade.GenerarateAlertAsync(request, traceContext);
            if (result)
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
