using AchillesShield.Models;
using AchillesShield.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AchillesShield.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissionsController : ControllerBase
{
    private readonly IPermissionService _permissionService;

    public PermissionsController(
        IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _permissionService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var permission =
            await _permissionService.GetByIdAsync(id);

        if (permission == null)
            return NotFound();

        return Ok(permission);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        Permission permission)
    {
        var created =
            await _permissionService.CreateAsync(permission);

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        Permission permission)
    {
        var result =
            await _permissionService
                .UpdateAsync(id, permission);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result =
            await _permissionService.DeleteAsync(id);

        if (!result)
            return NotFound();

        return NoContent();
    }
}