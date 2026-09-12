using AchillesShield.Models;

namespace AchillesShield.Services.Interfaces;

public interface IAlertService
{
    Task<IEnumerable<Alert>> GetAllAsync();

    Task<Alert?> GetByIdAsync(int id);

    Task<Alert> CreateAsync(Alert alert);

    Task<bool> UpdateAsync(int id, Alert alert);

    Task<bool> DeleteAsync(int id);
}