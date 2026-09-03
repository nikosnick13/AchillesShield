using AchillesShield.Data;
using AchillesShield.Models;
using AchillesShield.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AchillesShield.Repositories;

public class AuditLogRepository
    : BaseRepository<AuditLog>, IAuditLogRepository
{
    public AuditLogRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<AuditLog>> GetByUserIdAsync(int userId)
    {
        return await _dbSet
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.Timestamp)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<AuditLog>> GetByEntityAsync(
        string entityType,
        int entityId)
    {
        return await _dbSet
            .Where(a =>
                a.EntityType == entityType &&
                a.EntityId == entityId)
            .OrderByDescending(a => a.Timestamp)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<AuditLog>> GetByActionAsync(string action)
    {
        return await _dbSet
            .Where(a => a.Action == action)
            .OrderByDescending(a => a.Timestamp)
            .AsNoTracking()
            .ToListAsync();
    }
}