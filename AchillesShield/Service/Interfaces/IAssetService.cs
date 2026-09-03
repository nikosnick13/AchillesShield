using AchillesShield.Models;

namespace AchillesShield.Services.Interfaces;

public interface IAssetService
{
    Task<IEnumerable<Asset>> GetAllAsync();

    Task<Asset?> GetByIdAsync(int id);

    Task<Asset> CreateAsync(Asset asset);

    Task<bool> UpdateAsync(int id, Asset asset);

    Task<bool> DeleteAsync(int id);
}