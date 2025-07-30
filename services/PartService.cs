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

        public async Task<(bool ok, string? error, Part? part)> ValidarECriarAsync(PartCreateDto dto)
        {
            if (await _repository.ExistsByCode(dto.Code))
                return (false, "Já existe uma peça com esse código.", null);

            var station = await _stationRepository.GetByIdAsync(dto.CurStationId);
            if (station == null)
                return (false, "Peça não encontrada.", null);

            var part = new Part
            {
                Code = dto.Code,
                Status = dto.Status,
                CurStationId = dto.CurStationId
            };

            await _repository.AddAsync(part);
            return (true, null, part);
        }

        public async Task<IEnumerable<Part>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Part?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<(bool ok, string? error)> AtualizarAsync(int id, PartCreateDto dto)
        {
            var part = await _repository.GetByIdAsync(id);
            if (part == null)
                return (false, "Peça não encontrada.");

            
            part.Code = dto.Code;
            part.Status = dto.Status;

            await _repository.UpdateAsync(part);
            return (true, null);
        }

        public async Task<(bool ok, string? error)> DeletarAsync(int id)
        {
            var part = await _repository.GetByIdAsync(id);
            if (part == null)
                return (false, "Peça não encontrada.");

            await _repository.DeleteAsync(id);
            return (true, null);
        }

        // public async Task<(bool ok, string? error)> ValidarEMovimentarAsync(MovimentCreateDto dto)
        // {
        //     var part = await _repository.GetByIdAsync(dto.PartId);
        //     if (part == null)
        //         return (false, "Peça não encontrada.");

        //     var originStation = await _stationRepository.GetByIdAsync(part.CurStationId ?? 0);
        //     var destinationStation = await _stationRepository.GetByIdAsync(dto.DestinationStationId);

        //     if (destinationStation == null)
        //         return (false, "Estação destino inválida.");

        //     if (originStation == null)
        //         return (false, "Estação origem inválida.");

        //     if (destinationStation.Sort != originStation.Sort + 1)
        //         return (false, "Movimentação deve ser para a próxima estação na ordem.");

        //     var moviment = new Moviment
        //     {
        //         PartId = dto.PartId,
        //         DateTime = DateTime.Now,
        //         Origin = originStation.Title,
        //         Destination = destinationStation.Title,
        //         Responsable = dto.Responsable
        //     };

        //     await _movimentRepository.AddAsync(moviment);

        //     part.CurStationId = destinationStation.Id;

        //     var maxSort = await _stationRepository.GetMaxSortAsync();
        //     if (destinationStation.Sort == maxSort)
        //         part.Status = "Finalizada";

        //     await _repository.UpdateAsync(part);

        //     return (true, null);
        // }
    }

}

