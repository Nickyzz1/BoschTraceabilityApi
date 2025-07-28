using MyApi.Entities;
using MyApi.Interfaces;
using MyApi.DTO; 
namespace MyApi.Services {
    
    public class PartService
    {
        private readonly IPartRepository _repository;
        private readonly IStationRepository _stationRepository;

        public PartService(IPartRepository repository, IStationRepository stationRepo)
        {
            _repository = repository;
            _stationRepository = stationRepo;
        }

        public async Task<(bool ok, string? error)> ValidarECriarAsync(PartCreateDto dto)
        {
            if (await _repository.ExistsByCode(dto.Code))
                return (false, "Já existe uma peça com esse código.");

            var station = await _stationRepository.GetByIdAsync(dto.CurStationId);
            if (station == null)
                return (false, "Estação não encontrada.");

            var part = new Part
            {
                Code = dto.Code,
                Status = dto.Status,
                CurStationId = dto.CurStationId
            };

            await _repository.AddAsync(part);
            return (true, null);
        }
    }

}

