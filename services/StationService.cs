using MyApi.Entities;
using MyApi.Interfaces;
using MyApi.DTO; 

namespace MyApi.Services {
    
   public class StationService {

        private readonly IStationRepository _repository;

        public StationService(IStationRepository repository)
        {
             Console.WriteLine("StationService construído!");
            _repository = repository;
        }

        public async Task<IEnumerable<Station>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

         public async Task<int> GetMaxStation()
        {
            return await _repository.GetMaxSortAsync();
        }


        public async Task<Station?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<(bool ok, string? error)> ValidarECriarAsync(StationCreateDto dto)
        {
            if (await _repository.ExistsByTitleAsync(dto.Title))
                return (false, "Já existe uma estação com esse título.");

            if (await _repository.ExistsBySortAsync(dto.Sort))
                return (false, "Já existe uma estação com essa ordem.");


            var station = new Station
            {
                Title = dto.Title,
                Sort = dto.Sort,
                Parts = new List<Part>()
            };

            await _repository.AddAsync(station);
            return (true, null);
        }

        public async Task<(bool ok, string? error)> AtualizarAsync(int id, StationCreateDto dto)
        {
            var station = await _repository.GetByIdAsync(id);
            if (station == null)
                return (false, "Estação não encontrada.");
            var orderExist = await _repository.GetByOrder(dto.Sort);

            if(orderExist != null && orderExist.Id != id)
                return (false, "Ordem já usada");

            station.Title = dto.Title;
            station.Sort = dto.Sort;

            await _repository.UpdateAsync(station);
            return (true, null);
        }

        public async Task<(bool ok, string? error)> DeletarAsync(int id)
        {
            var station = await _repository.GetByIdAsync(id);
            if (station == null)
                return (false, "Estação não encontrada.");

            await _repository.DeleteAsync(station);
            return (true, null);
        }
    }

}

