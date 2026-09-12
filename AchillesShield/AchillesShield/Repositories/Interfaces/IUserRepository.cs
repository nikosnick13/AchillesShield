using AchillesShield.Models;

namespace AchillesShield.Repositories.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdWithRoleAsync(int id);
    Task<IEnumerable<User>> GetActiveUsersAsync();
}