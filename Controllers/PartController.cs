using Microsoft.AspNetCore.Mvc;
using MyApi.Entities;
using MyApi.Interfaces;
using MyApi.DTO;
using MyApi.Services;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/v1/part")]
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var part = await _partService.GetByIdAsync(id);
            if (part == null)
                return NotFound("Peça não encontrada.");
            return Ok(part);
        }

     
        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var part = await _partService.GetByCode(code);
            if (part == null)
                return NotFound("Peça não encontrada.");

            return Ok(part);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PartCreateDto dto)
        {
            var (ok, error, part) = await _partService.ValidarECriarAsync(dto);
            if (ok)
                return Ok(part);  // retorna o objeto criado, não só string
            else
                return BadRequest(error);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PartUpdateDto dto)
        {
            var (ok, error) = await _partService.AtualizarAsync(id, dto);
            return ok ? Ok(new { message = "Atualizado com sucesso." }) : NotFound(new { error });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var (ok, error) = await _partService.DeletarAsync(id);
            return ok ? Ok(new { message = "Removico com sucesso." }) : NotFound(new { error });
        }
        // [HttpPost("moviment")]
        // public async Task<IActionResult> Movimentar([FromBody] MovimentCreateDto dto)
        // {
        //     var (ok, error) = await _partService.ValidarEMovimentarAsync(dto);
        //     return ok ? Ok("Movimentação realizada.") : BadRequest(error);
        // }
    }
}
