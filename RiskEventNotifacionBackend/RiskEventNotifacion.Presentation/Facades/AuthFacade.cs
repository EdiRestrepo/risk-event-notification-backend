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
        public async Task<UserRequest> ValidateUsersAsync(UserRequest user)
        {

            UserRequest userResponse = user;

            var result =  await this.authService.ValidateCredentialsAsync(user.UserName, user.Password);

            if (result != null)
            {
                userResponse.Id = result.Id;
                userResponse.Name = result.Name;
            }
            return userResponse;

        }
    }
}
