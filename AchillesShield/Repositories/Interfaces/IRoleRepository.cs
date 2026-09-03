using AchillesShield.Models;

namespace AchillesShield.Repositories.Interfaces;

public interface IRoleRepository : IBaseRepository<Role>
{
    Task<Role?> GetByNameAsync(string name);

    Task<Role?> GetByIdWithPermissionsAsync(int id);
}