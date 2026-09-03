using AchillesShield.Models;
using AchillesShield.Repositories.Interfaces;
using AchillesShield.Services.Interfaces;

namespace AchillesShield.Services;

public class PlaybookService : IPlaybookService
{
    private readonly IPlaybookRepository _playbookRepository;

    public PlaybookService(
        IPlaybookRepository playbookRepository)
    {
        _playbookRepository = playbookRepository;
    }

    public async Task<IEnumerable<Playbook>> GetAllAsync()
    {
        return await _playbookRepository.GetAllAsync();
    }

    public async Task<Playbook?> GetByIdAsync(int id)
    {
        return await _playbookRepository.GetByIdAsync(id);
    }

    public async Task<Playbook> CreateAsync(
        Playbook playbook)
    {
        await _playbookRepository.AddAsync(playbook);
        return playbook;
    }

    public async Task<bool> UpdateAsync(
        int id,
        Playbook playbook)
    {
        var existingPlaybook =
            await _playbookRepository.GetByIdAsync(id);

        if (existingPlaybook == null)
            return false;

        existingPlaybook.Name =
            playbook.Name;

        existingPlaybook.Description =
            playbook.Description;

        existingPlaybook.TriggerType =
            playbook.TriggerType;

        existingPlaybook.UpdatedAt =
            DateTime.UtcNow;

        _playbookRepository.Update(existingPlaybook);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var playbook =
            await _playbookRepository.GetByIdAsync(id);

        if (playbook == null)
            return false;

        playbook.IsDeleted = true;
        playbook.DeletedAt = DateTime.UtcNow;
        playbook.UpdatedAt = DateTime.UtcNow;

        _playbookRepository.Update(playbook);

        return true;
    }
}