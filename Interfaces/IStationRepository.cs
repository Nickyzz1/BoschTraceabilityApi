using System.Threading.Tasks;
using MyApi.Entities;

public interface IStationRepository
{
    Task<Station> GetByIdAsync(int id);
}
