using System.Collections.Generic;
using System.Threading.Tasks;
using MyApi.Entities;
namespace MyApi.Interfaces
{
    public interface IPartRepository
    {
        Task<List<Part>> GetAllAsync();
        Task<Part> GetByIdAsync(int id);
        Task AddAsync(Part part);
        Task UpdateAsync(Part part);
        Task DeleteAsync(int id);
        Task<Part?> GetByCode(string code);
    }
    
}

