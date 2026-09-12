using AchillesShield.Data;
using AchillesShield.Models;
using AchillesShield.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AchillesShield.Repositories;

public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
{
    public PermissionRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<Permission?> GetByNameAsync(string name)
    {
        return await _dbSet
            .FirstOrDefaultAsync(p => p.Name == name);
    }

    public async Task<IEnumerable<Permission>> GetByRoleIdAsync(int roleId)
    {
        return await _dbSet
            .Where(p => p.RolePermissions
                .Any(rp => rp.RoleId == roleId))
            .AsNoTracking()
            .ToListAsync();
    }
}