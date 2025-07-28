using System.Threading.Tasks;
using MyApi.Entities;

namespace MyApi.Interfaces
{
    public interface IMovimentRepository
    {
        Task AddAsync(Moviment moviment);
    }
}
