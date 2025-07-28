using MyApi.Data;
using MyApi.Entities;
using MyApi.Interfaces;
using System.Threading.Tasks;

namespace MyApi.Repositories
{
    public class MovimentRepository : IMovimentRepository
    {
        private readonly BoschDbContext _context;

        public MovimentRepository(BoschDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Moviment moviment)
        {
            _context.Moviments.Add(moviment);
            await _context.SaveChangesAsync();
        }
    }
}
