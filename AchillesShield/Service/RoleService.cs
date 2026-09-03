using AchillesShield.Models;
using AchillesShield.Repositories.Interfaces;
using AchillesShield.Services.Interfaces;

namespace AchillesShield.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<IEnumerable<Role>> GetAllAsync()
    {
        return await _roleRepository.GetAllAsync();
    }

    public async Task<Role?> GetByIdAsync(int id)
    {
        return await _roleRepository.GetByIdAsync(id);
    }

    public async Task<Role?> GetByNameAsync(string name)
    {
        return await _roleRepository.GetByNameAsync(name);
    }

    public async Task<Role> CreateAsync(Role role)
    {
        await _roleRepository.AddAsync(role);
        return role;
    }

    public async Task<bool> UpdateAsync(int id, Role role)
    {
        var existingRole = await _roleRepository.GetByIdAsync(id);

        if (existingRole == null)
            return false;

        existingRole.Name = role.Name;

        _roleRepository.Update(existingRole);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var role = await _roleRepository.GetByIdAsync(id);

        if (role == null)
            return false;

        _roleRepository.Delete(role);

        return true;
    }
}