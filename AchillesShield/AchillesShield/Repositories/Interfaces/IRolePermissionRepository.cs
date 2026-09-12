using AchillesShield.Models;

public interface IRolePermissionRepository
{
    Task<RolePermission?> GetAsync(int roleId, int permissionId);

    Task<IEnumerable<RolePermission>> GetByRoleIdAsync(int roleId);

    Task<IEnumerable<RolePermission>> GetByPermissionIdAsync(int permissionId);

    Task AddAsync(RolePermission entity);

    void Delete(RolePermission entity);
}