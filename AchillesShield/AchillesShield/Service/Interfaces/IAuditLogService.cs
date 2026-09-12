using AchillesShield.Models;

namespace AchillesShield.Services.Interfaces;

public interface IAuditLogService
{
    Task<IEnumerable<AuditLog>> GetAllAsync();

    Task<AuditLog?> GetByIdAsync(int id);

    Task<IEnumerable<AuditLog>> GetByUserIdAsync(
        int userId);

    Task<IEnumerable<AuditLog>> GetByEntityAsync(
        string entityType,
        int entityId);

    Task<AuditLog> CreateAsync(AuditLog auditLog);
}