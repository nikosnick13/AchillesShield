using AchillesShield.Models;
using AchillesShield.Repositories.Interfaces;
using AchillesShield.Services.Interfaces;

namespace AchillesShield.Services;

public class PlaybookActionService : IPlaybookActionService
{
    private readonly IPlaybookActionRepository
        _playbookActionRepository;

    public PlaybookActionService(
        IPlaybookActionRepository playbookActionRepository)
    {
        _playbookActionRepository =
            playbookActionRepository;
    }

    public async Task<IEnumerable<PlaybookAction>> GetAllAsync()
    {
        return await _playbookActionRepository.GetAllAsync();
    }

    public async Task<PlaybookAction?> GetByIdAsync(int id)
    {
        return await _playbookActionRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<PlaybookAction>>
        GetByPlaybookIdAsync(int playbookId)
    {
        return await _playbookActionRepository
            .GetByPlaybookIdAsync(playbookId);
    }

    public async Task<PlaybookAction> CreateAsync(
        PlaybookAction action)
    {
          await _playbookActionRepository.AddAsync(action);
        return action;
    }

    public async Task<bool> UpdateAsync(
        int id,
        PlaybookAction action)
    {
        var existingAction =
            await _playbookActionRepository.GetByIdAsync(id);

        if (existingAction == null)
            return false;

        existingAction.Name = action.Name;
        existingAction.ActionType = action.ActionType;
        existingAction.ExecutionOrder = action.ExecutionOrder;
        existingAction.Relationship = action.Relationship;
        existingAction.UpdatedAt = DateTime.UtcNow;

        _playbookActionRepository.Update(existingAction);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var action =
            await _playbookActionRepository.GetByIdAsync(id);

        if (action == null)
            return false;

        action.IsDeleted = true;
        action.DeletedAt = DateTime.UtcNow;
        action.UpdatedAt = DateTime.UtcNow;

        _playbookActionRepository.Update(action);

        return true;
    }
}