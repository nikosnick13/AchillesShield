using AchillesShield.Models;

public interface IIncidentAssetRepository
{
    Task<IncidentAsset?> GetAsync(int incidentId, int assetId);

    Task<IEnumerable<IncidentAsset>> GetByIncidentIdAsync(int incidentId);

    Task<IEnumerable<IncidentAsset>> GetByAssetIdAsync(int assetId);

    Task AddAsync(IncidentAsset entity);

    void Delete(IncidentAsset entity);
}