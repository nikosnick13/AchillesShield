using AchillesShield.Models;

namespace AchillesShield.Services.Interfaces;

public interface ICommentService
{
    Task<IEnumerable<Comment>> GetAllAsync();
    Task<Comment?> GetByIdAsync(int id);
    Task<IEnumerable<Comment>> GetByIncidentIdAsync(int incidentId);
    Task<Comment> CreateAsync(Comment comment);
    Task<bool> UpdateAsync(int id, Comment comment);
    Task<bool> DeleteAsync(int id);
}