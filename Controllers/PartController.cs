using Microsoft.AspNetCore.Mvc;
using MyApi.Entities;
using MyApi.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class PartController : ControllerBase
{
    private readonly IPartRepository _repository;
    private readonly PartService _partService;

    public PartController(IPartRepository repository, PartService partService)
    {
        _repository = repository;
        _partService = partService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var parts = await _repository.GetAllAsync();
        return Ok(parts);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PartCreateDto dto)
    {
        var (ok, error) = await _partService.ValidarECriarAsync(dto);
        if (!ok) return BadRequest(error);
        return Ok();
    }
}