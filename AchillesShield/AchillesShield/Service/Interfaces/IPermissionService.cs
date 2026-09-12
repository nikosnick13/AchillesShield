using AchillesShield.Models;

namespace AchillesShield.Services.Interfaces;

public interface IPermissionService
{
    Task<IEnumerable<Permission>> GetAllAsync();

    Task<Permission?> GetByIdAsync(int id);

    Task<Permission?> GetByNameAsync(string name);

    Task<Permission> CreateAsync(Permission permission);

    Task<bool> UpdateAsync(int id, Permission permission);

    Task<bool> DeleteAsync(int id);
}