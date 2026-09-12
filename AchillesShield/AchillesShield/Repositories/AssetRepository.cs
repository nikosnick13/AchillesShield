using AchillesShield.Data;
using AchillesShield.Models;
using AchillesShield.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AchillesShield.Repositories;

public class AssetRepository : BaseRepository<Asset>, IAssetRepository
{
    public AssetRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<Asset?> GetByIdWithIncidentsAsync(int id)
    {
        return await _dbSet
            .Include(a => a.IncidentAssets)
                .ThenInclude(ia => ia.Incident)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Asset>> GetByTypeAsync(string type)
    {
        return await _dbSet
            .Where(a => a.AssetType == type)
            .AsNoTracking()
            .ToListAsync();
    }
}