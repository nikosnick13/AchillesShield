using AchillesShield.Models;

namespace AchillesShield.Services.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetAllAsync();
    Task<Role?> GetByIdAsync(int id);
    Task<Role?> GetByNameAsync(string name);
    Task<Role> CreateAsync(Role role);
    Task<bool> UpdateAsync(int id, Role role);
    Task<bool> DeleteAsync(int id);
}