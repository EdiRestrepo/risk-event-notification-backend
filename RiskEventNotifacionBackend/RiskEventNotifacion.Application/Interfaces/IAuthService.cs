using RiskEventNotifacion.Infraestructure.Entities;

namespace RiskEventNotifacion.Application.Interfaces
{
    public interface IAuthService
    {
        Task<UsersApplication> ValidateCredentialsAsync(String username, String password);
    }
}
