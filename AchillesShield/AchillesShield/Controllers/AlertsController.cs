using AchillesShield.Models;
using AchillesShield.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AchillesShield.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlertsController : ControllerBase
{
    private readonly IAlertService _alertService;

    public AlertsController(IAlertService alertService)
    {
        _alertService = alertService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _alertService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var alert =
            await _alertService.GetByIdAsync(id);

        if (alert == null)
            return NotFound();

        return Ok(alert);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Alert alert)
    {
        var created =
            await _alertService.CreateAsync(alert);

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        Alert alert)
    {
        var result =
            await _alertService.UpdateAsync(id, alert);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result =
            await _alertService.DeleteAsync(id);

        if (!result)
            return NotFound();

        return NoContent();
    }
}