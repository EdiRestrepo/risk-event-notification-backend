using RiskEventNotifacion.Presentation.Entities;

namespace RiskEventNotifacion.Presentation.Interfaces
{
    public interface IAuthFacade
    {
        Task<Boolean> ValidateUsersAsync(UserRequest user);
    }
}
