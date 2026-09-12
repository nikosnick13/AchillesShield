using AchillesShield.Models;

namespace AchillesShield.Repositories.Interfaces;

public interface IAssetRepository : IBaseRepository<Asset>
{
    Task<Asset?> GetByIdWithIncidentsAsync(int id);
    Task<IEnumerable<Asset>> GetByTypeAsync(string type);
}