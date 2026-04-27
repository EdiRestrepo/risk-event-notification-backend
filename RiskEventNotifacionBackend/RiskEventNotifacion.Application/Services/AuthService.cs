using RiskEventNotifacion.Application.Interfaces;
using RiskEventNotifacion.Domain.Entities;
using RiskEventNotifacion.Infraestructure.Interfaces;

namespace RiskEventNotifacion.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;
        public AuthService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Boolean> ValidateCredentialsAsync(String username, String password)
        {
            User user = new User();
            user.UserName = username;
            user.Password = password;

            return await userRepository.ValidateUserAsync(user);
        }
    }
}
