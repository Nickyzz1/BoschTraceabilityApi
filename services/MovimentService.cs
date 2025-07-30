using MyApi.Entities;
using MyApi.Interfaces;
using MyApi.DTO;
using System;
using System.Threading.Tasks;

namespace MyApi.Services {
    public class MovimentService
    {
        private readonly IPartRepository _partRepository;
        private readonly IStationRepository _stationRepository;
        private readonly IMovimentRepository _movimentRepository;

        public MovimentService(IPartRepository partRepo, IStationRepository stationRepo, IMovimentRepository movimentRepo)
        {
            _partRepository = partRepo;
            _stationRepository = stationRepo;
            _movimentRepository = movimentRepo;
        }

        public async Task<(bool ok, string? error)> CriarMovimentacaoAsync(MovimentCreateDto data)
        {
            var part = await _partRepository.GetByIdAsync(data.PartId);
            if (part == null) return (false, "Peça não encontrada.");

            var destnation = await _stationRepository.GetByIdAsync(data.DestinationStationId);
            if (destnation == null) return (false, "Estação destino inválida.");

            var atual = part.CurStationId.HasValue ? await _stationRepository.GetByIdAsync(part.CurStationId.Value) : null;

            if (atual == null && destnation.Sort != 1)
                return (false, "Peça ainda não está na primeira estação.");

            if (atual != null && destnation.Sort != atual.Sort + 1)
                return (false, "Movimentação inválida: pular ou retroceder estações não é permitido.");

            var maxSort = await _stationRepository.GetMaxSortAsync();

            if (destnation.Sort == maxSort)
                part.Status = "Finalizada";

            part.CurStationId = destnation.Id;
            await _partRepository.UpdateAsync(part);

            var moviment = new Moviment
            {
                PartId = part.Id,
                DateTime = DateTime.Now,
                Origin = atual.Id,
                Destination = destnation.Id,
                Responsable = data.Responsable
            };

            await _movimentRepository.AddAsync(moviment);

            return (true, null);
        }

        public async Task<IEnumerable<Moviment>> GetAllAsync()
        {
            return await _movimentRepository.GetAllAsync();
        }
    }
}