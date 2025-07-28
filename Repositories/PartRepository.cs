using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyApi.Entities;
using MyApi.Interfaces;
using MyApi.Data;

namespace MyApi.Repositories {
    
    public class PartRepository : IPartRepository
    {
        private readonly BoschDbContext _context;

        public PartRepository(BoschDbContext context)
        {
            _context = context;
        }

        public async Task<List<Part>> GetAllAsync()
        {
            return await _context.Parts.ToListAsync();
        }

        public async Task<Part> GetByIdAsync(int id)
        {
            return await _context.Parts.FindAsync(id);
        }

        public async Task AddAsync(Part part)
        {
            _context.Parts.Add(part);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Part part)
        {
            _context.Parts.Update(part);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var part = await _context.Parts.FindAsync(id);
            if (part != null)
            {
                _context.Parts.Remove(part);
                await _context.SaveChangesAsync();
            }
        }

        public Task<bool> ExistsByCode(string code)
        {
            throw new NotImplementedException();
        }
    }
}
