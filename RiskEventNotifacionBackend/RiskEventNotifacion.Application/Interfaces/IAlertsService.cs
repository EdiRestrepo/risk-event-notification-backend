using RiskEventNotifacion.Domain.Enum;

namespace RiskEventNotifacion.Application.Interfaces
{
    public interface IAlertsService
    {
        Task<Boolean> GenerarateAlertAsync(Int16 eventType, Int16 riskLevel, String title, String message, String location, String source, List<String> instructions, List<Int16> channels, Boolean isGeneric);
    }
}
