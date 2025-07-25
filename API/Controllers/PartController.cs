namespace BoschTraceabilityAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoschTraceabilityAPI.Core.Interfaces;
using BoschTraceabilityAPI.Core.Services;
using BoschTraceabilityAPI.Domain.Entities;

[ApiController]
[Route("api/[controller]")]
public class PartController : ControllerBase
{
    private readonly IPartService _partService;
    public PartController(IPartService partService) => _partService = partService;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Part part)
    {
        var newPart = await _partService.CreateAsync(part);
        return CreatedAtAction(nameof(GetById), new { id = newPart.Id }, newPart);
    }

    [HttpGet]
    public async Task<IActionResult> List() => Ok(await _partService.ListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var part = await _partService.GetByIdAsync(id);
        if (part is null) return NotFound();
        return Ok(part);
    }
}
