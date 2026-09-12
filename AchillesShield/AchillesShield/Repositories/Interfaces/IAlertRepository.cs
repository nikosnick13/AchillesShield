using AchillesShield.Models;

namespace AchillesShield.Repositories.Interfaces;

public interface IAlertRepository : IBaseRepository<Alert>
{
    Task<Alert?> GetByIdWithIncidentsAsync(int id);

    Task<IEnumerable<Alert>> GetBySeverityAsync(string severity);

    //Task<IEnumerable<Alert>> GetUnresolvedAlertsAsync();
}