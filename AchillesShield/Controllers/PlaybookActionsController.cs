using AchillesShield.Models;
using AchillesShield.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AchillesShield.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlaybookActionsController : ControllerBase
{
    private readonly IPlaybookActionService
        _playbookActionService;

    public PlaybookActionsController(
        IPlaybookActionService playbookActionService)
    {
        _playbookActionService =
            playbookActionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(
            await _playbookActionService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var action =
            await _playbookActionService.GetByIdAsync(id);

        if (action == null)
            return NotFound();

        return Ok(action);
    }

    [HttpGet("playbook/{playbookId:int}")]
    public async Task<IActionResult> GetByPlaybook(
        int playbookId)
    {
        return Ok(
            await _playbookActionService
                .GetByPlaybookIdAsync(playbookId));
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        PlaybookAction action)
    {
        var created =
            await _playbookActionService
                .CreateAsync(action);

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        PlaybookAction action)
    {
        var result =
            await _playbookActionService
                .UpdateAsync(id, action);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result =
            await _playbookActionService.DeleteAsync(id);

        if (!result)
            return NotFound();

        return NoContent();
    }
}