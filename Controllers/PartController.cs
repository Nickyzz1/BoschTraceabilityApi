using Microsoft.AspNetCore.Mvc;
using MyApi.Entities;
using MyApi.Interfaces;
using MyApi.DTO;
using MyApi.Services;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/v1/Part")]
    public class PartController : ControllerBase
    {
        // criando vars para acesso aos repositories que conversão com o banco de dados
        private readonly IPartRepository _repository;
        private readonly PartService _partService;

        // criando injeção de dependecias
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
}
