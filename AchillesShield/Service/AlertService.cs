using AchillesShield.Models;
using AchillesShield.Repositories.Interfaces;
using AchillesShield.Services.Interfaces;

namespace AchillesShield.Services;

public class AlertService : IAlertService
{
    private readonly IAlertRepository _alertRepository;

    public AlertService(IAlertRepository alertRepository)
    {
        _alertRepository = alertRepository;
    }

    public async Task<IEnumerable<Alert>> GetAllAsync()
    {
        return await _alertRepository.GetAllAsync();
    }

    public async Task<Alert?> GetByIdAsync(int id)
    {
        return await _alertRepository.GetByIdAsync(id);
    }

    public async Task<Alert> CreateAsync(Alert alert)
    {
        await _alertRepository.AddAsync(alert);
        return alert;
    }

    public async Task<bool> UpdateAsync(int id, Alert alert)
    {
        var existingAlert =
            await _alertRepository.GetByIdAsync(id);

        if (existingAlert == null)
            return false;

        // Βάζουμε εδώ ΜΟΝΟ τα πραγματικά properties του Alert.

        _alertRepository.Update(existingAlert);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var alert =
            await _alertRepository.GetByIdAsync(id);

        if (alert == null)
            return false;

        _alertRepository.Delete(alert);

        return true;
    }
}