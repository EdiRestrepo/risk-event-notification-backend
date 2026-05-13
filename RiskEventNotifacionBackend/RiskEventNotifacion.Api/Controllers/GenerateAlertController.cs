using Microsoft.AspNetCore.Mvc;
using RiskEventNotifacion.Presentation.DTOs;
using RiskEventNotifacion.Presentation.Entities;
using RiskEventNotifacion.Presentation.Interfaces;
using System.Diagnostics;

namespace RiskEventNotifacion.Api.Controllers
{
    [ApiController]
    [Route("api/alerts")]
    public class GenerateAlertController : ControllerBase
    {
        private readonly IAlertsFacade alertsFacade;
        private readonly ISiataAlertAdapter siataAlertAdapter;

        public GenerateAlertController(IAlertsFacade alertsFacade, ISiataAlertAdapter siataAlertAdapter)
        {
            this.alertsFacade = alertsFacade;
            this.siataAlertAdapter = siataAlertAdapter;
        }

        [HttpPost("receivealert")]
        public async Task<IActionResult> ReceiveAlert(SiataAlertDto siataAlertDto)
        {
            ResultObject resultObject = new ResultObject
            {
                Success = false,
                Message = String.Empty,
                Token = Guid.NewGuid()
            };

            AlertRequest request = this.siataAlertAdapter.Adapter(siataAlertDto);

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
