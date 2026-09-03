using AchillesShield.Models;

namespace AchillesShield.Services.Interfaces;

public interface IPlaybookActionService
{
    Task<IEnumerable<PlaybookAction>> GetAllAsync();
    Task<PlaybookAction?> GetByIdAsync(int id);
    Task<IEnumerable<PlaybookAction>> GetByPlaybookIdAsync(int playbookId);
    Task<PlaybookAction> CreateAsync(PlaybookAction action);
    Task<bool> UpdateAsync(int id,PlaybookAction action);
    Task<bool> DeleteAsync(int id);
}