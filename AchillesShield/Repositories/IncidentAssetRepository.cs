using AchillesShield.Data;
using AchillesShield.Models;
using Microsoft.EntityFrameworkCore;
public class IncidentAssetRepository : IIncidentAssetRepository
{
    private readonly ApplicationDbContext _context;

    public IncidentAssetRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IncidentAsset?> GetAsync(
        int incidentId,
        int assetId)
    {
        return await _context.IncidentAssets
            .Include(x => x.Incident)
            .Include(x => x.Asset)
            .FirstOrDefaultAsync(x =>
                x.IncidentId == incidentId &&
                x.AssetId == assetId);
    }

    public async Task<IEnumerable<IncidentAsset>> GetByIncidentIdAsync(
        int incidentId)
    {
        return await _context.IncidentAssets
            .Where(x => x.IncidentId == incidentId)
            .Include(x => x.Asset)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<IncidentAsset>> GetByAssetIdAsync(
        int assetId)
    {
        return await _context.IncidentAssets
            .Where(x => x.AssetId == assetId)
            .Include(x => x.Incident)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(IncidentAsset entity)
    {
        await _context.IncidentAssets.AddAsync(entity);
    }

    public void Delete(IncidentAsset entity)
    {
        _context.IncidentAssets.Remove(entity);
    }
}