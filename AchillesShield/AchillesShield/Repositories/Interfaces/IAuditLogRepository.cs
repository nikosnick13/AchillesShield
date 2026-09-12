using AchillesShield.Models;

namespace AchillesShield.Repositories.Interfaces;

public interface IAuditLogRepository : IBaseRepository<AuditLog>
{
    Task<IEnumerable<AuditLog>> GetByUserIdAsync(int userId);

    Task<IEnumerable<AuditLog>> GetByEntityAsync(
        string entityType,
        int entityId);

    Task<IEnumerable<AuditLog>> GetByActionAsync(string action);
}