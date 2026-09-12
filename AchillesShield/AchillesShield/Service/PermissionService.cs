using AchillesShield.Models;
using AchillesShield.Repositories.Interfaces;
using AchillesShield.Services.Interfaces;

namespace AchillesShield.Services;

public class PermissionService : IPermissionService
{
    private readonly IPermissionRepository _permissionRepository;

    public PermissionService(IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public async Task<IEnumerable<Permission>> GetAllAsync()
    {
        return await _permissionRepository.GetAllAsync();
    }

    public async Task<Permission?> GetByIdAsync(int id)
    {
        return await _permissionRepository.GetByIdAsync(id);
    }

    public async Task<Permission?> GetByNameAsync(string name)
    {
        return await _permissionRepository.GetByNameAsync(name);
    }

    public async Task<Permission> CreateAsync(Permission permission)
    {
        await _permissionRepository.AddAsync(permission);
        return permission;
    }

    public async Task<bool> UpdateAsync(
        int id,
        Permission permission)
    {
        var existingPermission =
            await _permissionRepository.GetByIdAsync(id);

        if (existingPermission == null)
            return false;

        existingPermission.Name = permission.Name;
        existingPermission.Description = permission.Description;

        _permissionRepository.Update(existingPermission);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var permission =
            await _permissionRepository.GetByIdAsync(id);

        if (permission == null)
            return false;

        _permissionRepository.Delete(permission);

        return true;
    }
}