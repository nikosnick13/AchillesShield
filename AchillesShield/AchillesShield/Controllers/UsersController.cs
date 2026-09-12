using AchillesShield.Models;
using AchillesShield.Service.Interfaces;
using AchillesShield.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AchillesShield.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpGet("username/{username}")]
    public async Task<IActionResult> GetByUsername(
        string username)
    {
        var user =
            await _userService.GetByUsernameAsync(username);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetByEmail(
        string email)
    {
        var user =
            await _userService.GetByEmailAsync(email);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        var created =
            await _userService.CreateAsync(user);

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        User user)
    {
        var result =
            await _userService.UpdateAsync(id, user);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result =
            await _userService.DeleteAsync(id);

        if (!result)
            return NotFound();

        return NoContent();
    }
}