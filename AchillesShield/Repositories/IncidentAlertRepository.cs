using AchillesShield.Data;
using AchillesShield.Models;
using AchillesShield.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AchillesShield.Repositories;

public class IncidentAlertRepository : IIncidentAlertRepository
{
    private readonly ApplicationDbContext _context;

    public IncidentAlertRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IncidentAlert?> GetAsync(
        int incidentId,
        int alertId)
    {
        return await _context.IncidentAlerts
            .Include(x => x.Alert)
            .Include(x => x.Incident)
            .FirstOrDefaultAsync(x =>
                x.IncidentId == incidentId &&
                x.AlertId == alertId);
    }

    public async Task<IEnumerable<IncidentAlert>> GetByIncidentIdAsync(
        int incidentId)
    {
        return await _context.IncidentAlerts
            .Where(x => x.IncidentId == incidentId)
            .Include(x => x.Alert)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<IncidentAlert>> GetByAlertIdAsync(
        int alertId)
    {
        return await _context.IncidentAlerts
            .Where(x => x.AlertId == alertId)
            .Include(x => x.Incident)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(IncidentAlert entity)
    {
        await _context.IncidentAlerts.AddAsync(entity);
    }

    public void Delete(IncidentAlert entity)
    {
        _context.IncidentAlerts.Remove(entity);
    }
}