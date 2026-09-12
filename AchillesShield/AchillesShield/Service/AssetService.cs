using AchillesShield.Models;
using AchillesShield.Repositories.Interfaces;
using AchillesShield.Services.Interfaces;

namespace AchillesShield.Services;

public class AssetService : IAssetService
{
    private readonly IAssetRepository _assetRepository;

    public AssetService(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    public async Task<IEnumerable<Asset>> GetAllAsync()
    {
        return await _assetRepository.GetAllAsync();
    }

    public async Task<Asset?> GetByIdAsync(int id)
    {
        return await _assetRepository.GetByIdAsync(id);
    }

    public async Task<Asset> CreateAsync(Asset asset)
    {
         await _assetRepository.AddAsync(asset);
        return asset;
    }

    public async Task<bool> UpdateAsync(int id, Asset asset)
    {
        var existingAsset =
            await _assetRepository.GetByIdAsync(id);

        if (existingAsset == null)
            return false;

        // ΜΟΝΟ τα πραγματικά properties του Asset.

        _assetRepository.Update(existingAsset);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var asset =
            await _assetRepository.GetByIdAsync(id);

        if (asset == null)
            return false;

        _assetRepository.Delete(asset);

        return true;
    }
}