namespace RiskEventNotifacion.Application.Interfaces
{
    public interface IAuthService
    {
        Task<Boolean> ValidateCredentialsAsync(String username, String password);
    }
}
