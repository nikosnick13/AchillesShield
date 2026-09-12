using AchillesShield.Data;
using AchillesShield.Models;
using AchillesShield.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AchillesShield.Repositories;

public class PlaybookRepository : BaseRepository<Playbook>, IPlaybookRepository
{
    public PlaybookRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<Playbook?> GetByIdWithActionsAsync(int id)
    {
        return await _dbSet
            .Include(p => p.PlaybookActions)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Playbook>> GetByTriggerTypeAsync(string triggerType)
    {
        return await _dbSet
            .Where(p => p.TriggerType == triggerType && !p.IsDeleted)
            .AsNoTracking()
            .ToListAsync();
    }
}