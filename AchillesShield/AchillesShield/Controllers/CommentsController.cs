using AchillesShield.Models;
using AchillesShield.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AchillesShield.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentsController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _commentService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var comment =
            await _commentService.GetByIdAsync(id);

        if (comment == null)
            return NotFound();

        return Ok(comment);
    }

    [HttpGet("incident/{incidentId:int}")]
    public async Task<IActionResult> GetByIncident(
        int incidentId)
    {
        return Ok(
            await _commentService
                .GetByIncidentIdAsync(incidentId));
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        Comment comment)
    {
        var created =
            await _commentService.CreateAsync(comment);

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        Comment comment)
    {
        var result =
            await _commentService.UpdateAsync(
                id,
                comment);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result =
            await _commentService.DeleteAsync(id);

        if (!result)
            return NotFound();

        return NoContent();
    }
}