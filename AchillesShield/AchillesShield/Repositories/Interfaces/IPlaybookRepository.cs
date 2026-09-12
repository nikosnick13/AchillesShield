using AchillesShield.Models;

namespace AchillesShield.Repositories.Interfaces;

public interface IPlaybookRepository : IBaseRepository<Playbook>
{
    Task<Playbook?> GetByIdWithActionsAsync(int id);

    Task<IEnumerable<Playbook>> GetByTriggerTypeAsync(string triggerType);
}