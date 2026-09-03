using AchillesShield.Models;
using AchillesShield.Repositories.Interfaces;
using AchillesShield.Services.Interfaces;

namespace AchillesShield.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(
        ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<IEnumerable<Comment>> GetAllAsync()
    {
        return await _commentRepository.GetAllAsync();
    }

    public async Task<Comment?> GetByIdAsync(int id)
    {
        return await _commentRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Comment>> GetByIncidentIdAsync(
        int incidentId)
    {
        return await _commentRepository
            .GetByIncidentIdAsync(incidentId);
    }

    public async Task<Comment> CreateAsync(Comment comment)
    {
        await _commentRepository.AddAsync(comment);
        return comment;
    }

    public async Task<bool> UpdateAsync(
        int id,
        Comment comment)
    {
        var existingComment =
            await _commentRepository.GetByIdAsync(id);

        if (existingComment == null)
            return false;

        existingComment.Content =
            comment.Content;

        existingComment.UpdatedAt =
            DateTime.UtcNow;

        _commentRepository.Update(existingComment);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var comment =
            await _commentRepository.GetByIdAsync(id);

        if (comment == null)
            return false;

        comment.IsDeleted = true;
        comment.DeletedAt = DateTime.UtcNow;
        comment.UpdatedAt = DateTime.UtcNow;

        _commentRepository.Update(comment);

        return true;
    }
}