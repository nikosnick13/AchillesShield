using AchillesShield.Data;
using AchillesShield.Models;
using AchillesShield.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AchillesShield.Repositories;

public class IncidentRepository : BaseRepository<Incident>, IIncidentRepository
{
    public IncidentRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<Incident?> GetByIncidentNumberAsync(string incidentNumber)
    {
        return await _dbSet
            .FirstOrDefaultAsync(i => i.IncidentNumber == incidentNumber);
    }

    public async Task<Incident?> GetByIdWithDetailsAsync(int id)
    {
        return await _dbSet
            .Include(i => i.AssignedUser)
            .Include(i => i.Comments)
                .ThenInclude(c => c.User)
            .Include(i => i.IncidentAlerts)
                .ThenInclude(ia => ia.Alert)
            .Include(i => i.IncidentAssets)
                .ThenInclude(ia => ia.Asset)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<IEnumerable<Incident>> GetByStatusAsync(string status)
    {
        return await _dbSet
            .Where(i => i.Status == status && !i.IsDeleted)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Incident>> GetBySeverityAsync(string severity)
    {
        return await _dbSet
            .Where(i => i.Severity == severity && !i.IsDeleted)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Incident>> GetAssignedToUserAsync(int userId)
    {
        return await _dbSet
            .Where(i => i.AssignedUserId == userId && !i.IsDeleted)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Incident>> GetOpenIncidentsAsync()
    {
        return await _dbSet
            .Where(i =>
                !i.IsDeleted &&
                i.Status != "Resolved" &&
                i.Status != "Closed")
            .AsNoTracking()
            .ToListAsync();
    }
}