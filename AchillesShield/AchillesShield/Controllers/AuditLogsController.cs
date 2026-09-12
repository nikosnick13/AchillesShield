using AchillesShield.Models;
using AchillesShield.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AchillesShield.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuditLogsController : ControllerBase
{
    private readonly IAuditLogService _auditLogService;

    public AuditLogsController(
        IAuditLogService auditLogService)
    {
        _auditLogService = auditLogService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(
            await _auditLogService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var log =
            await _auditLogService.GetByIdAsync(id);

        if (log == null)
            return NotFound();

        return Ok(log);
    }

    [HttpGet("user/{userId:int}")]
    public async Task<IActionResult> GetByUser(
        int userId)
    {
        return Ok(
            await _auditLogService
                .GetByUserIdAsync(userId));
    }

    [HttpGet("entity/{entityType}/{entityId:int}")]
    public async Task<IActionResult> GetByEntity(
        string entityType,
        int entityId)
    {
        return Ok(
            await _auditLogService
                .GetByEntityAsync(
                    entityType,
                    entityId));
    }
}