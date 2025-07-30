using Microsoft.AspNetCore.Mvc;
using MyApi.DTO;
using MyApi.Services;
using System.Threading.Tasks;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/v1/moviment")]
    public class MovimentController : ControllerBase
    {
        private readonly MovimentService _movimentService;

        public MovimentController(MovimentService movimentService)
        {
            _movimentService = movimentService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovimentCreateDto dto)
        {
            var (ok, error) = await _movimentService.CriarMovimentacaoAsync(dto);
            return ok ? Ok(new { message = "Movimentação realizada com sucesso." }) : NotFound(new { error });
        }

        [HttpGet]
         public async Task<IActionResult> GetAll()
        {
            var stations = await _movimentService.GetAllAsync();
            return Ok(stations);
        }
    }
}