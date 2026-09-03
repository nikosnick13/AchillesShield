using AchillesShield.Data;
using AchillesShield.Models;
using AchillesShield.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AchillesShield.Repositories;

public class CommentRepository : BaseRepository<Comment>, ICommentRepository
{
    public CommentRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Comment>> GetByIncidentIdAsync(int incidentId)
    {
        return await _dbSet
            .Where(c => c.IncidentId == incidentId)
            .Include(c => c.User)
            .OrderBy(c => c.CreatedAt)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Comment>> GetByUserIdAsync(int userId)
    {
        return await _dbSet
            .Where(c => c.UserId == userId)
            .AsNoTracking()
            .ToListAsync();
    }
}