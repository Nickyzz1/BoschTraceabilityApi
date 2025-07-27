using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Entities;
using System.Threading.Tasks;

public class StationRepository : IStationRepository
{
    private readonly BoschDbContext _context;

    public StationRepository(BoschDbContext context)
    {
        _context = context;
    }

    public async Task<Station> GetByIdAsync(int id)
    {
        return await _context.Stations.FindAsync(id);
    }
}
