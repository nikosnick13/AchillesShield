using AchillesShield.Data;
using AchillesShield.Models;
using Microsoft.EntityFrameworkCore;
public class RolePermissionRepository : IRolePermissionRepository
{
    private readonly ApplicationDbContext _context;

    public RolePermissionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<RolePermission?> GetAsync(
        int roleId,
        int permissionId)
    {
        return await _context.RolePermissions
            .Include(x => x.Role)
            .Include(x => x.Permission)
            .FirstOrDefaultAsync(x =>
                x.RoleId == roleId &&
                x.PermissionId == permissionId);
    }

    public async Task<IEnumerable<RolePermission>> GetByRoleIdAsync(
        int roleId)
    {
        return await _context.RolePermissions
            .Where(x => x.RoleId == roleId)
            .Include(x => x.Permission)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<RolePermission>> GetByPermissionIdAsync(
        int permissionId)
    {
        return await _context.RolePermissions
            .Where(x => x.PermissionId == permissionId)
            .Include(x => x.Role)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(RolePermission entity)
    {
        await _context.RolePermissions.AddAsync(entity);
    }

    public void Delete(RolePermission entity)
    {
        _context.RolePermissions.Remove(entity);
    }
}