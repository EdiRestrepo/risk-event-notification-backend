using RiskEventNotifacion.Presentation.Entities;

namespace RiskEventNotifacion.Presentation.Interfaces
{
    public interface IAlertsFacade
    {
        Task<Boolean> GenerarateAlertAsync(AlertRequest user);
    }
}
