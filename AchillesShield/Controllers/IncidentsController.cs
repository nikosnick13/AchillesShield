using AchillesShield.Models;
using AchillesShield.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AchillesShield.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncidentsController : ControllerBase
{
    private readonly IIncidentService _incidentService;

    public IncidentsController(
        IIncidentService incidentService)
    {
        _incidentService = incidentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _incidentService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var incident =
            await _incidentService.GetByIdAsync(id);

        if (incident == null)
            return NotFound();

        return Ok(incident);
    }

    [HttpGet("number/{incidentNumber}")]
    public async Task<IActionResult> GetByIncidentNumber(
        string incidentNumber)
    {
        var incident =
            await _incidentService
                .GetByIncidentNumberAsync(incidentNumber);

        if (incident == null)
            return NotFound();

        return Ok(incident);
    }

    [HttpGet("status/{status}")]
    public async Task<IActionResult> GetByStatus(
        string status)
    {
        return Ok(
            await _incidentService.GetByStatusAsync(status));
    }

    [HttpGet("severity/{severity}")]
    public async Task<IActionResult> GetBySeverity(
        string severity)
    {
        return Ok(
            await _incidentService.GetBySeverityAsync(severity));
    }

    [HttpGet("assigned/{userId:int}")]
    public async Task<IActionResult> GetAssigned(
        int userId)
    {
        return Ok(
            await _incidentService
                .GetAssignedToUserAsync(userId));
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        Incident incident)
    {
        var created =
            await _incidentService.CreateAsync(incident);

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        Incident incident)
    {
        var result =
            await _incidentService.UpdateAsync(
                id,
                incident);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result =
            await _incidentService.DeleteAsync(id);

        if (!result)
            return NotFound();

        return NoContent();
    }
}