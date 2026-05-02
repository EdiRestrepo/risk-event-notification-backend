using RiskEventNotifacion.Application.Interfaces;
using RiskEventNotifacion.Domain.Entities;
using RiskEventNotifacion.Infraestructure.Entities;
using RiskEventNotifacion.Infraestructure.Interfaces;

namespace RiskEventNotifacion.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsersApplicationRepository usersApplicationRepository;
        public AuthService(IUsersApplicationRepository usersApplicationRepository)
        {
            this.usersApplicationRepository = usersApplicationRepository;
        }

        public async Task<UsersApplication> ValidateCredentialsAsync(String username, String password)
        {
            Boolean isValidLogin = false;
            UsersApplication usersApplication = new UsersApplication();
            usersApplication.User = username;
            usersApplication.Password = password;


            //User user = new User();
            //user.UserName = username;
            //user.Password = password;

            //return await userRepository.ValidateUserAsync(user);

            return await this.usersApplicationRepository.ValidateUserLogin(usersApplication);

            //if (userExists != null) 
            //{
            //    isValidLogin = true;
            //}
            //return isValidLogin;
        }
    }
}
