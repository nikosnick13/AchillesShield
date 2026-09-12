using AchillesShield.Models;
using AchillesShield.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AchillesShield.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlaybooksController : ControllerBase
{
    private readonly IPlaybookService _playbookService;

    public PlaybooksController(
        IPlaybookService playbookService)
    {
        _playbookService = playbookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _playbookService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var playbook =
            await _playbookService.GetByIdAsync(id);

        if (playbook == null)
            return NotFound();

        return Ok(playbook);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        Playbook playbook)
    {
        var created =
            await _playbookService.CreateAsync(playbook);

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        Playbook playbook)
    {
        var result =
            await _playbookService
                .UpdateAsync(id, playbook);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result =
            await _playbookService.DeleteAsync(id);

        if (!result)
            return NotFound();

        return NoContent();
    }
}