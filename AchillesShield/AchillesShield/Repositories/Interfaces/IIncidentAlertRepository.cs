using AchillesShield.Models;

namespace AchillesShield.Repositories.Interfaces;

public interface IIncidentAlertRepository
{
    Task<IncidentAlert?> GetAsync(int incidentId, int alertId);

    Task<IEnumerable<IncidentAlert>> GetByIncidentIdAsync(int incidentId);

    Task<IEnumerable<IncidentAlert>> GetByAlertIdAsync(int alertId);

    Task AddAsync(IncidentAlert entity);

    void Delete(IncidentAlert entity);
}