using AchillesShield.Models;

namespace AchillesShield.Repositories.Interfaces;

public interface ICommentRepository : IBaseRepository<Comment>
{
    Task<IEnumerable<Comment>> GetByIncidentIdAsync(int incidentId);

    Task<IEnumerable<Comment>> GetByUserIdAsync(int userId);
}