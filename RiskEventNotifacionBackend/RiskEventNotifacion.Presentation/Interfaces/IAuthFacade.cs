using RiskEventNotifacion.Presentation.Entities;

namespace RiskEventNotifacion.Presentation.Interfaces
{
    public interface IAuthFacade
    {
        Task<UserRequest> ValidateUsersAsync(UserRequest user);
    }
}
