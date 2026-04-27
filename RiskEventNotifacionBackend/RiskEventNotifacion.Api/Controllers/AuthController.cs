using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RiskEventNotifacion.Application.Services;
using RiskEventNotifacion.Presentation.Entities;
using RiskEventNotifacion.Presentation.Facades;
using RiskEventNotifacion.Presentation.Interfaces;

namespace RiskEventNotifacion.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthFacade authFacade;

        public AuthController(IAuthFacade _authFacade)
        {
            this.authFacade = _authFacade;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserRequest request)
        {
            Boolean result = await this.authFacade.ValidateUsersAsync(request);
            if (result == true) {
                return Ok("Ingreso exitoso");
            }
            return Unauthorized("No autorizado");
        }
    }
}
