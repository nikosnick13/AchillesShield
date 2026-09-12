using AchillesShield.Models;
using AchillesShield.Repositories.Interfaces;
using AchillesShield.Services.Interfaces;

namespace AchillesShield.Services;

public class IncidentService : IIncidentService
{
    private readonly IIncidentRepository _incidentRepository;

    public IncidentService(
        IIncidentRepository incidentRepository)
    {
        _incidentRepository = incidentRepository;
    }

    public async Task<IEnumerable<Incident>> GetAllAsync()
    {
        return await _incidentRepository.GetAllAsync();
    }

    public async Task<Incident?> GetByIdAsync(int id)
    {
        return await _incidentRepository.GetByIdAsync(id);
    }

    public async Task<Incident?> GetByIncidentNumberAsync(
        string incidentNumber)
    {
        return await _incidentRepository
            .GetByIncidentNumberAsync(incidentNumber);
    }

    public async Task<IEnumerable<Incident>> GetByStatusAsync(
        string status)
    {
        return await _incidentRepository
            .GetByStatusAsync(status);
    }

    public async Task<IEnumerable<Incident>> GetBySeverityAsync(
        string severity)
    {
        return await _incidentRepository
            .GetBySeverityAsync(severity);
    }

    public async Task<IEnumerable<Incident>> GetAssignedToUserAsync(
        int userId)
    {
        return await _incidentRepository
            .GetAssignedToUserAsync(userId);
    }

    public async Task<Incident> CreateAsync(Incident incident)
    {
        await _incidentRepository.AddAsync(incident);
        return incident;
    }

    public async Task<bool> UpdateAsync(
        int id,
        Incident incident)
    {
        var existingIncident =
            await _incidentRepository.GetByIdAsync(id);

        if (existingIncident == null)
            return false;

        existingIncident.IncidentNumber =
            incident.IncidentNumber;

        existingIncident.Title =
            incident.Title;

        existingIncident.Description =
            incident.Description;

        existingIncident.Severity =
            incident.Severity;

        existingIncident.Status =
            incident.Status;

        existingIncident.AssignedUserId =
            incident.AssignedUserId;

        existingIncident.UpdatedAt =
            DateTime.UtcNow;

        _incidentRepository.Update(existingIncident);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var incident =
            await _incidentRepository.GetByIdAsync(id);

        if (incident == null)
            return false;

        incident.IsDeleted = true;
        incident.DeletedAt = DateTime.UtcNow;
        incident.UpdatedAt = DateTime.UtcNow;

        _incidentRepository.Update(incident);

        return true;
    }
}