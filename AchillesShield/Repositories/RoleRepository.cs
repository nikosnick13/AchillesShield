using AchillesShield.Data;
using AchillesShield.Models;
using AchillesShield.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AchillesShield.Repositories;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<Role?> GetByNameAsync(string name)
    {
        return await _dbSet
            .FirstOrDefaultAsync(r => r.Name == name);
    }

    public async Task<Role?> GetByIdWithPermissionsAsync(int id)
    {
        return await _dbSet
            .Include(r => r.RolePermissions)
                .ThenInclude(rp => rp.Permission)
            .FirstOrDefaultAsync(r => r.Id == id);
    }
}