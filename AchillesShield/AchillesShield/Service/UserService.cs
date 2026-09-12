using AchillesShield.Models;
using AchillesShield.Repositories.Interfaces;
using AchillesShield.Service.Interfaces;
 

namespace AchillesShield.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _userRepository.GetByUsernameAsync(username);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _userRepository.GetByEmailAsync(email);
    }

    public async Task<User> CreateAsync(User user)
    {
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

        await _userRepository.AddAsync(user);
        return user;
    }   

    public async Task<bool> UpdateAsync(int id, User user)
    {
        var existingUser = await _userRepository.GetByIdAsync(id);

        if (existingUser == null)
            return false;

        existingUser.Username = user.Username;
        existingUser.Email = user.Email;
        existingUser.IsActive = user.IsActive;
        existingUser.RoleId = user.RoleId;
        existingUser.UpdatedAt = DateTime.UtcNow;

        _userRepository.Update(existingUser);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            return false;

        user.IsDeleted = true;
        user.DeletedAt = DateTime.UtcNow;
        user.UpdatedAt = DateTime.UtcNow;

        _userRepository.Update(user);

        return true;
    }
}