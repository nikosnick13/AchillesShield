using AchillesShield.Models;

namespace AchillesShield.Services.Interfaces;

public interface IPlaybookService
{
    Task<IEnumerable<Playbook>> GetAllAsync();

    Task<Playbook?> GetByIdAsync(int id);

    Task<Playbook> CreateAsync(Playbook playbook);

    Task<bool> UpdateAsync(int id, Playbook playbook);

    Task<bool> DeleteAsync(int id);
}