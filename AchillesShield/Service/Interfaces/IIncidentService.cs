using AchillesShield.Models;

namespace AchillesShield.Services.Interfaces;

public interface IIncidentService
{
    Task<IEnumerable<Incident>> GetAllAsync();

    Task<Incident?> GetByIdAsync(int id);
    Task<Incident?> GetByIncidentNumberAsync(
        string incidentNumber);
    Task<IEnumerable<Incident>> GetByStatusAsync(
        string status);
    Task<IEnumerable<Incident>> GetBySeverityAsync(
        string severity);
    Task<IEnumerable<Incident>> GetAssignedToUserAsync(
        int userId);
    Task<Incident> CreateAsync(Incident incident);
    Task<bool> UpdateAsync(int id, Incident incident);
    Task<bool> DeleteAsync(int id);
}