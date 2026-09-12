using AchillesShield.Models;

namespace AchillesShield.Repositories.Interfaces;

public interface IPlaybookActionRepository : IBaseRepository<PlaybookAction>
{
    Task<IEnumerable<PlaybookAction>> GetByPlaybookIdAsync(int playbookId);
}