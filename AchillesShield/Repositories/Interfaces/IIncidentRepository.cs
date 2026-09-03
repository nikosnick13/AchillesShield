using AchillesShield.Models;

namespace AchillesShield.Repositories.Interfaces;

public interface IIncidentRepository : IBaseRepository<Incident>
{
    Task<Incident?> GetByIncidentNumberAsync(string incidentNumber);

    Task<Incident?> GetByIdWithDetailsAsync(int id);

    Task<IEnumerable<Incident>> GetByStatusAsync(string status);

    Task<IEnumerable<Incident>> GetBySeverityAsync(string severity);

    Task<IEnumerable<Incident>> GetAssignedToUserAsync(int userId);

    Task<IEnumerable<Incident>> GetOpenIncidentsAsync();
}