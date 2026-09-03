using AchillesShield.Data;
using AchillesShield.Models;
using AchillesShield.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AchillesShield.Repositories;

public class PlaybookActionRepository
    : BaseRepository<PlaybookAction>, IPlaybookActionRepository
{
    public PlaybookActionRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<PlaybookAction>> GetByPlaybookIdAsync(
        int playbookId)
    {
        return await _dbSet
            .Where(pa => pa.PlaybookId == playbookId && !pa.IsDeleted)
            .OrderBy(pa => pa.ExecutionOrder)
            .AsNoTracking()
            .ToListAsync();
    }
}