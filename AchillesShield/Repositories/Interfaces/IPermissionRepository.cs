using AchillesShield.Models;

namespace AchillesShield.Repositories.Interfaces;

public interface IPermissionRepository : IBaseRepository<Permission>
{
    Task<Permission?> GetByNameAsync(string name);

    Task<IEnumerable<Permission>> GetByRoleIdAsync(int roleId);
}