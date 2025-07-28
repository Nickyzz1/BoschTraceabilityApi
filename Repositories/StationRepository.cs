using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Entities;
using System.Threading.Tasks;
using MyApi.Interfaces;
namespace MyApi.Repositories {
    public class StationRepository : IStationRepository
    {
        private readonly BoschDbContext _context;

        public StationRepository(BoschDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Station>> GetAllAsync()
        {
            return await _context.Stations.ToListAsync();
        }

        public async Task<Station?> GetByIdAsync(int id)
        {
            return await _context.Stations.FindAsync(id);
        }

        public async Task AddAsync(Station station)
        {
            await _context.Stations.AddAsync(station);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Station station)
        {
            _context.Stations.Update(station);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Station station)
        {
            _context.Stations.Remove(station);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistsByTitleAsync(string title)
        {
            return await _context.Stations.AnyAsync(s => s.Title == title);
        }

        public async Task<bool> ExistsBySortAsync(int sort)
        {
            return await _context.Stations.AnyAsync(s => s.Sort == sort);
        }

    }


}
