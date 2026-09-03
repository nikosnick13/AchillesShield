using AchillesShield.Models;
using AchillesShield.Repositories.Interfaces;
using AchillesShield.Services.Interfaces;

namespace AchillesShield.Services;

public class AuditLogService : IAuditLogService
{
    private readonly IAuditLogRepository _auditLogRepository;

    public AuditLogService(
        IAuditLogRepository auditLogRepository)
    {
        _auditLogRepository = auditLogRepository;
    }

    public async Task<IEnumerable<AuditLog>> GetAllAsync()
    {
        return await _auditLogRepository.GetAllAsync();
    }

    public async Task<AuditLog?> GetByIdAsync(int id)
    {
        return await _auditLogRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<AuditLog>> GetByUserIdAsync(
        int userId)
    {
        return await _auditLogRepository
            .GetByUserIdAsync(userId);
    }

    public async Task<IEnumerable<AuditLog>> GetByEntityAsync(
        string entityType,
        int entityId)
    {
        return await _auditLogRepository
            .GetByEntityAsync(entityType, entityId);
    }

    public async Task<AuditLog> CreateAsync(AuditLog auditLog)
        
    {
        await _auditLogRepository.AddAsync(auditLog);
        return auditLog;
    }
}