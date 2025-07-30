using System.Threading.Tasks;
using MyApi.Entities;
namespace MyApi.Interfaces {

    public interface IStationRepository
    {
        Task<IEnumerable<Station>> GetAllAsync();
        Task<Station?> GetByIdAsync(int id);
        Task AddAsync(Station station);
        Task UpdateAsync(Station station);
        Task DeleteAsync(Station station);
        Task<bool> ExistsByTitleAsync(string title);
        Task<bool> ExistsBySortAsync(int sort);
        Task<int> GetMaxSortAsync();
        Task<Station> GetLastStationAsync();

        Task<Station> GetByOrder(int sort);
    }
}
