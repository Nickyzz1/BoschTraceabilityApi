
using Microsoft.AspNetCore.Mvc;
using MyApi.Entities;
using MyApi.Interfaces;
using MyApi.DTO;
using MyApi.Services;

namespace MyApi.Controllers {

    [ApiController]
    [Route("api/v1/station")]
    public class StationController : ControllerBase
    {

        private readonly StationService _service;

        public StationController(StationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stations = await _service.GetAllAsync();
            return Ok(stations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var station = await _service.GetByIdAsync(id);
            if (station == null)
                return NotFound("Estação não encontrada.");
            return Ok(station);
        }
         [HttpGet("max")]
        public async Task<IActionResult> GetMaxx(int id)
        {
            var stations = await _service.GetMaxStation();
            return Ok(stations);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StationCreateDto dto)
        {
            var (ok, error) = await _service.ValidarECriarAsync(dto);
            return ok ? Ok("Criado com sucesso.") : BadRequest(error);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] StationCreateDto dto)
        {
            var (ok, error) = await _service.AtualizarAsync(id, dto);
            return ok ? Ok("Atualizado com sucesso.") : NotFound(error);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var (ok, error) = await _service.DeletarAsync(id);
            return ok ? Ok("Removido com sucesso.") : NotFound(error);
        }
    }
}
