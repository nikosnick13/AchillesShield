using AchillesShield.Data;
using AchillesShield.Models;
using AchillesShield.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AchillesShield.Repositories;

public class AlertRepository : BaseRepository<Alert>, IAlertRepository
{
    public AlertRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<Alert?> GetByIdWithIncidentsAsync(int id)
    {
        return await _dbSet
            .Include(a => a.IncidentAlerts)
                .ThenInclude(ia => ia.Incident)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Alert>> GetBySeverityAsync(string severity)
    {
        return await _dbSet
            .Where(a => a.Severity == severity)
            .AsNoTracking()
            .ToListAsync();
    }

}