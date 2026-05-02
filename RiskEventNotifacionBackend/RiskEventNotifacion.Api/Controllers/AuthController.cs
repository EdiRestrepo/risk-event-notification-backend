using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RiskEventNotifacion.Application.Services;
using RiskEventNotifacion.Presentation.Entities;
using RiskEventNotifacion.Presentation.Facades;
using RiskEventNotifacion.Presentation.Interfaces;
using System.Xml.Linq;

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
            ResultObject resultObject = new ResultObject 
            { 
                Success = false, 
                Message = String.Empty, 
                Token = Guid.NewGuid() 
            };

            var result = await this.authFacade.ValidateUsersAsync(request);
            
            if (!String.IsNullOrEmpty(result.Id) && !String.IsNullOrEmpty(result.Name)) {
                resultObject.Success = true;
                resultObject.Message = "Ingreso exitoso";
                return Ok(new
                {
                    success = resultObject.Success,
                    message = resultObject.Message,
                    token = resultObject.Token,
                    user = new { id = result.Id, name = result.Name, userName = result.UserName}
                });
            }

            resultObject.Message = "Ingreso no autorizado";
            return Unauthorized(resultObject);
        }
    }
}
