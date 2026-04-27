using RiskEventNotifacion.Application.Interfaces;
using RiskEventNotifacion.Presentation.Entities;
using RiskEventNotifacion.Presentation.Interfaces;

namespace RiskEventNotifacion.Presentation.Facades
{
    public class AuthFacade : IAuthFacade
    {
        private readonly IAuthService authService;

        public AuthFacade(IAuthService authService)
        {
            this.authService = authService;
        }
        public async Task<Boolean> ValidateUsersAsync(UserRequest user)
        {
            return await this.authService.ValidateCredentialsAsync(user.UserName, user.Password);
        }
    }
}
